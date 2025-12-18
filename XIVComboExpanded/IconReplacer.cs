using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;

using Dalamud.Game;
using Dalamud.Hooking;
using Dalamud.Logging;
using Dalamud.Plugin.Services;
using Dalamud.Utility;
using FFXIVClientStructs.FFXIV.Client.Game;
using XIVComboExpandedestPlugin.Attributes;
using XIVComboExpandedestPlugin.Combos;

namespace XIVComboExpandedestPlugin
{
    /// <summary>
    /// This class facilitates the icon replacing.
    /// </summary>
    internal sealed partial class IconReplacer : IDisposable
    {
        private readonly unsafe ActionManager* clientStructActionManager;
        private readonly List<CustomCombo> customCombos;
        private readonly Hook<IsIconReplaceableDelegate> isIconReplaceableHook;
        private readonly Hook<GetIconDelegate> getIconHook;

        private Stopwatch tick;

        private IntPtr actionManager = IntPtr.Zero;

        private HashSet<uint> comboActionIDs = new();

        private Vector2 position;

        private float playerSpeed;

        private bool isPlayerMoving;

        /// <summary>
        /// Initializes a new instance of the <see cref="IconReplacer"/> class.
        /// </summary>
        public unsafe IconReplacer()
        {
            this.clientStructActionManager = ActionManager.Instance();

            this.tick = new Stopwatch();
            this.tick.Start();
            XIVComboExpandedestPlugin.Framework.Update += this.OnFrameworkUpdate;

            this.customCombos = Assembly.GetAssembly(typeof(CustomCombo))!.GetTypes()
                .Where(t => t.BaseType == typeof(CustomCombo))
                .Select(t => Activator.CreateInstance(t))
                .Cast<CustomCombo>()
                .ToList();

            this.UpdateEnabledActionIDs();

            this.getIconHook = Service.GameInteropProvider.HookFromAddress<GetIconDelegate>((nint)ActionManager.Addresses.GetAdjustedActionId.Value, this.GetIconDetour);
            this.isIconReplaceableHook = Service.GameInteropProvider.HookFromAddress<IsIconReplaceableDelegate>(Service.Address.IsActionIdReplaceable, this.IsIconReplaceableDetour);

            this.getIconHook.Enable();
            this.isIconReplaceableHook.Enable();
        }

        private delegate ulong IsIconReplaceableDelegate(uint actionID);

        private delegate uint GetIconDelegate(IntPtr actionManager, uint actionID);

        /// <inheritdoc/>
        public void Dispose()
        {
            this.getIconHook.Dispose();
            this.isIconReplaceableHook.Dispose();
            XIVComboExpandedestPlugin.Framework.Update -= this.OnFrameworkUpdate;
            this.tick.Stop();
        }

        /// <summary>
        /// Gets bool determining if action is greyed out or not.
        /// </summary>
        /// <param name="actionID">Action ID.</param>
        /// <param name="targetID">Target ID.</param>
        /// <returns>A bool value of whether the action can be used or not.</returns>
        internal unsafe bool CanUseAction(uint actionID, uint targetID = 0xE000_0000)
        {
            return clientStructActionManager->GetActionStatus(ActionType.Action, actionID, targetID, false, true) == 0;
        }

        /// <summary>
        /// Gets bool determining if player is moving.
        /// </summary>
        /// <returns>A bool value of whether the player is moving or not.</returns>
        internal bool IsMoving() => this.isPlayerMoving;

        /// <summary>
        /// Update what action IDs are allowed to be modified. This pulls from <see cref="PluginConfiguration.EnabledActions"/>.
        /// </summary>
        internal void UpdateEnabledActionIDs()
        {
            this.comboActionIDs = Enum
                .GetValues<CustomComboPreset>()
                .Select(preset => preset.GetAttribute<CustomComboInfoAttribute>()!)
                .SelectMany(comboInfo => comboInfo.ActionIDs)
                .Concat(Service.Configuration.DancerDanceCompatActionIDs)
                .ToHashSet();
        }

        /// <summary>
        /// Calls the original hook.
        /// </summary>
        /// <param name="actionID">Action ID.</param>
        /// <returns>The result from the hook.</returns>
        internal uint OriginalHook(uint actionID) => this.getIconHook.Original(this.actionManager, actionID);

        private unsafe void OnFrameworkUpdate(IFramework dFramework)
        {
            try
            {
                if (this.tick.ElapsedMilliseconds > 10)
                {
                    this.tick.Restart();
                    var localPlayer = Service.ObjectTable.LocalPlayer;
                    Vector2 newPosition = localPlayer is null ? Vector2.Zero : new Vector2(localPlayer.Position.X, localPlayer.Position.Z);

                    this.playerSpeed = Vector2.Distance(newPosition, this.position);

                    this.isPlayerMoving = this.playerSpeed > 0;

                    this.position = localPlayer is null ? Vector2.Zero : newPosition;
                }
            }
            catch (Exception ex)
            {
                Service.PluginLog.Error(ex.Message);
            }
        }

        private unsafe uint GetIconDetour(IntPtr actionManager, uint actionID)
        {
            this.actionManager = actionManager;

            try
            {
                var localPlayer = Service.ObjectTable.LocalPlayer;
                if (localPlayer == null || !this.comboActionIDs.Contains(actionID))
                    return this.OriginalHook(actionID);

                var lastComboMove = *(uint*)Service.Address.LastComboMove;
                var comboTime = *(float*)Service.Address.ComboTimer;
                var level = localPlayer.Level;

                foreach (var combo in this.customCombos)
                {
                    if (combo.TryInvoke(actionID, lastComboMove, comboTime, level, out var newActionID))
                        return newActionID;
                }

                return this.OriginalHook(actionID);
            }
            catch (Exception ex)
            {
                Service.PluginLog.Error(ex, "Don't crash the game");
                return this.OriginalHook(actionID);
            }
        }

        private ulong IsIconReplaceableDetour(uint actionID) => 1;
    }

    /// <summary>
    /// Cooldown getters.
    /// </summary>
    internal sealed partial class IconReplacer
    {
        private readonly Dictionary<uint, byte> cooldownGroupCache = new();

        /// <summary>
        /// Gets the cooldown data for an action.
        /// </summary>
        /// <param name="actionID">Action ID to check.</param>
        /// <returns>Cooldown data.</returns>
        internal unsafe CooldownData GetCooldown(uint actionID)
        {
            var cooldownGroup = this.GetCooldownGroup(actionID);
            if (this.actionManager == IntPtr.Zero)
                return new CooldownData() { ActionID = actionID };

            if (this.clientStructActionManager == null)
                return new CooldownData() { ActionID = actionID };

            var cooldownPtr = this.clientStructActionManager->GetRecastGroupDetail(cooldownGroup - 1);
            cooldownPtr->ActionId = actionID;
            return Marshal.PtrToStructure<CooldownData>((IntPtr)cooldownPtr);
        }

        private byte GetCooldownGroup(uint actionID)
        {
            if (this.cooldownGroupCache.TryGetValue(actionID, out var cooldownGroup))
                return cooldownGroup;

            var sheet = Service.DataManager.GetExcelSheet<Lumina.Excel.Sheets.Action>()!;
            var row = sheet.GetRow(actionID);

            return this.cooldownGroupCache[actionID] = row!.CooldownGroup;
        }

        /// <summary>
        /// Internal cooldown data.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        internal struct CooldownData
        {
            /// <summary>
            /// A value indicating whether the action is on cooldown.
            /// </summary>
            [FieldOffset(0x0)]
            public bool IsCooldown;

            /// <summary>
            /// Action ID on cooldown.
            /// </summary>
            [FieldOffset(0x4)]
            public uint ActionID;

            /// <summary>
            /// The elapsed cooldown time.
            /// </summary>
            [FieldOffset(0x8)]
            public float CooldownElapsed;

            /// <summary>
            /// The total cooldown time.
            /// </summary>
            [FieldOffset(0xC)]
            public float CooldownTotal;

            /// <summary>
            /// Gets the cooldown time remaining.
            /// </summary>
            public float CooldownRemaining => this.IsCooldown ? this.CooldownTotal - this.CooldownElapsed : 0;
        }
    }
}

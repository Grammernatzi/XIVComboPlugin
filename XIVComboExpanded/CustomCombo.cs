using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Objects.SubKinds;
using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Game.ClientState.Statuses;
using Dalamud.Utility;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using XIVComboExpandedestPlugin.Attributes;

namespace XIVComboExpandedestPlugin.Combos
{
    /// <summary>
    /// Base class for each combo.
    /// </summary>
    internal abstract partial class CustomCombo
    {
        private const uint InvalidObjectID = 0xE000_0000;

        private static readonly Dictionary<Type, JobGaugeBase> JobGaugeCache = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomCombo"/> class.
        /// </summary>
        protected CustomCombo()
        {
            var presetInfo = this.Preset.GetAttribute<CustomComboInfoAttribute>();
            this.JobID = presetInfo.JobID;
            this.ClassID = this.JobID switch
            {
                BLM.JobID => BLM.ClassID,
                BRD.JobID => BRD.ClassID,
                DRG.JobID => DRG.ClassID,
                MNK.JobID => MNK.ClassID,
                NIN.JobID => NIN.ClassID,
                PLD.JobID => PLD.ClassID,
                SCH.JobID => SCH.ClassID,
                SMN.JobID => SMN.ClassID,
                WAR.JobID => WAR.ClassID,
                WHM.JobID => WHM.ClassID,
                _ => 0xFF,
            };
            this.ActionIDs = presetInfo.ActionIDs;
        }

        /// <summary>
        /// Gets the preset associated with this combo.
        /// </summary>
        protected abstract CustomComboPreset Preset { get; }

        /// <summary>
        /// Gets the class ID associated with this combo.
        /// </summary>
        protected byte ClassID { get; }

        /// <summary>
        /// Gets the job ID associated with this combo.
        /// </summary>
        protected byte JobID { get; }

        protected uint FilteredLastComboMove { get; set; }

        protected Vector2 Position { get; set; }

        protected uint[] FilteredLastComboMoves { get; set; } = new uint[]
        {
            BRD.RainOfDeath,
            BRD.ApexArrow,
            BRD.BlastArrow,
            BRD.RadiantFinale,
            BRD.EmpyrealArrow,
            36976, // Resonant Arrow
            36977, // Radiant Encore
            PLD.NotFatedCircle,
            PLD.NotGnashingFangCombo,
            PLD.NotGnashingFang,
            PLD.NotSavageClaw,
            PLD.NotWickedTalon,
            DRG.FangAndClaw,
            DRG.WheelingThrust,
            RDM.Moulinet,
            RDM.EnchantedMoulinet,
            RDM.EnchantedMoulinetDeux,
            RDM.EnchantedMoulinetTrois,
            RDM.Manafication,
            RDM.Verholy,
            RDM.Verflare,
            RDM.Scorch,
            RDM.Resolution,
            RDM.Impact,
            RDM.Scatter,
            RDM.GrandImpact,
            BLM.FlareStar,
            3545, // Elixir Field
            25882, // Flint Strike
            3543, // Tornado Kick
            25768, // Rising Phoenix
            25769, // Phantom Rush
            25765, // Celestial Revolution (AKA Monk Bunny)
            36949, // Wind's Reply
            36950, // Fire's Reply
            0,
        };

        /// <summary>
        /// Gets the action IDs associated with this combo.
        /// </summary>
        protected virtual uint[] ActionIDs { get; }

        /// <summary>
        /// Performs various checks then attempts to invoke the combo.
        /// </summary>
        /// <param name="actionID">Starting action ID.</param>
        /// <param name="lastComboActionID">Last combo action.</param>
        /// <param name="comboTime">Current combo time.</param>
        /// <param name="level">Current player level.</param>
        /// <param name="newActionID">Replacement action ID.</param>
        /// <returns>True if the action has changed, otherwise false.</returns>
        public bool TryInvoke(uint actionID, uint lastComboActionID, float comboTime, byte level, out uint newActionID)
        {
            newActionID = 0;

            if (!this.FilteredLastComboMoves.Contains(lastComboActionID))
                this.FilteredLastComboMove = lastComboActionID;

            // Reset filtered last combo move if out of combat.
            if (LocalPlayer is not null && !HasCondition(ConditionFlag.InCombat))
                this.FilteredLastComboMove = 0;

            if (!IsEnabled(this.Preset))
                return false;

            var classJobID = LocalPlayer?.ClassJob.RowId;
            if ((this.JobID != classJobID && this.ClassID != classJobID) && this.JobID != 0)
                return false;

            if (!this.ActionIDs.Contains(actionID))
                return false;

            var resultingActionID = this.Invoke(actionID, lastComboActionID, comboTime, level);
            if (resultingActionID == 0 || actionID == resultingActionID)
                return false;

            newActionID = resultingActionID;

            return true;
        }

        /// <summary>
        /// Calculate the best action to use, based on cooldown remaining.
        /// If there is a tie, the original is used.
        /// </summary>
        /// <param name="original">The original action.</param>
        /// <param name="actions">Action data.</param>
        /// <returns>The appropriate action to use.</returns>
        protected static uint CalcBestAction(uint original, params uint[] actions)
        {
            static (uint ActionID, IconReplacer.CooldownData Data) Compare(
                uint original,
                (uint ActionID, IconReplacer.CooldownData Data) a1,
                (uint ActionID, IconReplacer.CooldownData Data) a2)
            {
                // Neither, return the first parameter
                if (!a1.Data.IsCooldown && !a2.Data.IsCooldown)
                    return original == a1.ActionID ? a1 : a2;

                // Both, return soonest available
                if (a1.Data.IsCooldown && a2.Data.IsCooldown)
                    return a1.Data.CooldownRemaining < a2.Data.CooldownRemaining ? a1 : a2;

                // One or the other
                return a1.Data.IsCooldown ? a2 : a1;
            }

            static (uint ActionID, IconReplacer.CooldownData Data) Selector(uint actionID)
            {
                return (actionID, GetCooldown(actionID));
            }

            return actions
                .Select(Selector)
                .Aggregate((a1, a2) => Compare(original, a1, a2))
                .ActionID;
        }

        /// <summary>
        /// Invokes the combo.
        /// </summary>
        /// <param name="actionID">Starting action ID.</param>
        /// <param name="lastComboActionID">Last combo action.</param>
        /// <param name="comboTime">Current combo time.</param>
        /// <param name="level">Current player level.</param>
        /// <returns>The replacement action ID.</returns>
        protected abstract uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level);
    }

    /// <summary>
    /// Passthrough methods and properties to IconReplacer. Shortens what it takes to call each method.
    /// </summary>
    internal abstract partial class CustomCombo
    {
        /// <summary>
        /// Gets the player or null.
        /// </summary>
        protected static IPlayerCharacter? LocalPlayer => Service.ObjectTable.LocalPlayer;

        /// <summary>
        /// Gets the current target or null.
        /// </summary>
        protected static IGameObject? CurrentTarget => Service.TargetManager.Target;

        /// <summary>
        /// Calls the original hook.
        /// </summary>
        /// <param name="actionID">Action ID.</param>
        /// <returns>The result from the hook.</returns>
        protected static uint OriginalHook(uint actionID) => Service.IconReplacer.OriginalHook(actionID);

        /// <summary>
        /// Gets bool determining if action is greyed out or not.
        /// </summary>
        /// <param name="actionID">Action ID.</param>
        /// <returns>A bool value of whether the action can be used or not.</returns>
        protected static bool CanUseAction(uint actionID) => Service.IconReplacer.CanUseAction(actionID);

        /// <summary>
        /// Gets bool determining if player is moving.
        /// </summary>
        /// <returns>A bool value of whether the player is moving or not.</returns>
        protected static unsafe bool IsMoving() => Service.IconReplacer.IsMoving(); // AgentMap.Instance() != null && AgentMap.Instance()->IsPlayerMoving > 0 ? true : false;

        /// <summary>
        /// Determine if the given preset is enabled.
        /// </summary>
        /// <param name="preset">Preset to check.</param>
        /// <returns>A value indicating whether the preset is enabled.</returns>
        protected static bool IsEnabled(CustomComboPreset preset) => Service.Configuration.IsEnabled(preset);

        /// <summary>
        /// Find if the player is in condition.
        /// </summary>
        /// <param name="flag">Condition flag.</param>
        /// <returns>A value indicating whether the player is in the condition.</returns>
        protected static bool HasCondition(ConditionFlag flag) => Service.Condition[flag];

        /// <summary>
        /// Find if an effect on the player exists.
        /// The effect may be owned by the player or unowned.
        /// </summary>
        /// <param name="effectID">Status effect ID.</param>
        /// <returns>A value indicating if the effect exists.</returns>
        protected static bool HasEffect(ushort effectID) => FindEffect(effectID) is not null;

        /// <summary>
        /// Finds an effect on the player.
        /// The effect must be owned by the player or unowned.
        /// </summary>
        /// <param name="effectID">Status effect ID.</param>
        /// <returns>Status object or null.</returns>
        protected static IStatus? FindEffect(ushort effectID) => FindEffect(effectID, LocalPlayer, (uint)LocalPlayer?.GameObjectId);

        /// <summary>
        /// Find if an effect on the target exists.
        /// The effect must be owned by the player or unowned.
        /// </summary>
        /// <param name="effectID">Status effect ID.</param>
        /// <returns>A value indicating if the effect exists.</returns>
        protected static bool TargetHasEffect(ushort effectID) => FindTargetEffect(effectID) is not null;

        /// <summary>
        /// Finds an effect on the current target.
        /// The effect must be owned by the player or unowned.
        /// </summary>
        /// <param name="effectID">Status effect ID.</param>
        /// <returns>Status object or null.</returns>
        protected static IStatus? FindTargetEffect(ushort effectID) => FindEffect(effectID, CurrentTarget, (uint)LocalPlayer?.GameObjectId);

        /// <summary>
        /// Find if an effect on the player exists.
        /// The effect may be owned by anyone or unowned.
        /// </summary>
        /// <param name="effectID">Status effect ID.</param>
        /// <returns>A value indicating if the effect exists.</returns>
        protected static bool HasEffectAny(ushort effectID) => FindEffectAny(effectID) is not null;

        /// <summary>
        /// Finds an effect on the player.
        /// The effect may be owned by anyone or unowned.
        /// </summary>
        /// <param name="effectID">Status effect ID.</param>
        /// <returns>Status object or null.</returns>
        protected static IStatus? FindEffectAny(ushort effectID) => FindEffect(effectID, LocalPlayer, null);

        /// <summary>
        /// Find if an effect on the target exists.
        /// The effect may be owned by anyone or unowned.
        /// </summary>
        /// <param name="effectID">Status effect ID.</param>
        /// <returns>A value indicating if the effect exists.</returns>
        protected static bool TargetHasEffectAny(ushort effectID) => FindTargetEffectAny(effectID) is not null;

        /// <summary>
        /// Finds an effect on the current target.
        /// The effect may be owned by anyone or unowned.
        /// </summary>
        /// <param name="effectID">Status effect ID.</param>
        /// <returns>Status object or null.</returns>
        protected static IStatus? FindTargetEffectAny(ushort effectID) => FindEffect(effectID, CurrentTarget, null);

        /// <summary>
        /// Finds an effect on the given object.
        /// </summary>
        /// <param name="effectID">Status effect ID.</param>
        /// <param name="obj">Object to look for effects on.</param>
        /// <param name="sourceID">Source object ID.</param>
        /// <returns>Status object or null.</returns>
        protected static IStatus? FindEffect(ushort effectID, IGameObject? obj, uint? sourceID)
        {
            if (obj is null)
                return null;

            if (obj is not IBattleChara chara)
                return null;

            foreach (var status in chara.StatusList)
            {
                if (status.StatusId == effectID && (!sourceID.HasValue || status.SourceId == 0 || status.SourceId == InvalidObjectID || status.SourceId == sourceID))
                    return status;
            }

            return null;
        }

        /// <summary>
        /// Determines if the enemy can be interrupted if they are currently casting.
        /// </summary>
        /// <returns>Bool indicating whether they can be interrupted or not.</returns>
        protected static bool CanInterruptEnemy()
        {
            if (CurrentTarget is null)
                return false;

            if (CurrentTarget is not IBattleChara chara)
                return false;

            if (chara.IsCasting)
                return chara.IsCastInterruptible;

            return false;
        }

        /// <summary>
        /// Gets the distance from the target.
        /// </summary>
        /// <returns>Double representing the distance from the target.</returns>
        protected static double GetTargetDistance()
        {
            if (CurrentTarget is null || LocalPlayer is null)
                return 0;

            if (CurrentTarget is not IBattleChara chara || CurrentTarget.ObjectKind != Dalamud.Game.ClientState.Objects.Enums.ObjectKind.BattleNpc)
                return 0;

            var position = new Vector2(chara.Position.X, chara.Position.Z);
            var selfPosition = new Vector2(LocalPlayer.Position.X, LocalPlayer.Position.Z);

            return (Vector2.Distance(position, selfPosition) - chara.HitboxRadius) - LocalPlayer.HitboxRadius;
        }

        /// <summary>
        /// Determines if you are in melee range from the current target.
        /// </summary>
        /// <returns>Bool indicating whether you are in melee range.</returns>
        protected static bool InMeleeRange()
        {
            var distance = GetTargetDistance();

            if (distance == 0)
                return true;

            if (distance > 3 + Service.Configuration.MeleeOffset)
                return false;

            return true;
        }

        /// <summary>
        /// Gets the cooldown data for an action.
        /// </summary>
        /// <param name="actionID">Action ID to check.</param>
        /// <returns>Cooldown data.</returns>
        protected static IconReplacer.CooldownData GetCooldown(uint actionID) => Service.IconReplacer.GetCooldown(actionID);

        /// <summary>
        /// Checks to see if an action is off-cooldown.
        /// </summary>
        /// <param name="actionID">Action ID to check.</param>
        /// <returns>A bool indicating if the action is off-cooldown or not.</returns>
        protected static bool IsActionOffCooldown(uint actionID) => GetCooldown(actionID).CooldownRemaining == 0;

        /// <summary>
        /// Checks to see if the GCD would not currently clip if you used a cooldown.
        /// </summary>
        /// <returns>A bool indicating if the GCD is greater-than-or-equal-to 0.5s or not.</returns>
        protected static bool GCDClipCheck() => GetCooldown(PLD.RageOfHalone).CooldownRemaining >= 0.5;

        /// <summary>
        /// Gets the job gauge.
        /// </summary>
        /// <typeparam name="T">Type of job gauge.</typeparam>
        /// <returns>The job gauge.</returns>
        protected static T GetJobGauge<T>() where T : JobGaugeBase
        {
            if (!JobGaugeCache.TryGetValue(typeof(T), out var gauge))
                gauge = JobGaugeCache[typeof(T)] = Service.JobGauges.Get<T>();

            return (T)gauge;
        }
    }
}
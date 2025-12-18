using System;

using Dalamud.Game;
using Dalamud.Logging;
using Dalamud.Plugin.Services;
using FFXIVClientStructs.FFXIV.Client.Game;

namespace XIVComboExpandedestPlugin
{
    /// <summary>
    /// Plugin address resolver.
    /// </summary>
    internal class PluginAddressResolver : BaseAddressResolver
    {
        /// <summary>
        /// Gets the address of the member ComboTimer.
        /// </summary>
        public IntPtr ComboTimer { get; private set; }

        /// <summary>
        /// Gets the address of the member LastComboMove.
        /// </summary>
        public IntPtr LastComboMove => this.ComboTimer + 0x4;

        /// <summary>
        /// Gets the address of fpIsIconReplacable.
        /// </summary>
        public IntPtr IsActionIdReplaceable { get; private set; }

        /// <summary>
        /// Gets the address of fpGetActionCooldown.
        /// </summary>
        public IntPtr GetActionCooldown { get; private set; }

        /// <summary>
        /// Set up memory signatures.
        /// </summary>
        /// <param name="scanner">Signature scanner.</param>
        public unsafe new void Setup(ISigScanner scanner)
        {
            this.ComboTimer = new IntPtr(&ActionManager.Instance()->Combo.Timer);

            this.IsActionIdReplaceable = scanner.ScanText("40 53 48 83 EC 20 8B D9 48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 74 1F");

            Service.PluginLog.Verbose("===== X I V C O M B O =====");
            Service.PluginLog.Verbose($"IsActionIdReplaceable 0x{this.IsActionIdReplaceable:X}");
            Service.PluginLog.Verbose($"ComboTimer            0x{this.ComboTimer:X}");
            Service.PluginLog.Verbose($"LastComboMove         0x{this.LastComboMove:X}");
        }
    }
}

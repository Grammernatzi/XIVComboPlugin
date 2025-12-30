using System;
using System.Collections.Generic;
using System.Linq;

using Dalamud.Configuration;
using Dalamud.Utility;
using Newtonsoft.Json;
using XIVComboExpandedestPlugin.Attributes;
using XIVComboExpandedestPlugin.Combos;

namespace XIVComboExpandedestPlugin
{
    /// <summary>
    /// Plugin configuration.
    /// </summary>
    [Serializable]
    public class PluginConfiguration : IPluginConfiguration
    {
        /// <summary>
        /// Gets or sets the configuration version.
        /// </summary>
        public int Version { get; set; } = 5;

        /// <summary>
        /// Gets or sets the collection of enabled combos.
        /// </summary>
        [JsonProperty("EnabledActionsV5")]
        public HashSet<CustomComboPreset> EnabledActions { get; set; } = new();

        /// <summary>
        /// Gets or sets the collection of enabled combos.
        /// </summary>
        [JsonProperty("EnabledActionsV4")]
        public HashSet<CustomComboPreset> EnabledActions4 { get; set; } = new();

        /// <summary>
        /// Gets or sets a value indicating whether to allow and display secret combos.
        /// </summary>
        [JsonProperty("Debug")]
        public bool EnableSecretCombos { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether to hide children of disabled features or not.
        /// </summary>
        [JsonProperty("HideChildren")]
        public bool HideChildren { get; set; } = true;

        /// <summary>
        /// Gets or sets an array of 4 ability IDs to interact with the <see cref="CustomComboPreset.DancerDanceComboCompatibility"/> combo.
        /// </summary>
        public uint[] DancerDanceCompatActionIDs { get; set; } = new uint[]
        {
            DNC.Cascade,
            DNC.Flourish,
            DNC.FanDance1,
            DNC.FanDance2,
        };

        /// <summary>
        /// Gets or sets the delay for Regress feature to activate. Default is 0.
        /// </summary>
        public float RegressDelay { get; set; } = 0;

        /// <summary>
        /// Gets or sets the offset of the melee range check. Default is 0.
        /// </summary>
        public double MeleeOffset { get; set; } = 0;

        /// <summary>
        /// Gets or sets the offset of the MP threshold for Lucid Dreaming reminders. Default is 8000.
        /// </summary>
        public uint LucidMPThreshold { get; set; } = 8000;

        /// <summary>
        /// Gets or sets the offset from 0 that a cooldown stops becoming Lucid Dreaming. Default is 0.
        /// </summary>
        public double LucidCooldownOffset { get; set; } = 0;

        /// <summary>
        /// Gets or sets the threshold for Verproc Cancel Prevention. Default is 2.0.
        /// </summary>
        public float VerprocCancelThreshold { get; set; } = 2.0f;

        /// <summary>
        /// Save the configuration to disk.
        /// </summary>
        public void Save()
            => Service.Interface.SavePluginConfig(this);

        /// <summary>
        /// Gets a value indicating whether a preset is enabled.
        /// </summary>
        /// <param name="preset">Preset to check.</param>
        /// <returns>The boolean representation.</returns>
        public bool IsEnabled(CustomComboPreset preset)
            => this.EnabledActions.Contains(preset) && (this.EnableSecretCombos || !this.IsSecret(preset));

        /// <summary>
        /// Gets a cached list of secret combos.
        /// </summary>
        [JsonIgnore]
        public HashSet<CustomComboPreset> SecretCombos { get; } = Enum.GetValues<CustomComboPreset>()
            .Where(preset => preset.GetAttribute<SecretCustomComboAttribute>() != default)
            .ToHashSet();

        /// <summary>
        /// Gets a value indicating whether a preset is secret.
        /// </summary>
        /// <param name="preset">Preset to check.</param>
        /// <returns>The boolean representation.</returns>
        public bool IsSecret(CustomComboPreset preset)
            => this.SecretCombos.Contains(preset);

        /// <summary>
        /// Gets an array of conflicting combo presets.
        /// </summary>
        /// <param name="preset">Preset to check.</param>
        /// <returns>The conflicting presets.</returns>
        public CustomComboPreset[] GetConflicts(CustomComboPreset preset)
            => preset.GetAttribute<ConflictingCombosAttribute>()?.ConflictingPresets ?? Array.Empty<CustomComboPreset>();

        /// <summary>
        /// Gets the parent combo preset if it exists, or null.
        /// </summary>
        /// <param name="preset">Preset to check.</param>
        /// <returns>The parent preset.</returns>
        public CustomComboPreset? GetParent(CustomComboPreset preset)
            => preset.GetAttribute<ParentComboAttribute>()?.ParentPreset;
    }
}

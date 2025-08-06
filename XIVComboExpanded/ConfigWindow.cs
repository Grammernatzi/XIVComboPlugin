using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

using Dalamud.Bindings.ImGui;
using Dalamud.Interface;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Windowing;
using Dalamud.Utility;

using XIVComboExpandedestPlugin.Attributes;

namespace XIVComboExpandedestPlugin
{
    /// <summary>
    /// Plugin configuration window.
    /// </summary>
    internal class ConfigWindow : Window
    {
        private readonly Dictionary<string, List<(CustomComboPreset Preset, CustomComboInfoAttribute Info)>> groupedPresets;
        private readonly Vector4 shadedColor = new(0.68f, 0.68f, 0.68f, 1.0f);

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigWindow"/> class.
        /// </summary>
        public ConfigWindow()
            : base("Custom Combo Setup")
        {
            this.RespectCloseHotkey = true;

            this.groupedPresets = Enum
                .GetValues<CustomComboPreset>()
                .Select(preset => (
                    PresetInfo: (preset, Info: preset.GetAttribute<CustomComboInfoAttribute>()),
                    Ordering: preset.GetAttribute<OrderedEnumAttribute>()))
                .Where(tpl => tpl.PresetInfo.Info != null && tpl.Ordering != null)
                .OrderBy(tpl => tpl.PresetInfo.Info.JobName)
                .ThenBy(tpl => tpl.Ordering.Order)
                .GroupBy(tpl => tpl.PresetInfo.Info.JobName)
                .ToDictionary(
                    tpl => tpl.Key,
                    tpl => tpl.Select(tpl => tpl.PresetInfo).ToList());

            this.SizeCondition = ImGuiCond.FirstUseEver;
            this.Size = new Vector2(740, 490);
        }

        /// <inheritdoc/>
        public override void Draw()
        {
            ImGui.Text("This window allows you to enable and disable custom combos to your liking.");
            ImGui.Text("For features that replace buttons with cooldowns, it is recommended you either make use of a cooldown bar, or a cooldown tracking plugin like Job Bars or DelvCD.");

            var showSecrets = Service.Configuration.EnableSecretCombos;
            if (ImGui.Checkbox("Daemitus's Secrets", ref showSecrets))
            {
                Service.Configuration.EnableSecretCombos = showSecrets;
                Service.Configuration.Save();
            }

            if (ImGui.IsItemHovered())
            {
                ImGui.BeginTooltip();
                ImGui.TextUnformatted("The secrets of the creator (as well as some silly stuff I don't want to clog the list).");
                ImGui.EndTooltip();
            }

            var hideChildren = Service.Configuration.HideChildren;
            if (ImGui.Checkbox("Hide children of disabled combos and features", ref hideChildren))
            {
                Service.Configuration.HideChildren = hideChildren;
                Service.Configuration.Save();
            }

            float offset = (float)Service.Configuration.MeleeOffset;

            var inputChangedeth = false;
            inputChangedeth |= ImGui.InputFloat("Melee Distance Offset", ref offset);

            if (inputChangedeth)
            {
                Service.Configuration.MeleeOffset = (double)offset;
                Service.Configuration.Save();
            }

            if (ImGui.IsItemHovered())
            {
                ImGui.BeginTooltip();
                ImGui.TextUnformatted("Offset of melee check distance for features that use it. For those who don't want to immediately use their ranged attack if the boss walks slightly out of range.");
                ImGui.EndTooltip();
            }

            ImGui.BeginChild("scrolling", new Vector2(0, -1), true);

            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(0, 5));

            var i = 1;

            foreach (var jobName in this.groupedPresets.Keys)
            {
                if (ImGui.CollapsingHeader(jobName))
                {
                    foreach (var (preset, info) in this.groupedPresets[jobName])
                    {
                        var enabled = Service.Configuration.IsEnabled(preset);
                        var secret = Service.Configuration.IsSecret(preset);
                        var conflicts = Service.Configuration.GetConflicts(preset);
                        var parent = Service.Configuration.GetParent(preset);

                        if (secret && !showSecrets)
                            continue;

                        if (parent != null)
                        {
                            if (!Service.Configuration.EnabledActions.Contains(parent.Value))
                            {
                                if (Service.Configuration.EnabledActions.Contains(preset)) Service.Configuration.EnabledActions.Remove(preset);
                                if (hideChildren) continue;
                            }

                            ImGui.Indent();
                        }

                        if (parent?.GetAttribute<ParentComboAttribute>() != null)
                            ImGui.Indent();

                        ImGui.PushItemWidth(200);

                        if (ImGui.Checkbox(info.FancyName, ref enabled))
                        {
                            if (enabled)
                            {
                                Service.Configuration.EnabledActions.Add(preset);
                                foreach (var conflict in conflicts)
                                {
                                    Service.Configuration.EnabledActions.Remove(conflict);
                                }
                            }
                            else
                            {
                                Service.Configuration.EnabledActions.Remove(preset);
                            }

                            Service.IconReplacer.UpdateEnabledActionIDs();
                            Service.Configuration.Save();
                        }

                        if (secret)
                        {
                            ImGui.SameLine();
                            ImGui.Text("  ");
                            ImGui.SameLine();
                            ImGui.PushFont(UiBuilder.IconFont);
                            ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.HealerGreen);
                            ImGui.Text(FontAwesomeIcon.Star.ToIconString());
                            ImGui.PopStyleColor();
                            ImGui.PopFont();

                            if (ImGui.IsItemHovered())
                            {
                                ImGui.BeginTooltip();
                                ImGui.TextUnformatted("Secret");
                                ImGui.EndTooltip();
                            }
                        }

                        ImGui.PopItemWidth();

                        var description = $"#{i}: {info.Description}";

                        ImGui.TextWrapped(description);
                        ImGui.Spacing();

                        if (conflicts.Length > 0)
                        {
                            var conflictText = conflicts.Select(preset =>
                            {
                                var info = preset.GetAttribute<CustomComboInfoAttribute>();
                                return $"\n - {info.FancyName}";
                            }).Aggregate((t1, t2) => $"{t1}{t2}");

                            ImGui.TextColored(this.shadedColor, $"Conflicts with: {conflictText}");
                            ImGui.Spacing();
                        }

                        if (preset == CustomComboPreset.DancerDanceComboCompatibility && enabled)
                        {
                            var actions = Service.Configuration.DancerDanceCompatActionIDs.Cast<int>().ToArray();

                            ImGui.Indent();
                            var inputChanged = false;
                            inputChanged |= ImGui.InputInt("Emboite (Red) ActionID", ref actions[0], 0);
                            inputChanged |= ImGui.InputInt("Entrechat (Blue) ActionID", ref actions[1], 0);
                            inputChanged |= ImGui.InputInt("Jete (Green) ActionID", ref actions[2], 0);
                            inputChanged |= ImGui.InputInt("Pirouette (Yellow) ActionID", ref actions[3], 0);
                            ImGui.Unindent();

                            if (inputChanged)
                            {
                                Service.Configuration.DancerDanceCompatActionIDs = actions.Cast<uint>().ToArray();
                                Service.IconReplacer.UpdateEnabledActionIDs();
                                Service.Configuration.Save();
                            }

                            ImGui.Spacing();
                        }

                        if (preset == CustomComboPreset.ReaperRegressFeature && enabled)
                        {
                            var delay = Service.Configuration.RegressDelay;

                            ImGui.Indent();
                            var inputChanged = false;
                            inputChanged |= ImGui.InputFloat("Regress Delay", ref delay);
                            ImGui.Unindent();

                            if (inputChanged)
                            {
                                Service.Configuration.RegressDelay = delay;
                                Service.Configuration.Save();
                            }

                            ImGui.Spacing();
                        }

                        if (new[] { CustomComboPreset.AstrologianLucidReminderFeature, CustomComboPreset.RedMageLucidReminderFeature, CustomComboPreset.SageLucidReminderFeature,
                                    CustomComboPreset.ScholarLucidReminderFeature, CustomComboPreset.SummonerLucidReminderFeature, CustomComboPreset.WhiteMageLucidReminderFeature, }.Contains(preset) && enabled)
                        {
                            int lucidThreshold = (int)Service.Configuration.LucidMPThreshold;
                            var lucidOffset = (float)Service.Configuration.LucidCooldownOffset;

                            ImGui.Indent();
                            var inputChanged = false;
                            inputChanged |= ImGui.InputInt("MP Threshold", ref lucidThreshold, 0);
                            inputChanged |= ImGui.InputFloat("Cooldown Remaining Offset", ref lucidOffset);
                            ImGui.Unindent();

                            if (inputChanged)
                            {
                                lucidThreshold = Math.Clamp(lucidThreshold, 0, 10000);
                                lucidOffset = Math.Clamp(lucidOffset, 0, 100);
                                Service.Configuration.LucidMPThreshold = (uint)lucidThreshold;
                                Service.Configuration.LucidCooldownOffset = (double)lucidOffset;
                                Service.Configuration.Save();
                            }

                            ImGui.Spacing();
                        }

                        if (parent != null)
                            ImGui.Unindent();

                        if (parent?.GetAttribute<ParentComboAttribute>() != null)
                            ImGui.Unindent();

                        i++;
                    }
                }
                else
                {
                    i += this.groupedPresets[jobName].Count;
                }
            }

            ImGui.PopStyleVar();

            ImGui.EndChild();
        }
    }
}

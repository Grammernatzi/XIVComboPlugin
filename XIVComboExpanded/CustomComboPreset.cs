using XIVComboExpandedestPlugin.Attributes;
using XIVComboExpandedestPlugin.Combos;

namespace XIVComboExpandedestPlugin
{
    /// <summary>
    /// Combo presets.
    /// </summary>
    public enum CustomComboPreset
    {
        // ====================================================================================
        #region MULTIPLE CLASSES/DOL

        [OrderedEnum]
        [CustomComboInfo("Raise to Swiftcast Feature", "Replaces the respective raise on RDM/SMN/SCH/WHM/AST/SGE with Swiftcast when it is off cooldown (and Dualcast isn't up).", All.JobID, All.Raise, All.Resurrection, All.Ascend, All.Verraise, All.Egeiro)]
        AllSwiftcastFeature = 9001,

        [OrderedEnum]
        [CustomComboInfo("Eureka Feature", "Replaces Solid Reason/Ageless Words with Wise to the World when you have Eureka Moment up.", All.JobID, All.SolidReason, All.AgelessWords)]
        AllEurekaFeature = 9002,

        [OrderedEnum]
        [CustomComboInfo("Tank Interrupt Feature", "Low Blow becomes Interject if the opponent can be interrupted and Interject is off-cooldown.", All.JobID, All.LowBlow)]
        AllTankInterruptFeature = 9003,

        [OrderedEnum]
        [CustomComboInfo("Cast / Hook Feature", "Replace Cast with Hook when fishing.", All.JobID, All.Cast)]
        DolCastHookFeature = 9004,

        [OrderedEnum]
        [CustomComboInfo("Cast / Gig Feature", "Replace Cast with Gig when underwater.", All.JobID, All.Cast)]
        DolCastGigFeature = 9005,

        [OrderedEnum]
        [CustomComboInfo("Surface Slap / Veteran Trade Feature", "Replace Surface Slap with Veteran Trade when underwater.", All.JobID, All.SurfaceSlap)]
        DolSurfaceTradeFeature = 9006,

        [OrderedEnum]
        [CustomComboInfo("Prize Catch / Nature's Bounty Feature", "Replace Prize Catch with Nature's Bounty when underwater.", All.JobID, All.PrizeCatch)]
        DolPrizeBountyFeature = 9007,

        [OrderedEnum]
        [CustomComboInfo("Snagging / Salvage Feature", "Replace Snagging with Salvage when underwater.", All.JobID, All.Snagging)]
        DolSnaggingSalvageFeature = 9008,

        [OrderedEnum]
        [CustomComboInfo("Cast Light / Electric Current Feature", "Replace Cast Light with Electric Current when underwater.", All.JobID, All.CastLight)]
        DolCastLightElectricCurrentFeature = 9009,

        #endregion

        #region ASTROLOGIAN

        [OrderedEnum]
        [CustomComboInfo("Draw on Play", "Play turns into Draw when no card is drawn, as well as the usual Play behavior.", AST.JobID, AST.Play)]
        AstrologianCardsOnDrawFeature = 3301,

        [OrderedEnum]
        [CustomComboInfo("Play to Astrodyne", "Play becomes Astrodyne when you have 3 seals.\nIf Draw on Play is enabled, Astrodyne replaces Draw on Play while Draw is on Cooldown.", AST.JobID, AST.Play)]
        AstrologianAstrodynePlayFeature = 3304,

        [OrderedEnum]
        [CustomComboInfo("Draw Lockout", "Prevents you from using Draw (not Draw on Play) while a card is drawn by replacing it with Malefic.", AST.JobID, AST.Draw)]
        AstrologianDrawLockoutFeature = 3306,

        [OrderedEnum]
        [CustomComboInfo("Minor Arcana to Crown Play", "Changes Minor Arcana to Crown Play when a card is not drawn.", AST.JobID, AST.MinorArcana, AST.CrownPlay)]
        AstrologianMinorArcanaPlayFeature = 3302,

        [OrderedEnum]
        [ParentCombo(AstrologianMinorArcanaPlayFeature)]
        [CustomComboInfo("Crown Play to Minor Arcana", "Changes Crown Play to Minor Arcana instead of the other way around.", AST.JobID, AST.CrownPlay)]
        AstrologianMinorArcanaPlayOption = 3307,

        [OrderedEnum]
        [CustomComboInfo("Benefic 2 to Benefic Level Sync", "Changes Benefic 2 to Benefic when below level 26 in synced content.", AST.JobID, AST.Benefic2)]
        AstrologianBeneficFeature = 3303,

        [OrderedEnum]
        [CustomComboInfo("Astrologian Lucid Dreaming Reminder", "All your non-role action cooldowns (that don't have charges) become Lucid Dreaming if they aren't up and Lucid Dreaming is, and you have less-than-or-equal-to 9000 MP.", AST.JobID, AST.Lightspeed, AST.MinorArcana, AST.CelestialOpposition, AST.CollectiveUnconscious, AST.Divination, AST.EarthlyStar, AST.Exaltation, AST.Macrocosmos, AST.NeutralSect, AST.Synastry, AST.Horoscope)]
        AstrologianLucidReminderFeature = 3305,

        #endregion
        // ====================================================================================
        #region BLACK MAGE

        [OrderedEnum]
        [CustomComboInfo("Blizzard 4/Fire 4 Switcher", "Change Fire 4 or Blizzard 4 to whichever action you can currently use.", BLM.JobID, BLM.Blizzard4, BLM.Fire4)]
        BlackEnochianFeature = 2501,

        [OrderedEnum]
        [ParentCombo(BlackEnochianFeature)]
        [CustomComboInfo("Blizzard 4/Fire 4 to Xenoglossy Movement Feature", "Change Fire 4 or Blizzard 4 to Xenoglossy while moving, if available and Triplecast/Swiftcast are not up.", BLM.JobID, BLM.Blizzard4, BLM.Fire4)]
        BlackEnochianXenoglossyFeature = 2520,

        [OrderedEnum]
        [SecretCustomCombo]
        [ParentCombo(BlackEnochianFeature)]
        [CustomComboInfo("Enochian Despair Feature", "Change Fire 4 or Blizzard 4 to Despair when in Astral Fire with less than 2400 mana.", BLM.JobID, BLM.Blizzard4, BLM.Fire4)]
        BlackEnochianDespairFeature = 2510,

        [OrderedEnum]
        [CustomComboInfo("Flare to Despair Feature", "Change Flare to Despair when Thunder III is applied to your target.", BLM.JobID, BLM.Flare, BLM.Freeze, BLM.Fire2, BLM.HighFire2)]
        BlackFlareDespairFeature = 2511,

        [OrderedEnum]
        [CustomComboInfo("Freeze/Flare Switcher", "Change Freeze or Flare to whichever action you can currently use.", BLM.JobID, BLM.Freeze, BLM.Flare)]
        BlackFreezeFlareFeature = 2502,

        [OrderedEnum]
        [ParentCombo(BlackFreezeFlareFeature)]
        [CustomComboInfo("Freeze/Flare to Foul Movement Feature", "Change Freeze or Flare to Foul while moving, if instant cast foul is unlocked, it is available, and Triplecast/Swiftcast are not up.", BLM.JobID, BLM.Freeze, BLM.Flare)]
        BlackFreezeFlareFoulFeature = 2521,

        [OrderedEnum]
        [CustomComboInfo("Umbral Soul Feature", "When you have no target, your ice spells become Umbral Soul while in Umbral Ice.", BLM.JobID, BLM.Freeze, BLM.Blizzard4, BLM.Blizzard, BLM.Blizzard2, BLM.Blizzard3, BLM.HighBlizzard2, BLM.Fire4, BLM.Flare)]
        BlackUmbralSoulFeature = 2503,

        [OrderedEnum]
        [CustomComboInfo("Transpose Feature", "When you have no target, spells of the opposite element (if you are in UI/AF) become Transpose.", BLM.JobID, BLM.Freeze, BLM.Blizzard4, BLM.Blizzard, BLM.Blizzard2, BLM.Blizzard3, BLM.HighBlizzard2, BLM.Fire4, BLM.Flare, BLM.Despair, BLM.Fire, BLM.Fire2, BLM.Fire3, BLM.HighFire2)]
        BlackTransposeFeature = 2516,

        [OrderedEnum]
        [CustomComboInfo("Despair to Transpose", "When you are in Umbral Ice or have zero MP, Despair becomes Transpose.\nThis is primarily for use in the Paradox rotation.", BLM.JobID, BLM.Despair)]
        BlackDespairTransposeFeature = 2517,

        [OrderedEnum]
        [CustomComboInfo("Umbral Soul to Transpose", "When you are outside of Umbral Ice, Umbral Soul becomes Transpose.", BLM.JobID, BLM.UmbralSoul)]
        BlackUmbralSoulTransposeFeature = 2518,

        [OrderedEnum]
        [CustomComboInfo("Fire 2 Feature", "(High) Fire 2 becomes Flare in Astral Fire if you have one Umbral Heart, or low MP, or if you have Enhanced Flare.", BLM.JobID, BLM.Fire2, BLM.HighFire2)]
        BlackFire2Feature = 2508,

        [OrderedEnum]
        [ParentCombo(BlackFire2Feature)]
        [CustomComboInfo("Fire 2 Triple High Fire 2 Feature", "When you have High Fire 2 unlocked, allows for a third cast of High Fire 2 when you have two Umbral Hearts and don't have Triplecast up.\nPlease note that you should put Flare on your bar if you are using this feature; you will need to manual flare at 2 hearts at certain points where mobs are about to die in order to not lose DPS.", BLM.JobID, BLM.Fire2, BLM.HighFire2)]
        BlackTripleHF2Option = 2519,

        [OrderedEnum]
        [CustomComboInfo("Ice 2 Feature", "(High) Blizzard 2 becomes Freeze in Umbral Ice.", BLM.JobID, BLM.Blizzard2, BLM.HighBlizzard2)]
        BlackBlizzard2Feature = 2509,

        [OrderedEnum]
        [CustomComboInfo("Fire 2/Ice 2 Option", "Fire 2 and Blizzard 2 will not change unless you're at max AF/UI with this option.", BLM.JobID, BLM.Blizzard2)]
        BlackFireBlizzard2Option = 2514,

        [OrderedEnum]
        [CustomComboInfo("(Between the) Ley Lines", "Change Ley Lines into BTL when Ley Lines is active.", BLM.JobID, BLM.LeyLines)]
        BlackLeyLinesFeature = 2504,

        [OrderedEnum]
        [CustomComboInfo("Fire 1/3 Feature", "Fire 1 becomes Fire 3 outside of Astral Fire, and when Firestarter proc is up, and also becomes Paradox when available.", BLM.JobID, BLM.Fire)]
        BlackFireFeature = 2505,

        [OrderedEnum]
        [CustomComboInfo("Blizzard 1/3 Feature", "Blizzard 1 becomes Blizzard 3 after you have unlocked it, and also becomes Paradox when available.", BLM.JobID, BLM.Blizzard)]
        BlackBlizzardFeature = 2506,

        [OrderedEnum]
        [ParentCombo(BlackFireFeature)]
        [CustomComboInfo("Fire 1/3 Option", "Fire will stay Fire 3 if you're not at max AF with this option.", BLM.JobID, BLM.Fire)]
        BlackFireOption = 2515,

        [OrderedEnum]
        [CustomComboInfo("Scathe/Xenoglossy Feature", "Scathe becomes Xenoglossy when available.", BLM.JobID, BLM.Scathe)]
        BlackScatheFeature = 2507,

        [OrderedEnum]
        [CustomComboInfo("Xenoglossy/Foul to Amplifier", "Xenoglossy/Foul become Amplifier when it's available, you have just used an action, and you have less than two Polyglot stacks, or if you have no target or have no Polyglot.", BLM.JobID, BLM.Xenoglossy, BLM.Foul)]
        BlackXenoAmpFeature = 2512,

        [OrderedEnum]
        [CustomComboInfo("Thunder 3/4 to Sharpcast", "Thunder 3/4 become Sharpcast when it is available, you have just used an action, and the effect is not currently up, or if you have no target.", BLM.JobID, BLM.Thunder, BLM.Thunder2, BLM.Thunder3, BLM.Thunder4)]
        BlackSharpThunderFeature = 2513,

        #endregion
        // ====================================================================================
        #region BARD

        [OrderedEnum]
        [CustomComboInfo("Heavy Shot into Straight Shot", "Replaces Heavy Shot/Burst Shot with Straight Shot/Refulgent Arrow when procced.", BRD.JobID, BRD.HeavyShot, BRD.BurstShot)]
        BardStraightShotUpgradeFeature = 2302,

        [OrderedEnum]
        [CustomComboInfo("Wanderer's into Pitch Perfect", "Replaces Wanderer's Minuet with Pitch Perfect while in WM.", BRD.JobID, BRD.WanderersMinuet)]
        BardWanderersPitchPerfectFeature = 2301,

        [OrderedEnum]
        [CustomComboInfo("Iron Jaws Feature", "Iron Jaws is replaced with Stormbite/Windbite if it is not up, or you do not have Iron Jaws yet.", BRD.JobID, BRD.IronJaws)]
        BardIronJawsFeature = 2311,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Iron Jaws Feature Plus", "Iron Jaws is replaced with Caustic Bite/Stormbite if one or both are not up.\nAlternates between the two if Iron Jaws isn't available.\nThis is a separate feature from Iron Jaws Feature, and will overwrite it if both are enabled.", BRD.JobID, BRD.IronJaws)]
        BardIronJawsFeaturePlus = 2303,

        [OrderedEnum]
        [CustomComboInfo("Quick Nock/Ladonsbite into Apex Arrow", "Replaces Quick Nock/Ladonsbite with Apex Arrow when gauge is 80 or above.", BRD.JobID, BRD.QuickNock, BRD.Ladonsbite)]
        BardApexFeature = 2304,

        [OrderedEnum]
        [CustomComboInfo("Quick Nock/Ladonsbite into Shadowbite", "Replaces Quick Nock/Ladonsbite with Shadowbite when it is ready.", BRD.JobID, BRD.QuickNock, BRD.Ladonsbite)]
        BardShadowbiteFeature = 2305,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Empyreal Arrow to Sidewinder", "Replaces Empyreal Arrow to Sidewinder if the latter is off-cooldown and the former is on-cooldown.", BRD.JobID, BRD.EmpyrealArrow)]
        BardSidewinderFeature = 2306,

        [OrderedEnum]
        [CustomComboInfo("Radiant Voice Feature", "Replaces Radiant Finale with Battle Voice if Battle Voice is off-cooldown.", BRD.JobID, BRD.RadiantFinale)]
        BardRadiantFeature = 2307,

        [OrderedEnum]
        [CustomComboInfo("Radiant Strikes Feature", "Replaces Radiant Finale with Raging Strikes if Raging Strikes is off-cooldown.\nThis takes priority over Battle Voice if Radiant Voice is enabled.", BRD.JobID, BRD.RadiantFinale)]
        BardRadiantStrikesFeature = 2309,

        [OrderedEnum]
        [CustomComboInfo("Barrage Feature", "Replaces Barrage with Straight Shot (and its upgrades) if you have Straight Shot Ready (unless Shadowbite is ready).", BRD.JobID, BRD.Barrage)]
        BardBarrageFeature = 2308,

        [OrderedEnum]
        [CustomComboInfo("Bloodletter to Rain of Death", "Replaces Bloodletter with Rain of Death if your last GCD was either Quick Nock/Ladonsbite or Shadowbite.", BRD.JobID, BRD.Bloodletter)]
        BardRainFeature = 2310,

        #endregion
        // ====================================================================================
        #region DANCER

        [OrderedEnum]
        [SecretCustomCombo]
        [ConflictingCombos(DancerDanceComboCompatibility)]
        [CustomComboInfo("Dance Step Combo", "Change Standard Step and Technical Step into each dance step while dancing.", DNC.JobID, DNC.StandardStep, DNC.TechnicalStep)]
        DancerDanceStepCombo = 3802,

        [OrderedEnum]
        [ConflictingCombos(DancerSingleTargetProcs)]
        [CustomComboInfo("Single Target Multibutton", "Change Cascade into procs and combos as available.", DNC.JobID, DNC.Cascade)]
        DancerSingleTargetMultibutton = 3804,

        [OrderedEnum]
        [ConflictingCombos(DancerSingleTargetMultibutton)]
        [CustomComboInfo("Single Target to Procs", "Change Single-Target actions into Procs when available.", DNC.JobID, DNC.Cascade, DNC.Fountain)]
        DancerSingleTargetProcs = 3811,

        [OrderedEnum]
        [ConflictingCombos(DancerAoeProcs)]
        [CustomComboInfo("AoE Multibutton", "Change Windmill into procs and combos as available.", DNC.JobID, DNC.Windmill)]
        DancerAoeMultibutton = 3805,

        [OrderedEnum]
        [ConflictingCombos(DancerAoeMultibutton)]
        [CustomComboInfo("AoE to Procs", "Change AoE actions into procs when available.", DNC.JobID, DNC.Windmill, DNC.Bladeshower)]
        DancerAoeProcs = 3812,

        [OrderedEnum]
        [CustomComboInfo("Fan Dance Combos", "Change Fan Dance and Fan Dance 2 into Fan Dance 3 while under Threefold Fan Dance.", DNC.JobID, DNC.FanDance1, DNC.FanDance2)]
        DancerFanDanceCombo = 3801,

        [OrderedEnum]
        [ParentCombo(DancerFanDanceCombo)]
        [CustomComboInfo("Fan Dance IV Combo", "Additionally change Fan Dance and Fan Dance 2 into Fan Dance 4 while under Fourfold Fan Dance.", DNC.JobID, DNC.FanDance1, DNC.FanDance2)]
        DancerFanDance4Combo = 3809,

        [OrderedEnum]
        [CustomComboInfo("Flourish Proc Saver", "Change Flourish into any available procs before using.", DNC.JobID, DNC.Flourish)]
        DancerFlourishFeature = 3803,

        [OrderedEnum]
        [CustomComboInfo("Flourish to Fan Dance IV", "Change Flourish into Fan Dance IV when it is ready.", DNC.JobID, DNC.Flourish)]
        DancerFlourishFanDance4Feature = 3808,

        [OrderedEnum]
        [CustomComboInfo("Flourish to Fan Dance III", "Change Flourish into Fan Dance III when it is ready.\nTakes priority over Fan Dance IV if Flourish to Fan Dance IV is active.", DNC.JobID, DNC.Flourish)]
        DancerFlourishFanDance3Feature = 3810,

        [OrderedEnum]
        [CustomComboInfo("Devilment Feature", "Change Devilment into Starfall Dance after use.", DNC.JobID, DNC.Devilment)]
        DancerDevilmentFeature = 3806,

        [OrderedEnum]
        [ConflictingCombos(DancerDanceStepCombo)]
        [CustomComboInfo(
            "Dance Step Feature",
            "Change actions into dance steps while dancing." +
            "\nThis helps ensure you can still dance with combos on, without using auto dance." +
            "\nYou can change the respective actions by inputting action IDs below for each dance step." +
            "\nThe defaults are Cascade, Flourish, Fan Dance and Fan Dance II. If set to 0, they will reset to these actions." +
            "\nYou can get Action IDs with Garland Tools by searching for the action and clicking the cog.",
            DNC.JobID)]
        DancerDanceComboCompatibility = 3807,

        #endregion
        // ====================================================================================
        #region DRAGOON

        [OrderedEnum]
        [CustomComboInfo("Full Thrust Combo", "Replace Full Thrust with its combo chain.", DRG.JobID, DRG.FullThrust, DRG.HeavensThrust)]
        DragoonFullThrustCombo = 2204,

        [OrderedEnum]
        [ParentCombo(DragoonFullThrustCombo)]
        [CustomComboInfo("Full Thrust Combo Vorpal Thrust Option", "Full Thrust's combo chain is instead replaced by Vorpal Thrust, not True Thrust, while you have no combo ongoing.", DRG.JobID, DRG.FullThrust, DRG.HeavensThrust)]
        DragoonFullThrustComboOption = 2210,

        [OrderedEnum]
        [ParentCombo(DragoonFullThrustCombo)]
        [CustomComboInfo("Full Thrust to Piercing Talon", "Full Thrust's combo is replaced with Piercing Talon when you are out of melee range.", DRG.JobID, DRG.FullThrust, DRG.HeavensThrust)]
        DragoonFullThrustTalonFeature = 2211,

        [OrderedEnum]
        [CustomComboInfo("Chaos Thrust Combo", "Replace Chaos Thrust with its combo chain.", DRG.JobID, DRG.ChaosThrust, DRG.ChaoticSpring)]
        DragoonChaosThrustCombo = 2203,

        [OrderedEnum]
        [ParentCombo(DragoonChaosThrustCombo)]
        [CustomComboInfo("Chaos Thrust Combo Disembowel Option", "Chaos Thrust's combo chain is instead replaced by Disembowel, not True Thrust, while you have no combo ongoing.", DRG.JobID, DRG.ChaosThrust, DRG.ChaoticSpring)]
        DragoonChaosThrustComboOption = 2209,

        [OrderedEnum]
        [ConflictingCombos(DragoonFangThrustFeature, DragoonFullChaosFeature)]
        [CustomComboInfo("Combos Wheeling Thrust/Fang and Claw Cosmetic Option", "This option makes it so that, when using your combos, only your current combo displays Wheeling Thrust/Fang and Claw.", DRG.JobID)]
        DragoonComboCosmeticOption = 2216,

        [OrderedEnum]
        [ConflictingCombos(DragoonComboCosmeticOption)]
        [CustomComboInfo("Wheeling Thrust/Fang and Claw Option", "When you have either Enhanced Fang and Claw or Wheeling Thrust,\nChaos Thrust Combo becomes Wheeling Thrust and Full Thrust Combo becomes Fang and Claw.\nRequires Chaos Thrust Combo and Full Thrust Combo.", DRG.JobID, DRG.FullThrust, DRG.ChaosThrust)]
        DragoonFangThrustFeature = 2205,

        [OrderedEnum]
        [CustomComboInfo("Opposite Combo/Disembowel to Wyrmwind", "Replaces the opposite combo of the one you are using (or Disembowel when not available) with Wyrmwind Thrust.", DRG.JobID, DRG.FullThrust, DRG.ChaosThrust, DRG.Disembowel)]
        DragoonOppositeWyrmwindFeature = 2212,

        [OrderedEnum]
        [CustomComboInfo("Fang and Claw to Wheeling Thrust", "Fang and Claw becomes Wheeling Thrust if the latter is available.", DRG.JobID, DRG.FangAndClaw)]
        DragoonFangToThrustFeature = 2214,

        [OrderedEnum]
        [ConflictingCombos(DragoonComboCosmeticOption)]
        [CustomComboInfo("Full Thrust to Chaos Thrust", "Full Thrust becomes Chaos Thrust after using Disembowel. Works even with combos on.", DRG.JobID, DRG.FullThrust, DRG.HeavensThrust)]
        DragoonFullChaosFeature = 2215,

        [OrderedEnum]
        [CustomComboInfo("True/Raiden Thrust to Wyrmwind", "Replace True/Raiden Thrust with Wyrmwind Thrust when available.", DRG.JobID, DRG.FullThrust, DRG.ChaosThrust, DRG.TrueThrust)]
        DragoonRaidenWyrmwindFeature = 2213,

        [OrderedEnum]
        [CustomComboInfo("Coerthan Torment Combo", "Replace Coerthan Torment with its combo chain.", DRG.JobID, DRG.CoerthanTorment)]
        DragoonCoerthanTormentCombo = 2202,

        [OrderedEnum]
        [ParentCombo(DragoonCoerthanTormentCombo)]
        [CustomComboInfo("Coerthan Torment Combo to Wyrmwind", "Coerthan Torment combo becomes Wyrmwind Thrust when you have two Firstminds' Focus.", DRG.JobID, DRG.CoerthanTorment)]
        DragoonWyrmwindFeature = 2207,

        [OrderedEnum]
        [CustomComboInfo("Jump to Mirage Dive", "Replace (High) Jump with Mirage Dive when Dive Ready.", DRG.JobID, DRG.Jump, DRG.HighJump)]
        DragoonJumpFeature = 2201,

        [OrderedEnum]
        [ConflictingCombos(DragoonStarfireDiveFeature)]
        [CustomComboInfo("Stardiver to Nastrond", "Stardiver becomes Nastrond when Nastrond is off-cooldown, and becomes Geirskogul outside of Life of the Dragon.", DRG.JobID, DRG.Stardiver)]
        DragoonNastrondFeature = 2206,

        [OrderedEnum]
        [ConflictingCombos(DragoonNastrondFeature)]
        [CustomComboInfo("Stardiver to Dragonfire Dive", "Stardiver becomes Dragonfire Dive when the latter is off-cooldown (and you have more than 7.5s of LotD left), or outside of Life of the Dragon.", DRG.JobID, DRG.Stardiver)]
        DragoonStarfireDiveFeature = 2208,

        #endregion
        // ====================================================================================
        #region DARK KNIGHT

        // unused enums: 3204

        [OrderedEnum]
        [CustomComboInfo("Souleater Combo", "Replace Souleater with its combo chain.", DRK.JobID, DRK.Souleater)]
        DarkSouleaterCombo = 3201,

        [OrderedEnum]
        [ParentCombo(DarkSouleaterCombo)]
        [CustomComboInfo("Souleater to Unmend", "Replace Souleater's combo with Unmend while out of melee range.", DRK.JobID, DRK.Souleater)]
        DarkSoulmendFeature = 3208,

        [OrderedEnum]
        [CustomComboInfo("Stalwart Soul Combo", "Replace Stalwart Soul with its combo chain.", DRK.JobID, DRK.StalwartSoul, DRK.Unleash)]
        DarkStalwartSoulCombo = 3202,

        [OrderedEnum]
        [SecretCustomCombo]
        [ParentCombo(DarkStalwartSoulCombo)]
        [CustomComboInfo("Evil Stalwart Soul Combo", "Replace Unleash with its combo chain, instead.", DRK.JobID, DRK.StalwartSoul, DRK.Unleash)]
        DarkEvilStalwartSoulCombo = 3205,

        [OrderedEnum]
        [CustomComboInfo("Dark Knight Gauge Overcap Feature", "Replace AoE combo with gauge spender if you are about to overcap.", DRK.JobID, DRK.StalwartSoul)]
        DRKOvercapFeature = 3203,

        [OrderedEnum]
        [CustomComboInfo("Blood Weapon Feature", "Replaces Carve and Spit with Blood Weapon if its cooldown is up .", DRK.JobID, DRK.CarveAndSpit)]
        DarkBloodWeaponFeature = 3206,

        [OrderedEnum]
        [CustomComboInfo("Living Shadow Feature", "Replaces Bloodspiller and Quietus with Living Shadow if its cooldown is up and you have 50 or more Blood Gauge.", DRK.JobID, DRK.Bloodspiller, DRK.Quietus)]
        DarkLivingShadowFeature = 3207,

        [OrderedEnum]
        [CustomComboInfo("Edge to Flood Feature", "Replaces Edge of Darkness/Shadow with Flood of Darkness/Shadow if currently using your AoE combo (as well as synced content before you unlock Edge).", DRK.JobID, DRK.EdgeOfDarkness, DRK.EdgeOfShadow)]
        DarkEdgeToFloodFeature = 3209,

        [OrderedEnum]
        [CustomComboInfo("Bloodspiller to Quietus Feature", "Replaces Bloodspiller with Quietus if currently using your AoE combo.", DRK.JobID, DRK.Bloodspiller)]
        DarkBloodspillerToQuietusFeature = 3210,

        [OrderedEnum]
        [CustomComboInfo("Carve and Spit to Abyssal Drain", "Replaces Carve and Spit with Abyssal Drain if currently using your AoE combo.", DRK.JobID, DRK.CarveAndSpit)]
        DarkCarveToDrainFeature = 3211,

        #endregion
        // ====================================================================================
        #region GUNBREAKER

        [OrderedEnum]
        [CustomComboInfo("Solid Barrel Combo", "Replace Solid Barrel with its combo chain.", GNB.JobID, GNB.SolidBarrel)]
        GunbreakerSolidBarrelCombo = 3701,

        [OrderedEnum]
        [ParentCombo(GunbreakerSolidBarrelCombo)]
        [CustomComboInfo("Solid Barrel to Lightning Shot", "Replace Solid Barrel's combo with Lightning Shot while out of melee range.", GNB.JobID, GNB.SolidBarrel)]
        GunbreakerSolidShotFeature = 3714,

        [OrderedEnum]
        [ParentCombo(GunbreakerSolidBarrelCombo)]
        [CustomComboInfo("Burst Strike Feature", "In addition to the Solid Barrel Combo, add Burst Strike when charges are full.", GNB.JobID, GNB.SolidBarrel)]
        GunbreakerBurstStrikeFeature = 3710,

        [OrderedEnum]
        [CustomComboInfo("Gnashing Fang Continuation", "Replace Gnashing Fang with Continuation when appropriate.", GNB.JobID, GNB.GnashingFang)]
        GunbreakerGnashingFangContinuation = 3702,

        [OrderedEnum]
        [CustomComboInfo("Burst Strike Continuation", "Replace Burst Strike with Continuation when appropriate.", GNB.JobID, GNB.BurstStrike)]
        GunbreakerBurstStrikeCont = 3703,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Bow Shock / Sonic Break Feature", "Replace Bow Shock and Sonic Break with one or the other depending on which is on cooldown.", GNB.JobID, GNB.BowShock, GNB.SonicBreak)]
        GunbreakerBowShockSonicBreakFeature = 3704,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("No Mercy Bow Shock / Sonic Break Feature", "Replace No Mercy with Bow Shock, and then Sonic Break, while No Mercy is active.", GNB.JobID, GNB.NoMercy)]
        GunbreakerNoMercyFeature = 3708,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Bow Shock / Sonic Break Option", "Makes it so Bow Shock only appears while the GCD is rolling in the above features. This is to prevent a rare clipping issue that naturally occurs in the current GNB rotation, but is a very minor DPS loss.\nRequires either Bow Shock / Sonic Break Feature", GNB.JobID, GNB.NoMercy)]
        GunbreakerBowShockSonicBreakOption = 3713,

        [OrderedEnum]
        [CustomComboInfo("Demon Slaughter Combo", "Replace Demon Slaughter with its combo chain.", GNB.JobID, GNB.DemonSlaughter, GNB.DemonSlice)]
        GunbreakerDemonSlaughterCombo = 3705,

        [OrderedEnum]
        [SecretCustomCombo]
        [ParentCombo(GunbreakerDemonSlaughterCombo)]
        [CustomComboInfo("Evil Demon Slaughter Combo", "Replace Demon Slice with its combo chain, instead.", GNB.JobID, GNB.DemonSlaughter, GNB.DemonSlice)]
        GunbreakerEvilDemonSlaughterCombo = 3709,

        [OrderedEnum]
        [CustomComboInfo("Fated Circle Feature", "In addition to the Demon Slaughter combo, add Fated Circle when charges are full.", GNB.JobID, GNB.DemonSlaughter, GNB.DemonSlice)]
        GunbreakerFatedCircleFeature = 3706,

        [OrderedEnum]
        [CustomComboInfo("Burst Strike/Fated Circle to Bloodfest Feature", "Replace Burst Strike and Fated Circle with Bloodfest if you have no powder gauge.", GNB.JobID, GNB.BurstStrike, GNB.FatedCircle)]
        GunbreakerBloodfestOvercapFeature = 3707,

        [OrderedEnum]
        [CustomComboInfo("No Mercy to Double Down Feature", "Replace No Mercy with Double Down while No Mercy is active and it is off-cooldown.\nThis takes priority over Bow Shock/Sonic Break if the No Mercy feature is enabled.", GNB.JobID, GNB.NoMercy)]
        GunbreakerNoMercyDoubleDownFeature = 3712,

        [OrderedEnum]
        [CustomComboInfo("Burst Strike to Fated Circle Feature", "Replace Burst Strike with Fated Circle if you are currently using your AoE combo.", GNB.JobID, GNB.BurstStrike)]
        GunbreakerBurstStrikeToFatedCircleFeature = 3715,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Double Down Feature", "Replace Burst Strike and Fated Circle with Double Down when available.", GNB.JobID, GNB.BurstStrike, GNB.FatedCircle)]
        GunbreakerDoubleDownFeature = 3711,

        #endregion
        // ====================================================================================
        #region MACHINIST

        [OrderedEnum]
        [ConflictingCombos(MachinistHypercomboOption)]
        [CustomComboInfo("(Heated) Shot Combo", "Replace either form of Clean Shot with its combo chain.", MCH.JobID, MCH.CleanShot, MCH.HeatedCleanShot)]
        MachinistMainCombo = 3101,

        [OrderedEnum]
        [CustomComboInfo("Spread Shot Heat", "Replace Spread Shot with Auto Crossbow when overheated.", MCH.JobID, MCH.SpreadShot, MCH.Scattergun)]
        MachinistSpreadShotFeature = 3102,

        [OrderedEnum]
        [CustomComboInfo("Hypercharge Feature", "Replace Heat Blast and Auto Crossbow with Hypercharge when not overheated.", MCH.JobID, MCH.HeatBlast, MCH.AutoCrossbow)]
        MachinistOverheatFeature = 3103,

        [OrderedEnum]
        [CustomComboInfo("Hypercharge Combo Feature", "Replace your main combo actions with Heat Blast while overheated.", MCH.JobID, MCH.SplitShot, MCH.HeatedSplitShot, MCH.SlugShot, MCH.HeatedSlugShot, MCH.CleanShot, MCH.HeatedCleanShot)]
        MachinistHypercomboFeature = 3108,

        [OrderedEnum]
        [ParentCombo(MachinistHypercomboFeature)]
        [ConflictingCombos(MachinistMainCombo)]
        [CustomComboInfo("Hypercharge Combo Option", "Only replace your current combo action with Heat Blast.", MCH.JobID, MCH.SplitShot, MCH.HeatedSplitShot, MCH.SlugShot, MCH.HeatedSlugShot, MCH.CleanShot, MCH.HeatedCleanShot)]
        MachinistHypercomboOption = 3110,

        [OrderedEnum]
        [CustomComboInfo("Overdrive Feature", "Replace Rook Autoturret and Automaton Queen with Overdrive while active.", MCH.JobID, MCH.RookAutoturret, MCH.AutomatonQueen)]
        MachinistOverdriveFeature = 3104,

        [OrderedEnum]
        [CustomComboInfo("Hypercharge to Wildfire", "Hypercharge becomes Wildfire if Wildfire is off-cooldown and you have a target.", MCH.JobID, MCH.Hypercharge)]
        MachinistHyperfireFeature = 3107,

        [OrderedEnum]
        [CustomComboInfo("Reassemble to Chainsaw", "Reassemble becomes Chainsaw while Reassemble is active.", MCH.JobID, MCH.Reassemble)]
        MachinistReassembleFeature = 3111,

        [OrderedEnum]
        [ParentCombo(MachinistReassembleFeature)]
        [CustomComboInfo("Reassemble to Chainsaw: Drill Sync", "Chainsaw on Reassemble becomes Drill while synced, for muscle memory purposes.", MCH.JobID, MCH.Reassemble)]
        MachinistReassembleOption = 3112,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Gauss Round / Ricochet Feature", "Replace Gauss Round and Ricochet with one or the other depending on which has more charges.", MCH.JobID, MCH.GaussRound, MCH.Ricochet)]
        MachinistGaussRoundRicochetFeature = 3105,

        [OrderedEnum]
        [SecretCustomCombo]
        [ParentCombo(MachinistGaussRoundRicochetFeature)]
        [CustomComboInfo("Gauss Round / Ricochet Overheat Option", "Gauss Round/Ricochet will only replace each other while Overheated.", MCH.JobID, MCH.GaussRound, MCH.Ricochet)]
        MachinistGaussRoundRicochetFeatureOption = 3109,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Drill / Air Anchor (Hot Shot) Feature", "Replace Drill and Air Anchor (Hot Shot) with one or the other (or Chainsaw) depending on which is on cooldown.", MCH.JobID, MCH.Drill, MCH.HotShot, MCH.AirAnchor)]
        MachinistHotShotDrillChainsawFeature = 3106,

        #endregion
        // ====================================================================================
        #region MONK

        [OrderedEnum]
        [ConflictingCombos(MonkSTCombo)]
        [CustomComboInfo("Monk Bootshine Combo", "Replace Bootshine with Monk's Bootshine/True Strike/Snap Punch combo.", MNK.JobID, MNK.Bootshine)]
        MonkBootshineCombo = 2019,

        [OrderedEnum]
        [ConflictingCombos(MonkSTCombo)]
        [CustomComboInfo("Monk Dragon Kick Combo", "Replace Dragon Kick with Monk's Dragon Kick/Twin Snakes/Demolish combo.\nYou will still need Twin Snakes and Demolish on your bar for Perfect Balance and Form Shift.", MNK.JobID, MNK.DragonKick, MNK.TwinSnakes)]
        MonkDragonKickCombo = 2020,

        [OrderedEnum]
        [ParentCombo(MonkDragonKickCombo)]
        [CustomComboInfo("Twin Snakes Option", "Instead of Dragon Kick being the combo's base action, Twin Snakes will be used, and will stay Twin Snakes during Perfect Balance and Formless Fist.\nThis means you only additionally need Demolish on your hotbar, if you are using the Monk Dragon Kick Bootshine Feature", MNK.JobID)]
        MonkDragonKickComboSnakeOption = 2023,

        [OrderedEnum]
        [ConflictingCombos(MonkSTCombo, MonkPerfectBalanceFeatureLockout)]
        [CustomComboInfo("Perfect Balance to Demolish", "Replace Perfect Balance with Demolish while in Perfect Balance.", MNK.JobID, MNK.PerfectBalance)]
        MonkPerfectBalanceDemolishFeature = 2026,

        [OrderedEnum]
        [CustomComboInfo("Monk Meditation Reminder", "Your GCDs become Meditate out of combat if you don't have the Fifth Chakra open.", MNK.JobID, MNK.TwinSnakes, MNK.TrueStrike, MNK.FormShift, MNK.SnapPunch, MNK.Demolish, MNK.Bootshine, MNK.DragonKick, MNK.MasterfulBlitz, MNK.Rockbreaker, MNK.ArmOfTheDestroyer, MNK.ShadowOfTheDestroyer, MNK.FourPointFury, MNK.SixSidedStar)]
        MonkMeditationReminder = 2013,

        [OrderedEnum]
        [CustomComboInfo("Monk AoE Combo", "Replaces Masterful Blitz (for bug reasons) with the AoE combo chain, or whatever your most damaging move is when Perfect Balance is active.\nFour-Point Fury becomes AoE combo chain in order of forms during Perfect Balance.\nMasterful Blitz replaces the AoE combo when you have 3 Beast Chakra.", MNK.JobID, MNK.MasterfulBlitz, MNK.FourPointFury, MNK.FormShift)]
        MonkAoECombo = 2001,

        [OrderedEnum]
        [ParentCombo(MonkAoECombo)]
        [ConflictingCombos(MonkSTComboFormOption)]
        [CustomComboInfo("Monk AoE Combo Form Shift Option", "Enabling this option has Form Shift turn into Four-Point Fury in Formless Fist, and 1-2-3 AoE combo in Perfect Balance.\nIf using Monk Complex Combos, you ideally should have Bootshine Feature enabled.", MNK.JobID, MNK.FormShift)]
        MonkAoEComboFormOption = 2009,

        [OrderedEnum]
        [ParentCombo(MonkAoECombo)]
        [CustomComboInfo("AoE Meditation Feature", "Replaces AoE combo with Howling Fist/Enlightment if you have the Fifth Chakra open, have a target, and you have just used an action.", MNK.JobID, MNK.MasterfulBlitz)]
        MonkAoEMeditationFeature = 2014,

        // [OrderedEnum]
        // [ParentCombo(MonkAoECombo)]
        // [CustomComboInfo("Monk AoE Balance Feature", "Replaces Monk's AoE Combo with Masterful Blitz if you have 3 Beast Chakra.", MNK.JobID, MNK.Rockbreaker)]
        // MonkAoEBalanceFeature = 2006,

        [OrderedEnum]
        [CustomComboInfo("Monk Dragon Kick Bootshine Feature", "Replaces Dragon Kick with Bootshine if Leaden Fist is up, and vice-versa when Leaden Fist is not up in Bootshine-related combos.", MNK.JobID, MNK.DragonKick)]
        MonkDragonKickBootshineFeature = 2002,

        [OrderedEnum]
        [CustomComboInfo("Monk Dragon Kick Balance Feature", "Replaces Dragon Kick with Masterful Blitz if you have 3 Beast Chakra.", MNK.JobID, MNK.DragonKick)]
        MonkDragonKickBalanceFeature = 2005,

        [OrderedEnum]
        [CustomComboInfo("Monk Dragon Clap Feature", "Replaces Dragon Kick with Thunderclap if you are out of melee range, or have a player targeted.", MNK.JobID, MNK.DragonKick)]
        MonkDragonClapFeature = 2022,

        [OrderedEnum]
        [CustomComboInfo("Forbidden Chakra to Enlightment Feature", "Replaces Forbidden Chakra with Enlightenment if your last-used GCD action was Arm/Shadow of the Destroyer, Four-Point Fury, or Rockbreaker.", MNK.JobID, MNK.Meditation)]
        MonkChakraToEnlightmentFeature = 2025,

        [OrderedEnum]
        [CustomComboInfo("Howling Fist / Meditation Feature", "Replaces Howling Fist/Enlightenment with Meditation when the Fifth Chakra is not open.", MNK.JobID, MNK.HowlingFist, MNK.Enlightenment)]
        MonkHowlingFistMeditationFeature = 2003,

        [OrderedEnum]
        [CustomComboInfo("Perfect Balance Feature", "Perfect Balance becomes Masterful Blitz while you have 3 Beast Chakra.", MNK.JobID, MNK.PerfectBalance)]
        MonkPerfectBalanceFeature = 2004,

        [OrderedEnum]
        [ParentCombo(MonkPerfectBalanceFeature)]
        [CustomComboInfo("Perfect Balance Feature: Lockout", "Perfect Balance becomes a useless action while Perfect Balance is active.\nDoes not work with Monk Complex Combos.", MNK.JobID, MNK.PerfectBalance)]
        MonkPerfectBalanceFeatureLockout = 2021,

        [OrderedEnum]
        [CustomComboInfo("Riddle of Fire to Brotherhood", "Riddle of Fire becomes Brotherhood if the former is on cooldown and the latter is not.", MNK.JobID, MNK.RiddleOfFire)]
        MonkRiddleToBrotherFeature = 2011,

        [OrderedEnum]
        [CustomComboInfo("Riddle of Fire to Riddle of Wind", "Riddle of Fire becomes Riddle of Wind if the former is on cooldown and the latter is not.\nIf Riddle of Fire to Brotherhood is enabled, Brotherhood takes priority.", MNK.JobID, MNK.RiddleOfFire)]
        MonkRiddleToRiddleFeature = 2012,

        [OrderedEnum]
        [CustomComboInfo("Dragon Kick to Anatman", "Dragon Kick becomes Anatman while you have no target.", MNK.JobID, MNK.DragonKick)]
        MonkDragonKickAnatmanFeature = 2024,

        [OrderedEnum]
        [ConflictingCombos(MonkBootshineCombo, MonkDragonKickCombo)]
        [CustomComboInfo("Monk Complex Combos", "This is a very complex legacy combo for Monk that is still around for people who prefer to use it, but is significantly more complicated (as it is designed to think for you as little as possible).\n" +
            "It is heavily recommended that you use the regular combos instead unless you are already used to this combo.\n" +
            "Normal Behavior: True Strike and Twin Snakes become Bootshine and Dragon Kick in Opo-Opo/no form, True Strike and Twin Snakes in Raptor, and Snap Punch and Demolish in Coeurl.\n" +
            "Perfect Balance Behavior: Perfect Balance becomes Dragon Kick. Form Shift becomes Bootshine (if Bootshine Feature is not enabled). The other combos become Demolish and Twin Snakes, and change to Raptor/Coeurl moves based on which you pick.\n" +
            "Formless Fist Behavior: True Strike becomes Dragon Kick. Twin Snakes stays normal. Perfect Balance becomes Demolish. Form Shift becomes Bootshine (Snap Punch with Bootshine feature).", MNK.JobID, MNK.TwinSnakes, MNK.TrueStrike, MNK.PerfectBalance, MNK.FormShift)]
        MonkSTCombo = 2007,

        [OrderedEnum]
        [ParentCombo(MonkSTCombo)]
        [CustomComboInfo("Twin Snake Option", "Enabling this option makes it so that the Twin Snakes button doesn't get used for combos. This means you need Demolish on your bar.", MNK.JobID, MNK.FormShift)]
        MonkSTComboTwinSnakeOption = 2016,

        [OrderedEnum]
        [ParentCombo(MonkSTCombo)]
        [CustomComboInfo("Dragon Kick Option", "Enabling this option makes it so that the True Strike button in Perfect Balance is replaced with Dragon Kick.", MNK.JobID, MNK.FormShift)]
        MonkSTComboDragonKickOption = 2017,

        [OrderedEnum]
        [ParentCombo(MonkSTCombo)]
        [CustomComboInfo("Double Solar Option", "Enabling this option makes it so that, if you use Opo-Opo first in Perfect Balance, Coeurl Form is chosen instead of Raptor Form.\nThis allows you to perform the Double Solar opener.", MNK.JobID, MNK.FormShift)]
        MonkSTComboDoubleSolarOption = 2018,

        [OrderedEnum]
        [ParentCombo(MonkSTCombo)]
        [CustomComboInfo("Opo-Opo Option", "Enabling this option makes it so that Dragon Kick/Bootshine replaces your combos in Perfect Balance if you have both Raptor and Coeurl Chakra.", MNK.JobID, MNK.TwinSnakes, MNK.TrueStrike)]
        MonkSTComboOpoOpoOption = 2010,

        [OrderedEnum]
        [ParentCombo(MonkSTCombo)]
        [CustomComboInfo("Perfect Balance Option", "Enabling this option makes it so that Perfect Balance under Formless Fist stays Perfect Balance for a short while after you use an action or if you have no target.", MNK.JobID, MNK.PerfectBalance)]
        MonkSTComboDemolishOption = 2015,

        [OrderedEnum]
        [ParentCombo(MonkSTCombo)]
        [ConflictingCombos(MonkAoEComboFormOption)]
        [CustomComboInfo("Form Shift Option", "Enabling this option makes it so that Form Shift does not turn into Snap Punch.", MNK.JobID, MNK.FormShift)]
        MonkSTComboFormOption = 2008,

        #endregion
        // ====================================================================================
        #region NINJA

        // last used: 3018

        [OrderedEnum]
        [CustomComboInfo("Aeolian Edge Combo", "Replace Aeolian Edge with its combo chain.", NIN.JobID, NIN.AeolianEdge)]
        NinjaAeolianEdgeCombo = 3002,

        [OrderedEnum]
        [ParentCombo(NinjaAeolianEdgeCombo)]
        [CustomComboInfo("Aeolian Edge to Throwing Dagger", "Replace Aeolian Edge combo with Throwing Dagger if you are out of range.", NIN.JobID, NIN.ThrowingDagger)]
        NinjaThrowingEdgeFeature = 3021,

        [OrderedEnum]
        [CustomComboInfo("Armor Crush Combo", "Replace Armor Crush with its combo chain.", NIN.JobID, NIN.ArmorCrush)]
        NinjaArmorCrushCombo = 3001,

        [OrderedEnum]
        [CustomComboInfo("Hakke Mujinsatsu Combo", "Replace Hakke Mujinsatsu with its combo chain.", NIN.JobID, NIN.HakkeMujinsatsu, NIN.DeathBlossom)]
        NinjaHakkeMujinsatsuCombo = 3003,

        [OrderedEnum]
        [SecretCustomCombo]
        [ParentCombo(NinjaHakkeMujinsatsuCombo)]
        [CustomComboInfo("Evil Hakke Mujinsatsu Combo", "Replace Death Blossom with its combo chain instead.", NIN.JobID, NIN.HakkeMujinsatsu, NIN.DeathBlossom)]
        NinjaEvilHakkeMujinsatsuCombo = 3014,

        [OrderedEnum]
        [CustomComboInfo("Huraijin Armor Crush Feature", "Replaces Huraijin with Armor Crush after using Gust Slash.", NIN.JobID, NIN.Huraijin)]
        NinjaHuraijinCrushFeature = 3018,

        [OrderedEnum]
        [CustomComboInfo("Kassatsu to Trick", "Replaces Kassatsu with Trick Attack while Suiton is up and Kassatsu is on cooldown, or Hidden is up.", NIN.JobID, NIN.Kassatsu)]
        NinjaKassatsuTrickFeature = 3004,

        [OrderedEnum]
        [CustomComboInfo("Kassatsu to Dream Within a Dream", "Replaces Kassatsu with Dream Within a Dream if the former is on cooldown and the latter is not.\nIf you have Kassatsu to Trick on, Trick Attack takes priority over DwaD.", NIN.JobID, NIN.Kassatsu)]
        NinjaKassatsuDWaDFeature = 3015,

        [OrderedEnum]
        [CustomComboInfo("Dream Within a Dream to Trick", "Replaces Dream Within a Dream with Trick Attack while Suiton or Hidden is active.", NIN.JobID, NIN.DreamWithinADream)]
        NinjaDWaDTrickFeature = 3019,

        [OrderedEnum]
        [CustomComboInfo("Ten Chi Jin to Meisui", "Replaces Ten Chi Jin (the move) with Meisui while Suiton is up.", NIN.JobID, NIN.TenChiJin)]
        NinjaTCJMeisuiFeature = 3005,

        [OrderedEnum]
        [CustomComboInfo("Kassatsu Chi/Jin Feature", "Replaces Chi with Jin while Kassatsu is up if you have Enhanced Kassatsu.", NIN.JobID, NIN.Chi)]
        NinjaKassatsuChiJinFeature = 3006,

        [OrderedEnum]
        [CustomComboInfo("Hide to Mug", "Replaces Hide with Mug while in combat.", NIN.JobID, NIN.Hide)]
        NinjaHideMugFeature = 3007,

        [OrderedEnum]
        [CustomComboInfo("Bhavacakra to Hellfrog Medium", "Replaces Bhavacakra with Hellfrog Medium while you are in the midst of your AoE combo.", NIN.JobID, NIN.Bhavacakra)]
        NinjaBhavacakraToFroggieFeature = 3022,

        [OrderedEnum]
        [ConflictingCombos(NinjaGCDNinjutsuFeature)]
        [CustomComboInfo("Aeolian to Ninjutsu Feature", "Replaces Aeolian Edge (combo) with your current Ninjutsu action if any Mudra are used.", NIN.JobID, NIN.AeolianEdge)]
        NinjaNinjutsuFeature = 3008,

        [OrderedEnum]
        [ConflictingCombos(NinjaNinjutsuFeature)]
        [CustomComboInfo("GCDs to Ninjutsu Feature", "Every non-Mudra GCD becomes your current Ninjutsu action while Mudras are being used.", NIN.JobID, NIN.AeolianEdge, NIN.ArmorCrush, NIN.HakkeMujinsatsu, NIN.Huraijin, NIN.DeathBlossom, NIN.ThrowingDagger, NIN.GustSlash, NIN.SpinningEdge, NIN.ForkedRaiju, NIN.FleetingRaiju)]
        NinjaGCDNinjutsuFeature = 3009,

        [OrderedEnum]
        [CustomComboInfo("Ninjutsu Double-Tap Feature", "Double-tapping your last-used mudra executes your current Ninjutsu action, or replaces all three if it is currently Doton/Huton/Suiton/Goka/Hyosho.", NIN.JobID, NIN.Ten, NIN.Chi, NIN.Jin)]
        NinjaTapNinjutsuFeature = 3020,

        [OrderedEnum]
        [CustomComboInfo("Armor Crush / Forked Raiju Feature", "Replaces the Armor Crush combo with Forked Raiju when available.", NIN.JobID, NIN.ArmorCrush)]
        NinjaArmorCrushRaijuFeature = 3012,

        [OrderedEnum]
        [CustomComboInfo("Aeolian Edge / Fleeting Raiju Feature", "Replaces the Aeolian Edge combo with Fleeting Raiju when available.", NIN.JobID, NIN.AeolianEdge)]
        NinjaAeolianEdgeRaijuFeature = 3013,

        [OrderedEnum]
        [CustomComboInfo("Huraijin / Forked Raiju Feature", "Replaces Huraijin with Forked Raiju when available.", NIN.JobID, NIN.Huraijin)]
        NinjaHuraijinRaijuFeature = 3011,

        [OrderedEnum]
        [ParentCombo(NinjaHuraijinRaijuFeature)]
        [CustomComboInfo("Huraijin / Fleeting Raiju Option", "Replaces Huraijin with Fleeting Raiju instead.", NIN.JobID, NIN.Huraijin)]
        NinjaHuraijinFleetingRaijuFeature = 3017,

        [OrderedEnum]
        [CustomComboInfo("Forked/Fleeting Raiju Switch Feature", "Forked/Fleeting Raiju change depending on distance from target (works with the Raiju features).", NIN.JobID, NIN.ForkedRaiju, NIN.FleetingRaiju)]
        NinjaSmartRaijuFeature = 3016,

        #endregion
        // ====================================================================================
        #region PALADIN

        [OrderedEnum]
        [CustomComboInfo("Royal Authority Combo", "Replace Royal Authority/Rage of Halone with its combo chain.", PLD.JobID, PLD.RoyalAuthority, PLD.RageOfHalone)]
        PaladinRoyalAuthorityCombo = 1902,

        [OrderedEnum]
        [ParentCombo(PaladinRoyalAuthorityCombo)]
        [CustomComboInfo("Royal Authority to Holy Spirit", "Replace your Royal Authority combo with Holy Spirit if you have Requiescat up, and Fight or Flight is not up.", PLD.JobID)]
        PaladinRoyalSpiritFeature = 1913,

        [OrderedEnum]
        [ParentCombo(PaladinRoyalAuthorityCombo)]
        [CustomComboInfo("Royal Authority to Shield Lob", "Replace Royal Authority/Rage of Halone's combo with Shield Lob when out of melee range.", PLD.JobID, PLD.RoyalAuthority, PLD.RageOfHalone)]
        PaladinRoyalLobFeature = 1912,

        [OrderedEnum]
        [ConflictingCombos(PaladinGoringBladeAtonementFeature)]
        [CustomComboInfo("Royal Authority Atonement Feature", "Replace Royal Authority with Atonement when under the effect of Sword Oath.", PLD.JobID, PLD.RageOfHalone, PLD.RoyalAuthority)]
        PaladinRoyalAuthorityAtonementFeature = 1903,

        [OrderedEnum]
        [CustomComboInfo("Goring Blade Combo", "Replace Goring Blade with its combo chain.", PLD.JobID, PLD.GoringBlade)]
        PaladinGoringBladeCombo = 1901,

        [OrderedEnum]
        [ConflictingCombos(PaladinRoyalAuthorityAtonementFeature)]
        [CustomComboInfo("Goring Blade Atonement Feature", "Replace Goring Blade with Atonement when under the effect of Sword Oath.\nThis conflicts with Atonement Feature because you always want to start a way to start your combo (dropping Sword Oath is very commonly necessary).", PLD.JobID, PLD.GoringBlade)]
        PaladinGoringBladeAtonementFeature = 1909,

        [OrderedEnum]
        [CustomComboInfo("Prominence Combo", "Replace Prominence with its combo chain.", PLD.JobID, PLD.Prominence, PLD.TotalEclipse)]
        PaladinProminenceCombo = 1904,

        [OrderedEnum]
        [SecretCustomCombo]
        [ParentCombo(PaladinProminenceCombo)]
        [CustomComboInfo("Evil Prominence Combo", "Replace Total Eclipse with its combo chain, instead.", PLD.JobID, PLD.Prominence, PLD.TotalEclipse)]
        PaladinEvilProminenceCombo = 1907,

        [OrderedEnum]
        [CustomComboInfo("Requiescat Confiteor", "Replace Requiescat with Confiter while under the effect of Requiescat. Includes Confiteor combo.", PLD.JobID, PLD.Requiescat)]
        PaladinRequiescatCombo = 1905,

        [OrderedEnum]
        [CustomComboInfo("AoE to Holy Circle", "Replace your AoE combo actions with Holy Circle while you have Requiescat.", PLD.JobID, PLD.TotalEclipse, PLD.Prominence)]
        PaladinHolyCircleFeature = 1910,

        [OrderedEnum]
        [CustomComboInfo("Holy Spirit to Holy Circle", "Replace Holy Spirit with Holy Circle if your last combo action was Total Eclipse or Prominence.", PLD.JobID, PLD.HolySpirit)]
        PaladinHolySpiritToHolyCircleFeature = 1914,

        [OrderedEnum]
        [CustomComboInfo("Shield Blash to Low Blow", "Replace Shield Bash to Low Blow when it is on cooldown.\nAlso works with Tank Interrupt feature.", PLD.JobID, PLD.ShieldBash)]
        PaladinLowBashFeature = 1911,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Confiteor Feature", "Replace Holy Spirit/Circle with Confiteor when Requiescat has one stack left. Includes Confiteor combo.", PLD.JobID, PLD.HolySpirit, PLD.HolyCircle)]
        PaladinConfiteorFeature = 1906,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Scornful Spirits Feature", "Replace Spirits Within and Circle of Scorn with whichever is available soonest.", PLD.JobID, PLD.SpiritsWithin, PLD.Expiacion, PLD.CircleOfScorn)]
        PaladinScornfulSpiritsFeature = 1908,

        #endregion
        // ====================================================================================
        #region REAPER

        [OrderedEnum]
        [CustomComboInfo("Slice Combo", "Replace Slice with its combo chain.", RPR.JobID, RPR.Slice, RPR.InfernalSlice)]
        ReaperSliceCombo = 3901,

        [OrderedEnum]
        [ParentCombo(ReaperSliceCombo)]
        [CustomComboInfo("Infernal Slice Combo", "Replace Infernal Slice with its combo chain and removes Slice's combo.", RPR.JobID, RPR.InfernalSlice)]
        ReaperInfernalSliceCombo = 3910,

        [OrderedEnum]
        [ParentCombo(ReaperSliceCombo)]
        [CustomComboInfo("Slice to Harpe", "Replace Slice combo with Harpe if you are out of range.", RPR.JobID, RPR.Slice)]
        ReaperHarpeSliceFeature = 3921,

        [OrderedEnum]
        [CustomComboInfo("Scythe Combo", "Replace Spinning Scythe with its combo chain.", RPR.JobID, RPR.SpinningScythe, RPR.NightmareScythe)]
        ReaperScytheCombo = 3902,

        [OrderedEnum]
        [ParentCombo(ReaperScytheCombo)]
        [CustomComboInfo("Nightmare Scythe Combo", "Replace Nightmare Scythe with its combo chain and removes Spinning Scythe's combo.", RPR.JobID, RPR.NightmareScythe)]
        ReaperNightmareScytheCombo = 3911,

        [OrderedEnum]
        [CustomComboInfo("Enshroud Communio Feature", "Replace Enshroud with Communio when Enshrouded.", RPR.JobID, RPR.Enshroud)]
        ReaperEnshroudCommunioFeature = 3903,

        [OrderedEnum]
        [CustomComboInfo("Stalking and Swathing Feature", "While you have Soul Reaver, Blood Stalk becomes whichever spender is enhanced, and Grim Swathe becomes Guillotine.", RPR.JobID, RPR.BloodStalk, RPR.GrimSwathe)]
        ReaperStalkingSwathingFeature = 3917,

        [OrderedEnum]
        [CustomComboInfo("Gibbets and Gallows Feature", "Slice and Shadow of Death are replaced with Gibbet and Gallows while Soul Reaver or Shroud is active.", RPR.JobID, RPR.Slice, RPR.ShadowOfDeath, RPR.SoulSlice)]
        ReaperGibbetGallowsFeature = 3904,

        [OrderedEnum]
        [ParentCombo(ReaperGibbetGallowsFeature)]
        [CustomComboInfo("Gibbets and Gallows Feature Swap", "Swaps Gibbet/Gallows for the Gibbet and Gallows Feature.", RPR.JobID, RPR.Slice, RPR.ShadowOfDeath, RPR.SoulSlice)]
        ReaperGibbetGallowsSwap = 3918,

        [OrderedEnum]
        [ParentCombo(ReaperGibbetGallowsFeature)]
        [CustomComboInfo("Gibbets and Gallows Soul Slice Option", "Have Soul Slice be replaced in the Gibbets and Gallows Feature instead of Shadow of Death.", RPR.JobID, RPR.Slice, RPR.ShadowOfDeath, RPR.SoulSlice)]
        ReaperGibbetGallowsSoulSliceOption = 3919,

        [OrderedEnum]
        [ParentCombo(ReaperGibbetGallowsSoulSliceOption)]
        [CustomComboInfo("Gibbet and Gallows Shroud Decombo", "Uncombos Void/Cross Reaping and spreads them across Soul Slice/Slice Combo.", RPR.JobID, RPR.Slice)]
        ReaperGibbetGallowsShroudOption = 3920,

        [OrderedEnum]
        [ParentCombo(ReaperGibbetGallowsFeature)]
        [CustomComboInfo("Gibbet and Gallows Enhanced Option", "Slice now turns into Gallows when Gallows is Enhanced, and removes it from Shadow of Death/Soul Slice while you have Enhanced Gibbet/Gallows.", RPR.JobID, RPR.Slice)]
        ReaperGibbetGallowsOption = 3905,

        [OrderedEnum]
        [CustomComboInfo("Guillotine Feature", "Spinning Scythe gets replaced with Guillotine while Soul Reaver or Shroud is active.", RPR.JobID, RPR.SpinningScythe)]
        ReaperGuillotineFeature = 3909,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Combo Communio Feature", "When one stack is left of Shroud, Communio replaces Gibbet/Gallows/Guillotine.", RPR.JobID, RPR.Slice, RPR.InfernalSlice, RPR.Gibbet, RPR.Gallows, RPR.Guillotine, RPR.SpinningScythe, RPR.NightmareScythe)]
        ReaperComboCommunioFeature = 3906,

        [OrderedEnum]
        [CustomComboInfo("Lemure Feature", "When you have two or more stacks of Void Shroud, Lemure Slice/Scythe replaces Gibbet/Gallows and Guillotine respectively.", RPR.JobID, RPR.Slice, RPR.InfernalSlice, RPR.Gibbet, RPR.Gallows, RPR.Guillotine, RPR.SpinningScythe, RPR.NightmareScythe)]
        ReaperLemureFeature = 3912,

        [OrderedEnum]
        [CustomComboInfo("Arcane Circle Harvest Feature", "Replace Arcane Circle with Plentiful Harvest when you have stacks of Immortal Sacrifice.", RPR.JobID, RPR.ArcaneCircle)]
        ReaperHarvestFeature = 3907,

        [OrderedEnum]
        [CustomComboInfo("Regress Feature", "Both Hell's Ingress and Hell's Egress turn into Regress when Threshold is active, instead of just the opposite of the one you used.\nYou can set an optional delay for this below:", RPR.JobID, RPR.HellsIngress, RPR.HellsEgress)]
        ReaperRegressFeature = 3908,

        [OrderedEnum]
        [CustomComboInfo("Blood Stalk to Gluttony Feature", "When Gluttony is off-cooldown, Blood Stalk will turn into Gluttony.", RPR.JobID, RPR.BloodStalk)]
        ReaperBloodStalkFeature = 3913,

        [OrderedEnum]
        [CustomComboInfo("Grim Swathe to Gluttony Feature", "When Gluttony is off-cooldown, Grim Swathe will turn into Gluttony.", RPR.JobID, RPR.GrimSwathe)]
        ReaperGrimSwatheFeature = 3914,

        [OrderedEnum]
        [CustomComboInfo("Blood Stalk to Grim Swathe Feature", "Blood Stalk turns into Grim Swathe if you are in the midst of your AoE combo.", RPR.JobID, RPR.BloodStalk)]
        ReaperBloodStalkToGrimSwatheFeature = 3922,

        [OrderedEnum]
        [CustomComboInfo("Soul Slice to Soul Scythe Feature", "Soul Slice turns into Soul Scythe if you are in the midst of your AoE combo.", RPR.JobID, RPR.SoulSlice)]
        ReaperSoulSliceToSoulScytheFeature = 3923,

        [OrderedEnum]
        [CustomComboInfo("Soulsow Reminder Feature", "Slice Combo, Soul Slice and Shadow of Death become Soulsow out of combat if you don't have it active.", RPR.JobID, RPR.Slice, RPR.InfernalSlice, RPR.ShadowOfDeath, RPR.WaxingSlice, RPR.SoulSlice)]
        ReaperSoulsowReminderFeature = 3915,

        [OrderedEnum]
        [CustomComboInfo("Soulsow Feature", "Spinning Scythe becomes Harvest Moon when Soulsow is active and you have a target. Shadow of Death becomes Soulsow if you have no target and Soulsow isn't active.", RPR.JobID, RPR.SpinningScythe, RPR.NightmareScythe, RPR.ShadowOfDeath)]
        ReaperSoulsowFeature = 3916,

        #endregion
        // ====================================================================================
        #region RED MAGE

        [OrderedEnum]
        [CustomComboInfo("Redoublement Combo", "Replaces Redoublement with its combo chain, following enchantment rules.", RDM.JobID, RDM.Redoublement, RDM.Moulinet)]
        RedMageMeleeCombo = 3502,

        [OrderedEnum]
        [ParentCombo(RedMageMeleeCombo)]
        [CustomComboInfo("Redoublement Combo Lockout Feature", "Prevents you from using Redoublement combo if you have less than 50/50 gauge and have Verflare unlocked by replacing it with Verflare (which is unusable).", RDM.JobID, RDM.Redoublement)]
        RedMageComboReminderFeature = 3515,

        [OrderedEnum]
        [ParentCombo(RedMageComboReminderFeature)]
        [CustomComboInfo("Redoublement Combo Lockout Option", "Replaces Redoublement with Flare instead of Verflare, to prevent queueing issues.", RDM.JobID, RDM.Redoublement)]
        RedMageComboReminderOption = 3517,

        [OrderedEnum]
        [ParentCombo(RedMageMeleeCombo)]
        [CustomComboInfo("Redoublement Combo to Moulinet", "Replaces Redoublement Combo with Moulinet if you have been using Veraero/Verthunder 2.", RDM.JobID, RDM.Redoublement)]
        RedMageComboToMoulinetFeature = 3521,

        [OrderedEnum]
        [ParentCombo(RedMageMeleeCombo)]
        [CustomComboInfo("Redoublement Combo Plus", "Replaces Redoublement/Moulinet with the combo spells after you have gained 3 mana stacks.\nVerflare will always be picked, meaning you must still manually press Verholy if appropriate.", RDM.JobID, RDM.Redoublement, RDM.Moulinet)]
        RedMageMeleeComboPlus = 3508,

        [OrderedEnum]
        [ParentCombo(RedMageMeleeComboPlus)]
        [CustomComboInfo("Redoublement Combo Plus Verholy Swap", "Swaps Verflare with Verholy in your melee combo (unless you aren't at a level you can use it).", RDM.JobID, RDM.Redoublement, RDM.Moulinet)]
        RedMageMeleeComboPlusVerholy = 3509,

        [OrderedEnum]
        [ParentCombo(RedMageMeleeCombo)]
        [CustomComboInfo("Redoublement Combo to Reprise", "Replaces Redoublement combo with Enchanted Reprise if you are out of melee range.", RDM.JobID, RDM.Redoublement)]
        RedMageMeleeComboReprise = 3518,

        [OrderedEnum]
        [ParentCombo(RedMageMeleeComboReprise)]
        [CustomComboInfo("Redoublement Combo to Reprise Under-50 Option", "Enchanted Reprise will also replace Redoublement combo if you are under 50 black or white Mana.", RDM.JobID, RDM.Redoublement)]
        RedMageMeleeComboRepriseOption = 3519,

        [OrderedEnum]
        [SecretCustomCombo]
        [ParentCombo(RedMageMeleeCombo)]
        [CustomComboInfo("Redoublement Combo Plus Plus", "Replaces Redoublement/Moulinet with the combo spells after you have gained 3 mana stacks.\nVerflare or Verholy will be picked, whichever is more appropriate.", RDM.JobID, RDM.Redoublement, RDM.Moulinet)]
        RedMageMeleeComboPlusPlus = 3503,

        [OrderedEnum]
        [CustomComboInfo("Verproc into Jolt", "Replaces Verstone/Verfire with Jolt/Scorch when no proc is available.", RDM.JobID, RDM.Verstone, RDM.Verfire)]
        RedMageVerprocCombo = 3504,

        [OrderedEnum]
        [ParentCombo(RedMageVerprocCombo)]
        [CustomComboInfo("Verproc into Jolt Plus", "Additionally replaces Verstone/Verfire with Veraero/Verthunder if Dualcast, Swiftcast, or Lost Chainspell are up.", RDM.JobID, RDM.Verstone, RDM.Verfire)]
        RedMageVerprocComboPlus = 3505,

        [OrderedEnum]
        [ParentCombo(RedMageVerprocComboPlus)]
        [CustomComboInfo("Verproc into Jolt Plus Opener Feature (Stone)", "Turns Verstone into Veraero when out of combat.", RDM.JobID, RDM.Verstone)]
        RedMageVerprocOpenerFeatureStone = 3506,

        [OrderedEnum]
        [ParentCombo(RedMageVerprocComboPlus)]
        [CustomComboInfo("Verproc into Jolt Plus Opener Feature (Fire)", "Turns Verfire into Verthunder when out of combat.", RDM.JobID, RDM.Verfire)]
        RedMageVerprocOpenerFeatureFire = 3507,

        [OrderedEnum]
        [ParentCombo(RedMageVerprocCombo)]
        [CustomComboInfo("Verproc into Reprise Movement Feature", "Verstone/Verfire additionally turn into Enchanted Reprise (if available) if you are moving and don't have any instant casts available.", RDM.JobID, RDM.Verstone, RDM.Verfire)]
        RedMageVerprocComboReprise = 3520,

        [OrderedEnum]
        [ConflictingCombos(RedMageVerprocComboPlus)]
        [CustomComboInfo("Veraero/Verthunder into Scorch", "Replaces Veraero/Verthunder 1/3 with Scorch when it's available.\nThis feature is already in Verproc into Jolt Plus, this is for people who don't want to use that.", RDM.JobID, RDM.Veraero, RDM.Verthunder, RDM.Veraero3, RDM.Verthunder3)]
        RedMageVeraeroVerThunderScorchFeature = 3510,

        [OrderedEnum]
        [CustomComboInfo("Red Mage AoE Combo", "Replaces Veraero/Verthunder 2 with Impact when Dualcast or Swiftcast are active.", RDM.JobID, RDM.Veraero2, RDM.Verthunder2)]
        RedMageAoECombo = 3501,

        [OrderedEnum]
        [CustomComboInfo("Moulinet Lockout Feature", "Prevents you from using Moulinet below 60/60 gauge by replacing it with Physick if you have Verflare unlocked.", RDM.JobID, RDM.Moulinet)]
        RedMageMoulinetReminderFeature = 3514,

        [OrderedEnum]
        [CustomComboInfo("Embolden to Manaification", "Replaces Embolden with Manafication if the former is on cooldown and the latter is not.", RDM.JobID, RDM.Embolden)]
        RedMageEmboldenFeature = 3511,

        [OrderedEnum]
        [CustomComboInfo("Acceleration to Swiftcast", "Replaces Acceleration with Swiftcast if the former is on cooldown and the latter is not.", RDM.JobID, RDM.Acceleration)]
        RedMageAccelerationFeature = 3512,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Fleche to Contre-Sixte", "Replaces Fleche with Contre-Sixte if the former is on cooldown and the latter is not.", RDM.JobID, RDM.Fleche)]
        RedMageContreSixteFeature = 3513,

        [OrderedEnum]
        [CustomComboInfo("Red Mage Lucid Dreaming Reminder", "All your non-role action cooldowns (that don't have charges) become Lucid Dreaming if they aren't up and Lucid Dreaming is, and you have less-than-or-equal-to 9000 MP.", RDM.JobID, RDM.Embolden, RDM.Manafication, RDM.Fleche, RDM.ContreSixte)]
        RedMageLucidReminderFeature = 3516,

        #endregion
        // ====================================================================================
        #region SAGE

        [OrderedEnum]
        [CustomComboInfo("Soteria into Kardia", "Soteria turns into Kardia when not active or Soteria is on-cooldown.", SGE.JobID, SGE.Soteria)]
        SageKardiaFeature = 4001,

        [OrderedEnum]
        [CustomComboInfo("Phlegma into Dyskrasia", "Phlegma turns into Dyskrasia when you are out of charges or are currently not targeting anything.", SGE.JobID, SGE.Phlegma, SGE.Phlegmara, SGE.Phlegmaga)]
        SagePhlegmaBalls = 4002,

        [OrderedEnum]
        [CustomComboInfo("Phlegma into Toxikon", "Phlegma turns into Toxikon if you have addersting and are either out of range or out of charges.\nThis is prioritized over Dyskrasia if the 'Phlegma into Dyskrasia' feature is enabled.", SGE.JobID, SGE.Phlegma, SGE.Phlegmara, SGE.Phlegmaga)]
        SagePhlegmaToxicBalls = 4003,

        [OrderedEnum]
        [CustomComboInfo("Taurochole into Druochole", "Replaces Taurochole with Druochole if the former is on cooldown.\nYou should probably still keep the latter on your bar for certain scenarios.", SGE.JobID, SGE.Taurochole)]
        SageTauroDruoFeature = 4004,

        [OrderedEnum]
        [CustomComboInfo("Eukrasia into Eukrasian Dosis", "Eukrasia turns into Eukrasian Dosis while you have it active.\nThis doesn't save a button or really much else, I just like how it feels.", SGE.JobID, SGE.Eukrasia)]
        SageEukrasiaDosisFeature = 4006,

        [OrderedEnum]
        [CustomComboInfo("Toxikon Movement Feature", "Dosis turns into Toxikon while you are moving and don't have Eukrasia.", SGE.JobID, SGE.Dosis, SGE.Dosis2, SGE.Dosis3)]
        SageToxikonMovementFeature = 4008,

        [OrderedEnum]
        [CustomComboInfo("Phlegma Movement Feature", "Dosis turns into Phlegma while you are moving, don't have Eukrasia, and are in range to use it.", SGE.JobID, SGE.Dosis, SGE.Dosis2, SGE.Dosis3)]
        SagePhlegmaMovementFeature = 4009,

        [OrderedEnum]
        [CustomComboInfo("Extreme Button Saver", "This changes your targeted healing actions into AoE heals if you have no target.\nRecommended only if you have disabilities, or REALLY like having a smaller hotbar, at the expense of having to untarget a lot.", SGE.JobID, SGE.Haima, SGE.Druochole, SGE.Taurochole, SGE.Krasis, SGE.Diagnosis, SGE.Pneuma)]
        SageExtremeButtonSaverFeature = 4007,

        [OrderedEnum]
        [CustomComboInfo("Sage Lucid Dreaming Reminder", "All your non-role action cooldowns (that don't have charges) become Lucid Dreaming if they aren't up and Lucid Dreaming is, and you have less-than-or-equal-to 9000 MP.", SGE.JobID, SGE.Kardia, SGE.Soteria, SGE.Zoe, SGE.Pepsis, SGE.Physis, SGE.Physis2, SGE.Ixochole, SGE.Holos, SGE.Rhizomata, SGE.Krasis, SGE.Kerachole, SGE.Taurochole, SGE.Haima, SGE.Panhaima, SGE.Pneuma)]
        SageLucidReminderFeature = 4005,

        #endregion
        // ====================================================================================
        #region SAMURAI

        [OrderedEnum]
        [CustomComboInfo("Gekko Combo", "Replace Gekko with its combo chain.", SAM.JobID, SAM.Gekko)]
        SamuraiGekkoCombo = 3402,

        [OrderedEnum]
        [ParentCombo(SamuraiGekkoCombo)]
        [CustomComboInfo("Gekko Combo Option", "Start the Gekko combo chain with Jinpu instead of Hakaze.", SAM.JobID, SAM.Gekko)]
        SamuraiGekkoOption = 3415,

        [OrderedEnum]
        [ParentCombo(SamuraiGekkoCombo)]
        [CustomComboInfo("Gekko to Enpi", "Replace Gekko Combo with Enpi if you are out of melee range.", SAM.JobID, SAM.Gekko)]
        SamuraiGekkoEnpiFeature = 3425,

        [OrderedEnum]
        [CustomComboInfo("Kasha Combo", "Replace Kasha with its combo chain.", SAM.JobID, SAM.Kasha)]
        SamuraiKashaCombo = 3403,

        [OrderedEnum]
        [ParentCombo(SamuraiKashaCombo)]
        [CustomComboInfo("Kasha Combo Option", "Start the Kasha combo chain with Shifu instead of Hakaze.", SAM.JobID, SAM.Kasha)]
        SamuraiKashaOption = 3416,

        [OrderedEnum]
        [CustomComboInfo("Yukikaze Combo", "Replace Yukikaze with its combo chain.", SAM.JobID, SAM.Yukikaze)]
        SamuraiYukikazeCombo = 3401,

        [OrderedEnum]
        [CustomComboInfo("Mangetsu Combo", "Replace Mangetsu with its combo chain.", SAM.JobID, SAM.Mangetsu, SAM.Fuga, SAM.Fuko)]
        SamuraiMangetsuCombo = 3404,

        [OrderedEnum]
        [SecretCustomCombo]
        [ParentCombo(SamuraiMangetsuCombo)]
        [CustomComboInfo("Evil Mangetsu Combo", "Replace Fuga/Fuko with its combo chain, instead.", SAM.JobID, SAM.Mangetsu, SAM.Fuga, SAM.Fuko)]
        SamuraiEvilMangetsuCombo = 3417,

        [OrderedEnum]
        [CustomComboInfo("Oka Combo", "Replace Oka with its combo chain.", SAM.JobID, SAM.Oka)]
        SamuraiOkaCombo = 3405,

        [OrderedEnum]
        [ConflictingCombos(SamuraiIaijutsuTsubameGaeshiFeature)]
        [CustomComboInfo("Tsubame-gaeshi to Iaijutsu", "Replace Tsubame-gaeshi with Iaijutsu when Sen is not empty.", SAM.JobID, SAM.TsubameGaeshi)]
        SamuraiTsubameGaeshiIaijutsuFeature = 3406,

        [OrderedEnum]
        [ConflictingCombos(SamuraiIaijutsuShohaFeature)]
        [CustomComboInfo("Tsubame-gaeshi to Shoha", "Replace Tsubame-gaeshi with Shoha when meditation is 3 and either you have used Tsubame or it wouldn't clip the GCD. Becomes Shoha 2 if your last combo action was Fuga/Fuko/Mangetsu/Oka.", SAM.JobID, SAM.TsubameGaeshi)]
        SamuraiTsubameGaeshiShohaFeature = 3407,

        [OrderedEnum]
        [ConflictingCombos(SamuraiTsubameGaeshiIaijutsuFeature)]
        [CustomComboInfo("Iaijutsu to Tsubame-gaeshi", "Replace Iaijutsu with Tsubame-gaeshi when Sen is empty.", SAM.JobID, SAM.Iaijutsu)]
        SamuraiIaijutsuTsubameGaeshiFeature = 3408,

        [OrderedEnum]
        [ConflictingCombos(SamuraiTsubameGaeshiShohaFeature)]
        [CustomComboInfo("Iaijutsu to Shoha", "Replace Iaijutsu with Shoha when meditation is 3 and either you have used Tsubame or for a short period of time after Iaijutsu. Becomes Shoha 2 if your last combo action was Fuga/Fuko/Mangetsu/Oka.", SAM.JobID, SAM.Iaijutsu)]
        SamuraiIaijutsuShohaFeature = 3409,

        [OrderedEnum]
        [CustomComboInfo("Ogi-Namikiri to Shoha", "Replace Ogi-Namikiri with Shoha when meditation is 3 and either you have used Tsubame or it wouldn't clip the GCD. Becomes Shoha 2 if your last combo action was Fuga/Fuko/Mangetsu/Oka.", SAM.JobID, SAM.Ikishoten, SAM.OgiNamikiri)]
        SamuraiNamikiriShohaFeature = 3423,

        [OrderedEnum]
        [CustomComboInfo("Iaijutsu/Tsubame to Shoha Persistence Option", "Makes it so Shoha doesn't disappear after a short amount of time after Iaijutsu.", SAM.JobID, SAM.Iaijutsu, SAM.TsubameGaeshi)]
        SamuraiShohaGCDOption = 3421,

        [OrderedEnum]
        [CustomComboInfo("Iaijutsu/Tsubame to Shoha Inbetween Option", "Makes it so Shoha doesn't appear inbetween Iaijutsu and Tsubame.", SAM.JobID, SAM.Iaijutsu, SAM.TsubameGaeshi)]
        SamuraiShohaBetweenOption = 3422,

        [OrderedEnum]
        [CustomComboInfo("Iaijutsu to Kaiten", "Replace Iaijutsu/Ogi-Namikiri with Kaiten if Kaiten is not active, you have the gauge to use it, an Iaijutsu is ready, and you have just used an action.", SAM.JobID, SAM.Iaijutsu, SAM.OgiNamikiri)]
        SamuraiKaitenFeature = 3418,

        [OrderedEnum]
        [ParentCombo(SamuraiKaitenFeature)]
        [CustomComboInfo("Iaijutsu to Kaiten Persistence Option", "Makes it so Kaiten doesn't require you to have just used an action.", SAM.JobID, SAM.Iaijutsu)]
        SamuraiKaitenFeatureGCDOption = 3420,

        [OrderedEnum]
        [CustomComboInfo("Kaiten to Iaijutsu", "Replace Kaiten with Iaijutsu if you have less than 20 Kenki or have used Kaiten.", SAM.JobID, SAM.Kaiten)]
        SamuraiKaitenIaijutsuFeature = 3424,

        [OrderedEnum]
        [CustomComboInfo("Ikishoten Namikiri Feature", "Replace Ikishoten with Ogi Namikiri and then Kaeshi Namikiri when available.", SAM.JobID, SAM.Ikishoten)]
        SamuraiIkishotenNamikiriFeature = 3411,

        [OrderedEnum]
        [CustomComboInfo("Shinten to Senei", "Replace Hissatsu: Shinten with Senei when its cooldown is up.", SAM.JobID, SAM.Shinten)]
        SamuraiSeneiFeature = 3413,

        [OrderedEnum]
        [CustomComboInfo("Senei to Guren Level Sync", "Replace Hissatsu: Senei with Guren if you are at a level where you can't use Senei.", SAM.JobID, SAM.Shinten, SAM.Senei)]
        SamuraiSeneiGurenFeature = 3419,

        [OrderedEnum]
        [CustomComboInfo("Shinten to Shoha", "Replace Hissatsu: Shinten with Shoha when Meditation is full.", SAM.JobID, SAM.Shinten)]
        SamuraiShohaFeature = 3412,

        [OrderedEnum]
        [CustomComboInfo("Shinten to Kyuten", "Replace Hissatsu: Shinten with Kyuten if your last combo action was Fuga/Fuko/Mangetsu/Oka.", SAM.JobID, SAM.Shinten)]
        SamuraiShintenToKyutenFeature = 3427,

        [OrderedEnum]
        [CustomComboInfo("Kyuten to Guren", "Replace Hissatsu: Kyuten with Guren when its cooldown is up.", SAM.JobID, SAM.Kyuten)]
        SamuraiGurenFeature = 3414,

        [OrderedEnum]
        [CustomComboInfo("Kyuten to Shoha II", "Replace Hissatsu: Kyuten with Shoha II when Meditation is full.", SAM.JobID, SAM.Kyuten)]
        SamuraiShoha2Feature = 3410,

        [OrderedEnum]
        [CustomComboInfo("Yukikaze to Meditate", "Replace Yukikaze with Meditate while you have no target.", SAM.JobID, SAM.Yukikaze)]
        SamuraiYukikazeMeditateFeature = 3426,

        #endregion
        // ====================================================================================
        #region SCHOLAR

        [OrderedEnum]
        [CustomComboInfo("Seraph Fey Blessing/Consolation", "Change Fey Blessing into Consolation when Seraph is out.", SCH.JobID, SCH.FeyBless)]
        ScholarSeraphConsolationFeature = 2801,

        [OrderedEnum]
        [CustomComboInfo("ED Aetherflow", "Change Energy Drain into Aetherflow when you have no more Aetherflow stacks.", SCH.JobID, SCH.EnergyDrain, SCH.Excogitation, SCH.Lustrate, SCH.SacredSoil, SCH.Indomitability)]
        ScholarEnergyDrainFeature = 2802,

        [OrderedEnum]
        [ParentCombo(ScholarEnergyDrainFeature)]
        [CustomComboInfo("Everything Aetherflow", "Change every Aetherflow action into Aetherflow when you have no more Aetherflow stacks.\nIndomitability and Excogitation also become available with Recitation.", SCH.JobID, SCH.EnergyDrain, SCH.Excogitation, SCH.Lustrate, SCH.SacredSoil, SCH.Indomitability)]
        ScholarEverythingFeature = 2803,

        [OrderedEnum]
        [CustomComboInfo("Excogitation to Recitation", "Change Excogitation into Recitation when the latter is off-cooldown.", SCH.JobID, SCH.Excogitation)]
        ScholarExcogRecitationFeature = 2808,

        [OrderedEnum]
        [CustomComboInfo("Fairy Feature", "Change every action that requires a fairy into Summon Eos if you do not have a fairy summoned.", SCH.JobID, SCH.WhisperingDawn, SCH.FeyIllumination, SCH.FeyBless, SCH.Aetherpact, SCH.Dissipation, SCH.SummonSeraph, SCH.Consolation)]
        ScholarFairyFeature = 2804,

        [OrderedEnum]
        [ParentCombo(ScholarFairyFeature)]
        [CustomComboInfo("Fairy Feature Selene Option", "Replaces Summon Eos replacing actions with Summon Selene, for if you think Eos is a skank.", SCH.JobID, SCH.WhisperingDawn, SCH.FeyIllumination, SCH.FeyBless, SCH.Aetherpact, SCH.Dissipation, SCH.SummonSeraph, SCH.Consolation)]
        ScholarSeleneOption = 2805,

        [OrderedEnum]
        [CustomComboInfo("Ruin 2 to Chain Stratagem", "Ruin 2 becomes Chain Stratagem for a short while after you have used any action (and if it's off cooldown).", SCH.JobID, SCH.Ruin2)]
        ScholarRuinChainFeature = 2807,

        [OrderedEnum]
        [CustomComboInfo("Ruin 2 Movement Feature", "Ruin/Broil becomes Ruin 2 while you are moving.", SCH.JobID, SCH.Ruin, SCH.Broil, SCH.Broil2, SCH.Broil3, SCH.Broil4)]
        ScholarRuin2MovementFeature = 2809,

        [OrderedEnum]
        [CustomComboInfo("Scholar Lucid Dreaming Reminder", "All your non-role action cooldowns (that don't have charges) become Lucid Dreaming if they aren't up and Lucid Dreaming is, and you have less-than-or-equal-to 9000 MP.", SCH.JobID, SCH.Aetherflow, SCH.EmergencyTactics, SCH.WhisperingDawn, SCH.FeyIllumination, SCH.FeyBless, SCH.Dissipation, SCH.ChainStratagem, SCH.Indomitability, SCH.Excogitation, SCH.SacredSoil, SCH.Recitation, SCH.DeploymentTactics, SCH.SummonSeraph)]
        ScholarLucidReminderFeature = 2806,

        #endregion
        // ====================================================================================
        #region SUMMONER

        [OrderedEnum]
        [CustomComboInfo("Enkindle/Summon Switch", "When Bahamut/Phoenix are summoned, Enkindle Bahamut/Phoenix will replace Summon Bahamut/Phoenix.", SMN.JobID, SMN.SummonBahamut, SMN.SummonPhoenix, SMN.DreadwyrmTrance, SMN.Aethercharge)]
        SummonerDemiCombo = 2701,

        [OrderedEnum]
        [CustomComboInfo("Demi Flow Feature", "When you can use Astral Flow, it will replace Summon Bahamut/Summon Phoenix/Dreadwyrm Trance.", SMN.JobID, SMN.SummonBahamut, SMN.SummonPhoenix, SMN.DreadwyrmTrance, SMN.Aethercharge)]
        SummonerDemiFlowFeature = 2716,

        [OrderedEnum]
        [ConflictingCombos(SummonerOutburstOfBrillianceFeature, SummonerRuiningShineFeature)]
        [CustomComboInfo("Shiny Enkindle Feature", "When Bahamut/Phoenix are summoned, changes Gemshine and Precious Brilliance with Enkindle.", SMN.JobID, SMN.Gemshine, SMN.PreciousBrilliance)]
        SummonerShinyDemiCombo = 2708,

        [OrderedEnum]
        [ConflictingCombos(SummonerOutburstOfBrillianceFeature, SummonerRuiningShineFeature)]
        [CustomComboInfo("Shiny Flow Feature", "When Bahamut/Phoenix are summoned, changes Gemshine and Precious Brilliance with Astral Flow.", SMN.JobID, SMN.Gemshine, SMN.PreciousBrilliance)]
        SummonerShinyFlowCombo = 2711,

        [OrderedEnum]
        [CustomComboInfo("ED Fester", "Change Fester into Energy Drain when out of Aetherflow stacks", SMN.JobID, SMN.Fester)]
        SummonerEDFesterCombo = 2702,

        [OrderedEnum]
        [CustomComboInfo("ES Painflare", "Change Painflare into Energy Syphon when out of Aetherflow stacks", SMN.JobID, SMN.Painflare)]
        SummonerESPainflareCombo = 2703,

        [OrderedEnum]
        [CustomComboInfo("Mountain Buster Feature", "Gemshine and Precious Brilliance become Mountain Buster while you have Titan's Favor.", SMN.JobID, SMN.Ruin1, SMN.Ruin2, SMN.Ruin3, SMN.Gemshine, SMN.Outburst, SMN.TriDisaster, SMN.PreciousBrilliance)]
        SummonerMountainBusterFeature = 2710,

        [OrderedEnum]
        [CustomComboInfo("Summoning Flow Feature", "When you have Favor, or Bahamut/Phoenix are summoned, your summoning actions become Astral Flow.", SMN.JobID, SMN.SummonRuby, SMN.SummonIfrit, SMN.SummonIfrit2, SMN.SummonTopaz, SMN.SummonTitan, SMN.SummonTitan2, SMN.SummonEmerald, SMN.SummonGaruda, SMN.SummonGaruda2)]
        SummonerSummoningFlowFeature = 2712,

        [OrderedEnum]
        [CustomComboInfo("Flowing Ruin Feature", "Change Ruin into Astral Flow when you have Favor, or have Deathflare/Rekindle available and unused.", SMN.JobID, SMN.Ruin1, SMN.Ruin2, SMN.Ruin3, SMN.Gemshine)]
        SummonerFlowingRuinFeature = 2715,

        [OrderedEnum]
        [CustomComboInfo("Shiny Ruin Feature", "Change Ruin into Gemburst when attuned.", SMN.JobID, SMN.Ruin1, SMN.Ruin2, SMN.Ruin3)]
        SummonerShinyRuinFeature = 2709,

        [OrderedEnum]
        [CustomComboInfo("Further Ruin Feature", "Change Ruin into Ruin 4 when available and appropriate.", SMN.JobID, SMN.Ruin1, SMN.Ruin2, SMN.Ruin3, SMN.Gemshine)]
        SummonerFurtherRuinFeature = 2705,

        [OrderedEnum]
        [ConflictingCombos(SummonerShinyDemiCombo, SummonerShinyFlowCombo)]
        [CustomComboInfo("Ruining Shine Feature", "Change Gemshine into Ruin while not attuned.\nThis lets you keep Ruin on your bar, so you can always use it for movement.\nAll the above Ruin features apply to Gemshine while this feature is enabled, and will be disabled on Ruin.", SMN.JobID, SMN.Gemshine)]
        SummonerRuiningShineFeature = 2717,

        [OrderedEnum]
        [CustomComboInfo("Flowing Outburst Feature", "Change Outburst/Tri-disaster into Astral Flow when you have Favor, or have Deathflare/Rekindle available and unused.", SMN.JobID, SMN.Outburst, SMN.TriDisaster, SMN.PreciousBrilliance)]
        SummonerFlowingOutburstFeature = 2714,

        [OrderedEnum]
        [CustomComboInfo("Shiny Outburst Feature", "Change Outburst/Tri-disaster into Precious Brilliance when attuned.", SMN.JobID, SMN.Outburst, SMN.TriDisaster)]
        SummonerShinyOutburstFeature = 2706,

        [OrderedEnum]
        [CustomComboInfo("Further Outburst Feature", "Change Outburst/Tri-disaster into Ruin 4 when available and appropriate.", SMN.JobID, SMN.Outburst, SMN.TriDisaster, SMN.PreciousBrilliance)]
        SummonerFurtherOutburstFeature = 2707,

        [OrderedEnum]
        [ConflictingCombos(SummonerShinyDemiCombo, SummonerShinyFlowCombo)]
        [CustomComboInfo("Outburst of Brilliance Feature", "Change Precious Brilliance into Outburst while not attuned.\nThis lets you keep Outburst on your bar, so you can always use it for movement.\nAll the above Outburst features apply to Gemshine while this feature is enabled, and will be disabled on Outburst.", SMN.JobID, SMN.PreciousBrilliance)]
        SummonerOutburstOfBrillianceFeature = 2718,

        [OrderedEnum]
        [CustomComboInfo("Carby Feature", "Every action that cannot be used without summoning carbuncle becomes Summon Carbuncle while a pet is not summoned.", SMN.JobID, SMN.RadiantAegis, SMN.SearingLight, SMN.Aethercharge, SMN.DreadwyrmTrance, SMN.SummonBahamut, SMN.SummonEmerald,
            SMN.SummonGaruda, SMN.SummonGaruda2, SMN.SummonRuby, SMN.SummonIfrit, SMN.SummonIfrit2, SMN.SummonTopaz, SMN.SummonTitan, SMN.SummonTitan2, SMN.Gemshine, SMN.PreciousBrilliance, SMN.AstralFlow)]
        SummonerCarbyFeature = 2704,

        [OrderedEnum]
        [CustomComboInfo("Searing Demi Feature", "If Searing Light and Aethercharge/Dreadwyrm/Summon Bahamut/Phoenix are both off-cooldown, Searing Light replaces the latter.", SMN.JobID, SMN.Aethercharge, SMN.DreadwyrmTrance, SMN.SummonBahamut, SMN.SummonPhoenix)]
        SummonerSearingDemiFeature = 2719,

        [OrderedEnum]
        [CustomComboInfo("Summoner Lucid Dreaming Reminder", "All your non-role action cooldowns (that don't have charges) become Lucid Dreaming if they aren't up and Lucid Dreaming is, and you have less-than-or-equal-to 9000 MP.", SMN.JobID, SMN.EnergyDrain, SMN.EnergySyphon, SMN.RadiantAegis, SMN.SearingLight, SMN.SummonBahamut, SMN.DreadwyrmTrance, SMN.EnkindleBahamut, SMN.Aethercharge)]
        SummonerLucidReminderFeature = 2713,

        #endregion
        // ====================================================================================
        #region WARRIOR

        [OrderedEnum]
        [CustomComboInfo("Storms Path Combo", "Replace Storms Path with its combo chain", WAR.JobID, WAR.StormsPath)]
        WarriorStormsPathCombo = 2101,

        [OrderedEnum]
        [ParentCombo(WarriorStormsPathCombo)]
        [CustomComboInfo("Storms Path to Tomahawk", "Replace Storms Path's combo with Tomahawk when out of melee range.", WAR.JobID, WAR.StormsPath)]
        WarriorStormsPathahawkFeature = 2110,

        [OrderedEnum]
        [ParentCombo(WarriorStormsPathCombo)]
        [CustomComboInfo("Storms Path to Storms Eye", "Replace Storms Path with Storms Eye when Surging Tempest is not active.", WAR.JobID, WAR.StormsPath)]
        WarriorStormsPathtoStormsEyeFeature = 2116,

        [OrderedEnum]
        [CustomComboInfo("Storms Eye Combo", "Replace Storms Eye with its combo chain", WAR.JobID, WAR.StormsEye)]
        WarriorStormsEyeCombo = 2102,

        [OrderedEnum]
        [ParentCombo(WarriorStormsEyeCombo)]
        [CustomComboInfo("Storms Eye to Tomahawk", "Replace Storms Eye's combo with Tomahawk when out of melee range.", WAR.JobID, WAR.StormsPath)]
        WarriorStormsEyeahawkFeature = 2112,

        [OrderedEnum]
        [ParentCombo(WarriorStormsEyeCombo)]
        [CustomComboInfo("Storms Eye Tomahawk Replacement", "Replace Storm's Eye's combo with Tomahawk while Storm's Eye is not available for use in combo.", WAR.JobID, WAR.StormsPath)]
        WarriorStormsEyeHawkReplacementFeature = 2113,

        [OrderedEnum]
        [CustomComboInfo("Mythril Tempest Combo", "Replace Mythril Tempest with its combo chain while you have a target.", WAR.JobID, WAR.MythrilTempest)]
        WarriorMythrilTempestCombo = 2103,

        [OrderedEnum]
        [CustomComboInfo("Overpower Combo", "Replace Overpower with its combo chain.", WAR.JobID, WAR.Overpower)]
        WarriorOverpowerCombo = 2104,

        [OrderedEnum]
        [CustomComboInfo("Warrior Gauge Overcap Feature", "Replace AoE combo with gauge spender if you are about to overcap", WAR.JobID, WAR.MythrilTempest, WAR.StormsEye, WAR.StormsPath)]
        WarriorGaugeOvercapFeature = 2105,

        [OrderedEnum]
        [CustomComboInfo("Inner Release Feature", "Replace Single-target and AoE combo with Fell Cleave/Decimate during Inner Release", WAR.JobID, WAR.MythrilTempest, WAR.StormsPath)]
        WarriorInnerReleaseFeature = 2106,

        [OrderedEnum]
        [ParentCombo(WarriorInnerReleaseFeature)]
        [CustomComboInfo("Inner Release Feature Tomahawk Option", "Replace Storm's Eye with Tomahawk during Inner Release.", WAR.JobID, WAR.MythrilTempest, WAR.StormsPath)]
        WarriorInnerReleaseahawkOption = 2111,

        [OrderedEnum]
        [CustomComboInfo("Nascent Flash Feature", "Replace Nascent Flash with Raw intuition when level synced below 76", WAR.JobID, WAR.NascentFlash)]
        WarriorNascentFlashFeature = 2107,

        [OrderedEnum]
        [CustomComboInfo("Primal Rend Feature", "Replace Inner Release with Primal Rend when available.", WAR.JobID, WAR.Berserk, WAR.InnerRelease)]
        WarriorPrimalRendFeature = 2108,

        [OrderedEnum]
        [CustomComboInfo("Mythril Rend Feature", "Replace your AoE combos of choice with Primal Rend when available.", WAR.JobID, WAR.MythrilTempest)]
        WarriorMythrilRendFeature = 2109,

        [OrderedEnum]
        [CustomComboInfo("Fell Cleave to Decimate Feature", "Replaces Fell Cleave/Inner Beast with Decimate/Steel Cyclone if you are in the midst of your AoE combo.", WAR.JobID, WAR.FellCleave, WAR.InnerBeast)]
        WarriorFellCleaveToDecimateFeature = 2115,

        [OrderedEnum]
        [CustomComboInfo("Upheaval to Orogeny", "Replace your Upheaval with Orogeny while you are in the midst of your AoE combo.", WAR.JobID, WAR.Upheaval)]
        WarriorUporgyFeature = 2114,

        #endregion
        // ====================================================================================
        #region WHITE MAGE

        [OrderedEnum]
        [CustomComboInfo("Solace into Misery", "Replaces Afflatus Solace with Afflatus Misery when Misery is ready to be used.", WHM.JobID, WHM.AfflatusSolace)]
        WhiteMageSolaceMiseryFeature = 2401,

        [OrderedEnum]
        [CustomComboInfo("Rapture into Misery", "Replaces Afflatus Rapture with Afflatus Misery when Misery is ready to be used and you have a target.", WHM.JobID, WHM.AfflatusRapture)]
        WhiteMageRaptureMiseryFeature = 2402,

        [OrderedEnum]
        [CustomComboInfo("Holy into Misery", "Replaces Holy/Holy 3 with Afflatus Misery when Misery is ready to be used and you have a target.", WHM.JobID, WHM.Holy, WHM.Holyga)]
        WhiteMageHolyMiseryFeature = 2405,

        [OrderedEnum]
        [CustomComboInfo("Cure 2 to Cure Level Sync", "Changes Cure 2 to Cure when below level 30 in synced content.", WHM.JobID, WHM.Cure2)]
        WhiteMageCureFeature = 2403,

        [OrderedEnum]
        [CustomComboInfo("Afflatus Feature", "Changes Cure 2 into Afflatus Solace, and Medica into Afflatus Rapture, when lilies are up.", WHM.JobID, WHM.Cure2, WHM.Medica)]
        WhiteMageAfflatusFeature = 2404,

        [OrderedEnum]
        [CustomComboInfo("White Mage Lucid Dreaming Reminder", "All your non-role action cooldowns (that don't have charges) become Lucid Dreaming if they aren't up and Lucid Dreaming is, and you have less-than-or-equal-to 9000 MP.", WHM.JobID, WHM.PresenceOfMind, WHM.Assize, WHM.Temperance, WHM.PlenaryIndulgence, WHM.Tetragrammaton, WHM.Asylum, WHM.Aquaveil, WHM.LiturgyOfTheBell, WHM.Benediction)]
        WhiteMageLucidReminderFeature = 2406,

        #endregion
        // ====================================================================================
    }
}

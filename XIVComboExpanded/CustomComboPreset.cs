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

        // Latest enum: 9015

        [OrderedEnum]
        [CustomComboInfo("Raise to Swiftcast Feature", "Replaces the respective raise on RDM/SMN/SCH/WHM/AST/SGE/BLU with Swiftcast when it is off cooldown (and Dualcast isn't up).", All.JobID, All.Raise, All.Resurrection, All.Ascend, All.Verraise, All.Egeiro, All.AngelWhisper)]
        AllSwiftcastFeature = 9001,

        [OrderedEnum]
        [CustomComboInfo("Raise Hard Target Lockout", "Replaces the respective raise on RDM/SMN/SCH/WHM/AST/SGE/BLU with a useless action when hard targeting a corpse that already has a raise effect on it.", All.JobID, All.Raise, All.Resurrection, All.Ascend, All.Verraise, All.Egeiro, All.AngelWhisper)]
        AllRaiseHardLockoutFeature = 9015,

        [OrderedEnum]
        [CustomComboInfo("Isle Sprint", "Replaces Sprint with Isle Sprint while you're in your Island Sanctuary.\nBecause sometimes SimpleTweaks doesn't have this.", All.JobID, All.Sprint)]
        AllIsleSprintFeature = 9014,

        [OrderedEnum]
        [CustomComboInfo("Eureka Feature", "Replaces Solid Reason/Ageless Words with Wise to the World when you have Eureka Moment up.", All.JobID, All.SolidReason, All.AgelessWords)]
        AllEurekaFeature = 9002,

        [OrderedEnum]
        [CustomComboInfo("Tank Interrupt Feature", "Low Blow becomes Interject if the opponent can be interrupted and Interject is off-cooldown.", All.JobID, All.LowBlow)]
        AllTankInterruptFeature = 9003,

        [OrderedEnum]
        [CustomComboInfo("Reprisal/Addle/Feint Lockout Feature", "Locks out Reprisal, Addle and Feint while they are available, but currently in use and more than 3s remain on their debuff, to prevent overwriting it.", All.JobID, All.Reprisal, All.Addle, All.Feint)]
        AllReprisalLockoutFeature = 9010,

        [OrderedEnum]
        [CustomComboInfo("Physical Ranged DPS Defense Cooldown Lockout Feature", "Locks out your Physical Ranged DPS defense cooldown (ex: Troubadour) while it is available, but one is currently in use and more than 3s remain on its buff, to prevent overwriting it.", All.JobID, All.Tactician, All.Troubadour, All.ShieldSamba)]
        AllRangedDefenseCooldownLockoutFeature = 9011,

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

        [OrderedEnum]
        [CustomComboInfo("Hooking Hooksets", "Replace Precision/Powerful Hookset with Hook when it is available and you do not have Inefficient Hooking.", All.JobID, All.PrecisionHookset, All.PowerfulHookset)]
        DolHookingHooksetsFeature = 9012,

        [OrderedEnum]
        [CustomComboInfo("Chummy Cast", "Replace Chum with Cast if Chum has already been used or you have less than 100 GP (less than 150 if you have Inefficient Hooking).", All.JobID, All.Chum)]
        DolChummyCastFeature = 9013,

        #endregion

        #region ASTROLOGIAN

        // latest enum: 3308

        [OrderedEnum]
        [CustomComboInfo("Astral/Umbral Draw on Play I", "Play I turns into Astral/Umbral Draw when no card is drawn, as well as the usual Play I behavior.", AST.JobID, AST.Play1)]
        AstrologianCardsOnDrawFeature = 3301,

        /*[OrderedEnum]
        [CustomComboInfo("Play to Astrodyne", "Play becomes Astrodyne when you have 3 seals.\nIf Draw on Play is enabled, Astrodyne replaces Draw on Play while Draw is on Cooldown.", AST.JobID, AST.Play)]
        AstrologianAstrodynePlayFeature = 3304,*/

        [OrderedEnum]
        [CustomComboInfo("Astral/Umbral Draw Lockout", "Prevents you from using Astral/Umbral Draw while any cards are drawn by replacing it with Malefic.", AST.JobID, AST.AstralDraw)]
        AstrologianDrawLockoutFeature = 3306,

        [OrderedEnum]
        [CustomComboInfo("Benefic 2 to Benefic Level Sync", "Changes Benefic 2 to Benefic when below level 26 in synced content.", AST.JobID, AST.Benefic2)]
        AstrologianBeneficFeature = 3303,

        [OrderedEnum]
        [CustomComboInfo("Divination Lockout Feature", "Locks out Divination while it is available and more than 3s remain on its buff, to prevent overwriting raid buffs.", AST.JobID, AST.Divination)]
        AstrologianDivinationLockoutFeature = 3308,

        [OrderedEnum]
        [CustomComboInfo("Astrologian Lucid Dreaming Reminder", "All your non-role action cooldowns (that don't have charges) become Lucid Dreaming if they aren't up and Lucid Dreaming is, and you have less-than-or-equal-to a set amount of MP.", AST.JobID, AST.CelestialOpposition, AST.CollectiveUnconscious, AST.Divination, AST.EarthlyStar, AST.Exaltation, AST.Macrocosmos, AST.NeutralSect, AST.Synastry, AST.Horoscope)]
        AstrologianLucidReminderFeature = 3305,

        #endregion
        // ====================================================================================
        #region BLACK MAGE

        // latest enum: 2530

        [OrderedEnum]
        [CustomComboInfo("Blizzard 4/Fire 4 Switcher", "Change Fire 4 or Blizzard 4 to whichever action you can currently use.\nWill also swap them for Blizzard 1/Fire 1 when one is not available while synced.", BLM.JobID, BLM.Blizzard4, BLM.Fire4)]
        BlackEnochianFeature = 2501,

        [OrderedEnum]
        [ParentCombo(BlackEnochianFeature)]
        [CustomComboInfo("Blizzard 4/Fire 4 to Xenoglossy Movement Feature", "Change Fire 4 or Blizzard 4 to Xenoglossy while moving, if available and Triplecast/Swiftcast are not up.", BLM.JobID, BLM.Blizzard4, BLM.Fire4)]
        BlackEnochianXenoglossyFeature = 2520,

        [OrderedEnum]
        [SecretCustomCombo]
        [ParentCombo(BlackEnochianFeature)]
        [CustomComboInfo("Enochian Despair Feature", "Change Fire 4 or Blizzard 4 to Despair when in Astral Fire with less than 1600 mana.", BLM.JobID, BLM.Blizzard4, BLM.Fire4)]
        BlackEnochianDespairFeature = 2510,

        [OrderedEnum]
        [CustomComboInfo("Blizzard/Fire Switcher", "Change Fire or Blizzard to whichever element you are currently aspected to.", BLM.JobID, BLM.Blizzard, BLM.Fire)]
        BlackEnochianButNotFeature = 2524,

        [OrderedEnum]
        [CustomComboInfo("Flare to Despair", "Change Flare to Despair when you are not using AoE spells and have it available.", BLM.JobID, BLM.Flare, BLM.Freeze, BLM.Fire2, BLM.HighFire2)]
        BlackFlareDespairFeature = 2511,

        [OrderedEnum]
        [CustomComboInfo("Flare to Flare Star", "Change Flare to Flare Star when available.", BLM.JobID, BLM.Flare)]
        BlackFlareStarFeature = 2527,

        [OrderedEnum]
        [CustomComboInfo("Despair to Flare Star", "Change Despair to Flare Star when at 0 MP or >= 1600 MP.", BLM.JobID, BLM.Despair)]
        BlackDespairStarFeature = 2530,

        [OrderedEnum]
        [CustomComboInfo("Blizzard 3 & 2 to Flare Star", "Change Blizzard 3 and High Blizzard 2 to Flare Star when available.", BLM.JobID, BLM.Blizzard, BLM.Blizzard2, BLM.Blizzard3, BLM.HighBlizzard2)]
        BlackBlizzardStarFeature = 2529,

        [OrderedEnum]
        [CustomComboInfo("High Thunder to High Thunder 2 Feature", "Change High Thunder to High Thunder 2 when you are using AoE spells and have it available.", BLM.JobID, BLM.Thunder, BLM.Thunder3, BLM.HighThunder)]
        BlackThunder2Feature = 2526,

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
        [CustomComboInfo("Umbral Soul to Transpose", "When you are outside of Umbral Ice, Umbral Soul becomes Transpose.", BLM.JobID, BLM.UmbralSoul)]
        BlackUmbralSoulTransposeFeature = 2518,

        [OrderedEnum]
        [CustomComboInfo("Fire 2 Feature", "(High) Fire 2 becomes Flare in Astral Fire.", BLM.JobID, BLM.Fire2, BLM.HighFire2)]
        BlackFire2Feature = 2508,

        [OrderedEnum]
        [CustomComboInfo("Ice 2 Feature", "(High) Blizzard 2 becomes Freeze in Umbral Ice.", BLM.JobID, BLM.Blizzard2, BLM.HighBlizzard2)]
        BlackBlizzard2Feature = 2509,

        [OrderedEnum]
        [CustomComboInfo("Fire 2/Ice 2 Option", "Fire 2 and Blizzard 2 will not change unless you're at max AF/UI with this option.", BLM.JobID, BLM.Blizzard2)]
        BlackFireBlizzard2Option = 2514,

        [OrderedEnum]
        [CustomComboInfo("(Between the) Ley Lines", "Change Ley Lines into Between the Lines when Ley Lines is active.\nMake sure to disable the vanilla Ley Lines to Retrace feature before applying this!", BLM.JobID, BLM.LeyLines)]
        BlackLeyLinesFeature = 2504,

        [OrderedEnum]
        [CustomComboInfo("Fire 1/3 Feature", "Fire 1 becomes Fire 3 outside of Astral Fire, and when Firestarter proc is up, and also becomes Paradox when available.", BLM.JobID, BLM.Fire)]
        BlackFireFeature = 2505,

        [OrderedEnum]
        [ParentCombo(BlackFireFeature)]
        [CustomComboInfo("Fire 1/3 Option", "Fire will stay Fire 3 if you're not at max AF with this option.", BLM.JobID, BLM.Fire)]
        BlackFireOption = 2515,

        [OrderedEnum]
        [CustomComboInfo("Blizzard 1/3 Feature", "Blizzard 1 becomes Blizzard 3 after you have unlocked it and are not in Umbral Ice 3.", BLM.JobID, BLM.Blizzard)]
        BlackBlizzardFeature = 2506,

        [OrderedEnum]
        [CustomComboInfo("Scathe/Xenoglossy Feature", "Scathe becomes Xenoglossy when available.", BLM.JobID, BLM.Scathe)]
        BlackScatheFeature = 2507,

        [OrderedEnum]
        [CustomComboInfo("Xenoglossy/Foul to Amplifier", "Xenoglossy/Foul become Amplifier when it's available, you have just used an action, and you have less than two Polyglot stacks, or if you have no target or have no Polyglot.", BLM.JobID, BLM.Xenoglossy, BLM.Foul)]
        BlackXenoAmpFeature = 2512,

        [OrderedEnum]
        [CustomComboInfo("Xenoglossy to Foul", "Xenoglossy becomes Foul if you are using AoE spells or if you do not have Xenoglossy.", BLM.JobID, BLM.Xenoglossy)]
        BlackXenoFoulFeature = 2522,

        [OrderedEnum]
        [CustomComboInfo("Triplecast to Swiftcast", "Triplecast becomes Swiftcast if you aren't capped out on charges and Swiftcast is ready, or if Triplecast is not unlocked.", BLM.JobID, BLM.Triplecast)]
        BlackTripleswiftFeature = 2523,

        [OrderedEnum]
        [CustomComboInfo("Flare Star to Manafont", "Flare Star becomes Manafont when it is not available.", BLM.JobID, BLM.FlareStar)]
        BlackFlareFontFeature = 2525,

        #endregion
        // ====================================================================================
        #region BARD

        // latest enum: 2316

        [OrderedEnum]
        [CustomComboInfo("Burst Shot into Refulgent Arrow", "Replaces Heavy Shot/Burst Shot with Straight Shot/Refulgent Arrow when procced.", BRD.JobID, BRD.HeavyShot, BRD.BurstShot)]
        BardStraightShotUpgradeFeature = 2302,

        [OrderedEnum]
        [CustomComboInfo("Biting Jaws", "Iron Jaws is replaced with Stormbite/Windbite if it is not up, or you do not have Iron Jaws yet.", BRD.JobID, BRD.IronJaws)]
        BardIronJawsFeature = 2311,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Biting Jaws Plus", "Iron Jaws is replaced with Caustic Bite/Stormbite if one or both are not up.\nAlternates between the two if Iron Jaws isn't available.\nThis is a separate feature from Biting Jaws, and will overwrite it if both are enabled.", BRD.JobID, BRD.IronJaws)]
        BardIronJawsFeaturePlus = 2303,

        [OrderedEnum]
        [CustomComboInfo("Ladonsbite into Apex Arrow", "Replaces Quick Nock/Ladonsbite with Apex Arrow when gauge is 80 or above.", BRD.JobID, BRD.QuickNock, BRD.Ladonsbite)]
        BardApexFeature = 2304,

        [OrderedEnum]
        [CustomComboInfo("Ladonsbite into Shadowbite", "Replaces Quick Nock/Ladonsbite with Wide Volley/Shadowbite when it is ready.", BRD.JobID, BRD.QuickNock, BRD.Ladonsbite)]
        BardShadowbiteFeature = 2305,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Empyreal Arrow to Sidewinder", "Replaces Empyreal Arrow with Sidewinder if the latter is off-cooldown and the former is on-cooldown.", BRD.JobID, BRD.EmpyrealArrow)]
        BardSidewinderFeature = 2306,

        [OrderedEnum]
        [CustomComboInfo("Sidewinder to Pitch Perfect", "Replaces Sidewinder with Pitch Perfect during Wanderer's Minuet if Repertoire is maxed out or Sidewinder is on cooldown.", BRD.JobID, BRD.Sidewinder)]
        BardPerfectSidesFeature = 2314,

        [OrderedEnum]
        [ParentCombo(BardPerfectSidesFeature)]
        [CustomComboInfo("Only When Full", "Replaces Sidewinder with Pitch Perfect only when you are full on Repertoire, no matter what.\nRemember that you will still need to use Pitch Perfect when Repertoire isn't full, this is only for convenience.", BRD.JobID, BRD.Sidewinder)]
        BardPerfectSidesOnlyFullOption = 2316,

        [OrderedEnum]
        [CustomComboInfo("Radiant Voice", "Replaces Radiant Finale with Battle Voice if Battle Voice is off-cooldown.", BRD.JobID, BRD.RadiantFinale)]
        BardRadiantFeature = 2307,

        [OrderedEnum]
        [ParentCombo(BardRadiantFeature)]
        [CustomComboInfo("Radiant Voice Evil Option", "Replaces Radiant Finale with Battle Voice after Radiant Finale is used, instead.", BRD.JobID, BRD.RadiantFinale)]
        BardRadiantVoiceOption = 2315,

        [OrderedEnum]
        [CustomComboInfo("Radiant Strikes", "Replaces Radiant Finale with Raging Strikes if Raging Strikes is off-cooldown and Radiant Finale is not.\nBattle Voice takes priority if Radiant Voice is enabled.", BRD.JobID, BRD.RadiantFinale)]
        BardRadiantStrikesFeature = 2309,

        [OrderedEnum]
        [CustomComboInfo("Battle Voice Lockout", "Locks out Battle Voice while it is available and more than 3s remain on its buff, to prevent overwriting raid buffs.", BRD.JobID, BRD.BattleVoice)]
        BardBattleVoiceLockoutFeature = 2312,

        [OrderedEnum]
        [CustomComboInfo("Radiant Finale Lockout", "Locks out Radiant Finale while it is available and more than 3s remain on its buff, to prevent overwriting raid buffs.", BRD.JobID, BRD.RadiantFinale)]
        BardRadiantLockoutFeature = 2313,

        [OrderedEnum]
        [CustomComboInfo("Barraging Arrow", "Replaces Barrage with Refulgent Arrow/Straight Shot if you have Hawkeye.", BRD.JobID, BRD.Barrage)]
        BardBarrageFeature = 2308,

        [OrderedEnum]
        [CustomComboInfo("Heartbreak Shot to Rain of Death", "Replaces Heartbreak Shot/Bloodletter with Rain of Death if your last GCD was either Quick Nock/Ladonsbite or Shadowbite.", BRD.JobID, BRD.HeartbreakShot, BRD.Bloodletter)]
        BardRainFeature = 2310,

        #endregion
        // ====================================================================================
        #region DANCER

        // latest enum: 3827

        [OrderedEnum]
        [SecretCustomCombo]
        [ConflictingCombos(DancerDanceComboCompatibility)]
        [CustomComboInfo("Dance Step Combo", "Change Standard Step and Technical Step into each dance step while dancing.", DNC.JobID, DNC.StandardStep, DNC.TechnicalStep)]
        DancerDanceStepCombo = 3802,

        [OrderedEnum]
        [ConflictingCombos(DancerSingleTargetProcs)]
        [CustomComboInfo("Cascade Combo", "Change Cascade into procs and combos as available.", DNC.JobID, DNC.Cascade)]
        DancerSingleTargetMultibutton = 3804,

        [OrderedEnum]
        [ParentCombo(DancerSingleTargetMultibutton)]
        [CustomComboInfo("No Cascade Combo Procs", "Don't change Cascade combo into procs.", DNC.JobID)]
        DancerSingleTargetMultibuttonNoProcs = 3814,

        [OrderedEnum]
        [ParentCombo(DancerSingleTargetMultibutton)]
        [CustomComboInfo("Cascading Saber Dance", "Change Cascade combo into Saber Dance during Devilment while you have more than 50 Esprit.", DNC.JobID)]
        DancerSingleTargetMultibuttonSaber = 3823,

        [OrderedEnum]
        [CustomComboInfo("Reverse Cascade Combo", "Change Reverse Cascade into Fountainfall if available.", DNC.JobID, DNC.ReverseCascade)]
        DancerReverseCascadeCombo = 3818,

        [OrderedEnum]
        [ParentCombo(DancerReverseCascadeCombo)]
        [CustomComboInfo("Change on AoE", "Become Rising Windmill Combo if you're using AoE actions.", DNC.JobID)]
        DancerReverseCascadeComboAoE = 3819,

        [OrderedEnum]
        [ConflictingCombos(DancerSingleTargetMultibutton)]
        [CustomComboInfo("Single Target to Procs", "Change Single-Target actions into Procs when available.", DNC.JobID, DNC.Cascade, DNC.Fountain)]
        DancerSingleTargetProcs = 3811,

        [OrderedEnum]
        [ConflictingCombos(DancerAoeProcs)]
        [CustomComboInfo("Windmill Combo", "Change Windmill into procs and combos as available.", DNC.JobID, DNC.Windmill)]
        DancerAoeMultibutton = 3805,

        [OrderedEnum]
        [ParentCombo(DancerAoeMultibutton)]
        [CustomComboInfo("No Windmill Combo Procs", "Don't change Windmill combo into procs.", DNC.JobID)]
        DancerAoeMultibuttonNoProcs = 3816,

        [OrderedEnum]
        [ParentCombo(DancerSingleTargetMultibutton)]
        [CustomComboInfo("Windmilling Saber Dance", "Change Windmill combo into Saber Dance during Devilment while you have more than 50 Esprit.", DNC.JobID)]
        DancerAoeMultibuttonSaber = 3824,

        [OrderedEnum]
        [CustomComboInfo("Rising Windmill Combo", "Change Rising Windmill into Bloodshower if available.", DNC.JobID, DNC.RisingWindmill)]
        DancerRisingWindmillCombo = 3817,

        [OrderedEnum]
        [ConflictingCombos(DancerAoeMultibutton)]
        [CustomComboInfo("AoE to Procs", "Change AoE actions into procs when available.", DNC.JobID, DNC.Windmill, DNC.Bladeshower)]
        DancerAoeProcs = 3812,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Saber Dance Overcap Prevention", "Change Cascade/Windmill combo into Saber Dance if you have 85+ Esprit.", DNC.JobID, DNC.Cascade, DNC.Windmill)]
        DancerCombosToSaberDanceOvercap = 3826,

        [OrderedEnum]
        [CustomComboInfo("Fan Dance I to II", "Change Fan Dance I to II if you are currently using your AoE combo.", DNC.JobID, DNC.FanDance1)]
        DancerFanDance1to2 = 3820,

        [OrderedEnum]
        [CustomComboInfo("Fan Dance I/II to III", "Change Fan Dance and Fan Dance 2 into Fan Dance 3 while under Threefold Fan Dance.", DNC.JobID, DNC.FanDance1, DNC.FanDance2)]
        DancerFanDanceCombo = 3801,

        [OrderedEnum]
        [ParentCombo(DancerFanDanceCombo)]
        [CustomComboInfo("Fan Dance I/II to IV", "Additionally change Fan Dance and Fan Dance 2 into Fan Dance 4 while under Fourfold Fan Dance.", DNC.JobID, DNC.FanDance1, DNC.FanDance2)]
        DancerFanDance4Combo = 3809,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Fan Dance Overcap Prevention", "Change your Cascade/Windmill combos into Fan Dance I/II while the GCD is rolling and you have four feathers.", DNC.JobID, DNC.Cascade, DNC.Windmill)]
        DancerCombosToFanDance = 3825,

        [OrderedEnum]
        [CustomComboInfo("Flourish to Fan Dance IV", "Change Flourish into Fan Dance IV when it is ready.", DNC.JobID, DNC.Flourish)]
        DancerFlourishFanDance4Feature = 3808,

        [OrderedEnum]
        [CustomComboInfo("Flourish to Fan Dance III", "Change Flourish into Fan Dance III when it is ready.\nTakes priority over Fan Dance IV if Flourish to Fan Dance IV is active.", DNC.JobID, DNC.Flourish)]
        DancerFlourishFanDance3Feature = 3810,

        [OrderedEnum]
        [CustomComboInfo("Standard Step into Last Dance", "Change Standard Step into Last Dance when available.", DNC.JobID, DNC.StandardStep)]
        DancerLastDanceFeature = 3821,

        [OrderedEnum]
        [CustomComboInfo("Standard Step into Technical Step", "Change Standard Step into Technical Step when Standard Step is on cooldown.", DNC.JobID, DNC.StandardStep)]
        DancerStandardechnicalStepFeature = 3822,

        [OrderedEnum]
        [CustomComboInfo("Technical Step Lockout Feature", "Locks out Technical Step while it is available and more than 8s remain on its raid buff, to prevent overwriting raid buffs.", DNC.JobID, DNC.TechnicalStep)]
        DancerTechnicalLockoutFeature = 3813,

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

        [OrderedEnum]
        [CustomComboInfo("Fan Dance II to Jete", "Fan Dance II becomes Jete while dancing because hotbar shenanigans.", DNC.JobID, DNC.FanDance2)]
        DancerJeteShenanigans = 3827,

        #endregion
        // ====================================================================================
        #region DRAGOON

        // latest enum: 2220

        [OrderedEnum]
        [CustomComboInfo("Heavens' Thrust Combo", "Replace Heavens'/Full Thrust with its combo chain.", DRG.JobID, DRG.FullThrust, DRG.HeavensThrust)]
        DragoonFullThrustCombo = 2204,

        [OrderedEnum]
        [ParentCombo(DragoonFullThrustCombo)]
        [CustomComboInfo("Heavens' Thrust Combo Lance Barrage Option", "Heavens'/Full Thrust's combo chain is instead replaced by Lance Barrage/Vorpal Thrust, not True Thrust, while you have no combo ongoing.", DRG.JobID, DRG.FullThrust, DRG.HeavensThrust)]
        DragoonFullThrustComboOption = 2210,

        [OrderedEnum]
        [ParentCombo(DragoonFullThrustCombo)]
        [CustomComboInfo("Heavens' Thrust to Piercing Talon", "Heavens'/Full Thrust's combo is replaced with Piercing Talon when you are out of melee range.", DRG.JobID, DRG.FullThrust, DRG.HeavensThrust)]
        DragoonFullThrustTalonFeature = 2211,

        [OrderedEnum]
        [CustomComboInfo("Chaotic Spring Combo", "Replace Chaotic Spring/Chaos Thrust with its combo chain.", DRG.JobID, DRG.ChaosThrust, DRG.ChaoticSpring)]
        DragoonChaosThrustCombo = 2203,

        [OrderedEnum]
        [ParentCombo(DragoonChaosThrustCombo)]
        [CustomComboInfo("Chaotic Spring Combo Spiral Blow Option", "Chaotic Spring/Chaos Thrust's combo chain is instead replaced by Spiral Blow/Disembowel, not True Thrust, while you have no combo ongoing.", DRG.JobID, DRG.ChaosThrust, DRG.ChaoticSpring)]
        DragoonChaosThrustComboOption = 2209,

        [OrderedEnum]
        [CustomComboInfo("Heavens' Thrust to Chaotic Spring", "Heavens'/Full Thrust becomes Chaotic Spring/Chaos Thrust after using Spiral Blow/Disembowel.\nWith combos, the Heavens' Thrust combo becomes the Chaotic Spring combo.", DRG.JobID, DRG.FullThrust, DRG.HeavensThrust)]
        DragoonFullChaosFeature = 2215,

        [OrderedEnum]
        [CustomComboInfo("Chaotic Glide", "Spiral Blow/Disembowel and Chaotic Spring/Chaos Thrust (plus their combos) become Winged Glide when out of melee range.", DRG.JobID, DRG.Disembowel, DRG.SpiralBlow, DRG.ChaosThrust, DRG.ChaoticSpring)]
        DragoonChaoticGlideFeature = 2220,

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
        [CustomComboInfo("Stardiver to Dragonfire Dive", "Stardiver becomes Dragonfire Dive when the latter is off-cooldown, or outside of Life of the Dragon.", DRG.JobID, DRG.Stardiver)]
        DragoonStarfireDiveFeature = 2208,

        [OrderedEnum]
        [CustomComboInfo("Lance Charge to Battle Litany", "Lance Charge becomes Battle Litany while on cooldown.", DRG.JobID, DRG.LanceCharge)]
        DragoonLancetanyFeature = 2218,

        [OrderedEnum]
        [CustomComboInfo("Battle Litany Lockout Feature", "Locks out Battle Litany while it is available and more than 3s remain on its buff, to prevent overwriting raid buffs.", DRG.JobID, DRG.BattleLitany)]
        DragoonLitanyLockoutFeature = 2219,

        #endregion
        // ====================================================================================
        #region DARK KNIGHT

        // unused enums: 3204
        // last used enum: 3213

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
        [ParentCombo(DarkStalwartSoulCombo)]
        [CustomComboInfo("Stalwart Soul to Disesteem", "Replace Stalwart Soul's combo with Disesteem while it is available.", DRK.JobID, DRK.StalwartSoul, DRK.Unleash)]
        DarkStalsteemFeature = 3213,

        [OrderedEnum]
        [SecretCustomCombo]
        [ParentCombo(DarkStalwartSoulCombo)]
        [CustomComboInfo("Evil Stalwart Soul Combo", "Replace Unleash with its combo chain, instead.", DRK.JobID, DRK.StalwartSoul, DRK.Unleash)]
        DarkEvilStalwartSoulCombo = 3205,

        [OrderedEnum]
        [CustomComboInfo("Dark Knight Gauge Overcap Feature", "Replace AoE combo with gauge spender if you are about to overcap.", DRK.JobID, DRK.StalwartSoul)]
        DRKOvercapFeature = 3203,

        [OrderedEnum]
        [CustomComboInfo("Delirium Feature", "Replaces Carve and Spit with Delirium if its cooldown is up .", DRK.JobID, DRK.CarveAndSpit)]
        DarkDeliriumFeature = 3206,

        [OrderedEnum]
        [CustomComboInfo("Edge to Flood Feature", "Replaces Edge of Darkness/Shadow with Flood of Darkness/Shadow if currently using your AoE combo (as well as synced content before you unlock Edge).", DRK.JobID, DRK.EdgeOfDarkness, DRK.EdgeOfShadow)]
        DarkEdgeToFloodFeature = 3209,

        [OrderedEnum]
        [CustomComboInfo("Bloodspiller to Quietus Feature", "Replaces Bloodspiller with Quietus if currently using your AoE combo.", DRK.JobID, DRK.Bloodspiller)]
        DarkBloodspillerToQuietusFeature = 3210,

        [OrderedEnum]
        [CustomComboInfo("Carve and Spit to Abyssal Drain", "Replaces Carve and Spit with Abyssal Drain if currently using your AoE combo.", DRK.JobID, DRK.CarveAndSpit)]
        DarkCarveToDrainFeature = 3211,

        [OrderedEnum]
        [CustomComboInfo("The Blackest Night to Oblation", "Replaces The Blackest Night with Oblation if The Blackest Night is on cooldown, Oblation is usable, and you currently do not have it applied to yourself.", DRK.JobID, DRK.TheBlackestNight)]
        DarkTBNToOblationFeature = 3212,

        #endregion
        // ====================================================================================
        #region GUNBREAKER

        // last used enum: 3719

        [OrderedEnum]
        [CustomComboInfo("Solid Barrel Combo", "Replace Solid Barrel with its combo chain.", GNB.JobID, GNB.SolidBarrel)]
        GunbreakerSolidBarrelCombo = 3701,

        [OrderedEnum]
        [ParentCombo(GunbreakerSolidBarrelCombo)]
        [CustomComboInfo("Solid Barrel to Lightning Shot", "Replace Solid Barrel's combo with Lightning Shot while out of melee range.", GNB.JobID, GNB.SolidBarrel)]
        GunbreakerSolidShotFeature = 3714,

        [OrderedEnum]
        [ParentCombo(GunbreakerSolidBarrelCombo)]
        [CustomComboInfo("Solid Barrel Combo to Burst Strike", "In addition to the Solid Barrel Combo, add Burst Strike when charges are full.", GNB.JobID, GNB.SolidBarrel)]
        GunbreakerBurstStrikeFeature = 3710,

        [OrderedEnum]
        [CustomComboInfo("Gnashing Fang Continuation", "Replace Gnashing Fang with Continuation when appropriate.", GNB.JobID, GNB.GnashingFang)]
        GunbreakerGnashingFangContinuation = 3702,

        [OrderedEnum]
        [CustomComboInfo("Burst Strike Continuation", "Replace Burst Strike with Continuation when appropriate.", GNB.JobID, GNB.BurstStrike)]
        GunbreakerBurstStrikeCont = 3703,

        [OrderedEnum]
        [CustomComboInfo("Fated Circle Continuation", "Replace Fated Circle with Continuation when appropriate.", GNB.JobID, GNB.FatedCircle)]
        GunbreakerFatedCircleContinuation = 3716,

        [OrderedEnum]
        [CustomComboInfo("Demon Slaughter Combo", "Replace Demon Slaughter with its combo chain.", GNB.JobID, GNB.DemonSlaughter, GNB.DemonSlice)]
        GunbreakerDemonSlaughterCombo = 3705,

        [OrderedEnum]
        [SecretCustomCombo]
        [ParentCombo(GunbreakerDemonSlaughterCombo)]
        [CustomComboInfo("Evil Demon Slaughter Combo", "Replace Demon Slice with its combo chain, instead.", GNB.JobID, GNB.DemonSlaughter, GNB.DemonSlice)]
        GunbreakerEvilDemonSlaughterCombo = 3709,

        [OrderedEnum]
        [ParentCombo(GunbreakerDemonSlaughterCombo)]
        [CustomComboInfo("Demon Slaughter Combo to Fated Circle", "In addition to the Demon Slaughter combo, add Fated Circle when charges are full.", GNB.JobID, GNB.DemonSlaughter, GNB.DemonSlice)]
        GunbreakerFatedCircleFeature = 3706,

        [OrderedEnum]
        [ParentCombo(GunbreakerDemonSlaughterCombo)]
        [CustomComboInfo("Demon Slaughter Combo to Lion Heart Combo", "Replace the Demon Slaughter combo with the Lion Heart (Reign of Beasts) combo when available.", GNB.JobID, GNB.DemonSlaughter, GNB.DemonSlice)]
        GunbreakerDemonHeartFeature = 3718,

        [OrderedEnum]
        [CustomComboInfo("Burst Strike to Fated Circle", "Replace Burst Strike with Fated Circle if you are currently using your AoE combo.", GNB.JobID, GNB.BurstStrike)]
        GunbreakerBurstStrikeToFatedCircleFeature = 3715,

        [OrderedEnum]
        [CustomComboInfo("Burst Strike/Fated Circle to Double Down", "Replace Burst Strike and Fated Circle with Double Down when it is available.", GNB.JobID, GNB.BurstStrike, GNB.FatedCircle)]
        GunbreakerDoubleDownFeature = 3711,

        [OrderedEnum]
        [CustomComboInfo("Burst Strike/Fated Circle to Lion Heart Combo", "Replace Burst Strike and Fated Circle with the Lion Heart combo when it is available.", GNB.JobID, GNB.BurstStrike, GNB.FatedCircle)]
        GunbreakerBurstHeartFeature = 3717,

        [OrderedEnum]
        [CustomComboInfo("No Mercy to Bow Shock", "Replace No Mercy with Bow Shock while No Mercy is active.\nIf No Mercy is currently Sonic Break, it will only take effect while the GCD is rolling.", GNB.JobID, GNB.NoMercy)]
        GunbreakerNoMercyFeature = 3708,

        [OrderedEnum]
        [CustomComboInfo("No Mercy to Double Down", "Replace No Mercy with Double Down while No Mercy is active and it is off-cooldown.\nThis takes priority over Bow Shock/Sonic Break if the No Mercy feature is enabled.", GNB.JobID, GNB.NoMercy)]
        GunbreakerNoMercyDoubleDownFeature = 3712,

        [OrderedEnum]
        [CustomComboInfo("Bloodfest to No Mercy", "Replace Bloodfest with No Mercy while only the former of the two is on cooldown.", GNB.JobID, GNB.Bloodfest)]
        GunbreakerBloodfestNoMercyFeature = 3719,

        #endregion
        // ====================================================================================
        #region MACHINIST

        // last used enum: 3114

        [OrderedEnum]
        [ConflictingCombos(MachinistHypercomboOption)]
        [CustomComboInfo("(Heated) Shot Combo", "Replace either form of Clean Shot with its combo chain.", MCH.JobID, MCH.CleanShot, MCH.HeatedCleanShot)]
        MachinistMainCombo = 3101,

        [OrderedEnum]
        [CustomComboInfo("Spread Shot Heat", "Replace Spread Shot with Auto Crossbow when overheated.", MCH.JobID, MCH.SpreadShot, MCH.Scattergun)]
        MachinistSpreadShotFeature = 3102,

        [OrderedEnum]
        [CustomComboInfo("Hypercharge Feature", "Replace Heat Blast and Auto Crossbow with Hypercharge when not overheated.", MCH.JobID, MCH.HeatBlast, MCH.BlazingShot, MCH.AutoCrossbow)]
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
        [CustomComboInfo("Drill to Bioblaster", "Drill becomes Bioblaster if Reassemble is not active and your last combo action was Spread Shot/Scattergun.", MCH.JobID, MCH.Drill)]
        MachinistBioDrillFeature = 3114,

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
        [CustomComboInfo("Chainsaw Cycling Feature", "Replace Chainsaw with Air Anchor and Drill, based on the priority of each cooldown. Does not replace any other actions, so you can easily watch their cooldowns.", MCH.JobID, MCH.Chainsaw)]
        MachinistChainsawFeature = 3113,

        [OrderedEnum]
        [SecretCustomCombo]
        [ParentCombo(MachinistChainsawFeature)]
        [CustomComboInfo("Reassemble to Chainsaw", "Reassemble becomes Chainsaw's cycling actions while Reassemble is active.", MCH.JobID, MCH.Reassemble)]
        MachinistReassembleFeature = 3111,

        #endregion
        // ====================================================================================
        #region MONK

        // latest enum: 2034

        [OrderedEnum]
        [CustomComboInfo("Leaping Opo Combo", "Replace Leaping Opo/Bootshine with Monk's Leaping Opo/Rising Raptor/Pouncing Coeurl combo.", MNK.JobID, MNK.LeapingOpo, MNK.Bootshine)]
        MonkOpoCombo = 2019,

        [OrderedEnum]
        [CustomComboInfo("Dragon Kick Combo", "Replace Dragon Kick with Monk's Dragon Kick combo.", MNK.JobID, MNK.DragonKick)]
        MonkDragonKickCombo = 2020,

        [OrderedEnum]
        [ConflictingCombos(MonkAoEComboFormOption)]
        [CustomComboInfo("Form Shift to Twin Snakes", "Replace Form Shift with Twin Snakes during Perfect Balance.", MNK.JobID, MNK.FormShift)]
        MonkFormSnakes = 2032,

        [OrderedEnum]
        [ConflictingCombos(MonkPerfectBalanceFeatureLockout)]
        [CustomComboInfo("Perfect Balance to Demolish", "Replace Perfect Balance with Demolish while in Perfect Balance, so you don't need it on your bar separately.", MNK.JobID, MNK.PerfectBalance)]
        MonkPerfectBalanceDemolishFeature = 2026,

        [OrderedEnum]
        [CustomComboInfo("Meditation Reminder", "Your GCDs become Meditate out of combat if you don't have the Fifth Chakra open.", MNK.JobID, MNK.TwinSnakes, MNK.TrueStrike, MNK.RisingRaptor, MNK.FormShift, MNK.SnapPunch, MNK.PouncingCoeurl, MNK.Demolish, MNK.Bootshine, MNK.LeapingOpo, MNK.DragonKick, MNK.MasterfulBlitz, MNK.Rockbreaker, MNK.ArmOfTheDestroyer, MNK.ShadowOfTheDestroyer, MNK.FourPointFury, MNK.SixSidedStar, PLD.TotalEclipse, MNK.PerfectBalance)]
        MonkMeditationReminder = 2013,

        [OrderedEnum]
        [CustomComboInfo("AoE Combo", "Replaces Masterful Blitz (for bug reasons) with the AoE combo chain, or whatever your most damaging move is when Perfect Balance is active.\nFour-Point Fury becomes AoE combo chain in order of forms during Perfect Balance.\nMasterful Blitz replaces the AoE combo when you have 3 Beast Chakra.", MNK.JobID, MNK.MasterfulBlitz, MNK.FourPointFury, MNK.FormShift, PLD.TotalEclipse)]
        MonkAoECombo = 2001,

        [OrderedEnum]
        [ParentCombo(MonkAoECombo)]
        [CustomComboInfo("Experimental No-Blitz Option", "Enabling this option makes it so that Total Eclipse is the basis for your main AoE combo, and Masterful Blitz is untouched.\n" +
            "To get Total Eclipse onto your Monk hotbar, use a shared hotbar, a macro, or a plugin like ReAction.", MNK.JobID)]
        MonkAoEComboBlitzOption = 2027,

        [OrderedEnum]
        [ParentCombo(MonkAoECombo)]
        [ConflictingCombos(MonkFormSnakes)]
        [CustomComboInfo("Form Shift Option", "Enabling this option has Form Shift turn into 1-2-3 AoE combo in Perfect Balance.", MNK.JobID, MNK.FormShift)]
        MonkAoEComboFormOption = 2009,

        [OrderedEnum]
        [ParentCombo(MonkAoECombo)]
        [CustomComboInfo("Meditation Feature", "Replaces AoE combo with Howling Fist/Enlightment if you have the Fifth Chakra open, have a target, and you have just used an action.", MNK.JobID, MNK.MasterfulBlitz)]
        MonkAoEMeditationFeature = 2014,

        // [OrderedEnum]
        // [ParentCombo(MonkAoECombo)]
        // [CustomComboInfo("Monk AoE Balance Feature", "Replaces Monk's AoE Combo with Masterful Blitz if you have 3 Beast Chakra.", MNK.JobID, MNK.Rockbreaker)]
        // MonkAoEBalanceFeature = 2006,

        [OrderedEnum]
        [CustomComboInfo("Draconic Leap", "Replaces Dragon Kick with Leaping Opo/Bootshine if Opo-Opo's Fury is up, as well as vice versa for Leaping Opo in combos.", MNK.JobID, MNK.DragonKick, MNK.Bootshine, MNK.LeapingOpo)]
        MonkDragonKickBootshineFeature = 2002,

        [OrderedEnum]
        [CustomComboInfo("Twin Raptors", "Replaces Twin Snakes with Rising Raptor/True Strike if Raptor's Fury is up, as well as vice versa for Rising Raptor in combos.", MNK.JobID, MNK.TwinSnakes)]
        MonkTwinRaptorsFeature = 2030,

        [OrderedEnum]
        [CustomComboInfo("Demolishing Pounce", "Replaces Demolish with Pouncing Coeurl/Snap Punch if Coeurl's Fury is up, as well as vice versa for Pouncing Coeurl in combos.", MNK.JobID, MNK.Demolish)]
        MonkDemolishingPounceFeature = 2031,

        [OrderedEnum]
        [CustomComboInfo("Perfect Balance Fury Option", "With this enabled, the three above Fury features only apply during Perfect Balance or Form Shift.", MNK.JobID, MNK.DragonKick)]
        MonkPerfectBalanceFuryOption = 2033,

        [OrderedEnum]
        [CustomComboInfo("Dragon Kick/Leaping Opo Balance Feature", "Replaces Dragon Kick and Leaping Opo with Masterful Blitz if you have 3 Beast Chakra.", MNK.JobID, MNK.DragonKick, MNK.Bootshine, MNK.LeapingOpo)]
        MonkDragonKickBalanceFeature = 2005,

        [OrderedEnum]
        [CustomComboInfo("Leaping Dragon Clap Feature", "Replaces Dragon Kick and Leaping Opo with Thunderclap if you are out of melee range, or have a player targeted.", MNK.JobID, MNK.DragonKick, MNK.Bootshine, MNK.LeapingOpo)]
        MonkDragonClapFeature = 2022,

        [OrderedEnum]
        [CustomComboInfo("Dragon Kick to Forbidden Chakra", "Replaces Dragon Kick and Leaping Opo with Forbidden Chakra while available, during global cooldown.", MNK.JobID, MNK.DragonKick, MNK.Bootshine, MNK.LeapingOpo)]
        MonkChakraKickFeature = 2034,

        [OrderedEnum]
        [CustomComboInfo("Forbidden Chakra to Enlightment Feature", "Replaces Forbidden Chakra with Enlightenment if your last-used GCD action was Arm/Shadow of the Destroyer, Four-Point Fury, or Rockbreaker.", MNK.JobID, MNK.Meditation, MNK.SteeledMeditation)]
        MonkChakraToEnlightmentFeature = 2025,

        [OrderedEnum]
        [CustomComboInfo("Perfect Balance Feature", "Perfect Balance becomes Masterful Blitz while you have 3 Beast Chakra.", MNK.JobID, MNK.PerfectBalance)]
        MonkPerfectBalanceFeature = 2004,

        [OrderedEnum]
        [ParentCombo(MonkPerfectBalanceFeature)]
        [CustomComboInfo("Perfect Balance Feature: Lockout", "Perfect Balance becomes a useless action while Perfect Balance is active.", MNK.JobID, MNK.PerfectBalance)]
        MonkPerfectBalanceFeatureLockout = 2021,

        [OrderedEnum]
        [CustomComboInfo("Riddle of Fire to Brotherhood", "Riddle of Fire becomes Brotherhood if Brotherhood is on cooldown.", MNK.JobID, MNK.RiddleOfFire)]
        MonkRiddleToBrotherFeature = 2011,

        [OrderedEnum]
        [CustomComboInfo("Riddle of Fire to Riddle of Wind", "Riddle of Fire becomes Riddle of Wind if the former is on cooldown and the latter is not.\nIf Riddle of Fire to Brotherhood is enabled, Brotherhood takes priority.", MNK.JobID, MNK.RiddleOfFire)]
        MonkRiddleToRiddleFeature = 2012,

        [OrderedEnum]
        [CustomComboInfo("Brotherhood Lockout Feature", "Brotherhood is locked out while it is available and more than 3s are left on its buff, to prevent overwriting raid buffs.", MNK.JobID, MNK.Brotherhood)]
        MonkBrotherhoodLockoutFeature = 2028,

        #endregion
        // ====================================================================================
        #region NINJA

        // last used: 3025

        [OrderedEnum]
        [CustomComboInfo("Aeolian Edge Combo", "Replace Aeolian Edge with its combo chain.", NIN.JobID, NIN.AeolianEdge)]
        NinjaAeolianEdgeCombo = 3002,

        [OrderedEnum]
        [ParentCombo(NinjaAeolianEdgeCombo)]
        [CustomComboInfo("Aeolian Edge to Throwing Dagger", "Replace Aeolian Edge combo with Throwing Dagger if you are out of range.", NIN.JobID, NIN.ThrowingDagger)]
        NinjaThrowingEdgeFeature = 3021,

/*        [OrderedEnum]
        [ParentCombo(NinjaAeolianEdgeCombo)]
        [CustomComboInfo("Aeolian Edge to Armor Crush", "Replace Aeolian Edge with Armor Crush in its combo if you do not have its buff applied.", NIN.JobID, NIN.AeolianEdge)]
        NinjaAeolianCrushFeature = 3024,*/

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
        [CustomComboInfo("Kassatsu to Kunai's Bane", "Replaces Kassatsu with Kunai's Bane/Trick Attack while Suiton is up and Kassatsu is on cooldown, or Hidden is up.", NIN.JobID, NIN.Kassatsu)]
        NinjaKassatsuTrickFeature = 3004,

        [OrderedEnum]
        [CustomComboInfo("Kassatsu to Dream Within a Dream", "Replaces Kassatsu with Dream Within a Dream if the former is on cooldown and the latter is not.\nIf you have Kassatsu to Trick on, Trick Attack takes priority over DwaD.", NIN.JobID, NIN.Kassatsu)]
        NinjaKassatsuDWaDFeature = 3015,

        [OrderedEnum]
        [ConflictingCombos(NinjaDWaDMeisuiFeature)]
        [CustomComboInfo("Dream Within a Dream to Kunai's Bane", "Replaces Dream Within a Dream with Kunai's Bane/Trick Attack while Suiton or Hidden is active.", NIN.JobID, NIN.DreamWithinADream)]
        NinjaDWaDTrickFeature = 3019,

        [OrderedEnum]
        [ConflictingCombos(NinjaDWaDTrickFeature)]
        [CustomComboInfo("Dream Within a Dream to Meisui", "Replaces Dream Within a Dream with Meisui while Suiton is active.", NIN.JobID, NIN.DreamWithinADream)]
        NinjaDWaDMeisuiFeature = 3025,

        [OrderedEnum]
        [CustomComboInfo("Ten Chi Jin to Meisui", "Replaces Ten Chi Jin (the move) with Meisui while Suiton is up.", NIN.JobID, NIN.TenChiJin)]
        NinjaTCJMeisuiFeature = 3005,

        [OrderedEnum]
        [CustomComboInfo("Kassatsu Chi/Jin Feature", "Replaces Chi with Jin while Kassatsu is up if you have Enhanced Kassatsu.", NIN.JobID, NIN.Chi)]
        NinjaKassatsuChiJinFeature = 3006,

        [OrderedEnum]
        [CustomComboInfo("Hide to Dokumori", "Replaces Hide with Dokumori/Mug while in combat.", NIN.JobID, NIN.Hide)]
        NinjaHideMugFeature = 3007,

        [OrderedEnum]
        [CustomComboInfo("Dokumori Lockout Feature", "Locks out Dokumori/Mug while it is available and more than 3s remain on its debuff, to prevent overwriting raid buffs.", NIN.JobID, NIN.Mug, NIN.Dokumori)]
        NinjaMugLockoutFeature = 3023,

        [OrderedEnum]
        [CustomComboInfo("Bhavacakra to Hellfrog Medium", "Replaces Bhavacakra with Hellfrog Medium while you are in the midst of your AoE combo.", NIN.JobID, NIN.Bhavacakra)]
        NinjaBhavacakraToFroggieFeature = 3022,

        [OrderedEnum]
        [ConflictingCombos(NinjaGCDNinjutsuFeature)]
        [CustomComboInfo("Aeolian to Ninjutsu Feature", "Replaces Aeolian Edge (combo) with your current Ninjutsu action if any Mudra are used.", NIN.JobID, NIN.AeolianEdge)]
        NinjaNinjutsuFeature = 3008,

        [OrderedEnum]
        [ConflictingCombos(NinjaNinjutsuFeature)]
        [CustomComboInfo("GCDs to Ninjutsu Feature", "Every non-Mudra GCD becomes your current Ninjutsu action while Mudras are being used.", NIN.JobID, NIN.AeolianEdge, NIN.ArmorCrush, NIN.HakkeMujinsatsu, NIN.DeathBlossom, NIN.ThrowingDagger, NIN.GustSlash, NIN.SpinningEdge, NIN.ForkedRaiju, NIN.FleetingRaiju)]
        NinjaGCDNinjutsuFeature = 3009,

        [OrderedEnum]
        [CustomComboInfo("Ninjutsu Double-Tap Feature", "Double-tapping your last-used mudra executes your current Ninjutsu action, or replaces all three if it is currently Doton/Huton/Suiton/Goka/Hyosho.", NIN.JobID, NIN.Ten, NIN.Chi, NIN.Jin)]
        NinjaTapNinjutsuFeature = 3020,

        [OrderedEnum]
        [CustomComboInfo("Armor Crush / Forked Raiju Feature", "Replaces Armor Crush with Forked Raiju when available.", NIN.JobID, NIN.ArmorCrush)]
        NinjaArmorCrushRaijuFeature = 3012,

        [OrderedEnum]
        [CustomComboInfo("Aeolian Edge / Fleeting Raiju Feature", "Replaces the Aeolian Edge combo with Fleeting Raiju when available.", NIN.JobID, NIN.AeolianEdge)]
        NinjaAeolianEdgeRaijuFeature = 3013,

        [OrderedEnum]
        [CustomComboInfo("Forked/Fleeting Raiju Switch Feature", "Forked/Fleeting Raiju change depending on distance from target (works with the Raiju features).", NIN.JobID, NIN.ForkedRaiju, NIN.FleetingRaiju)]
        NinjaSmartRaijuFeature = 3016,

        #endregion
        // ====================================================================================
        #region PALADIN

        // used enums: 1913, 1901, 1909, 1910, 1906
        // latest enum: 1923

        [OrderedEnum]
        [CustomComboInfo("Royal Authority Combo", "Replace Royal Authority/Rage of Halone with its combo chain.", PLD.JobID, PLD.RoyalAuthority, PLD.RageOfHalone)]
        PaladinRoyalAuthorityCombo = 1902,

        [OrderedEnum]
        [ParentCombo(PaladinRoyalAuthorityCombo)]
        [CustomComboInfo("Royal Authority to Shield Lob", "Replace Royal Authority/Rage of Halone's combo with Shield Lob when out of melee range.", PLD.JobID, PLD.RoyalAuthority, PLD.RageOfHalone)]
        PaladinRoyalLobFeature = 1912,

        [OrderedEnum]
        [CustomComboInfo("Royal Authority to Holy Spirit", "Replace Royal Authority with Holy Spirit while Divine Might is active", PLD.JobID, PLD.RoyalAuthority, PLD.RageOfHalone)]
        PaladinRoyalAuthorityNotBurstStrikeFeature = 1919,

        [OrderedEnum]
        [CustomComboInfo("Royal Authority Atonement Feature", "Replace Royal Authority with Atonement when under the effect of Sword Oath.", PLD.JobID, PLD.RageOfHalone, PLD.RoyalAuthority)]
        PaladinRoyalAuthorityAtonementFeature = 1903,

        [OrderedEnum]
        [ParentCombo(CustomComboPreset.PaladinRoyalAuthorityAtonementFeature)]
        [CustomComboInfo("'Only if Overwrite' Option", "Replace Royal Authority with Atonement only when you are about to overwrite Sword Oath.\nThis will take priority over Holy Spirit if it's also enabled.", PLD.JobID, PLD.RageOfHalone, PLD.RoyalAuthority)]
        PaladinRoyalAuthorityAtonementOption = 1923,

        [OrderedEnum]
        [CustomComboInfo("Shield Lob to Holy Spirit", "Replace Shield Lob with Holy Spirit while Divine Might is active.", PLD.JobID, PLD.ShieldLob)]
        PaladinShieldLobToNotBurstStrikeFeature = 1921,

        [OrderedEnum]
        [ParentCombo(PaladinShieldLobToNotBurstStrikeFeature)]
        [CustomComboInfo("Shield Lob to Holy Spirit Movement Option", "Also replace Shield Lob with Holy Spirit while not moving, even if Divine Might is not active.", PLD.JobID, PLD.ShieldLob)]
        PaladinShieldLobToNotBurstStrikeOption = 1922,

        /*[OrderedEnum]
        [CustomComboInfo("Holy Spirit to Atonement", "Replace Holy Spirit with Atonement while Divine Might or Requiescat are not up.", PLD.JobID, PLD.NotBurstStrike)]
        PaladinNotBurstStrikeToAtonement = 1916,*/

        [OrderedEnum]
        [CustomComboInfo("Prominence Combo", "Replace Prominence with its combo chain.", PLD.JobID, PLD.Prominence, PLD.TotalEclipse)]
        PaladinProminenceCombo = 1904,

        [OrderedEnum]
        [ParentCombo(PaladinProminenceCombo)]
        [CustomComboInfo("AoE Combo to Holy Circle", "Add Holy Circle before Prominence in your combo if Divine Might is active.", PLD.JobID)]
        PaladinNotFatedCircleOvercapFeature = 1918,

        [OrderedEnum]
        [SecretCustomCombo]
        [ParentCombo(PaladinProminenceCombo)]
        [CustomComboInfo("Evil Prominence Combo", "Replace Total Eclipse with its combo chain, instead.", PLD.JobID, PLD.Prominence, PLD.TotalEclipse)]
        PaladinEvilProminenceCombo = 1907,

        [OrderedEnum]
        [CustomComboInfo("Imperator Confiteor", "Replace Imperator/Requiescat with Confiteor while active. Includes Confiteor combo.", PLD.JobID, PLD.Requiescat, PLD.Imperator)]
        PaladinRequiescatCombo = 1905,

        [OrderedEnum]
        [ParentCombo(PaladinRequiescatCombo)]
        [CustomComboInfo("Requiescat Confiteor Level-sync Feature", "Replace Requiescat with Holy Spirit if Confiteor is not available, or already used and its combo is not unlocked.", PLD.JobID, PLD.Requiescat, PLD.Imperator)]
        PaladinRequiescatComboSpirit = 1917,

        [OrderedEnum]
        [CustomComboInfo("Confiteor Feature", "Replace Holy Spirit/Circle with Confiteor and its combo when it is available, as well as Blade of Honor.", PLD.JobID, PLD.NotBurstStrike, PLD.NotFatedCircle)]
        PaladinConfiteorFeature = 1906,

        [OrderedEnum]
        [CustomComboInfo("AoE Combo to Imperator Spells", "Replace your AoE combo actions with applicable spells while you have Imperator is active.", PLD.JobID, PLD.TotalEclipse, PLD.Prominence)]
        PaladinNotFatedCircleFeature = 1910,

        [OrderedEnum]
        [CustomComboInfo("Holy Spirit to Holy Circle", "Replace Holy Spirit with Holy Circle if your last combo action was Total Eclipse or Prominence.", PLD.JobID, PLD.NotBurstStrike)]
        PaladinHolySpiritToHolyCircleFeature = 1914,

        [OrderedEnum]
        [CustomComboInfo("Fight or Flight to Imperator", "Replace Fight or Flight with Imperator/Requiescat while the effect is active, as well as Blade of Honor.\nIf Fight or Flight is currently Goring Blade, this only will take effect during the global cooldown.", PLD.JobID, PLD.NotNoMercy)]
        PaladinNotNoMercyToRequiescat = 1920,

/*        [OrderedEnum]
        [CustomComboInfo("Fight or Flight to Goring Blade", "Replace Fight or Flight with Goring Blade while the effect is active.", PLD.JobID, PLD.NotNoMercy)]
        PaladinNotNoMercyToNotSonicBreak = 1915,*/

        [OrderedEnum]
        [CustomComboInfo("Shield Blash to Low Blow", "Replace Shield Bash to Low Blow when it is on cooldown.\nAlso works with Tank Interrupt feature.", PLD.JobID, PLD.ShieldBash)]
        PaladinLowBashFeature = 1911,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Scornful Spirits Feature", "Replace Spirits Within and Circle of Scorn with whichever is available soonest.", PLD.JobID, PLD.SpiritsWithin, PLD.Expiacion, PLD.CircleOfScorn)]
        PaladinScornfulSpiritsFeature = 1908,

        #endregion
        // ====================================================================================
        #region PICTOMANCER

        // last used enum: 4210

        [OrderedEnum]
        [CustomComboInfo("Subtracting Your Combos", "Replace your normal combos with subtractive combos while you have Subtractive Palette active.", PCT.JobID, PCT.FireInRed, PCT.Fire2InRed)]
        PictSubFeature = 4201,

        [OrderedEnum]
        [SecretCustomCombo]
        [ParentCombo(PictSubFeature)]
        [CustomComboInfo("Cleansing Your Palette", "Replace your combos with Subtractive Palette if your next action will overcap gauge.", PCT.JobID, PCT.FireInRed, PCT.Fire2InRed)]
        PictSubOvercapOption = 4207,

        [OrderedEnum]
        [ParentCombo(PictSubFeature)]
        [CustomComboInfo("Hallowed Movement", "Replace your combos with Holy in White if you are moving and don't have an instant cast.", PCT.JobID, PCT.FireInRed, PCT.Fire2InRed)]
        PictSubMovementOption = 4208,

        [OrderedEnum]
        [CustomComboInfo("Holy Comets!", "Replace Holy in White with Comet in Black when available.", PCT.JobID, PCT.HolyInWhite)]
        PictCometFeature = 4202,

        [OrderedEnum]
        [CustomComboInfo("A Motif for a Muse", "Replace your motifs with muses when you already have those motifs active.", PCT.JobID, PCT.CreatureMotif, PCT.WeaponMotif, PCT.LandscapeMotif)]
        PictMotifFeature = 4204,

        [OrderedEnum]
        [CustomComboInfo("Steel Your Hammers", "Replace Steel Muse with Hammer Stamp when available.", PCT.JobID, PCT.SteelMuse)]
        PictHammerFeature = 4205,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Subtract Your Comets Before It's Too Late!", "Replace Subtractive Palette with Comet in Black if available to prevent overwriting.", PCT.JobID, PCT.SubtractivePalette)]
        PictSubCometFeature = 4210,

        [OrderedEnum]
        [CustomComboInfo("Prisms in your Starscape", "Replace Scenic Muse with Star Prism when available.", PCT.JobID, PCT.ScenicMuse)]
        PictStarFeature = 4206,

        #endregion
        // ====================================================================================
        #region REAPER

        // latest enum: 3926

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
        [CustomComboInfo("Gibbets and Gallows Combo", "Gibbet becomes Gallows when Gallows is enhanced and vice-versa, but only in combo. It is removed from Shadow of Death/Soul Slice as a result after one is enhanced.", RPR.JobID, RPR.Gibbet, RPR.Gallows)]
        ReaperGibbetGallowsComboOption = 3925,

        [OrderedEnum]
        [ParentCombo(ReaperGibbetGallowsFeature)]
        [CustomComboInfo("Gibbets and Gallows Soul Slice Option", "Have Soul Slice be replaced in the Gibbets and Gallows Feature instead of Shadow of Death.", RPR.JobID, RPR.Slice, RPR.ShadowOfDeath, RPR.SoulSlice)]
        ReaperGibbetGallowsSoulSliceOption = 3919,

        [OrderedEnum]
        [ParentCombo(ReaperGibbetGallowsSoulSliceOption)]
        [CustomComboInfo("Gibbet and Gallows Shroud Decombo", "Uncombos Void/Cross Reaping and spreads them across Soul Slice/Slice Combo.", RPR.JobID, RPR.Slice)]
        ReaperGibbetGallowsShroudOption = 3920,

        [OrderedEnum]
        [CustomComboInfo("Enhanced Gallows and Gibbets Feature", "Gibbet becomes Gallows when Gallows is enhanced and vice-versa.", RPR.JobID, RPR.Gibbet, RPR.Gallows)]
        ReaperGibbetGallowsOption = 3905,

        [OrderedEnum]
        [ParentCombo(ReaperGibbetGallowsOption)]
        [CustomComboInfo("Shroud Only Option", "Only swap Gibbet/Gallows when Enshrouded.", RPR.JobID, RPR.Gibbet, RPR.Gallows)]
        ReaperGibbetGallowsShroudOnlyOption = 3924,

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
        [CustomComboInfo("Sacrificium Feature", "While under Void Shroud and Sacrificium is available, replace Gibbet/Gallows/Guillotine with Sacrificium during global cooldown.", RPR.JobID, RPR.Slice, RPR.InfernalSlice, RPR.Gibbet, RPR.Gallows, RPR.Guillotine, RPR.SpinningScythe, RPR.NightmareScythe)]
        ReaperSacrificiumFeature = 3926,

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

        // latest enum: 3526

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
        [CustomComboInfo("Verproc into Jolt", "Replaces Verstone/Verfire with Jolt/Scorch when no proc is available. In the strange gap between level 84-93 where Jolt 3 is always better, Verstone/verfire will always be replaced with Jolt 3.", RDM.JobID, RDM.Verstone, RDM.Verfire, RDM.Verthunder, RDM.Verthunder3)]
        RedMageVerprocCombo = 3504,

        [OrderedEnum]
        [ParentCombo(RedMageVerprocCombo)]
        [ConflictingCombos(RedMageVerprocComboVerstoneOption)]
        [CustomComboInfo("Verproc into Jolt Verfire Opt Out", "Verfire does NOT change into Jolt (or any Jolt-related actions).", RDM.JobID, RDM.Verstone, RDM.Verfire)]
        RedMageVerprocComboVerfireOption = 3524,

        [OrderedEnum]
        [ParentCombo(RedMageVerprocCombo)]
        [ConflictingCombos(RedMageVerprocComboVerfireOption)]
        [CustomComboInfo("Verproc into Jolt Verstone Opt Out", "Verstone does NOT change into Jolt (or any Jolt-related actions).", RDM.JobID, RDM.Verstone, RDM.Verfire)]
        RedMageVerprocComboVerstoneOption = 3525,

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
        [ParentCombo(RedMageVerprocComboPlus)]
        [CustomComboInfo("Verproc into Jolt Plus Verthunder Option", "Verthunder is used as the base for the black magic side of Verproc into Jolt, not Verfire.\nThis is so you can use Verfire by itself even with acceleration up to use a slightly more optimal opener.", RDM.JobID, RDM.Verthunder)]
        RedMageVerprocComboVerthunderOption = 3526,


        [OrderedEnum]
        [ParentCombo(RedMageVerprocCombo)]
        [CustomComboInfo("Verproc to Jolt 3 Optimization", "Changes Verstone/Verfire to Jolt 3 when it is a DPS gain.", RDM.JobID, RDM.Verstone, RDM.Verfire)]
        RedMageVerprocJolt3Option = 3527,


        [OrderedEnum]
        [ParentCombo(RedMageVerprocComboPlus)]
        [CustomComboInfo("Verproc into Jolt Plus Option", "Verstone/Verfire never get replaced by their respective long cast (Veraero/Verthunder) if usable (unless both are usable).\nMildly incompatible with current RDM opener.", RDM.JobID, RDM.Verstone, RDM.Verfire)]
        RedMageVerprocComboPlusOption = 3523,

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
        [CustomComboInfo("Moulinet Lockout Feature", "Prevents you from using Moulinet below 50/50 gauge by replacing it with Physick if you have Verflare unlocked.", RDM.JobID, RDM.Moulinet)]
        RedMageMoulinetReminderFeature = 3514,

        [OrderedEnum]
        [CustomComboInfo("Embolden to Manafication", "Replaces Embolden with Manafication if the former is on cooldown and the latter is not.", RDM.JobID, RDM.Embolden)]
        RedMageEmboldenFeature = 3511,

        [OrderedEnum]
        [CustomComboInfo("Embolden Lockout Feature", "Locks out Embolden if it is available and more than 3s remain on its buff, to prevent overwriting raid buffs.", RDM.JobID, RDM.Embolden)]
        RedMageEmboldenLockoutFeature = 3522,

        [OrderedEnum]
        [CustomComboInfo("Acceleration to Swiftcast", "Replaces Acceleration with Swiftcast if the former is on cooldown and the latter is not.", RDM.JobID, RDM.Acceleration)]
        RedMageAccelerationFeature = 3512,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Fleche to Contre-Sixte", "Replaces Fleche with Contre-Sixte if the former is on cooldown and the latter is not.", RDM.JobID, RDM.Fleche)]
        RedMageContreSixteFeature = 3513,

        [OrderedEnum]
        [CustomComboInfo("Red Mage Lucid Dreaming Reminder", "All your non-role action cooldowns (that don't have charges) become Lucid Dreaming if they aren't up and Lucid Dreaming is, and you have less-than-or-equal-to a set amount of MP.", RDM.JobID, RDM.Embolden, RDM.Manafication, RDM.Fleche, RDM.ContreSixte)]
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
        [CustomComboInfo("Phlegma into Eukrasian Dyskrasia", "Phlegma turns into Eukrasian Dyskrasia when you have Eukrasia active.", SGE.JobID, SGE.Phlegma, SGE.Phlegmara, SGE.Phlegmaga)]
        SagePhlegmaDysBalls = 4011,

        [OrderedEnum]
        [CustomComboInfo("Phlegma into Toxikon", "Phlegma turns into Toxikon if you have addersting and are either out of range or out of charges.\nThis is prioritized over Dyskrasia if the 'Phlegma into Dyskrasia' feature is enabled.", SGE.JobID, SGE.Phlegma, SGE.Phlegmara, SGE.Phlegmaga)]
        SagePhlegmaToxicBalls = 4003,

        [OrderedEnum]
        [CustomComboInfo("Phlegma into Psyche", "Phlegma turns into Psyche while the GCD is rolling and it is off cooldown.", SGE.JobID, SGE.Phlegma, SGE.Phlegmara, SGE.Phlegmaga)]
        SagePhlegmaPsychicBalls = 4010,

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
        [CustomComboInfo("Sage Lucid Dreaming Reminder", "All your non-role action cooldowns (that don't have charges) become Lucid Dreaming if they aren't up and Lucid Dreaming is, and you have less-than-or-equal-to a set amount of MP.", SGE.JobID, SGE.Kardia, SGE.Soteria, SGE.Zoe, SGE.Pepsis, SGE.Physis, SGE.Physis2, SGE.Ixochole, SGE.Holos, SGE.Rhizomata, SGE.Krasis, SGE.Kerachole, SGE.Taurochole, SGE.Haima, SGE.Panhaima, SGE.Pneuma)]
        SageLucidReminderFeature = 4005,

        #endregion
        // ====================================================================================
        #region SAMURAI

        [OrderedEnum]
        [CustomComboInfo("Gekko Combo", "Replace Gekko with its combo chain.", SAM.JobID, SAM.Gekko)]
        SamuraiGekkoCombo = 3402,

        [OrderedEnum]
        [ParentCombo(SamuraiGekkoCombo)]
        [CustomComboInfo("Gekko Combo Option", "Start the Gekko combo chain with Jinpu instead of Gyofu/Hakaze.", SAM.JobID, SAM.Gekko)]
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
        [CustomComboInfo("Kasha Combo Option", "Start the Kasha combo chain with Shifu instead of Gyofu/Hakaze.", SAM.JobID, SAM.Kasha)]
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
        [CustomComboInfo("Tsubame-gaeshi to Shoha", "Replace Tsubame-gaeshi with Shoha when meditation is 3 and either you have used Tsubame or it wouldn't clip the GCD.", SAM.JobID, SAM.TsubameGaeshi)]
        SamuraiTsubameGaeshiShohaFeature = 3407,

        [OrderedEnum]
        [ConflictingCombos(SamuraiTsubameGaeshiIaijutsuFeature)]
        [CustomComboInfo("Iaijutsu to Tsubame-gaeshi", "Replace Iaijutsu with Tsubame-gaeshi when Sen is empty.", SAM.JobID, SAM.Iaijutsu)]
        SamuraiIaijutsuTsubameGaeshiFeature = 3408,

        [OrderedEnum]
        [ConflictingCombos(SamuraiTsubameGaeshiShohaFeature)]
        [CustomComboInfo("Iaijutsu to Shoha", "Replace Iaijutsu with Shoha when meditation is 3 and either you have used Tsubame or for a short period of time after Iaijutsu.", SAM.JobID, SAM.Iaijutsu)]
        SamuraiIaijutsuShohaFeature = 3409,

        [OrderedEnum]
        [CustomComboInfo("Ogi-Namikiri to Shoha", "Replace Ogi-Namikiri with Shoha when meditation is 3 and either you have used Tsubame or it wouldn't clip the GCD.", SAM.JobID, SAM.Ikishoten, SAM.OgiNamikiri)]
        SamuraiNamikiriShohaFeature = 3423,

        [OrderedEnum]
        [CustomComboInfo("Iaijutsu/Tsubame to Shoha Persistence Option", "Makes it so Shoha doesn't disappear after a short amount of time after Iaijutsu.", SAM.JobID, SAM.Iaijutsu, SAM.TsubameGaeshi)]
        SamuraiShohaGCDOption = 3421,

        [OrderedEnum]
        [CustomComboInfo("Iaijutsu/Tsubame to Shoha Inbetween Option", "Makes it so Shoha doesn't appear inbetween Iaijutsu and Tsubame.", SAM.JobID, SAM.Iaijutsu, SAM.TsubameGaeshi)]
        SamuraiShohaBetweenOption = 3422,

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
        [CustomComboInfo("Yukikaze to Meditate", "Replace Yukikaze with Meditate while you have no target.", SAM.JobID, SAM.Yukikaze)]
        SamuraiYukikazeMeditateFeature = 3426,

        #endregion
        // ====================================================================================
        #region SCHOLAR

        // latest enum: 2811

        [OrderedEnum]
        [CustomComboInfo("Adloquium to Physick Level Sync", "Change Adloquium to Physick when level-synced.", SCH.JobID, SCH.Adloquium)]
        ScholarAdloPhysickSyncFeature = 2810,

        [OrderedEnum]
        [CustomComboInfo("Seraph Fey Blessing/Consolation", "Change Fey Blessing into Consolation when Seraph is out.\nNot needed anymore, but some people still have the old XIVCombo muscle memory.", SCH.JobID, SCH.FeyBless)]
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
        [CustomComboInfo("Ruin 2 to Chain Stratagem", "Ruin 2 becomes Chain Stratagem for a short while after you have used any action (and if it's off cooldown).", SCH.JobID, SCH.Ruin2)]
        ScholarRuinChainFeature = 2807,

        [OrderedEnum]
        [CustomComboInfo("Chain Stratagem Lockout Feature", "Locks out Chain Stratagem while it is available and more than 3s remain on its debuff, to prevent overwriting raid buffs.", SCH.JobID, SCH.ChainStratagem)]
        ScholarChainLockoutFeature = 2811,

        [OrderedEnum]
        [CustomComboInfo("Ruin 2 Movement Feature", "Ruin/Broil becomes Ruin 2 while you are moving.", SCH.JobID, SCH.Ruin, SCH.Broil, SCH.Broil2, SCH.Broil3, SCH.Broil4)]
        ScholarRuin2MovementFeature = 2809,

        [OrderedEnum]
        [CustomComboInfo("Scholar Lucid Dreaming Reminder", "All your non-role action cooldowns (that don't have charges) become Lucid Dreaming if they aren't up and Lucid Dreaming is, and you have less-than-or-equal-to a set amount of MP.", SCH.JobID, SCH.Aetherflow, SCH.EmergencyTactics, SCH.WhisperingDawn, SCH.FeyIllumination, SCH.FeyBless, SCH.Dissipation, SCH.ChainStratagem, SCH.Indomitability, SCH.Excogitation, SCH.SacredSoil, SCH.Recitation, SCH.DeploymentTactics, SCH.SummonSeraph)]
        ScholarLucidReminderFeature = 2806,

        #endregion
        // ====================================================================================
        #region SUMMONER

        // latest enum: 2721

        [OrderedEnum]
        [CustomComboInfo("Enkindle/Summon Switch", "When (Solar) Bahamut/Phoenix are summoned, Enkindle (Solar) Bahamut/Phoenix will replace Summon (Solar) Bahamut/Phoenix.", SMN.JobID, SMN.SummonBahamut, SMN.SummonPhoenix, SMN.DreadwyrmTrance, SMN.Aethercharge)]
        SummonerDemiCombo = 2701,

        [OrderedEnum]
        [CustomComboInfo("Demi Flow Feature", "When you can use Astral Flow, it will replace Summon (Solar) Bahamut/Summon Phoenix/Dreadwyrm Trance.", SMN.JobID, SMN.SummonBahamut, SMN.SummonPhoenix, SMN.DreadwyrmTrance, SMN.Aethercharge)]
        SummonerDemiFlowFeature = 2716,

        [OrderedEnum]
        [ConflictingCombos(SummonerOutburstOfBrillianceFeature, SummonerRuiningShineFeature)]
        [CustomComboInfo("Shiny Enkindle Feature", "When (Solar) Bahamut/Phoenix are summoned, changes Gemshine and Precious Brilliance with Enkindle.", SMN.JobID, SMN.Gemshine, SMN.PreciousBrilliance)]
        SummonerShinyDemiCombo = 2708,

        [OrderedEnum]
        [ConflictingCombos(SummonerOutburstOfBrillianceFeature, SummonerRuiningShineFeature)]
        [CustomComboInfo("Shiny Flow Feature", "When Bahamut/Phoenix/Solar Bahamut are summoned, changes Gemshine and Precious Brilliance with Astral Flow.", SMN.JobID, SMN.Gemshine, SMN.PreciousBrilliance)]
        SummonerShinyFlowCombo = 2711,

        [OrderedEnum]
        [CustomComboInfo("ED Necrotize", "Change Necrotize/Fester into Energy Drain when out of Aetherflow stacks", SMN.JobID, SMN.Fester, SMN.Necrotize)]
        SummonerEDFesterCombo = 2702,

        [OrderedEnum]
        [CustomComboInfo("ES Painflare", "Change Painflare into Energy Syphon when out of Aetherflow stacks", SMN.JobID, SMN.Painflare)]
        SummonerESPainflareCombo = 2703,

        [OrderedEnum]
        [CustomComboInfo("ES Level Sync", "Change Energy Siphon into Energy Drain when level synced below its acquisition.", SMN.JobID, SMN.Painflare, SMN.EnergySyphon)]
        SummonerEStoED = 2721,

        [OrderedEnum]
        [CustomComboInfo("Mountain Buster Feature", "Gemshine and Precious Brilliance become Mountain Buster while you have Titan's Favor.", SMN.JobID, SMN.Ruin1, SMN.Ruin2, SMN.Ruin3, SMN.Gemshine, SMN.Outburst, SMN.TriDisaster, SMN.PreciousBrilliance)]
        SummonerMountainBusterFeature = 2710,

        [OrderedEnum]
        [CustomComboInfo("Summoning Flow Feature", "When you have Favor, or (Solar) Bahamut/Phoenix are summoned, your summoning actions become Astral Flow.", SMN.JobID, SMN.SummonRuby, SMN.SummonIfrit, SMN.SummonIfrit2, SMN.SummonTopaz, SMN.SummonTitan, SMN.SummonTitan2, SMN.SummonEmerald, SMN.SummonGaruda, SMN.SummonGaruda2)]
        SummonerSummoningFlowFeature = 2712,

        [OrderedEnum]
        [CustomComboInfo("Flowing Ruin Feature", "Change Ruin into Astral Flow when you have Favor, or have Deathflare/Rekindle/Sunflare available and unused.", SMN.JobID, SMN.Ruin1, SMN.Ruin2, SMN.Ruin3, SMN.Gemshine)]
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
        [CustomComboInfo("Flowing Outburst Feature", "Change Outburst/Tri-disaster into Astral Flow when you have Favor, or have Deathflare/Rekindle/Sunflare available and unused.", SMN.JobID, SMN.Outburst, SMN.TriDisaster, SMN.PreciousBrilliance)]
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
        [CustomComboInfo("Carby Feature", "Every action that cannot be used without summoning carbuncle becomes Summon Carbuncle while a pet is not summoned.", SMN.JobID, SMN.RadiantAegis, SMN.Aethercharge, SMN.DreadwyrmTrance, SMN.SummonBahamut, SMN.SummonEmerald,
            SMN.SummonGaruda, SMN.SummonGaruda2, SMN.SummonRuby, SMN.SummonIfrit, SMN.SummonIfrit2, SMN.SummonTopaz, SMN.SummonTitan, SMN.SummonTitan2, SMN.Gemshine, SMN.PreciousBrilliance, SMN.AstralFlow)]
        SummonerCarbyFeature = 2704,

        [OrderedEnum]
        [CustomComboInfo("Searing Light Lockout Feature", "Locks out Searing Light if it is available and more than 3s remain on its buff, to prevent overwriting raid buffs.", SMN.JobID, SMN.SearingLight)]
        SummonerSearingLockoutFeature = 2720,

        [OrderedEnum]
        [CustomComboInfo("Summoner Lucid Dreaming Reminder", "All your non-role action cooldowns (that don't have charges) become Lucid Dreaming if they aren't up and Lucid Dreaming is, and you have less-than-or-equal-to a set amount of MP.", SMN.JobID, SMN.EnergyDrain, SMN.EnergySyphon, SMN.RadiantAegis, SMN.SearingLight, SMN.SummonBahamut, SMN.DreadwyrmTrance, SMN.EnkindleBahamut, SMN.Aethercharge)]
        SummonerLucidReminderFeature = 2713,

        #endregion
        // ====================================================================================
        #region VIPER

        // last used enum: 4116

        [OrderedEnum]
        [CustomComboInfo("Fanged Tails", "Your last-used action becomes Serpent's Tail when it is active.\nIn Reawakening, this applies to *all* your combo actions (because it's pretty hard to track your combo step there).", VPR.JobID, VPR.SteelFangs, VPR.ReavingFangs, VPR.SteelMaw, VPR.ReavingMaw, VPR.HuntersCoil, VPR.SwiftskinsCoil, VPR.HuntersDen, VPR.SwiftskinsDen)]
        ViperTailFeature = 4101,

        [OrderedEnum]
        [CustomComboInfo("Reaving Steel", "Steel/Reaving Fangs/Maw will become whatever current combo starter is empowered.", VPR.JobID, VPR.SteelFangs, VPR.ReavingFangs, VPR.SteelMaw, VPR.ReavingMaw)]
        ViperReavingSteelFeature = 4115,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Striking Fangs", "The last action of your combo will become whatever usable combo ender is currently empowered.", VPR.JobID, VPR.SteelFangs, VPR.ReavingFangs, VPR.SteelMaw, VPR.ReavingMaw)]
        ViperStrikingFangsFeature = 4116,

        [OrderedEnum]
        [CustomComboInfo("Coiling Dens", "Replace your left/right combos with each Coil/Den action while they are available.", VPR.JobID, VPR.SteelFangs, VPR.ReavingFangs, VPR.SteelMaw, VPR.ReavingMaw)]
        ViperCoilFeature = 4102,

        [OrderedEnum]
        [ParentCombo(ViperCoilFeature)]
        [CustomComboInfo("Coiling Dens Coil Swap Option", "Swap the Coil actions for your left/right actions (so Swiftskin's Coil is left and Hunter's Coil is right).", VPR.JobID, VPR.SteelMaw, VPR.ReavingMaw)]
        ViperCoilFeatureSwapOption = 4110,

        [OrderedEnum]
        [ParentCombo(ViperCoilFeature)]
        [CustomComboInfo("Coiling Dens Den Swap Option", "Swap the Den actions for your left/right actions (so Swiftskin's Den is left and Hunter's Den is right).", VPR.JobID, VPR.SteelMaw, VPR.ReavingMaw)]
        ViperCoilFeatureDenSwapOption = 4114,

        [OrderedEnum]
        [ParentCombo(ViperCoilFeature)]
        [CustomComboInfo("Coiling Dens Reawakening Option", "Additionally replace your aoe combos with Third/Fourth Generation instead of First/Second.", VPR.JobID, VPR.SteelMaw, VPR.ReavingMaw)]
        ViperCoilAwakenedOption = 4103,

        [OrderedEnum]
        [CustomComboInfo("Bloody Fangs", "Replace your left/right combos and Coil/Den moves with the Twinfang/blood actions while they are available.", VPR.JobID, VPR.SteelFangs, VPR.ReavingFangs, VPR.SteelMaw, VPR.ReavingMaw, VPR.HuntersCoil, VPR.SwiftskinsCoil, VPR.HuntersDen, VPR.SwiftskinsDen)]
        ViperBloodFangFeature = 4104,

        [OrderedEnum]
        [CustomComboInfo("Twin Tails", "Replace Twinfang/blood with Serpent's Tail when it is active.", VPR.JobID, VPR.Twinfang, VPR.Twinblood)]
        ViperTwinTailsFeature = 4108,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Twisted Twins", "Replace Twinfang/blood with the other when buffed and active.", VPR.JobID, VPR.Twinfang, VPR.Twinblood)]
        ViperTwistedTwinsFeature = 4111,

        [OrderedEnum]
        [CustomComboInfo("Atmospheric Ouroboros", "Replace Fourth Generation with Ouroboros if it is available and you are on your last stack of Anguine Tribute.", VPR.JobID, VPR.ReavingFangs, VPR.ReavingMaw, VPR.SwiftskinsCoil, VPR.SwiftskinsDen)]
        ViperOuroborosFeature = 4105,

        [OrderedEnum]
        [CustomComboInfo("Writhing Steel Fangs", "Replace your Steel Fangs combo with Writhing Snap while out of melee range.", VPR.JobID, VPR.SteelFangs)]
        ViperSteelFangRangedFeature = 4106,

        [OrderedEnum]
        [CustomComboInfo("Slithering Reaving Fangs", "Replace your Reaving Fangs combo with Slither while out of melee range or targeting a player.", VPR.JobID, VPR.ReavingFangs)]
        ViperDreadFangDashFeature = 4107,

        [OrderedEnum]
        [CustomComboInfo("Snapping Fury", "Have Uncoiled Fury replace Writhing Snap if you have Rattling Coil stacks.", VPR.JobID, VPR.WrithingSnap)]
        ViperSnapUncoiledFuryFeature = 4109,

        [OrderedEnum]
        [CustomComboInfo("Twin Fury", "Have Twinfang/Twinblood replace Uncoiled Fury in order when available after Uncoiled Fury.", VPR.JobID, VPR.UncoiledFury)]
        ViperTwinFuryFeature = 4112,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Reawakened Fangs", "Steel Fangs/Maw will become your entire Reawakening combo while it is available.", VPR.JobID, VPR.SteelFangs, VPR.SteelMaw)]
        ViperReawakenedFangsFeature = 4113,

        #endregion
        // ====================================================================================
        #region WARRIOR

        // last used enum: 2118

        [OrderedEnum]
        [CustomComboInfo("Storm's Path Combo", "Replace Storm's Path with its combo chain.", WAR.JobID, WAR.StormsPath)]
        WarriorStormsPathCombo = 2101,

        [OrderedEnum]
        [ParentCombo(WarriorStormsPathCombo)]
        [CustomComboInfo("Storm's Path to Storm's Eye", "Replace Storm's Path in its combo with Storm's Eye if Surging Tempest is not up.\nSince you still want to reapply it before the buff runs out, this is not a button replacement, nor is it an auto-upkeep feature.", WAR.JobID, WAR.StormsPath)]
        WarriorStormsPathEyeFeature = 2116,

        [OrderedEnum]
        [ParentCombo(WarriorStormsPathCombo)]
        [CustomComboInfo("Storm's Path to Tomahawk", "Replace Storm's Path's combo with Tomahawk when out of melee range.", WAR.JobID, WAR.StormsPath)]
        WarriorStormsPathahawkFeature = 2110,

        [OrderedEnum]
        [CustomComboInfo("Storm's Eye Combo", "Replace Storm's Eye with its combo chain.", WAR.JobID, WAR.StormsEye)]
        WarriorStormsEyeCombo = 2102,

        [OrderedEnum]
        [ParentCombo(WarriorStormsEyeCombo)]
        [ConflictingCombos(WarriorStormsEyeslaughtFeature)]
        [CustomComboInfo("Storm's Eye to Tomahawk", "Replace Storm's Eye's combo with Tomahawk when out of melee range.", WAR.JobID, WAR.StormsEye)]
        WarriorStormsEyeahawkFeature = 2112,

        [OrderedEnum]
        [ParentCombo(WarriorStormsEyeCombo)]
        [ConflictingCombos(WarriorStormsEyeslaughtFeature)]
        [CustomComboInfo("Storm's Eye Tomahawk Replacement", "Replace Storm's Eye with Tomahawk while Storm's Eye is not available for use in combo.", WAR.JobID, WAR.StormsEye)]
        WarriorStormsEyeHawkReplacementFeature = 2113,

        [OrderedEnum]
        [ParentCombo(WarriorStormsEyeCombo)]
        [ConflictingCombos(WarriorStormsEyeHawkReplacementFeature, WarriorStormsEyeahawkFeature)]
        [CustomComboInfo("Storm's Eye Onslaught Replacement", "Replace Storm's Eye with Onslaught while Storm's Eye is not available for use in combo, or you are out of melee range.", WAR.JobID, WAR.StormsEye)]
        WarriorStormsEyeslaughtFeature = 2117,

        [OrderedEnum]
        [CustomComboInfo("Mythril Tempest Combo", "Replace Mythril Tempest with its combo chain.", WAR.JobID, WAR.MythrilTempest)]
        WarriorMythrilTempestCombo = 2103,

        [OrderedEnum]
        [CustomComboInfo("Overpower Combo", "Replace Overpower with its combo chain.", WAR.JobID, WAR.Overpower)]
        WarriorOverpowerCombo = 2104,

        [OrderedEnum]
        [CustomComboInfo("Warrior Gauge Overcap Feature", "Replace AoE combo with gauge spender if you are about to overcap.", WAR.JobID, WAR.MythrilTempest, WAR.StormsEye, WAR.StormsPath)]
        WarriorGaugeOvercapFeature = 2105,

        [OrderedEnum]
        [CustomComboInfo("Inner Release AoE to Decimate Feature", "Replace AoE combo with Decimate during Inner Release.", WAR.JobID, WAR.MythrilTempest)]
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

        [OrderedEnum]
        [CustomComboInfo("Primal Upheaval", "Replace Upheaval/Orogeny with Primal Wrath while available.", WAR.JobID, WAR.Upheaval, WAR.Orogeny)]
        WarriorPrimalUpheavalFeature = 2118,

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
        [CustomComboInfo("Holy into Misery", "Replaces Holy/Holy III with Afflatus Misery when Misery is ready to be used and you have a target.", WHM.JobID, WHM.Holy, WHM.Holyga)]
        WhiteMageHolyMiseryFeature = 2405,

        [OrderedEnum]
        [CustomComboInfo("Holy into Glare IV", "Replaces Holy/Holy III with Glare IV when it is ready to be used and you have a target.\nHas lesser priority than Afflatus Misery if that feature is also enabled.", WHM.JobID, WHM.Holy, WHM.Holyga)]
        WhiteMageHolyGlareFeature = 2407,

        [OrderedEnum]
        [CustomComboInfo("Cure 2 to Cure Level Sync", "Changes Cure II to Cure when below level 30 in synced content.", WHM.JobID, WHM.Cure2)]
        WhiteMageCureFeature = 2403,

        [OrderedEnum]
        [CustomComboInfo("Afflatus Feature", "Changes Cure II into Afflatus Solace, and Medica into Afflatus Rapture, when lilies are up.", WHM.JobID, WHM.Cure2, WHM.Medica)]
        WhiteMageAfflatusFeature = 2404,

        [OrderedEnum]
        [CustomComboInfo("White Mage Lucid Dreaming Reminder", "All your non-role action cooldowns (that don't have charges) become Lucid Dreaming if they aren't up and Lucid Dreaming is, and you have less-than-or-equal-to a set amount of MP.", WHM.JobID, WHM.PresenceOfMind, WHM.Assize, WHM.Temperance, WHM.PlenaryIndulgence, WHM.Tetragrammaton, WHM.Asylum, WHM.Aquaveil, WHM.LiturgyOfTheBell, WHM.Benediction)]
        WhiteMageLucidReminderFeature = 2406,

        #endregion
        // ====================================================================================
    }
}

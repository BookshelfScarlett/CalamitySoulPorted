using System;
using System.Linq;
using System.Security;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Aerospec;
using CalamityMod.Items.Armor.Auric;
using CalamityMod.Items.Armor.Bloodflare;
using CalamityMod.Items.Armor.Daedalus;
using CalamityMod.Items.Armor.GodSlayer;
using CalamityMod.Items.Armor.Hydrothermic;
using CalamityMod.Items.Armor.Reaver;
using CalamityMod.Items.Armor.Silva;
using CalamityMod.Items.Armor.Statigel;
using CalamityMod.Items.Armor.Tarragon;
using CalamityMod.Items.Armor.Victide;
using CalamityMod.Items.Placeables.Furniture.Trophies;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamitySoulPorted.ItemNew.Weapons.MeleeWeapon;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulMethods
{
    public class MethodsRecipeGroup: ModSystem
    {
        public static RecipeGroup VictideHead;
        public static RecipeGroup StatigelHead;
        public static RecipeGroup AerospecHead;
        public static RecipeGroup DaedalusHead;
        public static RecipeGroup HydrothermicHead;
        public static RecipeGroup ReaverHead;
        public static RecipeGroup GodSlayerHead;
        public static RecipeGroup AuricTeslaHead;
        public static RecipeGroup SilvaHead;
        public static RecipeGroup TarragonHead;
        public static RecipeGroup BloodflareHead;
        public static RecipeGroup ElementalLance;
        public static RecipeGroup TrophyLA;
        public static RecipeGroup TrophyExoTwin;
        #region CrossMod
        public static RecipeGroup TerraBlade;
        public static RecipeGroup ElementalShiv;
        public static RecipeGroup StellarContempt;
        public static RecipeGroup BYDGoozmaWDNMD;
        #endregion
        #region 灾厄遗产怎么这么多东西？
        public static RecipeGroup ElemMelee;
        public static RecipeGroup ElemRanged;
        public static RecipeGroup ElemMagic;
        public static RecipeGroup ElemSummon;
        public static RecipeGroup ElemRogue;

        #endregion
        #region Others
        public static RecipeGroup EvilBars;
        #endregion
        public override void Unload()
        {
            RecipeGroup[] Train =
            [
                VictideHead,
                StatigelHead,
                AerospecHead,
                DaedalusHead,
                HydrothermicHead,
                ReaverHead,
                GodSlayerHead,
                AuricTeslaHead,
                SilvaHead,
                TarragonHead,
                BloodflareHead,

                TrophyLA,
                TrophyExoTwin,

                ElementalLance,

                ElementalShiv,
                TerraBlade,
                StellarContempt,

                EvilBars,
                BYDGoozmaWDNMD
            ];
            for (int i = 0; i < Train.Length; i++)
                Train[i] = null;
            RecipeGroup[] inhertiance =
            [
                ElemMelee,
                ElemRanged,
                ElemMagic,
                ElemSummon,
                ElemRogue
            ];
        }
        public override void AddRecipeGroups()
        {
            #region 安装
            VictideHead         = InstallGroup<VictideHeadMelee>     (Item<VictideHeadMelee>(),      Item<VictideHeadRanged>(),          Item<VictideHeadMagic>(),           Item<VictideHeadSummon>(),      Item<VictideHeadRogue>());
            StatigelHead        = InstallGroup<StatigelHeadMelee>    (Item<StatigelHeadMelee>(),     Item<StatigelHeadRanged>(),         Item<StatigelHeadMagic>(),          Item<StatigelHeadSummon>(),     Item<StatigelHeadRogue>());
            AerospecHead        = InstallGroup<AerospecHelm>         (Item<AerospecHelm>(),          Item<AerospecHood>(),               Item<AerospecHat>(),                Item<AerospecHelmet>(),         Item<AerospecHeadgear>());
            DaedalusHead        = InstallGroup<DaedalusHeadMelee>    (Item<DaedalusHeadMelee>(),     Item<DaedalusHeadRanged>(),         Item<DaedalusHeadMagic>(),          Item<DaedalusHeadSummon>(),     Item<DaedalusHeadRogue>());
            ReaverHead          = InstallGroup<ReaverHeadExplore>    (Item<ReaverHeadTank>(),        Item<ReaverHeadMobility>(),         Item<ReaverHeadExplore>());
            HydrothermicHead    = InstallGroup<HydrothermicHeadMelee>(Item<HydrothermicHeadMelee>(), Item<HydrothermicHeadRanged>(),     Item<HydrothermicHeadMagic>(),      Item<HydrothermicHeadSummon>(), Item<HydrothermicHeadRogue>());
            TarragonHead        = InstallGroup<TarragonHeadMelee>    (Item<TarragonHeadMelee>(),     Item<TarragonHeadRanged>(),         Item<TarragonHeadMagic>(),          Item<TarragonHeadSummon>(),     Item<TarragonHeadRogue>());
            BloodflareHead      = InstallGroup<BloodflareHeadMelee>  (Item<BloodflareHeadMelee>(),   Item<BloodflareHeadRanged>(),       Item<BloodflareHeadMagic>(),        Item<BloodflareHeadSummon>(),   Item<BloodflareHeadRogue>());
            SilvaHead           = InstallGroup<SilvaHeadMagic>       (Item<SilvaHeadMagic>(),        Item<SilvaHeadSummon>());
            GodSlayerHead       = InstallGroup<GodSlayerHeadMelee>   (Item<GodSlayerHeadMelee>(),    Item<GodSlayerHeadRanged>(),        Item<GodSlayerHeadRogue>());
            AuricTeslaHead      = InstallGroup<AuricTeslaRoyalHelm>  (Item<AuricTeslaRoyalHelm>(),   Item<AuricTeslaHoodedFacemask>(),   Item<AuricTeslaWireHemmedVisage>(), Item<AuricTeslaSpaceHelmet>(),  Item<AuricTeslaPlumedHelm>());
            TrophyLA            = InstallGroup<LeviathanTrophy>      (Item<AnahitaTrophy>());
            TrophyExoTwin       = InstallGroup<ApolloTrophy>         (Item<ArtemisTrophy>());

            EvilBars = InstallGroup(ItemID.DemoniteBar, ItemID.DemoniteBar, ItemID.CrimtaneBar);

            #endregion

            #region 注册名字
            VictideHead.        NameHelperGroup("VictideHead");
            StatigelHead.       NameHelperGroup("StatigelHead");
            AerospecHead.       NameHelperGroup("AerospecHead");
            DaedalusHead.       NameHelperGroup("DaedalusHead");
            ReaverHead.         NameHelperGroup("ReaverHead");
            HydrothermicHead.   NameHelperGroup("HydrothermicHead");
            TarragonHead.       NameHelperGroup("TarragonHead");
            BloodflareHead.     NameHelperGroup("BloodflareHead");
            SilvaHead.          NameHelperGroup("SilvaHead");
            GodSlayerHead.      NameHelperGroup("GodSlayerHead");
            AuricTeslaHead.     NameHelperGroup("AuricTeslaHead");

            TrophyLA.           NameHelperGroup("TrophyLA");
            TrophyExoTwin.      NameHelperGroup("TrophyExoTwin");

            EvilBars.NameHelperGroup("EvilBars");
            #endregion

            #region 武器相关
            ElementalLance = InstallGroup<ElementalLance>(Item<ElementalSpearReborn>());
            //注册
            ElementalLance.NameHelperGroup("ElementalLance");
            #endregion



            #region 模组联动
            if (CalamitySoulPorted.Inhertiance != null)
                DoInheritanceGroup(CalamitySoulPorted.Inhertiance);
            if (CalamitySoulPorted.Hunt != null)
                DoHunt(CalamitySoulPorted.Hunt);

            #endregion
        }

        public static void DoHunt(Mod hunt)
        {
            int bag1 = hunt.TryFindBetter<ModItem>("TreasureTrunk").Type;
            int bag2 = hunt.TryFindBetter<ModItem>("TreasureBucket").Type;
            BYDGoozmaWDNMD = InstallGroup(bag1, bag1, bag2);
            BYDGoozmaWDNMD.NameHelperGroup("FuckingGoozma");
        }

        public void DoInheritanceGroup(Mod inheritance)
        {
            //注册泰拉边锋
            int terraEdge = inheritance.TryFindBetter<ModItem>("TerraEdge").Type;
            //注册元素短剑
            int eleShiv = inheritance.TryFindBetter<ModItem>("ElementalShivold").Type;
            //注册锤子
            int stellarHammer = inheritance.TryFindBetter<ModItem>("MeleeTypeHammerStellarContemptLegacy").Type;
            #region 遗产怎么这么多饰品？
            int EGlove = inheritance.TryFindModItem("ElementalGauntletold").Type;
            int EQuiver = inheritance.TryFindModItem("ElementalQuiver").Type;
            int ETalisman = inheritance.TryFindModItem("AncientEtherealTalisman").Type;
            int Enucler = inheritance.TryFindModItem("NucleogenesisLegacy").Type;
            int EMirror = inheritance.TryFindModItem("EclispeMirrorLegacy").Type;
            ElemMelee = InstallGroup<ElementalGauntlet>(Item<ElementalGauntlet>(), EGlove);
            ElemRanged = InstallGroup<ElementalQuiver>(Item<ElementalQuiver>(), EQuiver);
            ElemMagic = InstallGroup<EtherealTalisman>(Item<EtherealTalisman>(), ETalisman);
            ElemSummon = InstallGroup<Nucleogenesis>(Item<Nucleogenesis>(), Enucler);
            ElemRogue = InstallGroup<EclipseMirror>(Item<EclipseMirror>(), EMirror);

            ElemMelee.NameHelperGroup("ElementalGauntlet");
            ElemRanged.NameHelperGroup("ElementalQuiver");
            ElemMagic.NameHelperGroup("EtherealTalisman");
            ElemSummon.NameHelperGroup("Nucleogenesis");
            ElemRogue.NameHelperGroup("EclipseMirror");

            #endregion
            TerraBlade = InstallGroup(ItemID.TerraBlade, ItemID.TerraBlade, terraEdge);
            ElementalShiv = InstallGroup<ElementalShiv>(Item<ElementalShiv>(), eleShiv);
            StellarContempt = InstallGroup<StellarContempt>(Item<StellarContempt>(), stellarHammer);
            //注册名字
            TerraBlade.NameHelperGroup("TerraBladeCrossMod");
            ElementalShiv.NameHelperGroup("ElementalShivCrossMod");
            StellarContempt.NameHelperGroup("StellarContemptCrossMod");
        }

        public static RecipeGroup InstallGroup<T>(params int[] setItems) where T : ModItem => new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ModContent.ItemType<T>())}", setItems);
        public static RecipeGroup InstallGroup(int showedItemID, params int[] setItems) => new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(showedItemID)}", setItems);
        public static int Item<T>() where T : ModItem => ModContent.ItemType<T>();
        public static int QuickCrossItem(Mod mod, string wantedItemName) => mod.Find<ModItem>(wantedItemName).Type;
    }
    public class SoulRecpieGroupID
    {
        public static string VictideHead => "VictideHead".GetNameGroup();
        public static string AerospecHead => "AerospecHead".GetNameGroup();
        public static string StatigelHead => "StatigelHead".GetNameGroup();
        public static string DaedalusHead => "DaedalusHead".GetNameGroup();
        public static string ReaverHead => "ReaverHead".GetNameGroup();
        public static string HydrothermicHead => "HydrothermicHead".GetNameGroup();
        public static string TarragonHead => "TarragonHead".GetNameGroup();
        public static string BloodflareHead => "BloodflareHead".GetNameGroup();
        public static string GodSlayerHead => "GodSlayerHead".GetNameGroup();
        public static string SilvaHead => "SilvaHead".GetNameGroup();
        public static string AuricTeslaHead => "AuricTeslaHead".GetNameGroup();
        public static string TerraBlade => "TerraBladeCrossMod".GetNameGroup();
        public static string ElementalLance => "ElementalLance".GetNameGroup();
        public static string StellarContempt => "StellarContemptCrossMod".GetNameGroup();
        public static string ElementalShiv => "ElementalShivCrossMod".GetNameGroup();
        public static string TrophyLA => "TrophyLA".GetNameGroup();
        public static string TrophyExoTwin => "TrophyExoTwin".GetNameGroup();
        public static string EvilBars => "EvilBars".GetNameGroup();
        public static string FuckingGoozma => "FuckingGoozma".GetNameGroup();

        #region 遗产饰品，怎么这么多的？
        public static string ElementalGauntlet => "ElementalGauntlet".GetNameGroup();
        public static string ElementalQuiver => "ElementalQuiver".GetNameGroup();
        public static string EtherealTalisman => "EtherealTalisman".GetNameGroup();
        public static string Nucleogenesis => "Nucleogenesis".GetNameGroup();
        public static string EclipseMirror => "EclipseMirror".GetNameGroup();
        #endregion
    }
}
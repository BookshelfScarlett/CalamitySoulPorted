using System;
using System.Security;
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

                EvilBars
            ];
            for (int i = 0; i < Train.Length; i++)
                Train[i] = null;
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
            bool isEnableInheritance = ModLoader.TryGetMod("CalamityInheritance", out Mod inheritance);
            if (isEnableInheritance)
                DoInheritanceGroup(inheritance);

            #endregion
        }

        public void DoInheritanceGroup(Mod inheritance)
        {
            //注册泰拉刃的合成表。这里需要补充一个泰拉边锋
            TerraBlade = InstallGroup(ItemID.TerraBlade, QuickCrossItem(inheritance, "TerraEdge"));
            ElementalShiv = InstallGroup<ElementalShiv>(QuickCrossItem(inheritance, "ElementalShivold"));
            StellarContempt = InstallGroup<StellarContempt>(QuickCrossItem(inheritance, "MeleeTypeHammerStellarContemptLegacy"));
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
        

    }
}
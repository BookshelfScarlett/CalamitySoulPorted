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
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulMethods
{
    public class RecipeGroupMethods : ModSystem
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
                BloodflareHead
            ];
            for (int i = 0; i < Train.Length; i++)
                Train[i] = null;
        }
        public override void AddRecipeGroups()
        {
            #region 安装
            VictideHead         = InstallGroupMod<VictideHeadMelee>     (Item<VictideHeadMelee>(),      Item<VictideHeadRanged>(),          Item<VictideHeadMagic>(),           Item<VictideHeadSummon>(),      Item<VictideHeadRogue>());
            StatigelHead        = InstallGroupMod<StatigelHeadMelee>    (Item<StatigelHeadMelee>(),     Item<StatigelHeadRanged>(),         Item<StatigelHeadMagic>(),          Item<StatigelHeadSummon>(),     Item<StatigelHeadRogue>());
            AerospecHead        = InstallGroupMod<AerospecHelm>         (Item<AerospecHelm>(),          Item<AerospecHood>(),               Item<AerospecHat>(),                Item<AerospecHelmet>(),         Item<AerospecHeadgear>());
            DaedalusHead        = InstallGroupMod<DaedalusHeadMelee>    (Item<DaedalusHeadMelee>(),     Item<DaedalusHeadRanged>(),         Item<DaedalusHeadMagic>(),          Item<DaedalusHeadSummon>(),     Item<DaedalusHeadRogue>());
            ReaverHead          = InstallGroupMod<ReaverHeadExplore>    (Item<ReaverHeadTank>(),        Item<ReaverHeadMobility>(),         Item<ReaverHeadExplore>());
            HydrothermicHead    = InstallGroupMod<HydrothermicHeadMelee>(Item<HydrothermicHeadMelee>(), Item<HydrothermicHeadRanged>(),     Item<HydrothermicHeadMagic>(),      Item<HydrothermicHeadSummon>(), Item<HydrothermicHeadRogue>());
            TarragonHead        = InstallGroupMod<TarragonHeadMelee>    (Item<TarragonHeadMelee>(),     Item<TarragonHeadRanged>(),         Item<TarragonHeadMagic>(),          Item<TarragonHeadSummon>(),     Item<TarragonHeadRogue>());
            BloodflareHead      = InstallGroupMod<BloodflareHeadMelee>  (Item<BloodflareHeadMelee>(),   Item<BloodflareHeadRanged>(),       Item<BloodflareHeadMagic>(),        Item<BloodflareHeadSummon>(),   Item<BloodflareHeadRogue>());
            SilvaHead           = InstallGroupMod<SilvaHeadMagic>       (Item<SilvaHeadMagic>(),        Item<SilvaHeadSummon>());
            GodSlayerHead       = InstallGroupMod<GodSlayerHeadMelee>   (Item<GodSlayerHeadMelee>(),    Item<GodSlayerHeadRanged>(),        Item<GodSlayerHeadRogue>());
            AuricTeslaHead      = InstallGroupMod<AuricTeslaRoyalHelm>  (Item<AuricTeslaRoyalHelm>(),   Item<AuricTeslaHoodedFacemask>(),   Item<AuricTeslaWireHemmedVisage>(), Item<AuricTeslaSpaceHelmet>(),  Item<AuricTeslaPlumedHelm>());
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
            #endregion
        }
        public static RecipeGroup InstallGroupMod<T>(params int[] setItems) where T : ModItem => new(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ModContent.ItemType<T>())}", setItems);
        public static int Item<T>() where T : ModItem => ModContent.ItemType<T>();
    }
    public class SoulRecpieGroupID
    {
        public static string VictideHead        => "VictideHead".      GetNameGroup();
        public static string AerospecHead       => "AerospecHead".       GetNameGroup();
        public static string StatigelHead       => "StatigelHead".       GetNameGroup();
        public static string DaedalusHead       => "DaedalusHead".       GetNameGroup();
        public static string ReaverHead         => "ReaverHead".         GetNameGroup();
        public static string HydrothermicHead   => "HydrothermicHead".   GetNameGroup();
        public static string TarragonHead       => "TarragonHead".       GetNameGroup();
        public static string BloodflareHead     => "BloodflareHead".     GetNameGroup();
        public static string GodSlayerHead      => "GodSlayerHead".      GetNameGroup();
        public static string SilvaHead          => "SilvaHead".          GetNameGroup();
        public static string AuricTeslaHead     => "AuricTeslaHead".     GetNameGroup();
    }
}
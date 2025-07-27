using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;
using CalamitySoulPorted.RarityCustom;
using CalamityMod.Items.Armor.Tarragon;
using CalamityMod.Items.Fishing.FishingRods;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using Terraria.ID;
using Terraria.Localization;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PostML
{
    public class TarragonEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => PostML;
        public const float ArmorToughnessMax = 0.30f;
        public const float ArmorToughnessMin = 0.05f;
        public const float ArmorToughnessReduceRate = 0.0025f;
        public const int DamageDivityRateMin = 75;
        public const int DamageDivityRateMax = 120;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = SoulShopValue.EnchPostML;
            Item.rare = ModContent.RarityType<EnchPostML>();
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().EnchTarragon = true;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs((int)(ArmorToughnessMax * 100), DamageDivityRateMin, DamageDivityRateMax, (int)(ArmorToughnessMin * 100), (int)(ArmorToughnessMax * 100));
        public override void AddRecipes()
        {
            CreateRecipe().
                AddRecipeGroup(SoulRecpieGroupID.TarragonHead).
                AddIngredient<TarragonBreastplate>().
                AddIngredient<TarragonLeggings>().
                AddIngredient<LifehuntScythe>().
                AddIngredient<NettlevineGreatbow>().
                AddIngredient<EarlyBloomRod>().
                AddTile(TileID.LunarCraftingStation).
                Register();
        }
    }
}
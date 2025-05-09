using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Auric;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalamitySoulPorted.RarityCustom;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PostML
{
    public class AuricTeslaEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => PostML;
        public override void SetDefaults()
        {
            Item.value = SoulShopValue.EnchPostML;
            Item.rare = ModContent.RarityType<EnchPostML>();
            base.SetDefaults();
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().AuricTeslaEnch = true;
        public override void AddRecipes()
        {
            CreateRecipe().
                AddRecipeGroup(SoulRecpieGroupID.AuricTeslaHead).
                AddIngredient<AuricTeslaBodyArmor>().
                AddIngredient<AuricTeslaCuisses>().
                AddIngredient<HeliumFlash>().
                AddIngredient<TyrannysEnd>().
                AddIngredient<Seraphim>().
                AddTile<CosmicAnvil>().
                Register();
        }
    }
}
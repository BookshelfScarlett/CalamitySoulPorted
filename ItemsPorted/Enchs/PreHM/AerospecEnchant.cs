using CalamityMod.Items.Armor.Aerospec;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using CalamitySoulPorted.RarityCustom;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PreHM
{
    public class AerospecEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => PreHardMode;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = SoulShopValue.EnchPreHardMode;
            Item.rare = ModContent.RarityType<EnchPreHardMode>();
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().EnchAerospec = true;
        public override void AddRecipes()
        {
            CreateRecipe().
                AddRecipeGroup(SoulRecpieGroupID.AerospecHead).
                AddIngredient<AerospecBreastplate>().
                AddIngredient<AerospecLeggings>().
                AddIngredient<GoldplumeSpear>().
                AddIngredient<Galeforce>().
                AddIngredient<SkyStabber>().
                AddTile(TileID.DemonAltar).
                Register();
        }
    }
}
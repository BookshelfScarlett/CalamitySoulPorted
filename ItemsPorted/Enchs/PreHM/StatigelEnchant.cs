using CalamitySoulPorted.SoulMethods;
using CalamitySoulPorted.RarityCustom;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Armor.Statigel;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PreHM
{
    public class StatigelEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => PreHardMode;
        public override int GiveValue => base.GiveValue;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<EnchPreHardMode>();
            Item.value = SoulShopValue.EnchPreHardMode;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().EnchStatigel = true;
        public override void AddRecipes()
        {
            CreateRecipe().
                AddRecipeGroup(SoulRecpieGroupID.StatigelHead).
                AddIngredient<StatigelArmor>().
                AddIngredient<StatigelGreaves>().
                AddIngredient<GeliticBlade>().
                AddIngredient<Goobow>().
                AddIngredient<GelDart>().
                AddTile(TileID.DemonAltar).
                Register();
        }
    }
}
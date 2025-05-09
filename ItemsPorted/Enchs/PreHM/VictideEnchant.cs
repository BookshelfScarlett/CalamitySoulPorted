using CalamityMod.Items.Armor.Victide;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.GameContent.UI;
using CalamitySoulPorted.RarityCustom;
using Terraria.ID;
using Terraria.ModLoader;
using System.Security.Cryptography.X509Certificates;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PreHM
{
    public class VictideEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => PreHardMode;
        public override int GiveValue => base.GiveValue;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = SoulShopValue.EnchPreHardMode;
            Item.rare = ModContent.RarityType<EnchPreHardMode>();
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().VictideEnch = true;
        public override void AddRecipes()
        {
            CreateRecipe().
                AddRecipeGroup(SoulRecpieGroupID.VictideHead).
                AddIngredient<VictideBreastplate>().
                AddIngredient<VictideGreaves>().
                AddIngredient<RedtideSpear>().
                AddIngredient<CoralSpout>().
                AddIngredient<ReedBlowgun>().
                DisableDecraft().
                AddTile(TileID.DemonAltar).
                Register();
        }
    }
}
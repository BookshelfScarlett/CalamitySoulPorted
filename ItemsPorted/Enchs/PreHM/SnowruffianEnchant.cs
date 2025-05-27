using CalamityMod.Items.Armor.SnowRuffian;
using CalamityMod.Items.Weapons.Magic;
using CalamitySoulPorted.SoulMethods;
using CalamitySoulPorted.RarityCustom;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PreHM
{
    public class SnowRuffianEnchant: GenericEnchant, ILocalizedModType
    {
        public override string Category => PreHardMode;
        public override int GiveValue => base.GiveValue;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<EnchPreHardMode>();
            Item.value = SoulShopValue.EnchPreHardMode;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().EnchSnowruffian = true;
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<SnowRuffianMask>().
                AddIngredient<SnowRuffianChestplate>().
                AddIngredient<SnowRuffianGreaves>().
                AddIngredient(ItemID.IceBoomerang).
                AddIngredient(ItemID.FrostDaggerfish, 150).
                AddIngredient<IcicleStaff>().
                DisableDecraft().
                AddTile(TileID.DemonAltar).
                Register();


        }
    }
}
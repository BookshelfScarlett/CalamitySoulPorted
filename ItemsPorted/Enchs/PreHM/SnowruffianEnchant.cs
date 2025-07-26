using CalamityMod.Items.Armor.SnowRuffian;
using CalamityMod.Items.Weapons.Magic;
using CalamitySoulPorted.SoulMethods;
using CalamitySoulPorted.RarityCustom;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Accessories;
using CalamityMod;

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
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var calPlayer = player.Calamity();
            calPlayer.stealthStrike75Cost = true;
            calPlayer.rogueStealthMax += 0.05f;
            player.Soul().EnchSnowruffian = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<SnowRuffianMask>().
                AddIngredient<SnowRuffianChestplate>().
                AddIngredient<SnowRuffianGreaves>().
                AddIngredient(ItemID.IceBoomerang).
                AddIngredient(ItemID.FrostDaggerfish, 150).
                AddIngredient<CoinofDeceit>().
                DisableDecraft().
                AddTile(TileID.DemonAltar).
                Register();


        }
    }
}
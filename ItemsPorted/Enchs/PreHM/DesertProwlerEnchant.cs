using CalamityMod.Items.Armor.DesertProwler;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Summon;
using CalamitySoulPorted.RarityCustom;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PreHM
{
    public class DesertProwlerEnchant : GenericEnchant, ILocalizedModType
    {
        public const int DesertFlatDamage = 12;
        public override string Category => PreHardMode;
        public override int GiveValue => base.GiveValue;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = SoulShopValue.EnchPreHardMode;
            Item.rare = ModContent.RarityType<EnchHardMode>();
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().EnchDesertProwler = true;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(DesertFlatDamage);
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<DesertProwlerHat>().
                AddIngredient<DesertProwlerShirt>().
                AddIngredient<DesertProwlerPants>().
                AddIngredient<StormjawStaff>().
                AddIngredient<SunSpiritStaff>().
                AddIngredient(ItemID.Sandgun).
                AddTile(TileID.DemonAltar).
                Register();
        }
    }
}
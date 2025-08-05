using CalamityMod.Items.Armor.Vanity;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using CalamitySoulPorted.RarityCustom;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PreHM
{
    public class OldHunterEnchant : GenericEnchant ,ILocalizedModType
    {
        public const float Size = 2.5f;
        public override string Category => PreHardMode;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(Size.FloatToInt());
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = SoulShopValue.EnchPreHardMode;
            Item.rare = ModContent.RarityType<EnchPreHardMode>();
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().EnchOldHunter = true;
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<OldHunterHat>().
                AddIngredient<OldHunterShirt>().
                AddIngredient<OldHunterPants>().
                AddIngredient<Barinade>().
                AddIngredient<ScourgeoftheDesert>().
                AddIngredient<SaharaSlicers>().
                AddTile(TileID.DemonAltar).
                Register();
        }
    }
}
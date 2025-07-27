using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.MarniteArchitect;
using CalamityMod.Items.Tools;
using CalamitySoulPorted.RarityCustom;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PreHM
{
    public class MarniteArchitectEnchant: GenericEnchant, ILocalizedModType
    {
        public override string Category => PreHardMode;
        public const int ChanceToSmeltEnch = 3;
        public const int ChanceToSmeltForce = 1;
        public const float MiningSpeed = 30f;
        public const int TileRange = 30;
        public const float PlaceSpeed = 100f;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = SoulShopValue.EnchPreHardMode;
            Item.rare = ModContent.RarityType<EnchPreHardMode>();
        }
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MiningSpeed, TileRange, PlaceSpeed, ChanceToSmeltEnch);
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().EnchMarniteArchitect = true;
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<MarniteArchitectHeadgear>().
                AddIngredient<MarniteArchitectToga>().
                AddIngredient<MarniteDeconstructor>().
                AddIngredient<MarniteObliterator>().
                AddIngredient<MarniteRepulsionShield>().
                AddIngredient<UnstableGraniteCore>().
                AddTile(TileID.DemonAltar).
                Register();
        }
    }
}
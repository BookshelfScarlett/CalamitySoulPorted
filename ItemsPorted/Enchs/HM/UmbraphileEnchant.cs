using CalamityMod.Items.Armor.Umbraphile;
using CalamityMod.Items.Weapons.Rogue;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.HM
{
    public class UmbraphileEnchant : GenericEnchant, ILocalizedModType
    {
        public static readonly float EnchUmbraphileAttackSpeedBouns = 0.1f;
        public override string Category => HardMode;
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().EnchUmbraphile = true;
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<UmbraphileHood>().
                AddIngredient<UmbraphileRegalia>().
                AddIngredient<UmbraphileBoots>().
                AddIngredient<TotalityBreakers>().
                AddIngredient<FantasyTalisman>(300).
                AddIngredient<BallisticPoisonBomb>().
                AddTile(TileID.MythrilAnvil).
                Register();
        }
        //做转化主要还是为了打注释。
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(EnchUmbraphileAttackSpeedBouns.ConvertToInt());
    }
}
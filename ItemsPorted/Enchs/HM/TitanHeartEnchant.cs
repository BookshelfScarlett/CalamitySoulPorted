using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.TitanHeart;
using CalamityMod.Items.Weapons.Rogue;
using CalamitySoulPorted.ItemsPorted.Enchs.PreHM;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.HM
{
    public class TitanHeartEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => HardMode;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var calPlayer = player.Calamity();
            calPlayer.stealthStrikeHalfCost = true;
            calPlayer.rogueStealthMax += 0.10f;
            player.Soul().EnchTitanHeart = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<TitanHeartMask>().
                AddIngredient<TitanHeartMantle>().
                AddIngredient<TitanHeartBoots>().
                AddIngredient<RuinMedallion>().
                AddIngredient<GacruxianMollusk>().
                AddIngredient<SnowRuffianEnchant>().
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
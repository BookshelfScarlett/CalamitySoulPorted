using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.HM
{
    public class PlaguebringerEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => HardMode;
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().PlaguebringerEnch = true;
        public override void AddRecipes()
        {
            base.AddRecipes();
        }
    }
}
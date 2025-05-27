using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.HM
{
    public class DaedalusEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => HardMode;
        public override void SetDefaults()
        {
            base.SetDefaults();
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().EnchDaedalus = true;
        public override void AddRecipes()
        {
            base.AddRecipes();
        }
    }
}
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.HM
{
    public class TitanHeartEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => HardMode;
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().EnchTitanHeart = true;
    }
}
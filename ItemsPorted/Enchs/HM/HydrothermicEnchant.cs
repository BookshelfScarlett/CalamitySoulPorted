using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.Graphics.Renderers;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.HM
{
    public class HydrothermicEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => HardMode;
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().EnchHydrothermic = true;
    }

}
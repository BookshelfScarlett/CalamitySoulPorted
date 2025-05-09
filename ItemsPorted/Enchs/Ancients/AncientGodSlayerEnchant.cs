using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.Ancients
{
    //Todo: 远古弑神综合自活 + 旧弑神大冲
    public class AncientGodSlayerEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => PostML;
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().AncientGodSlayerEnch = true;
    }
}
using System;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.Graphics.Renderers;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.HM
{
    public class MolluskEnchant : GenericEnchant, ILocalizedModType 
    {
        public override string Category => HardMode;
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().MolluskEnch = true;
    }
}
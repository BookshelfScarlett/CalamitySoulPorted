using System.ComponentModel;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader.Config;

namespace CalamitySoulPorted.SoulConfigs
{
    [BackgroundColor(49, 32, 36, 216)]
    public class DebugConfig : ModConfig
    {
        public static DebugConfig Instance;
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref NetworkText message)
        {
            return true;
        }
        [BackgroundColor(192, 54, 64, 192)]
        [SliderColor(244, 165, 56, 128)]
        [Range(-1000, 1000)]
        [DefaultValue(1)]
        public int DebugInt { get; set; }
        [BackgroundColor(192, 54, 64, 192)]
        [SliderColor(244, 165, 56, 128)]
        [Range(-1000, 1000)]
        [DefaultValue(1)]
        public int DebugInt2 { get; set; }
        [BackgroundColor(192, 54, 64, 192)]
        [SliderColor(244, 165, 56, 128)]
        public Color DebugColor { get; set; }
        

    }
}
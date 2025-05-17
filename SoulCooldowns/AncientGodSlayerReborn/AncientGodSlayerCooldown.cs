using CalamityMod.Cooldowns;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using CalamitySoulPorted.SoulMethods;
using Microsoft.CodeAnalysis;

namespace CalamitySoulPorted.SoulCooldowns.AncientGodSlayerReborn
{
    public class AncientGodSlayerCooldown : CooldownHandler
    {
        public static new string ID => "AncientGodSlayerCooldown";
        public override bool ShouldDisplay => true;
        public override LocalizedText DisplayName => SoulMethod.GetText($"{ID}");
        public override string Texture => SoulMethod.CDPathValue("AncientGodSlayerReborn/GodSlayerCooldown");
        public override Color OutlineColor => Color.Lerp(new Color(252, 109, 203), new Color(58, 91, 146), instance.Completion);
        public override Color CooldownStartColor => new Color(148, 62, 216);
        public override Color CooldownEndColor => new Color(255, 187, 207);
    }
}

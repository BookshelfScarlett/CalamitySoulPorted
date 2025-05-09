using CalamityMod.Rarities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.RarityCustom
{
    public partial class EnchPreHardMode: ModRarity
    {
        //花园绿，应介于绿->橙之间
        public override Color RarityColor => new (124,252,0);
        public override int GetPrefixedRarity(int offset, float valueMult) => offset switch
        {
            -2 => ItemRarityID.Green,
            -1 => ItemRarityID.Orange,
            +1 => ItemRarityID.LightRed,
            +2 => ItemRarityID.Pink,
            _ => Type
        };
    }
    public partial class EnchHardMode : ModRarity
    {
        //火砖, 介于青->红之间
        public override Color RarityColor => new (178,34,34);
        public override int GetPrefixedRarity(int offset, float valueMult) => offset switch
        {
            -2 => ItemRarityID.Lime,
            -1 => ItemRarityID.Cyan,
            +1 => ItemRarityID.Red,
            +2 => ItemRarityID.Purple,
            _ => Type
        };
    }
    public partial class EnchPostML : ModRarity
    {
        //与原灾的紫色同级
        public override Color RarityColor => new (153,50,204);
        public override int GetPrefixedRarity(int offset, float valueMult) => offset switch
        {
            -2 => ModContent.RarityType<PureGreen>(),
            -1 => ModContent.RarityType<DarkBlue>(),
            +1 => ModContent.RarityType<Force>(),
            +2 => ModContent.RarityType<CalamityRed>(),
            _ => Type
        };
    }
    public partial class Force : ModRarity
    {
        //这一稀有度颜色与原灾的pink同等级。
        public override Color RarityColor => new (255,105,180);
        public override int GetPrefixedRarity(int offset, float valueMult) => offset switch
        {
            -2 => ModContent.RarityType<DarkBlue>(),
            -1 => ModContent.RarityType<Violet>(),
            +1 => ModContent.RarityType<CalamityRed>(),
            _ => Type
        };
    }
}
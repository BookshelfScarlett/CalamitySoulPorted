using Microsoft.Xna.Framework;
using Terraria;

namespace CalamitySoulPorted.SoulMethods
{
    public static partial class SoulDebug 
    {
        public static void DebugText(string text, int colorRed = 255, int colorGreen = 255, int colorBlue = 255)
        {
            Color color = new (colorRed, colorGreen, colorBlue);
            Main.NewText(text, color);
        }
    }
}
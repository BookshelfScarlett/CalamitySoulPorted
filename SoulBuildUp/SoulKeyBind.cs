using CalamitySoulPorted.SoulMethods;
using Microsoft.Xna.Framework.Input;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulBuildUp
{
    public class SoulKeybind : ModSystem
    {
        //弑神魔石大冲
        public static ModKeybind GodSlayerEnchantDash {get; private set;}
        public override void Load()
        {
            GodSlayerEnchantDash = Mod.BindKeyBetter("GodSlayerEnchantDash", Keys.T);
        }
        public override void Unload()
        {
            ModKeybind[] train=
            [
                GodSlayerEnchantDash
            ];
            for(int i = 0; i < train.Length; i++)
                train[i] = null;
        }
    }
}
using CalamitySoulPorted.SoulMethods;
using Microsoft.Xna.Framework.Input;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulBuildUp
{
    public class SoulKeybind : ModSystem
    {
        //弑神魔石大冲
        public static ModKeybind GodSlayerEnchantDash {get; private set;}
        //天蓝魔石冲
        public static ModKeybind EnchAeroDashKey{ get; private set; }
        public override void Load()
        {
            GodSlayerEnchantDash = Mod.BindKeyBetter("GodSlayerEnchantDash", Keys.T);
            EnchAeroDashKey = Mod.BindKeyBetter("AerospecEnchantDash", Keys.C);
        }
        public override void Unload()
        {
            ModKeybind[] train=
            [
                GodSlayerEnchantDash,
                EnchAeroDashKey
            ];
            for(int i = 0; i < train.Length; i++)
                train[i] = null;
        }
    }
}
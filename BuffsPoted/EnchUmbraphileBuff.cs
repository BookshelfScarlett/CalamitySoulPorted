using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.BuffsPoted
{
    public class EnchUmbraphileBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            base.SetStaticDefaults();
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.Soul().EnchUmbraphileBuff = true;
        }
    }
}
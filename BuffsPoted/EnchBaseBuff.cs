using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.BuffsPoted
{
    public abstract class EnchBaseBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = false;
            Main.debuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            Main.pvpBuff[Type] = false;
            ExtraSSD();     
        }
        public virtual void ExtraSSD() { }
    }
}
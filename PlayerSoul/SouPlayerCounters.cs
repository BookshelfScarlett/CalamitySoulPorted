using CalamityMod;
using CalamityMod.Cooldowns;
using CalamitySoulPorted.SoulCooldowns.AncientGodSlayerReborn;
using Terraria.ModLoader;

namespace CalamitySoulPorted.PlayerSoul
{
    public partial class SoulPlayer : ModPlayer
    {
        public const int EnchSilvaRebornDuration = 900;
        public const int EnchSilvaForceHealDuration = 60;
        public const int EnchUmbNotHoldingWeaponDuration = 600;
        #region 林海
        public int EnchSilvaRebornCounter = EnchSilvaRebornDuration;
        //林海强起
        public int EnchSilvaForceHealCounter = 0;
        public int EnchSilvaForceHealCD = 0;
        #endregion
        //日影魔石
        public int EnchUmbBoomCD = 0;
        public int EnchUmbNotHoldingWeaponCounter = 0;
        //皇天魔石次数盾
        public int EmpyreanShieldTimes = 3;
        public int EmpyreanShieldCD = 0;
        //弑神魔石冲刺
        public int GodSlayerEnchDashTime = 0;
        //弑神魔石的免伤
        public int GodSlayerEnchDamageReductionCounter = 0;
        //标记是否已经进入最大CD
        public bool PingGodSlayerMaxCD = false;
        //远古弑神魔石强起后的闪避
        public bool EnchAncientGodSlayerRebornDodge = true;
        public void EnchCounters()
        {
            //林海强起 
            if (EnchSilvaForceHealCD > 0)
                EnchSilvaForceHealCD--;

            if (EnchUmbBoomCD > 0)
                EnchUmbBoomCD--;
            //未佩戴的情况下重置为0
            if (!EnchUmbraphile)
                EnchUmbNotHoldingWeaponCounter = 0;

            if (GodSlayerEnchDamageReductionCounter > 0)
                GodSlayerEnchDamageReductionCounter--;

            if (!Player.HasCooldown(GodSlayerDash.ID))
            {
                GodSlayerEnchDashTime = 0;
                PingGodSlayerMaxCD = false;
            }
            //远古弑神魔石强起CD结束后重置这个闪避
            if (!Player.HasCooldown(AncientGodSlayerCooldown.ID))
                EnchAncientGodSlayerRebornDodge = true;
            
            if (EnchEmpyrean && EmpyreanShieldCD > 0)
            {
                EmpyreanShieldCD--;
                if (EmpyreanShieldCD == 0)
                    EmpyreanShieldTimes = 3;
            }
        }
    }
}
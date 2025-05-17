using System;
using CalamityMod;
using Terraria.ModLoader;

namespace CalamitySoulPorted.PlayerSoul
{
    public partial class SoulPlayer : ModPlayer
    {
        #region PreHM
        public bool WulfrumEnch = false;
        public bool SnowruffianEnch = false;
        public bool DesertProwlerEnch = false;
        public bool OldHunterEnch = false;
        public bool VictideEnch = false;
        public bool MarniteArchitectEnch = false;
        public bool AerospecEnch = false;
        #endregion
        #region HM
        public bool StatigelEnch = false;
        public bool DaedalusEnch = false;
        public bool PlaguebringerEnch = false;
        public bool BrimflameEnch = false;
        public bool AstralEnch = false;
        public bool SulphurousEnch = false;
        public bool TitanHeartEnch = false;
        public bool FathomSwarmerEnch = false;
        public bool UmbraphileEnch = false;
        public bool PlagueReaperEnch = false;
        public bool HydrothermicEnch = false;
        public bool ReaverEnch = false;
        public bool MolluskEnch = false;
        public bool ForbiddenEnch = false;
        #endregion
        #region PostML
        public bool AuricTeslaEnch = false;
        public bool SilvaEnch = false;
        public bool TarragonEnch = false;
        public bool EmpyreanEnch = false;
        public bool PrismaticEnch = false;
        public bool OmegaBlueEnch = false;
        public bool BloodflareEnch = false;
        public bool FearmongerEnch = false;
        public bool AncientGodSlayerEnch = false;
        public bool GodSlayerEnch = false;
        public bool DemonshadeEnch = false;
        public bool GemTechEnch = false;
        public bool CalamitasEnch = false;
        #endregion
        #region data
        public float GetAcceleration = 1f;
        public float GetRunSpeed = 1f;
        //林海强起
        public bool IsUsedEnchSilvaReborn = false;
        #endregion
        #region Buffs
        public bool EnchUmbraphileBuff = false;
        #endregion
        #region EnchPower
        //皇天强制潜伏属性
        public bool EmpyreanEnchForceStealth = false;
        #endregion
        public override void ResetEffects()
        {
            ResetNumber();
            ResetEnchPreHM();
            ResetEnchHM();
            ResetEnchPostML();
            ResetEnchPower();
            ResetTrigger();
        }
        public override void UpdateDead()
        {
            IsUsedEnchSilvaReborn = false;
            UpdateDeadTrigger();
        }
        public override void UpdateEquips()
        {
            UpdateEnch();
            UpdateEnchPower();
        }
        #region Update Equips
        public void UpdateEnchPower()
        {
            if (EmpyreanEnchForceStealth)
            {
                Player.Calamity().wearingRogueArmor = true;
            }
        }

        public void UpdateEnch()
        {
            //皇天魔石:继承日影魔石 + 启用盗贼潜伏 + 20潜伏值
            if (EmpyreanEnch)
            {
                Player.Calamity().rogueStealthMax += 0.2f;
                EmpyreanEnchForceStealth = true;
                UmbraphileEnch = true;
            }
        }
        #endregion
        public override void PostUpdateRunSpeeds()
        {
            #region CustomDash

            #endregion
        }
        #region Reset
        public void ResetEnchPower()
        {
            EmpyreanEnchForceStealth = false;
        }

        public void ResetEnchPostML()
        {
            EmpyreanEnch = false;
            SilvaEnch = false;
            TarragonEnch = false;
            BloodflareEnch = false;
            DemonshadeEnch = false;
            OmegaBlueEnch = false;
            FearmongerEnch = false;
            AncientGodSlayerEnch = false;
            GodSlayerEnch = false;
            ReaverEnch = false;
            AuricTeslaEnch = false;
            GemTechEnch = false;
            CalamitasEnch = false;
        }

        public void ResetEnchHM()
        {
            DaedalusEnch = false;
            PlaguebringerEnch = false;
            BrimflameEnch = false;
            AstralEnch = false;
            SulphurousEnch = false;
            TitanHeartEnch = false;
            FathomSwarmerEnch = false;
            UmbraphileEnch = false;
            PlaguebringerEnch = false;
            HydrothermicEnch = false;
            MolluskEnch = false;
            ForbiddenEnch = false;
        }

        public void ResetEnchPreHM()
        {
            WulfrumEnch = false;
            MarniteArchitectEnch = false;
            SnowruffianEnch = false;
            VictideEnch = false;
            DesertProwlerEnch = false;
            AerospecEnch = false;
            StatigelEnch = false;
            OldHunterEnch = false;
        }

        public void ResetNumber()
        {
            GetAcceleration = 1f;
            GetRunSpeed = 1f;
        }
        #endregion
    }
}
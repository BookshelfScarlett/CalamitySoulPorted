using System;
using CalamityMod;
using Terraria.ModLoader;

namespace CalamitySoulPorted.PlayerSoul
{
    public partial class SoulPlayer : ModPlayer
    {
        #region PreHM
        public bool EnchWulfrum = false;
        public bool EnchSnowruffian = false;
        public bool EnchDesertProwler = false;
        public bool EnchOldHunter = false;
        public bool EnchVictide = false;
        public bool EnchMarniteArchitect = false;
        public bool EnchAerospec = false;
        #endregion
        #region HM
        public bool EnchStatigel = false;
        public bool EnchDaedalus = false;
        public bool EnchPlaguebringer = false;
        public bool EnchBrimflame = false;
        public bool EnchAstral = false;
        public bool EnchSulphurous = false;
        public bool EnchTitanHeart = false;
        public bool EnchFathomSwarmer = false;
        public bool EnchUmbraphile = false;
        public bool EnchPlagueReaper = false;
        public bool EnchHydrothermic = false;
        public bool EnchReaver = false;
        public bool EnchMollusk = false;
        public bool EnchForbidden = false;
        #endregion
        #region PostML
        public bool EnchAuricTesla = false;
        public bool EnchSilva = false;
        public bool EnchTarragon = false;
        public bool EnchEmpyrean = false;
        public bool EnchPrismatic = false;
        public bool EnchOmegaBlue = false;
        public bool EnchBloodflare = false;
        public bool EnchFearmonger = false;
        public bool EnchAncientGodSlayer = false;
        public bool EnchGodSlayer = false;
        public bool EnchDemonshade = false;
        public bool EnchGemTech = false;
        public bool EnchCalamitas = false;
        #endregion
        #region data
        public float GetAcceleration = 1f;
        public float GetRunSpeed = 1f;
        public float GetDirectlyDR = 1f;
        public int GetSummonCrits = 0;
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
        #region 饰品
        public bool GuarrantedPrestige = false;
        #endregion
        public override void ResetEffects()
        {
            ResetNumber();
            ResetEnchPreHM();
            ResetEnchHM();
            ResetEnchPostML();
            ResetEnchPower();
            ResetTrigger();
            ResetAccessories();
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
            if (EnchEmpyrean)
            {
                Player.Calamity().rogueStealthMax += 0.2f;
                EmpyreanEnchForceStealth = true;
                EnchUmbraphile = true;
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
            EnchEmpyrean = false;
            EnchSilva = false;
            EnchTarragon = false;
            EnchBloodflare = false;
            EnchDemonshade = false;
            EnchOmegaBlue = false;
            EnchFearmonger = false;
            EnchAncientGodSlayer = false;
            EnchGodSlayer = false;
            EnchReaver = false;
            EnchAuricTesla = false;
            EnchGemTech = false;
            EnchCalamitas = false;
        }

        public void ResetEnchHM()
        {
            EnchDaedalus = false;
            EnchPlaguebringer = false;
            EnchBrimflame = false;
            EnchAstral = false;
            EnchSulphurous = false;
            EnchTitanHeart = false;
            EnchFathomSwarmer = false;
            EnchUmbraphile = false;
            EnchPlaguebringer = false;
            EnchHydrothermic = false;
            EnchMollusk = false;
            EnchForbidden = false;
        }

        public void ResetEnchPreHM()
        {
            EnchWulfrum = false;
            EnchMarniteArchitect = false;
            EnchSnowruffian = false;
            EnchVictide = false;
            EnchDesertProwler = false;
            EnchAerospec = false;
            EnchStatigel = false;
            EnchOldHunter = false;
        }

        public void ResetNumber()
        {
            GetAcceleration = 1f;
            GetRunSpeed = 1f;
            GetSummonCrits = 0;
        }
        public void ResetAccessories()
        {
            GuarrantedPrestige = false;
        }
        #endregion
    }
}
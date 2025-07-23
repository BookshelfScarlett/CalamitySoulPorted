using CalamityMod;
using CalamitySoulPorted.SoulMethods;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
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
        public float GetDamageMult = 1f;
        //林海强起
        public bool IsUsedEnchSilvaReborn = false;
        #endregion
        #region Buffs
        public bool EnchUmbraphileBuff = false;
        #endregion
        #region EnchPower
        //皇天强制潜伏属性
        public bool EmpyreanEnchForceStealth = false;
        public bool EnchAeroJumping = false;
        //天蓝魔石冲刺方向
        public float EnchAeroJumpingDir;
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
            EnchAeroDashing();
            #endregion
        }

        public void EnchAeroDashing()
        {
            if (!EnchAerospec)
                return;

            var calPlayer = Player.Calamity();
            if (EnchAeroJumpingEffect > 0)
            {
                Vector2 direciton = EnchAeroJumpingDir.ToRotationVector2();
                Player.direction = (Player.Center.X - direciton.X > 0).ToDirectionInt();
                Player.maxFallSpeed = 50;
                Player.Center += direciton * 40f;
                Player.velocity = direciton * 10f;
                //干掉玩家的……武器状态
                Player.itemAnimation = Player.itemTime = -1;
                Player.channel = false;

                if (EnchAeroJumpingEffect == 1)
                    Player.itemAnimation = Player.itemTime = 0;
                //射弹AI，等会再搞，草
                if (Main.rand.NextBool(4) && Player.whoAmI == Main.myPlayer)
                {
                    SoulDebug.DebugText("发射射弹");
                    // Projectile.NewProjectile()
                }
                //下方都是粒子处理
                for (int i = 0; i < 5; i++)
                {
                    Vector2 randomPos = new Vector2(1f, 0f).RotatedByRandom(MathHelper.TwoPi);
                    Dust d = Dust.NewDustPerfect(Player.Center + randomPos * 8f - direciton * i * 8f, DustID.GoldFlame);
                    d.noGravity = true;
                    d.velocity = direciton * 10f;
                    d.scale *= 2.5f;
                }
                for (int j = 0; j < 5; j++)
                {
                    for (int k = -1; k <= 1; k += 2)
                    {
                        Vector2 dirWings = direciton.RotatedBy(k * MathHelper.PiOver2);
                        Dust wingD = Dust.NewDustPerfect(Player.Center - direciton * k * 8f + dirWings * 18f, DustID.BlueFairy);
                        wingD.noGravity = true;
                        wingD.velocity = direciton * 10f;
                        wingD.scale *= 0.8f;
                    }
                }

            }
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
using System;
using CalamityMod;
using CalamityMod.CalPlayer;
using CalamityMod.Items.Potions;
using CalamityMod.Particles;
using CalamitySoulPorted.BuffsPoted;
using CalamitySoulPorted.ItemsPorted.Enchs.PostML;
using CalamitySoulPorted.ItemsPorted.Enchs.PreHM;
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
        public bool EnchDesertProwlerDamage;
        //斯塔提斯擦弹
        public bool EnchStatigelArea = false;
        //合成岩魔石放置距离，挖掘速度等
        public bool EnchMarniteArchStat = false;
        //合成岩魔石熔炼效果
        public bool EnchMarniteArchAutoSmelt = false;
        //合成岩魔石自动合成
        public bool EnchMarniteArchAutoCraft = false;
        //雪景暴徒效果
        public bool EnchSnowruffianFalling = false;
        //龙蒿盔甲韧性
        public bool EnchTarragonToughness = false;
        public int EnchTarragonTakeDamage = 0;
        //血药过饱和
        public bool EnchBloodflareOverSatu = false;
        public bool EnchBloodFlareIsDoneSatu = false;
        public bool EnchBloodFlareCanHealAgain = false;
        #endregion
        #region 饰品
        public bool GuarrantedPrestige = false;
        //原灾的Modify
        //魔镜等级
        public int MirrorLevel = 0;
        //刀鞘等级
        public int SheathLevel = 0;
        #endregion
        
        public override void PreUpdate()
        {
            
        }
        

        
        #region Update Equips
        public override void UpdateEquips()
        {
            UpdateEnch();
            UpdateOthers();
        }
        //更新魂石效果
        public void UpdateEnch()
        {
            var calPlayer = Player.Calamity();
            //皇天魔石:继承日影魔石 + 启用盗贼潜伏 + 20潜伏值
            if (EnchEmpyrean)
            {
                calPlayer.rogueStealthMax += 0.2f;
                EmpyreanEnchForceStealth = true;
                EnchUmbraphile = true;
            }
            //合成岩建筑师：数值，无视
            if (EnchMarniteArchitect)
            {
                EnchMarniteArchStat = true;
                EnchMarniteArchAutoCraft = true;
            }
            if (EnchMarniteArchStat)
            {
                Player.pickSpeed -= MarniteArchitectEnchant.MiningSpeed * 0.01f;
                Player.tileRangeX += MarniteArchitectEnchant.TileRange;
                Player.tileRangeY += MarniteArchitectEnchant.TileRange;
                Player.tileSpeed += MarniteArchitectEnchant.PlaceSpeed * 0.01f; 
            }
            
            if (EnchBloodflare)
                BloodflareHealingEffect(calPlayer);
            
        }
        //其他与魂石无关的效果
        private void UpdateOthers()
        {

            var calPlayer = Player.Calamity();
            if (SheathLevel > 0)
                GetSheathPoints(calPlayer);
        }

        public void GetSheathPoints(CalamityPlayer calPlayer)
        {
            float basicStealth = 0.05f;
            calPlayer.rogueStealthMax += basicStealth * SheathLevel;
        }
        #endregion

        #region CustomDash
        public override void PostUpdateRunSpeeds()
        {
            EnchAeroDashing();
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
        #endregion
        #region Reset
        public override void ResetEffects()
        {
            ResetNumber();
            ResetEnchPreHM();
            ResetEnchHM();
            ResetEnchPostML();
            ResetEnchPower();
            ResetTrigger();
            ResetAccessories();
            //直接启用盗贼潜伏攻击
            Player.Calamity().wearingRogueArmor = Player.HeldItem.CountClassAs<RogueDamageClass>();
        }
        //重置魂石特殊效果
        public void ResetEnchPower()
        {
            EmpyreanEnchForceStealth = false;
            EnchDesertProwlerDamage = false;
            EnchStatigelArea = false;
            EnchMarniteArchAutoSmelt = false;
            EnchMarniteArchStat = false;
            EnchSnowruffianFalling = false;
            EnchTarragonToughness = false;
            EnchTarragonTakeDamage = 0;
            EnchBloodflareOverSatu = false;
        }
        //重置月后魂石
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
        //重置肉后魂石
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
        //重置肉前魂石
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
            GetDamageMult = 1f;
            GetDirectlyDR = 1f;
        }
        public void ResetAccessories()
        {
            GuarrantedPrestige = false;
            MirrorLevel = 0;
            SheathLevel = 0;
        }
        //死亡时重置
        public override void UpdateDead()
        {
            IsUsedEnchSilvaReborn = false;
            EnchBloodFlareIsDoneSatu = false;
            EnchBloodFlareCanHealAgain = false;
            UpdateDeadTrigger();
        }
        #endregion
        public override void Load()
        {
            base.Load();
        }
    }
}
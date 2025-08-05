using System;
using System.Collections.Generic;
using System.Linq;
using CalamityMod;
using CalamityMod.Buffs.StatBuffs;
using CalamityMod.CalPlayer;
using CalamityMod.Items.Armor.Silva;
using CalamitySoulPorted.ItemNew.Accessories.CalamityModify.FuckCalamityRogue;
using CalamitySoulPorted.ItemsPorted.Enchs.PostML;
using CalamitySoulPorted.SoulCooldowns.AncientGodSlayerReborn;
using CalamitySoulPorted.SoulCustomSounds;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace CalamitySoulPorted.PlayerSoul
{
    public partial class SoulPlayer : ModPlayer
    {
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genDust, ref PlayerDeathReason damageSource)
        {
            var calPlayer = Player.Calamity();
            //远古弑神魔石强起
            if (EnchAncientGodSlayer && !Player.HasCooldown(AncientGodSlayerCooldown.ID))
            {
                SoundEngine.PlaySound(SoulSoundID.SoundRainbowGun, Player.Center);
                //粒子
                SendGodSlayerRebornDust();
                //回1/5
                Player.Heal(Player.statLifeMax2 / 5);
                //无龙魂，不做特判
                //给CD
                Player.AddCooldown(AncientGodSlayerCooldown.ID, 1800);
                //启用免死
                return false;
            }
            if (EnchSilvaReborn(calPlayer))
                return false;
            //林海魔石强起
            //两个boolen ; 1 玩家仅佩戴林海魂石，不包括弑神魂石
            //2玩家佩戴弑神魂石与林海魂石
            
            return true;
        }

        

        public void SendGodSlayerRebornDust()
        {
            for (int i = 0; i < 50; i++)
            {
                int nebulousReviveDust = Dust.NewDust(Player.position, Player.width, Player.height, DustID.ShadowbeamStaff, 0f, 0f, 100, default, 2f);
                    Dust dust = Main.dust[nebulousReviveDust];
                    dust.position.X += Main.rand.Next(-20, 21);
                    dust.position.Y += Main.rand.Next(-20, 21);
                    dust.velocity *= 0.9f;
                    dust.scale *= 1f + Main.rand.Next(40) * 0.01f;
                    // Change this accordingly if we have a proper equipped sprite.
                    dust.shader = GameShaders.Armor.GetSecondaryShader(Player.cBody, Player);
                    if (Main.rand.NextBool())
                        dust.scale *= 1f + Main.rand.Next(40) * 0.01f;
            }
        }
        public override bool FreeDodge(Player.HurtInfo info)
        {
            //日影魔石满充能后给予一个闪避
            if (EnchUmbraphile && EnchUmbNotHoldingWeaponCounter == -1)
            {
                //粒子。
                SendDodgeDust();
                EnchUmbNotHoldingWeaponCounter = 0;
                return true;
            }
            //远古弑神自起成功后给予一个无时限的闪避
            if (EnchAncientGodSlayer && Player.HasCooldown(AncientGodSlayerCooldown.ID) && EnchAncientGodSlayerRebornDodge)
            {
                EnchAncientGodSlayerRebornDodge = false;
                return true;
            }
            #region 魔镜Dodge
            //玩家佩戴任意魔镜类饰品
            if (MirrorDodge())
                return true;
            
            return false;
            #endregion
        }

        

        public void SendDodgeDust()
        {
            for (int i = 0; i < 32; i++)
            {
                Vector2 dir = MathHelper.ToRadians(i / 32f * 360f).ToRotationVector2();
                Dust flame = Dust.NewDustPerfect(Player.Center + dir, DustID.GoldFlame);
                flame.noGravity = true;
                flame.velocity = dir * 4f;
                flame.scale = 2.4f;
                Dust dark = Dust.NewDustPerfect(Player.Center, DustID.AncientLight);
                dark.noGravity = true;
                dark.noLight = true;
                dark.velocity = dir * 3f;
                dark.scale = 1.6f;
                dark.color = Color.Black;
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Vector2 dir = MathHelper.ToRadians(i * 45f).ToRotationVector2() * 1.2f;
                    if (i % 2 == 0) dir *= 1.2f;
                    dir *= (4 + j) / 4f;
                    Dust flame = Dust.NewDustPerfect(Player.Center + dir, DustID.GoldFlame);
                    flame.noGravity = true;
                    flame.velocity = dir * 4f;
                    flame.scale = 2.4f;
                }
            }
        }
        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            //龙蒿盔甲韧性

        }
        public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        {
            // GodSlayerEnchDR();
            // EmpyreanEnchDR();
            if (EnchTarragonToughness)
                ToughnessCalculate(npc.damage, ref modifiers);
        }


        public override void ModifyHitByProjectile(Projectile proj, ref Player.HurtModifiers modifiers)
        {
            // GodSlayerEnchDR();
            // EmpyreanEnchDR();
            if (EnchTarragonToughness)
            {
                int actualDamage = proj.damage;
                ToughnessCalculate(actualDamage, ref modifiers);
            }
        }
        
        //皇天魔石三次机会
        public void EmpyreanEnchDR()
        {
            //有次数盾且日影模式仍然存在时不启用
            if (EmpyreanShieldCD == 0 && EnchUmbNotHoldingWeaponCounter == -1)
                return;

            //承伤时 -1
            if (EmpyreanShieldTimes == 0)
            {
                EmpyreanShieldCD = 120;
                return;
            }
            EmpyreanShieldTimes--;
            Main.NewText("皇天免伤-1");
            //20%免伤
            float actualDR = 1 - 0.2f;
            GetDirectlyDR *= actualDR;
        }

        //弑神魔石免伤 
        public void GodSlayerEnchDR()
        {
            if (GodSlayerEnchDamageReductionCounter <= 0)
                return;

            //20%免伤
            float actualDR = 1 - 0.2f;
            GetDirectlyDR *= actualDR;
        }
        public override void OnHurt(Player.HurtInfo info)
        {
            var calPlayer = Player.Calamity();
            MirrorStealthRegen(calPlayer);
            if (EnchExoShield)
                ExoShieldActive(calPlayer, info);
            if (EnchTarragonToughness && EnchTarragonTakeDamage == 0)
            {
                int actualDamage = info.Damage - Player.statDefense;
                if (actualDamage < info.Damage * 0.85f)
                    return;
                EnchTarragonTakeDamage = actualDamage;
            }
        }
        #region 魔镜承伤相关
        public bool MirrorDodge()
        {


            //没有魔镜等级直接返回
            if (MirrorLevel <= 0)
                return false;
            else
            {
                int giveChance = -1;
                switch (MirrorLevel)
                {
                    case 1:
                        //1/7
                        giveChance = ReworkMirageMirror.DodgeChance;
                        break;
                    case 2:
                        //1/6
                        giveChance = ReworkAbyssalMirror.DodgeChance;
                        break;
                    case 3:
                        //1/5
                        giveChance = ReworkEclipseMirror.DodgeChance;
                        break;
                    default:
                        break;
                }
                bool shouldDodgeChance = giveChance > 0 ? Main.rand.NextBool(giveChance) : false;
                //闪避成功恢复对应的潜伏值。基础恢复50%，魔镜等级+1，提升恢复量
                if (shouldDodgeChance)
                    Player.Calamity().rogueStealth = Player.Calamity().rogueStealthMax * 0.25f * MirrorLevel;
                return shouldDodgeChance;
            }
        }
        public void MirrorStealthRegen(CalamityPlayer calPlayer)
        {
            if (MirrorLevel > 0)
            {
                float giveRegen = 0f;
                switch (MirrorLevel)
                {
                    case 1:
                        //1/7
                        giveRegen = ReworkMirageMirror.OnHurtStealthRegen;
                        break;
                    case 2:
                        //1/6
                        giveRegen = ReworkAbyssalMirror.OnHurtStealthRegen;
                        break;
                    case 3:
                        //1/5
                        giveRegen = ReworkEclipseMirror.OnHurtStealthRegen;
                        break;
                    default:
                        break;
                }
                calPlayer.rogueStealth = calPlayer.rogueStealthMax * giveRegen;
            }
        }
        #endregion
    }
}
using System;
using System.Numerics;
using CalamityMod;
using CalamityMod.Buffs.StatBuffs;
using CalamityMod.Items.Armor.Silva;
using CalamitySoulPorted.PlayerSoul.SoulDashesManage;
using CalamitySoulPorted.SoulCooldowns.AncientGodSlayerReborn;
using CalamitySoulPorted.SoulMethods;
using CalamitySoulPorted.SoulSounds;
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
            //林海魔石强起
            //两个boolen ; 1 玩家仅佩戴林海魂石，不包括弑神魂石
            //2玩家佩戴弑神魂石与林海魂石
            if ((EnchSilva && !EnchAncientGodSlayer && EnchSilvaRebornCounter > 0) || (EnchSilva && EnchAncientGodSlayer && EnchSilvaRebornCounter > 0 && Player.HasCooldown(AncientGodSlayerCooldown.ID)))
            {
                //给予一次
                if (EnchSilvaRebornCounter == EnchSilvaRebornDuration)
                {
                    Player.AddBuff(ModContent.BuffType<SilvaRevival>(), EnchSilvaRebornDuration);
                    //音效
                    SoundEngine.PlaySound(SilvaHeadSummon.ActivationSound, Player.Center);
                }
                //林海强起后给翅膀的治疗效果
                if (!IsUsedEnchSilvaReborn)
                    Player.Heal(Player.statLifeMax2 / 2);
                //结束林海强起
                IsUsedEnchSilvaReborn = true;
                //防处死处理
                if (Player.statLife < 1)
                    Player.statLife = 1;
                //血神圣杯特判.
                if (calPlayer.chaliceOfTheBloodGod)
                {
                    calPlayer.chaliceBleedoutBuffer = 0D;
                    calPlayer.chaliceDamagePointPartialProgress = 0D;
                }
                return false;
            }
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
            return false;
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
        public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        {
            GodSlayerEnchDR();
            EmpyreanEnchDR();
            //直接乘以这个数
            modifiers.SourceDamage *= GetDirectlyDR;
            GetDirectlyDR = 1f;
        }
        public override void ModifyHitByProjectile(Projectile proj, ref Player.HurtModifiers modifiers)
        {
            GodSlayerEnchDR();
            EmpyreanEnchDR();
            //直接乘以这个数
            modifiers.SourceDamage *= GetDirectlyDR;
            //计算完之后记得重置免伤数据
            GetDirectlyDR = 1f;
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
        }
    }
}
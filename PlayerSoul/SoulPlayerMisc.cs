using CalamityMod;
using CalamityMod.Cooldowns;
using CalamityMod.Items.Armor.Silva;
using CalamitySoulPorted.BuffsPoted;
using CalamitySoulPorted.ItemsPorted.Enchs.HM;
using CalamitySoulPorted.SoulCustomSounds;
using CalamitySoulPorted.SoulMethods;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.PlayerSoul
{
    public partial class SoulPlayer : ModPlayer
    {
        public override void PostUpdateMiscEffects()
        {
            Enchantment();
            EnchantmentBuff();
            EnchCounters();
            AccessoriesBuff();
            CustomSpeedUpdate();
            EffectRelatedOnNPC();
        }

        private void EffectRelatedOnNPC()
        {
        }

        public void AccessoriesBuff()
        {
            #region 斯塔提斯擦弹
            bool statisShouldGaze = false;
            //擦撞NPC
            foreach (NPC npc in Main.npc)
            {
                if (!npc.active)
                    continue;

                float distRec = SoulMethod.DistFromRectan(Player.Center, npc.Hitbox);
                float dist = (Player.Center - npc.Center).Length();

                if (!npc.friendly && npc.damage > 0 && EnchStatigelArea)
                {
                    Main.NewText("擦撞NPC");
                    statisShouldGaze = StatisGaze(distRec);
                }
            }
            //擦撞Projs
            foreach (Projectile proj in Main.projectile)
            {
                if (!proj.active)
                    continue;
                
                float distRec = SoulMethod.DistFromRectan(Player.Center, proj.Hitbox);
                if (!statisShouldGaze && proj.hostile && distRec < 125f && EnchStatigelArea)
                {
                    statisShouldGaze = true;
                    Main.NewText("擦撞射弹");
                }
            }
            //处理擦弹buff
            if (statisShouldGaze && EnchStatigelArea)
            {
                int statigelBuffType = ModContent.BuffType<EnchStatigelDamageBuff>();
                int getIndex = Player.FindBuffIndex(statigelBuffType);
                if (getIndex == -1)
                {
                    Player.AddBuff(statigelBuffType, 900);
                    Player.GiveImmnueTime(90);
                }
            }
            #endregion
        }

        private bool StatisGaze(float distRec)
        {
            if (!EnchStatigelArea)
                return false;
            if (distRec < 125f)
                return true;

            return false;
        }

        private void EnchantmentBuff()
        {
            //日影魔石 + 10%攻速
            if (EnchUmbraphileBuff)
                Player.GetAttackSpeed<GenericDamageClass>() += UmbraphileEnchant.EnchUmbraphileAttackSpeedBouns;
        }

        public void Enchantment()
        {
            var calPlayer = Player.Calamity();
            //钨钢
            EnchWulfrumEffect(calPlayer);
            //雪境
            if (EnchSnowruffian)
                EnchSnowruffianFalling = true;
            //沙漠行者：面板伤害
            if (EnchDesertProwler)
                EnchDesertProwlerDamage = true;

            if (EnchStatigel)
                EnchStatigelArea = true;

            if (EnchTarragon)
            {
                EnchTarragonToughness = true;
                Player.noKnockback = true;
            }

            #region 林海相关
            //林海自起
            if (IsUsedEnchSilvaReborn && EnchSilvaRebornCounter > 0)
            {
                //下跑Counter
                if (EnchSilvaRebornCounter > 0)
                    EnchSilvaRebornCounter--;
                //免疫灾厄提供的Debuff清单
                foreach (int debuff in CalamityLists.debuffList)
                    Player.buffImmune[debuff] = true;
                //补置零效果
                if (Player.lifeRegen < 1)
                    Player.lifeRegen = 1;
                //粒子
                EnchSilvaDust();
                //Counter结束，给CD
                if (EnchSilvaRebornCounter <= 0)
                {
                    SoundEngine.PlaySound(SilvaHeadSummon.DispelSound, Player.Center);
                    Player.AddCooldown(SilvaRevive.ID, CalamityUtils.SecondsToFrames(5));
                }
            }
            //CD结束，重置林海自起
            if (!Player.HasCooldown(SilvaRevive.ID) && IsUsedEnchSilvaReborn && EnchSilvaRebornCounter <= 0)
            {
                EnchSilvaRebornCounter = EnchSilvaRebornDuration;
                IsUsedEnchSilvaReborn = false;
            }
            //林海强起
            if (EnchSilva && EnchSilvaForceHealCounter > 0)
            {
                EnchSilvaForceHealCounter--;
                if (Player.statLife < Player.statLifeMax2 - 50)
                {
                    Player.statLife += 5;
                    Player.HealEffect(5);
                }
            }
            #endregion
            //日影魔石将会重置
            if (EnchUmbraphile)
            {
                //蓄能大于10秒即可
                if (EnchUmbNotHoldingWeaponCounter >= EnchUmbNotHoldingWeaponDuration)
                {
                    //Send a tint.
                    SoundEngine.PlaySound(SoulSoundID.SoundFallenStar, Player.Center);
                    //粒子
                    //Set to -1
                    EnchUmbNotHoldingWeaponCounter = -1;
                }
                if (EnchUmbNotHoldingWeaponCounter >= 0)
                {
                    EnchUmbNotHoldingWeaponCounter++;
                    //日影非手持效果下的降CD
                    if (Player.itemAnimation > 0) EnchUmbNotHoldingWeaponCounter = 0;
                }
                if (EnchUmbNotHoldingWeaponCounter == -1)
                {
                    //大于10秒下提供这个buff
                    Player.AddBuff(ModContent.BuffType<EnchUmbraphileBuff>(), 2);
                }
            }
            //天蓝：冲刺
            if (EnchAerospec)
                EnchAeroJumping = true;
            //合成岩建筑师：自动熔炼
            if (EnchMarniteArchitect)
                EnchMarniteArchAutoSmelt = true;
        }

        public void EnchSilvaDust()
        {
            for (int i = 0; i < 2; i++)
            {
                int d = Dust.NewDust(Player.position, Player.width, Player.height, DustID.Chlorophyte, 0f, 0f, 100, new Color(Main.DiscoR, 203, 103), 2f);
                Main.dust[d].position.X += Main.rand.Next(-20, 21);
                Main.dust[d].position.Y += Main.rand.Next(-20, 21);
                Main.dust[d].velocity *= 0.9f;
                Main.dust[d].noGravity = true;
                Main.dust[d].scale *= 1f + Main.rand.Next(40) * 0.01f;
                Main.dust[d].shader = GameShaders.Armor.GetSecondaryShader(Player.ArmorSetDye(), Player);
                if (Main.rand.NextBool())
                    Main.dust[d].scale *= 1f + Main.rand.Next(40) * 0.01f;

            }
        }

        public void CustomSpeedUpdate()
        {
            Player.runAcceleration *= GetAcceleration;
            Player.maxRunSpeed *= GetRunSpeed;
            Player.accRunSpeed *= GetRunSpeed;
        }
    }
}
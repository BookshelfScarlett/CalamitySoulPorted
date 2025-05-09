using CalamityMod;
using CalamityMod.Buffs.Summon;
using CalamityMod.Cooldowns;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Silva;
using CalamityMod.Projectiles.Summon;
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
            EnchCounters();
            CustomSpeedUpdate();

        }
        public void Enchantment()
        {
            var calPlayer = Player.Calamity();
            //钨钢
            if (WulfrumEnch)
            {
                int droneBuff = ModContent.BuffType<WulfrumDroidBuff>();
                //给生命恢复与1栏位
                Player.maxMinions += 1;
                Player.lifeRegen += 2;
                //挖掘速度
                Player.pickSpeed -= 0.25f;
                //无人机
                Player.maxMinions += 2;
                if (Player.FindBuffIndex(droneBuff) == -1)
                    Player.AddBuff(droneBuff, 3600, true);

                if (Player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumDroid>()] < 2)
                     Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, Vector2.Zero, ModContent.ProjectileType<WulfrumDroid>(), (int)Player.GetTotalDamage<SummonDamageClass>().ApplyTo(16), 0f, Player.whoAmI);
                //盾
                calPlayer.roverDrive = true;
                if (calPlayer.RoverDriveShieldDurability > 0)
                    Player.statDefense += RoverDrive.ShieldDefenseBoost;
                
            }
            //雪境
            if (SnowruffianEnch)
            {
                //空中移速
                if (Player.velocity.Y != 0)
                {
                    GetRunSpeed *= 1.2f;
                    GetAcceleration *= 1.2f;
                }
                //免疫摔落伤害
                Player.noFallDmg = true;
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
            if (SilvaEnch && EnchSilvaForceHealCounter > 0)
            {
                EnchSilvaForceHealCounter--;
                if (Player.statLife < Player.statLifeMax2 - 50)
                {
                    Player.statLife += 5;
                    Player.HealEffect(5);
                }
            }
            #endregion
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
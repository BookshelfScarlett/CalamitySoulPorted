using CalamityMod;
using CalamityMod.Buffs.Summon;
using CalamityMod.CalPlayer;
using CalamityMod.Items.Accessories;
using CalamityMod.Projectiles.Summon;
using CalamitySoulPorted.BuffsPoted;
using CalamitySoulPorted.ItemsPorted.Enchs.PostML;
using CalamitySoulPorted.SoulCustomSounds;
using CalamitySoulPorted.SoulMethods;
using CalamitySoulPorted.SoulProjectiles.HealingProj;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.PlayerSoul
{
    public partial class SoulPlayer : ModPlayer
    {
        #region 血炎魔石过饱和与击中回血机制
        //血炎饱和治疗
        public void HandleBloodflareGetHeal(Item item, bool quickHeal, ref int healValue)
        {
            if (!EnchBloodflareOverSatu && !quickHeal)
                return;
            
            bool hasOverSatu = Player.HasBuff<EnchBloodflareOverSatuBuff>();
            if (hasOverSatu)
            {
                int healAmt = (int)(item.healLife * Player.Calamity().healingPotionMultiplier);
                CalculateOverHeal(healAmt, ref healValue);
                Player.HandlePotionSick();
                return;
            }
        }
        
        public void HandlePotionSickForEnchBF()
        {
            if (!EnchBloodflareOverSatu)
                return;
            if (PlayerInput.Triggers.JustPressed.QuickHeal)
            {
                bool isGrantedBuff = Player.HasBuff<EnchBloodflareOverSatuBuff>();
                if (!isGrantedBuff)
                {
                    Player.HandlePotionSick();
                }
                //只有玩家低于最大生命值时才能正常降低治疗量，避免某些人都满生命值了还狂按H结果后续只能吃1血
                else if (Player.statLife < Player.statLifeMax2 && EnchBFInnerCD.IsDone())
                    EnchBloodflareReducedHealing += 1 * isGrantedBuff.ToInt();
                //经过60帧时才判定增加
                Player.AddBuff<EnchBloodflareOverSatuBuff>(BloodflareEnchant.OverSaturationTime.IntToFrames());
                EnchBFInnerCD = 60;
            }
        }
        private void CalculateOverHeal(int healAmt, ref int finalValue)
        {
            int shouldHeal = healAmt;
            //先减去这个值
            shouldHeal -= BloodflareEnchant.MinusHealAmount * (1 + EnchBloodflareReducedHealing);
            if (shouldHeal <= 0)
            {
                finalValue = BloodflareEnchant.MininumHealAmount;
                return;
            }

            //每次遍历这个循环时，都会在这个治疗量上不断削减
            //治疗次数 + 1
            finalValue = shouldHeal;

        }
        public static void BloodflareHealingEffect(CalamityPlayer calPlayer)
        {
            calPlayer.healingPotionMultiplier += BloodflareEnchant.ExtraHealAmt;
        }
        private void EffectBloodflareEnchDrain(NPC target, NPC.HitInfo hit)
        {
            if (!EnchBloodflare)
                return;
                
            if (Main.rand.Next(BloodflareEnchant.SpawnHealingChance) - EnchBloodflareCurChance <= 0)
            {
                SoundEngine.PlaySound(SoundID.Item103, target.Center);
                int basicHeal = 20;
                int spawnCounts = 5;
                int healPerProj = basicHeal / spawnCounts;
                SoulMethod.HealProj<EnchBloodflareHealing>(target.GetSource_FromThis(), target.Center, Player, healPerProj, CD: 60, spawnCounts: 5, eu: 2);
                EnchBloodflareCurChance = 0;
            }
            else
                EnchBloodflareCurChance++;
        }
        #endregion
        private void EnchSnowruffianEffect()
        {
            if (EnchSnowruffianFalling)
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
        }
        private void EnchWulfrumEffect(CalamityPlayer calPlayer)
        {
            if (EnchWulfrum)
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
        }
    }
}
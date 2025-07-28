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
            if (!EnchBloodflareOverSatu)
                return;
            
            bool hasOverSatu = Player.HasBuff<EnchBloodflareOverSatuBuff>();
            if (hasOverSatu)
            {

                if (!quickHeal)
                    return;

                Main.NewText("GetHealingHandle", Color.Red);
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
            if (!Player.HasBuff<EnchBloodflareOverSatuBuff>() && PlayerInput.Triggers.JustPressed.QuickHeal)
            {
                Player.AddBuff<EnchBloodflareOverSatuBuff>(BloodflareEnchant.OverSaturationTime.IntToFrames());
                Player.HandlePotionSick();
            }
            Main.NewText("MiscEffectHandle", Color.Red);
        }
        private void CalculateOverHeal(int healAmt, ref int finalValue)
        {
            int shouldHeal = healAmt;
            //先减去这个值
            shouldHeal -= BloodflareEnchant.MinusHealAmount;
            if (shouldHeal <= 0)
            {
                finalValue = BloodflareEnchant.MininumHealAmount;
                return;
            }
            //每次遍历这个循环时，都会在这个治疗量上不断削减
            //标记他
            EnchBloodFlareIsDoneSatu = true;
            finalValue = shouldHeal;

        }
        public static void BloodflareHealingEffect(CalamityPlayer calPlayer)
        {
            calPlayer.healingPotionMultiplier += BloodflareEnchant.ExtraHealAmt;
        }
        private void EffectBloodflareEnchDrain(NPC target, NPC.HitInfo hit)
        {
            if (Main.rand.Next(BloodflareEnchant.SpawnHealingChance) - EnchBloodflareCurChance <= 0)
            {
                SoundEngine.PlaySound(SoundID.Item103, target.Center);
                SoulMethod.HealProj<EnchBloodflareHealing>(target.GetSource_FromThis(), target.Center, Player, 20, CD: 60);
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
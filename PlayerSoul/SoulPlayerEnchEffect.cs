using System;
using System.Collections.Generic;
using System.Linq;
using CalamityMod;
using CalamityMod.Buffs.StatBuffs;
using CalamityMod.Buffs.Summon;
using CalamityMod.CalPlayer;
using CalamityMod.Cooldowns;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Silva;
using CalamityMod.Projectiles.Rogue;
using CalamityMod.Projectiles.Summon;
using CalamitySoulPorted.BuffsPoted;
using CalamitySoulPorted.ItemsPorted.Enchs.PostML;
using CalamitySoulPorted.SoulCooldowns.AncientGodSlayerReborn;
using CalamitySoulPorted.SoulCustomSounds;
using CalamitySoulPorted.SoulMethods;
using CalamitySoulPorted.SoulProjectiles.EnchProjectiles;
using CalamitySoulPorted.SoulProjectiles.HealingProj;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.PlayerSoul
{
    public partial class SoulPlayer : ModPlayer
    {
        #region 星流护盾
        public void ExoShieldActive(CalamityPlayer calPlayer, Player.HurtInfo info)
        {
            if (info.Damage > ExoEnchant.ShieldActiveDamage)
                Player.AddBuff<EnchShieldBuff>(SoulMethod.IntToFrames(10));

        }
        #endregion
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
        #region 龙蒿魔石盔甲韧性计算
        private void ToughnessCalculate(int damage, ref Player.HurtModifiers modifiers)
        {
            int shouldTake = damage;
            //将原始的伤害随机拆分成多个小块伤害，由大至小排序，每一小块伤害差值最少为50
            List<int> damageList = SeperateDamageList(shouldTake);
            int finalTaken = 0;
            foreach (int dmg in damageList)
            {
                if (dmg < 0)
                    continue;
                //将伤害表遍历进韧性衰减方法，伤害量越高，其韧性提供的伤害减免越强
                float debugTough = TryCalToughness(dmg);
                //获得一次韧性保护之后，直接将这个伤害乘以这个韧性并叠加
                finalTaken += Math.Max(1, (int)(dmg * (1f - debugTough)));
            }
            
            int realShouldTake = ((damage - finalTaken) > 1).ToInt() * (damage - finalTaken);
            //最终承伤
            modifiers.FinalDamage.Flat -= realShouldTake;
        }
        public static float TryCalToughness(int damage)
        {
            //开始进行盔甲韧性的计算
            //最低趋近韧性：5%，最高趋近韧性：30%
            const float miniTough = TarragonEnchant.ArmorToughnessMin;
            const float maxTough = TarragonEnchant.ArmorToughnessMax;
            //衰减系数：0.25%
            const float k = TarragonEnchant.ArmorToughnessReduceRate;
            //计算实际韧性，承伤越低，韧性的衰减速度会越高
            float scaledDamage = Math.Max(1, damage);
            float tough = miniTough + (maxTough - miniTough) * (1 - (float)Math.Exp(-k * scaledDamage));
            //使结果不会低于最小值
            return Math.Clamp(tough, miniTough, maxTough);
        }
        //数学公式这一块，目前大概没问题了
        public static List<int> SeperateDamageList(int damage)
        {
            //边界处理：伤害过小时直接返回原伤害（避免拆分）
            int minSafeDamage = TarragonEnchant.DamageDivityRateMin * 2;
            if (damage <= minSafeDamage)
            {
                return [damage];
            }
            //获取随机值
            Random rand = new();
            //建空表
            List<int> list = [];
            int divityRateMin = TarragonEnchant.DamageDivityRateMin;
            int divityRateMax = TarragonEnchant.DamageDivityRateMax;
            //最大循环次数
            int maxRetries = 25;
            int retryTimes = 0;
            while (retryTimes < maxRetries)
            {
                //清理可能无效的结果
                list.Clear();
                retryTimes++;
                //依据随机值取传入进来的伤害的可能存在的最大拆分数
                int possbileMax = 1;
                //可能是这里有问题（？
                //获得最大拆分数
                possbileMax = CalMaxPossbileSplit(damage, divityRateMin);
                possbileMax = Math.Max(2, possbileMax);
                //根据伤害大小设置拆分数量范围
                int minCount = 2;
                int maxCount = Math.Min(possbileMax, (int)(damage / (divityRateMin * 2f)));
                maxCount = Math.Max(minCount, maxCount);
                //择优录取（X）随机选择至少两个数
                int count = rand.Next(minCount, maxCount + 1);
                //生成随机差值
                int totalDiffer = 0;
                int[] randDiffer = new int[count - 1];
                for (int i = 0; i < randDiffer.Length; i++)
                {
                    randDiffer[i] = rand.Next(divityRateMin, divityRateMax + 1);
                    totalDiffer += randDiffer[i];
                }
                //计算第一个数的值
                int firstNum = (damage + totalDiffer) / count;
                //然后，生成所有的数值
                list.Add(firstNum);
                int cur = firstNum;

                foreach (int differ in randDiffer)
                {
                    cur -= differ;
                    list.Add(cur);
                }
                //将总和精确性地调整为原本的伤害值
                int listTotal = list.Sum();
                if (listTotal != damage)
                {
                    int adjust = damage - listTotal;
                    //如果存在误差，将其直接给第一个数
                    list[0] += adjust;
                }
                //查阅是否存在负数
                bool allPositive = true;
                foreach (int val in list)
                {
                    if (val <= 0)
                    {
                        allPositive = false;
                        break;
                    }
                }
                if (allPositive)
                    break;
            }
            //极端情况：多次重试后仍无效，返回原伤害（避免崩溃）
            if (list.Any(v => v <= 0) || list.Count == 0)
            {
                list.Clear();
                list.Add(damage);
            }
            //将排序好的表单返回即可
            return list;
        }

        private static int CalMaxPossbileSplit(int damage, int divityRateMin)
        {
            //基于等差数列去求可能存在的最大拆分数
            int maxN = 1;
            while (true)
            {
                //计算n+1时的最小理论总和
                long minSum = (long)(maxN + 1) * maxN * divityRateMin/ 2;
                if (minSum >= damage)
                    break;
                    
                maxN++;
            }
            return maxN;
        }

        //计算i个数字的最小可能总和（差值都取50）
        public static int TryCalMinSum(int i, int damage, int divityRateMin) => (damage * 2 + divityRateMin * (i - 1) * (i - 2)) / (2 * i);
        #endregion
        #region 金源灭弹
        public void AuricTeslaClearBullet(CalamityPlayer calPlayer)
        {
            if (Player.whoAmI != Main.myPlayer)
                return;
            int auricFlash = ModContent.ProjectileType<AuricFlash>();
            Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, Vector2.Zero, auricFlash, 0, 0f, Player.whoAmI);
            float randAngle = Main.rand.NextFloat(MathHelper.TwoPi);
            //这金源魔石怎么还会在原地拉史呢
            for (int i = 0; i < 15; i++)
            {
                Vector2 direction = (MathHelper.ToRadians(i * 360f / 15) + randAngle).ToRotationVector2();
                int damage = (int)Player.GetBestClassDamage().ApplyTo(5000);
                Projectile manWhatCanISay = Projectile.NewProjectileDirect(Player.GetSource_FromThis(), Player.Center + direction * 32f, direction * 1f, ModContent.ProjectileType<DragonShit>(), damage, 10f, Player.whoAmI);
                manWhatCanISay.DamageType = DamageClass.Generic;
            }
        }
        #endregion
        #region 林海强起
        private bool EnchSilvaReborn(CalamityPlayer calPlayer)
        {
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
                return true;
            }
            else return false;
        }
        //林海强起执行时的相关操作
        private void EnchSilvaRegen()
        {
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
        }
        //粒子
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
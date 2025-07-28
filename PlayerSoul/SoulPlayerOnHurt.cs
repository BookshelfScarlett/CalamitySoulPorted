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
using CalamityMod;
using CalamityMod.Buffs.StatBuffs;
using CalamityMod.Items.Armor.Silva;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalamitySoulPorted.PlayerSoul
{
    public partial class SoulPlayer : ModPlayer
    {
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genDust, ref PlayerDeathReason damageSource)
        {
            var calPlayer = Player.Calamity();
            //林海魔石强起
            if (SilvaEnch && EnchSilvaRebornCounter > 0)
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
        public override void OnHurt(Player.HurtInfo info)
        {
        }
    }
}
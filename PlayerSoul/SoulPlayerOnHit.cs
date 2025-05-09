using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.PlayerSoul
{
    public partial class SoulPlayer : ModPlayer
    {
        public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)
        {
            SnowRuffianEffect(target);
            SilvaEffect(target, hit);
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            SnowRuffianEffect(target);
            SilvaEffect(target, hit);
        }

        private void SnowRuffianEffect(NPC target)
        {
            if (!WulfrumEnch)
                return;
            //并非为boss
            if (Main.rand.NextBool(5) && !target.CheckBoss())
                target.velocity *= 0f;
        }
        //林海
        public void SilvaEffect(NPC target, NPC.HitInfo hit)
        {
            if (!SilvaEnch)
                return;
            //暴击、魔法伤害，符合条件，触发林海强起
            if (hit.CountClassAs<MagicDamageClass>() && hit.Crit)
            {
                if (EnchSilvaForceHealCD == 0 && Main.rand.NextBool(3))
                {
                    EnchSilvaForceHealCounter = EnchSilvaForceHealDuration;
                    EnchSilvaForceHealCD = EnchSilvaForceHealDuration * 4;
                    SoundEngine.PlaySound(SoundID.Item4, Player.Center);
                }
            }
        }
        
    }
}
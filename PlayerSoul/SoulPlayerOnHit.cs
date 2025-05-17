using System;
using CalamityMod;
using CalamityMod.Projectiles.Rogue;
using CalamitySoulPorted.SoulMethods;
using Microsoft.Xna.Framework;
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

        public void UmbraphileEffect(NPC target, Projectile proj)
        {
            if (!UmbraphileEnch)
                return;
            
            
            //日影魔石: 潜伏命中的日影爆炸
            if (proj.CountClassAs<RogueDamageClass>() && EnchUmbBoomCD < 1)
            {
                //1000基伤，吃盗贼增幅
                int damage = (int)Player.GetTotalDamage<RogueDamageClass>().ApplyTo(1000);
                int p = Projectile.NewProjectile(Player.GetSource_FromThis(), target.Center, Vector2.Zero, ModContent.ProjectileType<UmbraphileBoom>(), damage, 0f, Player.whoAmI);
                Main.projectile[p].DamageType = DamageClass.Generic;
                Main.projectile[p].usesLocalNPCImmunity = true;
                Main.projectile[p].localNPCHitCooldown = 10;
                EnchUmbBoomCD = 60;
            }

        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            SnowRuffianEffect(target);
            SilvaEffect(target, hit);
            UmbraphileEffect(target, proj);
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
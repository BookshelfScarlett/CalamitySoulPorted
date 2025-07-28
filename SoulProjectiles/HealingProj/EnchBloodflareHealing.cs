using CalamityMod.Particles;
using CalamitySoulPorted.SoulProjectiles.CustomProjectileClass;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulProjectiles.HealingProj
{
    public class EnchBloodflareHealing : BaseHealProj, ILocalizedModType
    {
        public override string LocalizationCategory => SoulGlobalProjectiles.TypelessPath;
        public override string Texture => SoulGlobalProjectiles.InvisProj;
        public override void ExAI()
        {
            SparkParticle line = new SparkParticle(Projectile.Center - Projectile.velocity * 1.1f, Projectile.velocity * 0.01f, false, 18, 1f, Color.Red);
            GeneralParticleHandler.SpawnParticle(line);
            for (int i = 0; i < 3; i++)
            {
                int d = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Blood, 0f, 0f, 100, default, 0.75f);
                Main.dust[d].noGravity = true;
                Main.dust[d].velocity *= 0f;
            }
        }
    }
}
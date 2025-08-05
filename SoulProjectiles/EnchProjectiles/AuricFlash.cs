using CalamityMod.Projectiles.Boss;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulProjectiles.EnchProjectiles
{
    public class AuricFlash : ModProjectile, ILocalizedModType
    {
        //I don't know how to code
        public new string LocalizationCategory => SoulGlobalProjectiles.TypelessPath;
        public override string Texture => SoulGlobalProjectiles.InvisProj;
        public ref float RangeCounter => ref Projectile.ai[0];
        public ref float Range => ref Projectile.ai[1];
        public ref float DustRing => ref Projectile.localAI[0];
        public const float HitBoxRange = 16f;
        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 1;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 300;
            Projectile.soundDelay = 2;
        }
        
        public override void AI()
        {
            if (Projectile.soundDelay == 1)
            {
                RangeCounter = 1f;
                Range = 64f;
            }
            if (RangeCounter < HitBoxRange)
                RangeCounter *= 1.07f;
            if (Range < 640f)
            {
                Projectile.timeLeft = 60;
                Range += RangeCounter;
            }
            else
                Range += 2f;
            DustRing++;
            if (DustRing % 3 == 0)
            {
                int rand = Main.rand.Next(360);
                int dAmount = (int)(360 * Range / 640);
                for (int i = 0; i < dAmount; i++)
                {
                    if (Main.rand.NextBool(8))
                        continue;
                    Dust d = Dust.NewDustPerfect(Projectile.position + MathHelper.ToRadians(i * 360f / dAmount + rand).ToRotationVector2() * Range, DustID.GoldFlame);
                    d.noGravity = true;
                    d.scale = 1.6f;
                    d.velocity = Vector2.Zero;
                }
            }
            int redMoon = ModContent.ProjectileType<BrimstoneMonster>();
            for (int i = 0; i < Main.projectile.Length; i++)
            {
                Projectile proj = Main.projectile[i];
                if (!proj.active || !proj.hostile || proj.friendly)
                    continue;
                if (proj.type != redMoon && proj.Hitbox.Distance(Projectile.position) < Range)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), proj.Center, Vector2.Zero, ProjectileID.SolarWhipSwordExplosion, 0, 0f, Main.player[Projectile.owner].whoAmI);
                    proj.Kill();
                }
            }
        }
    }
}
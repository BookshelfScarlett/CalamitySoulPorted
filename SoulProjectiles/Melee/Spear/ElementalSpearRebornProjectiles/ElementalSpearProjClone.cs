using System;
using System.Security.Cryptography.X509Certificates;
using CalamityMod;
using CalamityMod.Buffs.DamageOverTime;
using CalamityMod.Projectiles.Melee;
using CalamitySoulPorted.SoulMethods;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulProjectiles.Melee.Spear.ElementalSpearRebornProjectiles
{
    public class ElementalSpearProjClone: ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => SoulGlobalProjectiles.MeleePath;
        private const int TimeLeft = 180;
        public override string Texture => "CalamitySoulPorted/SoulProjectiles/Melee/Spear/ElementalSpearRebornProjectiles/ElementalSpearProj";

        #region Typedef
        public Player Owner => Main.player[Projectile.owner];
        public int AttackTarget
        {
            get => (int)Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }
        public ref float AttackTimer => ref Projectile.ai[1];
        public ref float AttackSprite => ref Projectile.ai[2];
        public const float DoNotSplit = 0f;
        public const float DoSplit = 1f;
        public const float DoFading = 2f;
        public bool PingCanSplit = false;
        #endregion
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.timeLeft = TimeLeft;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 30;
        }
        public override bool? CanDamage() => AttackTimer > 30f;

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 0.05f, 1f, 0.05f);
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + MathHelper.PiOver4;
            DoGeneric();
            AttackTimer += 1f;
            //满足条件后追踪。
            NPC target = Projectile.FindClosestTarget(1800f);
            if (target != null)
            {
                AttackTarget = target.whoAmI;
                if (AttackTimer > 30f)
                {
                    //无视距离。
                    Projectile.HomeInOnTarget(target, 1800f, 16f + AttackTimer / 27f, 20f, 1, null, null, true);
                }
                else if (target is null) Projectile.Kill();
            }
        }

        private void DoGeneric()
        {
            #region 处理视觉效果
            if (Main.rand.NextBool())
            {
                int dust = Dust.NewDust(Projectile.oldPosition + Projectile.oldVelocity, Projectile.width, Projectile.height, DustID.TerraBlade, 0f, 0f, 100, default, 1.25f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0f;
                Main.dust[dust].noLightEmittence = true;
            }
            #endregion
        }

        public override Color? GetAlpha(Color lightColor) => new Color(128, byte.MaxValue, 128);

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D tex = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value; 
            string PathKey = "CalamityMod/Projectiles/Melee";
            //选择贴图，进行绘制。
            switch (AttackSprite)
            {
                case 0:
                    tex = ModContent.Request<Texture2D>($"{PathKey}/SpatialSpear").Value;
                    break;
                case 1:
                    tex = ModContent.Request<Texture2D>($"{PathKey}/SpatialSpear2").Value;
                    break;
                case 2:
                    tex = ModContent.Request<Texture2D>($"{PathKey}/SpatialSpear3").Value;
                    break;
                case 3:
                    tex = ModContent.Request<Texture2D>($"{PathKey}/SpatialSpear4").Value;
                    break;
            }
            CalamityUtils.DrawAfterimagesCentered(Projectile, ProjectileID.Sets.TrailingMode[Projectile.type], lightColor, 2, tex);
            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<ElementalMix>(), 30);
            //提取Target
            NPC wantedTarget = Main.npc[AttackTarget];
            if (wantedTarget != null && target.whoAmI == AttackTarget)
            {
                Projectile.Kill();
                Projectile.netUpdate = true;
            }
        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.Center);
            for (int i = 4; i < 31; i++)
            {
                float projOldX = Projectile.oldVelocity.X * (30f / i);
                float projOldY = Projectile.oldVelocity.Y * (30f / i);
                int dust = Dust.NewDust(new Vector2(Projectile.oldPosition.X - projOldX, Projectile.oldPosition.Y - projOldY), 8, 8, DustID.TerraBlade, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default, 1.8f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].noLightEmittence = true;

                dust = Dust.NewDust(new Vector2(Projectile.oldPosition.X - projOldX, Projectile.oldPosition.Y - projOldY), 8, 8, DustID.TerraBlade, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default, 1.4f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0.1f;
                Main.dust[dust].noLightEmittence = true;
            }
        }
    }
}

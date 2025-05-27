using System;
using CalamityMod;
using CalamityMod.Buffs.DamageOverTime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulProjectiles.Melee.Spear.ElementalSpearRebornProjectiles
{
    public class ElementalSpearProj: ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => SoulGlobalProjectiles.MeleePath;

        private const int TimeLeft = 180;

        #region Typedef
        public Player Owner => Main.player[Projectile.owner];
        public ref float AttackType => ref Projectile.ai[0];
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
            Projectile.penetrate = 1;
            Projectile.timeLeft = TimeLeft;
        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 0.05f, 1f, 0.05f);
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + MathHelper.PiOver4;
            DoGeneric();
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
            
            //Split the Spear
            int numProj = 4;
            float rotation = MathHelper.ToRadians(15);
            float speed = 13f;
            if (Owner.whoAmI != Projectile.owner)
                return;
            for (int i = 0; i < numProj; i++)
            {
                Vector2 setDefSpeed = Projectile.velocity.SafeNormalize(Vector2.UnitY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (float)(numProj - 1)));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, setDefSpeed * speed, ModContent.ProjectileType<ElementalSpearProjClone>(), (int)(Projectile.damage * 0.8f), 0f, Owner.whoAmI, target.whoAmI, 0f, Main.rand.Next(0, 4));
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

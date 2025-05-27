using System;
using CalamitySoulPorted.ItemNew.Weapons.MeleeWeapon;
using CalamitySoulPorted.SoulMethods;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulProjectiles.Melee.Spear.ElementalSpearRebornProjectiles
{
    public class ElementalSpearRebornProj : ModProjectile
    {
        protected virtual float RangeMin => 56f;
        protected virtual float RangeMax => 196f;
        public override string LocalizationCategory => SoulGlobalProjectiles.MeleePath;
        public override LocalizedText DisplayName => SoulMethod.GetModItemName<ElementalSpearReborn>();
        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 40;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 90;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.ownerHitCheck = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 6;
            Projectile.aiStyle = 19;
        }
        //处理矛的AI
        public override bool PreAI()
        {
            Player owner = Main.player[Projectile.owner];
            int dura = owner.itemAnimationMax;
            owner.heldProj = Projectile.whoAmI;

            //必要时刻重置生命
            if (Projectile.timeLeft > dura)
                Projectile.timeLeft = dura;

            Projectile.velocity = Vector2.Normalize(Projectile.velocity * 5);

            float halfDura = dura * 0.5f;
            float progression;

            if (Projectile.timeLeft < halfDura)
                progression = Projectile.timeLeft / halfDura;
            else
                progression = (dura - Projectile.timeLeft) / halfDura;

            //让矛开始移动
            Projectile.Center = owner.MountedCenter + Vector2.SmoothStep(Projectile.velocity * RangeMin, Projectile.velocity * RangeMax, progression);
            
            //给矛一个正确的转角
            if (Projectile.spriteDirection == -1)
                //贴图朝左，转45°
                Projectile.rotation += MathHelper.ToRadians(45f);
            else
                //贴图朝右，转135°
                Projectile.rotation += MathHelper.ToRadians(135f);
            if (Projectile.ai[0] == 0f)
            {
                //让矛刺出的第一帧发射弹幕，而非顶点发射
                ShootProj();
                Projectile.ai[0] = 1f;
            }

            //干掉AI钩子
            return false;
        }

        private void ShootProj()
        {
            if (Projectile.owner != Main.myPlayer)
                return;
            Vector2 projPos = Projectile.Center + Projectile.velocity;
            Vector2 projVel = Projectile.velocity * 25f;
            float projSprite = Main.rand.Next(0, 4);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), projPos, projVel, ModContent.ProjectileType<ElementalSpearProj>(), Projectile.damage, 0f, Main.myPlayer, 0f, 0f, projSprite);
        }
    }
}
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulProjectiles.CustomProjectileClass
{
    public abstract class BoomerangProjectile : ModProjectile
    {
        /// <summary>
        /// 返程速度
        /// </summary>
        public virtual float ReturnSpeed { get; }
        /// <summary>
        /// 返程加速度
        /// </summary>
        public virtual float Acceleration{ get; }
        /// <summary>
        /// 多远距离下干掉射弹本身
        /// </summary>
        public virtual float KillDistance => 3000f; 
        /// <summary>
        /// 返程时间
        /// </summary>
        public virtual int ReturnTimer{ get; }
        public int Timer = 0;
        //SD请自己写一个。
        public override void AI()
        {
            Timer++;
            if (Timer > ReturnTimer)
            {
                ReturnAI();
                DoReturnBehavior();
            }
            else
            {
                DoShootBehavior();
            }
            //回旋镖返程AI
        }
        /// <summary>
        /// 返程前回旋镖进行的AI
        /// </summary>
        public virtual void DoShootBehavior()
        {

        }
        /// <summary>
        /// 返程时回旋镖进行的AI
        /// </summary>
        public virtual void DoReturnBehavior()
        {

        }
        public void ReturnAI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.tileCollide = false;
            Vector2 distLength = player.Center - Projectile.Center;

            //大于这个距离处死射弹
            float dist = distLength.Length();
            if (dist > KillDistance) Projectile.Kill();
            //转速度向量
            dist = ReturnSpeed / dist;
            distLength.X *= dist;
            distLength.Y *= dist;
            //设置返程加速度
            if (Projectile.velocity.X < distLength.X)
            {
                Projectile.velocity.X += Acceleration;
                if (Projectile.velocity.X < 0f && distLength.X > 0f)
                    Projectile.velocity.X += Acceleration;
            }
            else if (Projectile.velocity.X > distLength.X)
            {
                Projectile.velocity.X -= Acceleration;
                if (Projectile.velocity.X > 0f && distLength.X < 0f)
                    Projectile.velocity.X -= Acceleration;
            }
            if (Projectile.velocity.Y < distLength.Y)
            {
                Projectile.velocity.Y += Acceleration;
                if (Projectile.velocity.Y < 0f && distLength.Y > 0f)
                    Projectile.velocity.Y += Acceleration;
            }
            else if (Projectile.velocity.Y > distLength.Y)
            {
                Projectile.velocity.Y -= Acceleration;
                if (Projectile.velocity.Y > 0f && distLength.Y < 0f)
                    Projectile.velocity.Y -= Acceleration;
            }
            //处死射弹
            if (Main.myPlayer == Projectile.owner)
                if (Projectile.Hitbox.Intersects(player.Hitbox))
                    Projectile.Kill();
        }
    }
}
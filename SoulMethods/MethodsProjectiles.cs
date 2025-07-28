using System;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulMethods
{
    public static partial class SoulMethod
    {
        /// <summary>
        /// 从灾厄那里搬过来的跟踪算法，加了一个角度限制.
        /// <param name="projectile">弹幕类型.</param>
        /// <param name="ignoreTiles">是否无视墙壁.</param>
        /// <param name="distanceRequired">跟踪范围.</param>
        /// <param name="homingVelocity">跟踪速度.</param>
        /// <param name="inertia">惯性.</param>
        /// <param name="maxAngleChange">角度限制（不写默认不限制）.</param>
        /// </summary>
        public static void HomeInOnNPC(Projectile projectile, bool ignoreTiles, float distanceRequired, float homingVelocity, float inertia, float? maxAngleChange = null)
        {
            if (!projectile.friendly)
                return;

            // Set amount of extra updates.
            if (projectile.Soul().StoreEU== -1)
                projectile.Soul().StoreEU= projectile.extraUpdates;

            Vector2 destination = projectile.Center;
            float maxDistance = distanceRequired;
            bool locatedTarget = false;

            //寻找距离最近的目标
            int targetIndex = -1;

            if(locatedTarget == false)
            {
                foreach (NPC npc in Main.ActiveNPCs)
                {
                    float extraDistance = (npc.width / 2) + (npc.height / 2);
                    if (!npc.CanBeChasedBy(projectile, false) || !projectile.WithinRange(npc.Center, maxDistance + extraDistance))
                        continue;

                    float currentNPCDist = Vector2.Distance(npc.Center, projectile.Center);
                    if ((currentNPCDist < maxDistance) && (ignoreTiles || Collision.CanHit(projectile.Center, 1, 1, npc.Center, 1, 1)))
                    {
                        maxDistance = currentNPCDist;
                        targetIndex = npc.whoAmI;
                    }
                }
            }

            if (targetIndex != -1)
            {
                destination = Main.npc[targetIndex].Center;
                locatedTarget = true;
            }

            if (locatedTarget)
            {
                // Increase amount of extra updates to greatly increase homing velocity.
                projectile.extraUpdates = projectile.Soul().StoreEU + 1;

                // 计算制导向量
                Vector2 homeDirection = (destination - projectile.Center).SafeNormalize(Vector2.UnitY);
                Vector2 newVelocity = (projectile.velocity * inertia + homeDirection * homingVelocity) / (inertia + 1f);

                // 限制角度
                if (maxAngleChange.HasValue)
                {
                    float currentAngle = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X);
                    float targetAngle = (float)Math.Atan2(newVelocity.Y, newVelocity.X);
                    float angleDifference = MathHelper.WrapAngle(targetAngle - currentAngle);

                    // 添加了转换角度为弧度，以便进行比较和限制。如果角度差大于最大允许的角度变化，则将速度限制在最大角度变化的范围内。
                    // 不需要手动转换了
                    float maxChangeRadians = MathHelper.ToRadians(maxAngleChange.Value);
                    if (Math.Abs(angleDifference) > maxChangeRadians)
                    {
                        float clampedAngle = currentAngle + Math.Sign(angleDifference) * maxChangeRadians;
                        float speed = newVelocity.Length();
                        newVelocity = new Vector2((float)Math.Cos(clampedAngle), (float)Math.Sin(clampedAngle)) * speed;
                    }
                }

                projectile.velocity = newVelocity;
            }
            else
            {
                // Set amount of extra updates to default amount.
                projectile.extraUpdates = projectile.Soul().StoreEU;
            }
        }
        /// <summary>
        /// 用于搜索距离射弹最近的npc单位，并返回NPC实例。通常情况下与上方的追踪方法配套
        /// 这个方法会同时实现穿墙、数组、boss优先度的搜索。不过只能用于射弹。但也足够
        /// 这里Boss优先度的实现逻辑是如果我们但凡搜索到一个Boss，就把这个Boss临时存储，在返回实例的时候优先使用
        /// </summary>
        /// <param name="p">射弹</param>
        /// <param name="maxDist">最大搜索距离</param>
        /// <param name="bossFirst">boss优先度，这个还没实现好逻辑，所以填啥都没用（</param>
        /// <param name="ignoreTiles">穿墙搜索, 默认为</param>
        /// <param name="arrayFirst">数组优先, 这个将会使射弹优先针对数组内第一个单位,默认为否</param>
        /// <returns>返回一个NPC实例</returns>
        public static NPC FindClosestTarget(this Projectile p, float maxDist, bool bossFirst = false, bool ignoreTiles = true, bool arrayFirst = false)
        {
            //bro我真的要遍历整个NPC吗？
            float distStoraged = maxDist;
            NPC tryGetBoss = null;
            NPC acceptableTarget = null;
            bool alreadyGetBoss = false;
            foreach (NPC npc in Main.ActiveNPCs)
            {
                float exDist = npc.width + npc.height;
                //如果优先搜索boss单位，且当前敌怪不是一个boss，直接跳过
                //单位不可被追踪 或者 超出索敌距离则continue
                if (Vector2.Distance(p.Center, npc.Center) > distStoraged + exDist)
                    continue;

                if (!npc.active || npc.friendly || npc.lifeMax < 5 || !npc.CanBeChasedBy(p.Center, false)) 
                    continue;
                //补: 如果优先搜索Boss单位, 且附近至少有一个。我们直接存储这个Boss单位
                //已经获取到的会被标记，使其不会再跑一遍搜索.
                if (npc.boss && bossFirst && !alreadyGetBoss)
                {
                    tryGetBoss = npc;
                    alreadyGetBoss = true;
                }
                
                //搜索符合条件的敌人, 准备返回这个NPC实例
                float curNpcDist = Vector2.Distance(npc.Center, p.Center);
                if (curNpcDist < distStoraged && (ignoreTiles || Collision.CanHit(p.Center, 1, 1, npc.Center, 1, 1)))
                {
                    distStoraged = curNpcDist;
                    acceptableTarget = npc;
                    if (tryGetBoss != null & bossFirst)
                        acceptableTarget = tryGetBoss;
                    //如果是数组优先，直接在这返回实例
                    if (arrayFirst)
                        return acceptableTarget;
                }
            }
            //返回这个NPC实例
            return acceptableTarget;      
        }
        /// <summary>
        /// 新的追踪方法，这个会指定一个NPC, 且可以自定义输入额外更新，以及强制速度不受距离影响
        /// 目前没有角度限制等一类的东西，如果需要则可以补上。
        /// </summary>
        /// <param name="proj">射弹</param>
        /// <param name="target">射弹目标</param>
        /// <param name="distRequired">最大范围</param>
        /// <param name="speed">射弹速度</param>
        /// <param name="inertia">惯性</param>
        /// <param name="giveExtraUpdate">给予额外更新，默认1</param>
        /// <param name="forceSpeed">指定射弹无视距离，使射弹使用你输入的速度。这个效果有一个距离特判，即距离比你输入的射弹速度还短的时候才会生效, 一般可无视。</param>
        /// <param name="maxAngleChage">角度限制，默认为空. </param>
        /// <param name="ignoreDist">使这个射弹无视索敌距离(distRequired), 默认取否. </param>
        public static void HomeInOnTarget(this Projectile proj, NPC target, float distRequired, float speed, float inertia, int giveExtraUpdate = 1, float? forceSpeed = null, float? maxAngleChage = null, bool ignoreDist = false)
        {
            //一般来说你用这个方法就说明target理论上应当可以被追，但……just in case
            if (!proj.friendly || target == null || !target.active)
                return;
            bool canHome;

            float curDist = Vector2.Distance(target.Center, proj.Center);
            //存储射弹当前额外更新
            if (proj.Soul().StoreEU == -1)
                proj.Soul().StoreEU = proj.extraUpdates;

            if (!target.chaseable || (curDist > distRequired && !ignoreDist)) 
                canHome = false;
            else canHome = true;
            if (canHome)
            {
                //给予额外更新
                proj.extraUpdates = proj.Soul().StoreEU + giveExtraUpdate;
                //开始追踪target
                Vector2 home = (target.Center - proj.Center).SafeNormalize(Vector2.UnitY);
                Vector2 velo = (proj.velocity * inertia + home * speed) / (inertia + 1f);
                //这里给了一个角度限制
                if(maxAngleChage.HasValue)
                {
                    float curAngle =  proj.velocity.ToRotation();   
                    float tarAngle = velo.ToRotation();
                    float angleDiffer = MathHelper.WrapAngle(tarAngle - curAngle);
                    //转弧度
                    float maxRadians = MathHelper.ToRadians(maxAngleChage.Value);
                    if (Math.Abs(angleDiffer) > maxRadians)
                    {
                        float clampedAngle = curAngle + Math.Sign(angleDiffer) * maxRadians;
                        float setSpeed = velo.Length();
                        velo = new Vector2((float)Math.Cos(clampedAngle), (float)Math.Sin(clampedAngle)) * setSpeed;
                    }
                }
                //除非你当前距离比射弹速度还少, 我们才会重新设定速度
                if (forceSpeed.HasValue && curDist < speed)
                    velo = proj.velocity.SafeNormalize(Vector2.Zero) * home * forceSpeed.Value;
                //设定速度
                proj.velocity = velo;
            }
            //否则返回射弹原本的额外更新
            else proj.extraUpdates = proj.Soul().StoreEU;
        }
        /// <summary>
        /// 生成治疗射弹
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <param name="pos"></param>
        /// <param name="player"></param>
        /// <param name="healAmt"></param>
        /// <param name="flyingSpeed"></param>
        /// <param name="acceleration"></param>
        /// <param name="CD"></param>
        public static void HealProj<T>(IEntitySource src, Vector2 pos, Player player, int healAmt, float flyingSpeed = 20f, float acceleration = 2.4f, int CD = 60) where T : ModProjectile
        {
            if (player.Soul().HealProjCD > 0)
                return;
            float randomAngleOffset = Main.rand.NextFloat(MathHelper.TwoPi);
            Vector2 dire = new((float)Math.Cos(randomAngleOffset), (float)Math.Sin(randomAngleOffset));
            float randomSpeed = Main.rand.NextFloat(12f, 16f);
            Projectile.NewProjectile(src, pos, dire * randomSpeed, ModContent.ProjectileType<T>(), 0, 0f, player.whoAmI, flyingSpeed, acceleration, healAmt);
            player.Soul().HealProjCD = CD;
        }
    }
}
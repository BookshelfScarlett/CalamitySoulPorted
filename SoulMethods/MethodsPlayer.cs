using CalamityMod;
using CalamityMod.Cooldowns;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulMethods
{
    public static partial class SoulMethod
    {
        /// <summary>
        /// byd灾厄你全家死完了吧为什么没有移除冷却的方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="player"></param>
        /// <param name="cooldownID"></param>
        public static void DelBuffAndCooldown<T>(this Player player, string cooldownID) where T : ModBuff => DelBuffAndCooldown(player, ModContent.BuffType<T>(), cooldownID);
        /// <summary>
        /// byd灾厄你全家死完了吧为什么没有移除冷却的方法
        /// </summary>
        /// <param name="player"></param>
        /// <param name="buffID"></param>
        /// <param name="cooldownID"></param>
        public static void DelBuffAndCooldown(this Player player, int buffID, string cooldownID)
        {
            player.ClearBuff(buffID);
            player.FuckcalamityCD(cooldownID);
        }
        public static void FuckcalamityCD(this Player player, string cooldownID)
        {
            player.Calamity().cooldowns.Remove(cooldownID);
        }
        /// <summary>
        /// Mod方法的immmnueBuff，不要把这个改成大写
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="player"></param>
        /// <param name="immnue"></param>
        /// <returns></returns>
        public static void buffImmue<T>(this Player player, bool immnue = true) where T : ModBuff => player.buffImmune[ModContent.BuffType<T>()] = immnue;
        public static void ClearBuff<T>(this Player player) where T : ModBuff => player.ClearBuff(ModContent.BuffType<T>());
        public static void AddBuff<T>(this Player player, int timeToAdd, bool quiet = false, bool foodHack = false) where T : ModBuff
        {
            player.AddBuff(ModContent.BuffType<T>(), timeToAdd, quiet, foodHack);
        }
        /// <summary>
        /// 控制治疗药水的药水病
        /// </summary>
        /// <param name="player"></param>
        /// <param name="time">药水病的持续时间</param>
        /// <param name="shouldGivePotionSick">查看是否应该给予药水病</param>
        /// <returns></returns>
        public static void HandlePotionSick(this Player player, int time = 0, bool shouldGivePotionSick = false)
        {
            player.potionDelayTime = time;
            player.potionDelay = time;
            if (shouldGivePotionSick)
            {
                player.AddBuff(BuffID.PotionSickness, time);
                player.AddCooldown(PotionSickness.ID, time);
            }
            else
                DelBuffAndCooldown(player, BuffID.PotionSickness, PotionSickness.ID);
        }
        ///<summary>
        ///跟踪玩家
        ///不会自动和玩家重叠时消失
        ///<param name="player">玩家</param>
        ///<param name="proj">要跟踪玩家的弹幕.</param>
        ///<param name="inertia">惯性.</param>
        ///<param name="acceleration">加速度，一般填1-3左右.</param>
        ///<param name="homingVelocity">跟踪速度</param>
        ///</summary>
        public static void HomeInPlayer(this Player player, Projectile proj, float inertia, float homingVelocity, float? acceleration, bool needALittleBitFarAwayFromPlayer = false, float awayDist = 0f, bool usePrognosis = false)
        {
            // 计算制导向量
            Vector2 homeDirection = (player.Center + player.velocity - proj.Center).SafeNormalize(Vector2.UnitY);
            Vector2 newVelocity = (proj.velocity * inertia + homeDirection * homingVelocity) / (inertia + 1f);

            proj.velocity = newVelocity;
            
            if(acceleration.HasValue)
                proj.velocity *= 1 + acceleration.Value / 100;

            if (!needALittleBitFarAwayFromPlayer)
                return;
                
            float xDist = player.Center.X - proj.Center.X;
            float yDist = player.Center.Y - proj.Center.Y;
            float distance = new Vector2(xDist, yDist).Length();
            if (distance < awayDist)
            {
                proj.velocity *= 0.90f;
            }
        }
    }
}
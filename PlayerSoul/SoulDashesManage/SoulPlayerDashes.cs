using CalamityMod.CalPlayer.Dashes;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalamitySoulPorted.PlayerSoul.SoulDashesManage
{
    public enum DashThroughType
    {
        NoThrough = 0,
        DoSlam = 1,
        DoBonk = 2
    }
    public struct DashHitType
    {
        public int DashDamage;
        public float DashKB;
        public DamageClass DashDamageClass;
        public int ImmunityFrames;
        public int HitDirection;
    }
    public abstract class SoulPlayerDahses
    {
        //Some Custom Dashes ID
        public string SoulDashID {get;}
        //冲刺的撞击类型（穿透、盾冲与回弹）
        public abstract DashThroughType ThroughType {get;}
        //可否自由变相？
        public abstract bool CanFreeDirection{get;}
        //冲刺速度计算
        public abstract float CalculateDashSpeed(Player player);
        public virtual void DashEffect(Player player) {}
        public virtual void MidDashEffect(Player player ,ref float dashSpeed, ref float dashSpeedDecelartionFactor, ref float runSpeedDecelerationFactor) {}
        public virtual void OnHitEffects(Player player, NPC npc, IEntitySource source, ref DashHitType hitContext) { }

    }
}
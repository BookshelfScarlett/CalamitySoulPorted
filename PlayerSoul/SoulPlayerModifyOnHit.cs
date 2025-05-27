using System;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.PlayerSoul
{
    public partial class SoulPlayer : ModPlayer
    {
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers)
        {
            SetSummonCrits(proj, ref modifiers);
            base.ModifyHitNPCWithProj(proj, target, ref modifiers);
        }

        public void SetSummonCrits(Projectile proj, ref NPC.HitModifiers modifiers)
        {
            if (!proj.CountsAsClass<SummonDamageClass>())
                return;

            if (Main.rand.NextBool(GetSummonCrits))
                modifiers.SourceDamage *= 2;
        }
    }
}
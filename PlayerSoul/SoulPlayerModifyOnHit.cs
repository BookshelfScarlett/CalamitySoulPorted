using System;
using CalamityMod;
using CalamityMod.Items.Weapons.Magic;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.PlayerSoul
{
    public partial class SoulPlayer : ModPlayer
    {
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers)
        {
            SetSummonCrits(proj, ref modifiers);
            FuckEveryThingWithAnyThing(target, ref modifiers);
            base.ModifyHitNPCWithProj(proj, target, ref modifiers);
        }
        public override void ModifyHitNPCWithItem(Item item, NPC target, ref NPC.HitModifiers modifiers)
        {
            base.ModifyHitNPCWithItem(item, target, ref modifiers);
            FuckEveryThingWithAnyThing(target, ref modifiers);
        }
        //草所有人
        public void FuckEveryThingWithAnyThing(NPC target, ref NPC.HitModifiers modifiers)
        {
            var calPlayer = Player.Calamity();
            
            float multipler = 0f;
            //我tm都不知道乘算增伤怎么塞我决定先这样摆着
            modifiers.SourceDamage *= (int)GetDamageMult + multipler;

        }

        public void SetSummonCrits(Projectile proj, ref NPC.HitModifiers modifiers)
        {
            if (!proj.CountsAsClass<SummonDamageClass>())
                return;
            if (Player.HeldItem.type == ModContent.ItemType<Sylvestaff>())
            if (Main.rand.NextBool(GetSummonCrits))
                modifiers.SetCrit();
        }
    }
}
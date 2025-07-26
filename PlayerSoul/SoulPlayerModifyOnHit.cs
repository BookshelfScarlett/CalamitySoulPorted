using System;
using CalamityMod;
using CalamityMod.Items.Weapons.Magic;
using CalamitySoulPorted.SoulCustomSounds;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace CalamitySoulPorted.PlayerSoul
{
    public partial class SoulPlayer : ModPlayer
    {
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers)
        {
            SetSummonCrits(proj, ref modifiers);
            FuckEveryThingWithAnyThing(target, ref modifiers);
            MirrorCrits(proj, target, modifiers);
            base.ModifyHitNPCWithProj(proj, target, ref modifiers);
        }

        private void MirrorCrits(Projectile proj, NPC target, NPC.HitModifiers modifiers)
        {
            if (MirrorLevel > 0)
            {
                //幻象33% 深渊66% 日蚀100%
                if (Main.rand.NextBool(4 - MirrorLevel) && proj.CountClassAs<RogueDamageClass>() && proj.Calamity().stealthStrike)
                {
                    modifiers.SetCrit();
                }
            }
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
            
            //标记为精通的饰品将会直接处决低于5%血量的敌人
            if (GuarrantedPrestige)
            {
                var isRealNPC = target.realLife == -1 ? target : Main.npc[target.realLife];
                if (isRealNPC.life <= isRealNPC.lifeMax * 0.05f)
                {
                    modifiers.SetInstantKill();
                    SoundEngine.PlaySound(SoulCustomSound.SoundSlasher, target.Center);
                }
            }
            

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
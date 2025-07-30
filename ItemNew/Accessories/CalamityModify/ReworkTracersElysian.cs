using System;
using CalamityMod;
using CalamityMod.Buffs.DamageOverTime;
using CalamityMod.CalPlayer;
using CalamityMod.Items.Accessories.Wings;
using CalamityMod.Items.Armor.GodSlayer;
using CalamitySoulPorted.SoulMethods;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.CalamityModify
{
    public class ReworkTracersElysian
    {
        public static void Load()
        {
            nameof(TracersElysian.UpdateAccessory).QuickHook<TracersElysian>(FuckUpdateAcc_Hook);
        }
        public static void FuckUpdateAcc_Hook(TracersElysian self, Player player, bool hideVisual)
        {
            CheckedIfGodSlayer(player);
            if (player.controlJump && player.wingTime > 0f && player.jump == 0 && player.velocity.Y != 0f && !hideVisual)
            {
                int dustXOffset = 4;
                if (player.direction == 1)
                {
                    dustXOffset = -40;
                }
                int flightDust = Dust.NewDust(new Vector2(player.Center.X + dustXOffset, player.Center.Y - 15f), 30, 30, Main.rand.NextBool() ? 206 : 173, 0f, 0f, 100, default, 2.4f);
                Main.dust[flightDust].noGravity = true;
                Main.dust[flightDust].velocity *= 0.3f;
                if (Main.rand.NextBool(10))
                {
                    Main.dust[flightDust].fadeIn = 2f;
                }
                Main.dust[flightDust].shader = GameShaders.Armor.GetSecondaryShader(player.cWings, player);
            }
            CalamityPlayer modPlayer = player.Calamity();
            player.accRunSpeed = 9.5f;
            player.moveSpeed += 0.24f;
            player.jumpSpeedBoost += 0.50f;
            player.iceSkate = true;
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaImmune = true;
            player.buffImmue<GodSlayerInferno>();
            player.buffImmue<HolyFlames>();
            player.buffImmune[BuffID.CursedInferno] = true;
            player.buffImmune[BuffID.OnFire3] = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.noFallDmg = true;
            modPlayer.tracersDust = !hideVisual;
            modPlayer.elysianWingsDust = !hideVisual;
            modPlayer.tracersElysian = true;
        }

        public static void CheckedIfGodSlayer(Player player)
        {
            bool isGSHead = player.armor[0].Same<GodSlayerHeadMelee>() | player.armor[0].Same<GodSlayerHeadRanged>() || player.armor[0].Same<GodSlayerHeadRogue>();
            bool isGChest = player.armor[1].Same<GodSlayerChestplate>();
            bool isGLeg = player.armor[2].Same<GodSlayerLeggings>();
            if (isGSHead && isGChest && isGLeg)
            {
                player.wingTimeMax += 60 * 60;
                player.Calamity().contactDamageReduction += 0.25f;
                player.statDefense += 15;
            }
        }
        public static int Armor<T>() where T : ModItem => ModContent.ItemType<T>();
    }
}
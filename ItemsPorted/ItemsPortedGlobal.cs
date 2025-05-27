using System;
using CalamityMod;
using CalamityMod.Projectiles.Magic;
using CalamitySoulPorted.SoulMethods;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.UI;

namespace CalamitySoulPorted.ItemsPorted
{
    public class SoulGlobalItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            var usPlayer = player.Soul();
            //林海与炼金狂人射弹。
            if (usPlayer.EnchSilva && item.CountClassAs<MagicDamageClass>())
            {
                for (int i = 0; i < 3; i++)
                EnchSilvaFlasks(source, damage, player);
            }
            //皇天效果：强制潜伏攻击。
            if (usPlayer.EnchEmpyrean && item.CountClassAs<RogueDamageClass>() && !player.CheckStealth())
            {
                int forceDamage = (int)(damage * 0.25f);
                int p = Projectile.NewProjectile(source, position, velocity, type, forceDamage, knockback, player.whoAmI);
                Main.projectile[p].Calamity().stealthStrike = true;
                return false;
            }
            return true;
        }

        
        #region EnchShoot
        public static void EnchSilvaFlasks(EntitySource_ItemUse_WithAmmo source, int damage, Player player)
        {
                int[] FlaskIDs =
                [
                    ModContent.ProjectileType<MadAlchemistsCocktailRed>(),
                    ModContent.ProjectileType<MadAlchemistsCocktailBlue>(),
                    ModContent.ProjectileType<MadAlchemistsCocktailGreen>(),
                    ModContent.ProjectileType<MadAlchemistsCocktailPurple>(),
                    ModContent.ProjectileType<MadAlchemistsCocktailAlt>()
                ];
                int idRandom = Main.rand.Next(0, 5);
                //瓶子射弹伤害为每个射弹的20%
                int flaskDamage = damage / 5;
                //我们重设定攻击方式与范围
                float srcX = Main.MouseWorld.X + Main.rand.NextFloat(-200, 201f);
                float srcY = Main.MouseWorld.Y - Main.rand.NextFloat(-500, -700f);
                Vector2 srcPos = new(srcX, srcY);
                Vector2 distVec = Main.MouseWorld - srcPos;
                //转速度向量
                float dist = distVec.Length();
                dist = 30f / dist;
                distVec.X *= dist;
                distVec.Y *= dist;
                int flask = Projectile.NewProjectile(source, srcPos, distVec, FlaskIDs[idRandom], flaskDamage, 0f, player.whoAmI);
                Main.projectile[flask].scale *= 1.5f;
        }
        #endregion
    }
}
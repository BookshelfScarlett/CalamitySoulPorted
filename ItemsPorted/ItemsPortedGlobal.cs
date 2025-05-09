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
            if (usPlayer.SilvaEnch && item.CountsAsClass<MagicDamageClass>())
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
                Projectile.NewProjectile(source, position, velocity * 1.1f, FlaskIDs[idRandom], flaskDamage, 0f, player.whoAmI);
            }
            return true;
        }

    }
}
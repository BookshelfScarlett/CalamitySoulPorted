using System;
using CalamityMod;
using CalamitySoulPorted.ItemsPorted.Enchs.PreHM;
using CalamitySoulPorted.PlayerSoul;
using CalamitySoulPorted.SoulMethods;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulProjectiles
{
    public class SoulGlobalProjectiles : GlobalProjectile
    {
        #region Category
        public static string MeleePath => "Projectiles.MeleeProj";
        public static string RangedPath => "Projectiles.RangedProj";
        public static string MagicPath => "Projectiles.MagicProj";
        public static string SummonPath => "Projectiles.SummonProj";
        public static string RoguePath => "Projectiles.RogueProj";
        public static string TypelessPath => "Projectiles.TypelessProj";
        #endregion
        #region Generic Projectile Path
        public static string ProjRoute => "CalamitySoulPorted/SoulProjectiles";
        public static string InvisProj => $"{ProjRoute}/InvisibleProj";
        #endregion
        #region Enchantment Power
        public float OldHunterSize = 1f;
        #endregion
        public int StoreEU = -1;
        public bool IsUsedForceStealth = false;
        public override bool InstancePerEntity => true;
        public override void AI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
        }
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            Player player = Main.player[projectile.owner];
            SoulPlayer usPlayer = player.Soul();
            var calPlayer = player.Calamity();

            if (usPlayer.EnchOldHunterSize)
                ModifyProjectileSize(projectile);
        }

        public override bool PreAI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
            var usPlayer = player.Soul(); 
            if (projectile.owner == Main.myPlayer)
            {
                //没有效果时得直接重置这个size
                if (OldHunterSize != 1f && !usPlayer.EnchOldHunterSize)
                {
                    projectile.position = projectile.Center;
                    projectile.scale /= OldHunterSize;
                    projectile.width = (int)(projectile.width / OldHunterSize);
                    projectile.height = (int)(projectile.height / OldHunterSize);
                    projectile.Center = projectile.position;
                    OldHunterSize = 1f;
                }
            }
            return true;
        }
        public override void PostAI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
            var usPlayer = player.Soul();
            if (usPlayer.EnchOldHunterSize && OldHunterSize == 1f)
                ModifyProjectileSize(projectile);
        }
        public override bool TileCollideStyle(Projectile projectile, ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            //处理撞墙
            if (OldHunterSize != 1f)
            {
                width = (int)(width / OldHunterSize);
                height = (int)(height / OldHunterSize);
            }
            return base.TileCollideStyle(projectile, ref width, ref height, ref fallThrough, ref hitboxCenterFrac);
        }
        public static void ModifyProjectileSize(Projectile projectile)
        {
            float scale = OldHunterEnchant.Size;
            projectile.position = projectile.Center;
            projectile.scale *= scale;
            projectile.width = (int)(projectile.width * scale);
            projectile.height = (int)(projectile.height * scale);
            projectile.Center = projectile.position;
            projectile.Soul().OldHunterSize = scale;
            if (projectile.aiStyle == ProjAIStyleID.Spear || projectile.aiStyle == ProjAIStyleID.ShortSword)
                projectile.velocity *= scale;
        }
    }
}
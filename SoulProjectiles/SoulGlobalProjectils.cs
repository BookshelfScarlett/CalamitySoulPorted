using CalamityMod;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.DataStructures;
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
        public int StoreEU = -1;
        public bool IsUsedForceStealth = false;
        public override bool InstancePerEntity => true;
        public override void AI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
        }
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            base.OnSpawn(projectile, source);
        }
    }
}
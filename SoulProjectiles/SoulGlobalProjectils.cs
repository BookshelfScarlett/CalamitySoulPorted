using CalamityMod;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulProjectiles
{
    public class SoulGlobalProjectiles : GlobalProjectile
    {
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
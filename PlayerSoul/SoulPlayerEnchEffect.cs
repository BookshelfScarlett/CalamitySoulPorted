using CalamityMod.Buffs.Summon;
using CalamityMod.CalPlayer;
using CalamityMod.Items.Accessories;
using CalamityMod.Projectiles.Summon;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.PlayerSoul
{
    public partial class SoulPlayer : ModPlayer
    {
        private void EnchSnowruffianEffect()
        {
            if (EnchSnowruffianFalling)
            {
                //空中移速
                if (Player.velocity.Y != 0)
                {
                    GetRunSpeed *= 1.2f;
                    GetAcceleration *= 1.2f;
                }
                //免疫摔落伤害
                Player.noFallDmg = true;
            }
        }
        private void EnchWulfrumEffect(CalamityPlayer calPlayer)
        {
            if (EnchWulfrum)
            {
                int droneBuff = ModContent.BuffType<WulfrumDroidBuff>();
                //给生命恢复与1栏位
                Player.maxMinions += 1;
                Player.lifeRegen += 2;
                //挖掘速度
                Player.pickSpeed -= 0.25f;
                //无人机
                Player.maxMinions += 2;
                if (Player.FindBuffIndex(droneBuff) == -1)
                    Player.AddBuff(droneBuff, 3600, true);

                if (Player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumDroid>()] < 2)
                     Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, Vector2.Zero, ModContent.ProjectileType<WulfrumDroid>(), (int)Player.GetTotalDamage<SummonDamageClass>().ApplyTo(16), 0f, Player.whoAmI);
                //盾
                calPlayer.roverDrive = true;
                if (calPlayer.RoverDriveShieldDurability > 0)
                    Player.statDefense += RoverDrive.ShieldDefenseBoost;
                
            }
        }
    }
}
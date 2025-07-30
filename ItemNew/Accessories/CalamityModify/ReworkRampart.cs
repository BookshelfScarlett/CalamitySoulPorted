using System.Reflection;
using CalamityMod;
using CalamityMod.CalPlayer;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalamitySoulPorted.SoulMethods;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.CalamityModify
{
    public class ReworkRampart
    {
        public static void Load()
        {
            MethodInfo fuckAcc = typeof(RampartofDeities).GetMethod(nameof(RampartofDeities.UpdateAccessory));
            MethodInfo fuckRecipe = typeof(RampartofDeities).GetMethod(nameof(RampartofDeities.AddRecipes));

            MonoModHooks.Add(fuckAcc, FuckUpdateAcc_Hook);
            MonoModHooks.Add(fuckRecipe, FuckRecipe_Hook);
        }
    
        public static void FuckUpdateAcc_Hook(RampartofDeities self, Player player, bool hideVisual)
        {
            //仍然获得原灾的效果
            var calPlayer = player.Calamity();

            //仍然继承神圣护符与十项链的效果
            player.longInvince = true;
            calPlayer.dAmulet = true;
            //回归神话护身符
            player.pStone = true;
            //的长的无敌帧
            calPlayer.rampartOfDeities = true;
            //霜冻之炎的所有效果
            calPlayer.frostFlare = true;
            if (player.statLife <= player.statLifeMax2 * 0.5)
                player.AddBuff(BuffID.IceBarrier, 5);

            //noKB
            player.noKnockback = true;

            //帕拉丁盾
            if (player.statLife > player.statLifeMax2 * 0.25f)
            {
                player.hasPaladinShield = true;
                if (player.whoAmI != Main.myPlayer && player.miscCounter % 10 == 0)
                {
                    int myPlayer = Main.myPlayer;
                    if (Main.player[myPlayer].team == player.team && player.team != 0)
                    {
                        float teamPlayerXDist = player.position.X - Main.player[myPlayer].position.X;
                        float teamPlayerYDist = player.position.Y - Main.player[myPlayer].position.Y;
                        Vector2 dist = new(teamPlayerXDist, teamPlayerYDist);
                        if (dist.Length() < 800f)
                            Main.player[myPlayer].AddBuff(BuffID.PaladinsShield, 20);
                    }
                }
            }

        }
        public static void FuckRecipe_Hook(RampartofDeities self)
        {
            self.CreateRecipe().
                AddIngredient(ItemID.FrozenShield).
                AddIngredient<DeificAmulet>().
                AddIngredient<FrostFlare>().
                AddIngredient<CosmiliteBar>(5).
                AddIngredient<AscendantSpiritEssence>(5).
                AddTile<CosmicAnvil>().
                Register();
        }
    }
}
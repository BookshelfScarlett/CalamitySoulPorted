using System.Reflection;
using CalamityMod;
using CalamityMod.CalPlayer;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Placeables;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalamitySoulPorted.SoulMethods;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.CalamityModify
{
    public class ReworkAmulet
    {
        public static void Load()
        {
            MethodInfo fuckRecipe = typeof(DeificAmulet).GetMethod(nameof(DeificAmulet.AddRecipes));
            MethodInfo fuckUpdate = typeof(DeificAmulet).GetMethod(nameof(DeificAmulet.UpdateAccessory));
            MonoModHooks.Add(fuckRecipe, FuckRecipe_Hook);
            MonoModHooks.Add(fuckUpdate, FuckUpdateAcc_Hook);
        }
    
        public static void FuckUpdateAcc_Hook(DeificAmulet self, Player player, bool hideVisual)
        {
            //仍然获得原灾的效果
            var calPlayer = player.Calamity();

            //仍然继承神圣护符与十项链的效果
            player.longInvince = true;
            calPlayer.dAmulet = true;
            //回归神话护身符
            player.pStone = true;
        }
        public static void FuckRecipe_Hook(DeificAmulet self)
        {
            self.CreateRecipe().
                AddIngredient(ItemID.StarVeil).
                AddIngredient(ItemID.CharmofMyths).
                AddIngredient<SeaPrism>().
                AddIngredient<Necroplasm>(5).
                AddTile(TileID.MythrilAnvil).
                Register();
        }
    }
}
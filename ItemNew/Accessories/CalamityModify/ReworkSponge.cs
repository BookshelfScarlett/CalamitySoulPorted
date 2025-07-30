using System.Reflection;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamityMod.Tiles.Furniture.CraftingStations;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.CalamityModify
{
    public class ReworkSponge
    {
        public static void Load()
        {
            MethodInfo fuckRecipe = typeof(TheSponge).GetMethod(nameof(TheSponge.AddRecipes));
            MonoModHooks.Add(fuckRecipe, FuckRecipe_Hook);
        }
        public static void FuckRecipe_Hook(TheSponge self)
        {
            self.CreateRecipe().
                AddIngredient<RoverDrive>().
                AddIngredient<MysteriousCircuitry>(5).
                AddIngredient<RuinousSoul>(5).
                AddIngredient<DubiousPlating>(5).
                AddTile(TileID.LunarCraftingStation).
                Register();
        }
    }
}
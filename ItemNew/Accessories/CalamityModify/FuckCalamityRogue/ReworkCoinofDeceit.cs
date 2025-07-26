using System.Reflection;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.CalamityModify.FuckCalamityRogue
{
    public class ReworkCoin
    {
        public static void Load()
        {
            MethodInfo fuckRecipe = typeof(CoinofDeceit).GetMethod(nameof(CoinofDeceit.AddRecipes));
            MethodInfo fuckUpdate = typeof(CoinofDeceit).GetMethod(nameof(CoinofDeceit.UpdateAccessory));
            MonoModHooks.Add(fuckRecipe, FuckRecipe_Hook);
            MonoModHooks.Add(fuckUpdate, FuckUpdateAcc_Hook);
        }
        public static void FuckUpdateAcc_Hook(CoinofDeceit self, Player player, bool hideVisual)
        {
            player.Calamity().stealthStrike85Cost = true;
            player.Calamity().rogueStealthMax += 0.05f;
        }
        public static void FuckRecipe_Hook(CoinofDeceit self)
        {
            self.CreateRecipe().
                AddRecipeGroup("AnyCopperBar", 5).
                AddRecipeGroup("AnyIronBar", 5).
                AddTile(TileID.WorkBenches).
                Register();
        }
    }
}
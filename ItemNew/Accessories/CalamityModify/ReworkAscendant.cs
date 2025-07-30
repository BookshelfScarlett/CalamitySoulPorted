using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamityMod.Projectiles.Ranged;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;

namespace CalamitySoulPorted.ItemNew.Accessories.CalamityModify
{
    public class ReworkAscendant
    {
        public static void Load()
        {
            nameof(AscendantInsignia.AddRecipes).QuickHook<AscendantInsignia>(FuckRecipe_Hook);
            nameof(AscendantInsignia.UpdateAccessory).QuickHook<AscendantInsignia>(FuckUpdate_Hook);
        }
        public static void FuckUpdate_Hook(AscendantInsignia self, Player player, bool hideVisual)
        {
            player.runAcceleration *= 1.75f;
            player.Soul().InfiniteFlightPower = true;
            player.jumpSpeedBoost += 1.8f;
        }
        public static void FuckRecipe_Hook(AscendantInsignia self)
        {
            self.CreateRecipe().
                AddIngredient(ItemID.EmpressFlightBooster).
                AddIngredient<EffulgentFeather>(5).
                AddIngredient(ItemID.SoulofFlight, 5).
                AddIngredient<GalacticaSingularity>(5).
                AddTile(TileID.LunarCraftingStation).
                Register();
        }
    }
}
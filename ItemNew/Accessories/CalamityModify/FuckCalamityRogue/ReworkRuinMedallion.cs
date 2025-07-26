using System.Reflection;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.CalamityModify.FuckCalamityRogue
{
    public class ReworkRuinMedallion
    {
        public static void Load()
        {
            MethodInfo fuckRecipe = typeof(RuinMedallion).GetMethod(nameof(RuinMedallion.AddRecipes));
            MethodInfo fuckUpdate = typeof(RuinMedallion).GetMethod(nameof(RuinMedallion.UpdateAccessory));
            MonoModHooks.Add(fuckRecipe, FuckRecipe_Hook);
            MonoModHooks.Add(fuckUpdate, FuckUpdate_Hook);
        }
        public static void FuckUpdate_Hook(RuinMedallion self, Player player, bool hideVisual)
        {
            var calPlayer = player.Calamity();
            calPlayer.rogueStealthMax += 0.05f;
            calPlayer.stealthStrike75Cost = true;
        }
        public static void FuckRecipe_Hook(RuinMedallion self)
        {
            self.CreateRecipe().
                AddIngredient<CoinofDeceit>().
                AddIngredient(ItemID.HellstoneBar, 4).
                AddIngredient<EssenceofHavoc>(2).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
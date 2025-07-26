using System.Reflection;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.CalamityModify.FuckCalamityRogue
{
    public class ReworkSilenceSheath
    {
        public static void Load()
        {
            MethodInfo fuckUpdate = typeof(SilencingSheath).GetMethod(nameof(SilencingSheath.UpdateAccessory));
            MonoModHooks.Add(fuckUpdate, FuckUpdateAcc_Hook);
            MethodInfo fuckRecipe = typeof(SilencingSheath).GetMethod(nameof(SilencingSheath.AddRecipes));
            MonoModHooks.Add(fuckRecipe, FuckRecipe_Hook);
        }
        public static void FuckUpdateAcc_Hook(SilencingSheath self, Player player, bool hideVisual)
        {
            player.Soul().SheathLevel = 1;
            player.GetDamage<RogueDamageClass>() += 0.05f;
            player.GetCritChance<RogueDamageClass>() += 5;
        }
        public static void FuckRecipe_Hook(SilencingSheath self)
        {
            self.CreateRecipe().
                AddRecipeGroup(SoulRecpieGroupID.EvilBars, 5).
                AddIngredient(ItemID.Silk, 5).
                AddIngredient<SulphuricScale>(5).
                AddTile(TileID.Loom).
                Register();
        }
    }
}
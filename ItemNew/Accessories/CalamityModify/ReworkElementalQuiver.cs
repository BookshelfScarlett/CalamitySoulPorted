using System.Reflection;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalamitySoulPorted.ItemNew.Accessories.Prestige;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.CalamityModify
{
    public class ReworkElementalQuiver
    {
        public static void Load()
        {
            MethodInfo fuckRecipe = typeof(ElementalQuiver).GetMethod(nameof(ElementalQuiver.AddRecipes));
            MethodInfo fuckUpdate = typeof(ElementalQuiver).GetMethod(nameof(ElementalQuiver.UpdateAccessory));
            MonoModHooks.Add(fuckRecipe, FuckRecipe_Hook);
            MonoModHooks.Add(fuckUpdate, FuckUpdateAcc_Hook);
            
        }
        public static void FuckUpdateAcc_Hook(ElementalQuiver self, Player player, bool hideVisual)
        {
            var calPlayer = player.Calamity();
            var usPlayer = player.Soul();
            
            usPlayer.GuarrantedPrestige = true;
            #region 
            player.GetDamage<RangedDamageClass>() += EAccsStats.Damage;
            player.GetCritChance<RangedDamageClass>() += EAccsStats.Crits;
            player.GetAttackSpeed<RangedDamageClass>() += EAccsStats.AttackSpeed;
            #endregion

        }
        public static void FuckRecipe_Hook(ElementalQuiver self)
        {
            self.CreateRecipe().
                AddIngredient<SoulPrestigeRanged>().
                AddIngredient<GalacticaSingularity>(5).
                AddIngredient<RuinousSoul>(5).
                AddTile<CosmicAnvil>().
                Register();   
        }
    }
}
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
    public class ReworkElementalGauntlet 
    {
        public static void Load()
        {
            MethodInfo fuckRecipe = typeof(ElementalGauntlet).GetMethod(nameof(ElementalGauntlet.AddRecipes));
            MethodInfo fuckUpdate = typeof(ElementalGauntlet).GetMethod(nameof(ElementalGauntlet.UpdateAccessory));
            MonoModHooks.Add(fuckRecipe, FuckRecipe_Hook);
            MonoModHooks.Add(fuckUpdate, FuckUpdateAcc_Hook);
            
        }
        public static void FuckUpdateAcc_Hook(ElementalGauntlet self, Player player, bool hideVisual)
        {
            var calPlayer = player.Calamity();
            var usPlayer = player.Soul();
            
            usPlayer.GuarrantedPrestige = true;
            #region 与盗贼潜伏有关的所有效果，包括伤害、恢复速度、潜伏条等
            player.GetDamage<MeleeDamageClass>() += 0.25f;
            player.GetDamage<TrueMeleeDamageClass>() += 0.25f;
            player.GetCritChance<MeleeDamageClass>() += 20f;
            player.GetAttackSpeed<MeleeDamageClass>() += 0.20f;
            #endregion

        }
        public static void FuckRecipe_Hook(ElementalGauntlet self)
        {
            self.CreateRecipe().
                AddIngredient<SoulPrestigeMelee>().
                AddIngredient<GalacticaSingularity>(5).
                AddIngredient<RuinousSoul>(5).
                AddTile<CosmicAnvil>().
                Register();   
        }
    }
    public class EAccsStats
    {
        public const float Damage = 0.25f;
        public const float Crits = 20f;
        public const float AttackSpeed = 0.15f; 
    }
}
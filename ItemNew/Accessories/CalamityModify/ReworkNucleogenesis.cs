using System.Reflection;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalamitySoulPorted.ItemNew.Accessories.Prestige;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.CalamityModify
{
    public class ReworkNucleogenesis
    {
        public static void Load()
        {
            MethodInfo fuckRecipe = typeof(Nucleogenesis).GetMethod(nameof(Nucleogenesis.AddRecipes));
            MethodInfo fuckUpdate = typeof(Nucleogenesis).GetMethod(nameof(Nucleogenesis.UpdateAccessory));
            MonoModHooks.Add(fuckRecipe, FuckRecipe_Hook);
            MonoModHooks.Add(fuckUpdate, FuckUpdateAcc_Hook);
            
        }
        public static void FuckUpdateAcc_Hook(Nucleogenesis self, Player player, bool hideVisual)
        {
            var calPlayer = player.Calamity();
            var usPlayer = player.Soul();
            
            #region 与盗贼潜伏有关的所有效果，包括伤害、恢复速度、潜伏条等
            player.GetDamage<SummonDamageClass>() += EAccsStats.Damage;
            usPlayer.GetSummonCrits += (int)EAccsStats.Crits;
            player.whipRangeMultiplier += 0.50f;
            player.GetAttackSpeed<SummonMeleeSpeedDamageClass>() += 0.50f;
            player.maxMinions += 5;
            player.maxTurrets += 4;
            usPlayer.GuarrantedPrestige = true;
            #endregion

        }
        public static void FuckRecipe_Hook(Nucleogenesis self)
        {
            self.CreateRecipe().
                AddIngredient<SoulPrestigeSummon>().
                AddIngredient(ItemID.BerserkerGlove).
                AddIngredient<GalacticaSingularity>(5).
                AddIngredient<RuinousSoul>(5).
                AddTile<CosmicAnvil>().
                Register();   
        }
    }
}
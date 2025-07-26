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
    public class ReworkEtherealTalisman
    {
        public static void Load()
        {
            MethodInfo fuckRecipe = typeof(EtherealTalisman).GetMethod(nameof(EtherealTalisman.AddRecipes));
            MethodInfo fuckUpdate = typeof(EtherealTalisman).GetMethod(nameof(EtherealTalisman.UpdateAccessory));
            MonoModHooks.Add(fuckRecipe, FuckRecipe_Hook);
            MonoModHooks.Add(fuckUpdate, FuckUpdateAcc_Hook);
            
        }
        public static void FuckUpdateAcc_Hook(EtherealTalisman self, Player player, bool hideVisual)
        {
            var calPlayer = player.Calamity();
            var usPlayer = player.Soul();
            
            usPlayer.GuarrantedPrestige = true;
            #region 与盗贼潜伏有关的所有效果，包括伤害、恢复速度、潜伏条等
            player.GetDamage<MagicDamageClass>() += EAccsStats.Damage;
            player.GetCritChance<MagicDamageClass>() += EAccsStats.Crits;
            player.GetAttackSpeed<MagicDamageClass>() += EAccsStats.AttackSpeed;
            player.manaCost -= 0.25f;
            player.statManaMax2 += 250;
            player.manaFlower = !hideVisual;
            #endregion

        }
        public static void FuckRecipe_Hook(EtherealTalisman self)
        {
            self.CreateRecipe().
                AddIngredient<SoulPrestigeMagic>().
                AddRecipeGroup("AnyManaFlower").
                AddIngredient<GalacticaSingularity>(5).
                AddIngredient<RuinousSoul>(5).
                AddTile<CosmicAnvil>().
                Register();   
        }
    }
}
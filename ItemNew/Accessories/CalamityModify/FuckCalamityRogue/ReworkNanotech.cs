using System.Reflection;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalamitySoulPorted.ItemNew.Accessories.Prestige;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.CalamityModify.FuckCalamityRogue
{
    public class ReworkNanotech 
    {
        public static void Load()
        {
            MethodInfo fuckRecipe = typeof(Nanotech).GetMethod(nameof(Nanotech.AddRecipes));
            MethodInfo fuckUpdate = typeof(Nanotech).GetMethod(nameof(Nanotech.UpdateAccessory));
            MonoModHooks.Add(fuckRecipe, FuckRecipe_Hook);
            MonoModHooks.Add(fuckUpdate, FuckUpdateAcc_Hook);
            
        }
        public static void FuckUpdateAcc_Hook(Nanotech self, Player player, bool hideVisual)
        {
            var calPlayer = player.Calamity();
            var usPlayer = player.Soul();
            
            usPlayer.GuarrantedPrestige = true;
            #region 与盗贼潜伏有关的所有效果，包括伤害、恢复速度、潜伏条等
            player.GetDamage<RogueDamageClass>() += 0.30f;
            player.GetCritChance<RogueDamageClass>() += 30f;
            calPlayer.rogueStealthMax += 0.30f;
            calPlayer.stealthStrikeHalfCost = true;
            calPlayer.rogueVelocity += 0.15f;
            calPlayer.stealthGenMoving += 0.5f;
            calPlayer.stealthGenStandstill += 0.5f;
            #endregion

        }
        public static void FuckRecipe_Hook(Nanotech self)
        {
            self.CreateRecipe().
                AddIngredient<RaidersTalisman>().
                AddIngredient<MoonstoneCrown>().
                AddIngredient<ElectriciansGlove>().
                AddIngredient<GalacticaSingularity>(5).
                AddIngredient<AscendantSpiritEssence>(5).
                AddIngredient<ShadowspecBar>(5).
                AddTile<DraedonsForge>().
                Register();   
        }
    }
}
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
    public class ReworkEclipseMirror 
    {
        public const int DodgeChance = 5;
        public const float OnHurtStealthRegen = 0.50f;
        public static void Load()
        {
            MethodInfo fuckRecipe = typeof(EclipseMirror).GetMethod(nameof(EclipseMirror.AddRecipes));
            MethodInfo fuckUpdate = typeof(EclipseMirror).GetMethod(nameof(EclipseMirror.UpdateAccessory));
            MonoModHooks.Add(fuckRecipe, FuckRecipe_Hook);
            MonoModHooks.Add(fuckUpdate, FuckUpdateAcc_Hook);
            
        }
        public static void FuckUpdateAcc_Hook(EclipseMirror self, Player player, bool hideVisual)
        {
            var calPlayer = player.Calamity();
            var usPlayer = player.Soul();
            
            usPlayer.GuarrantedPrestige = true;
            usPlayer.MirrorLevel = 3;
            usPlayer.SheathLevel = 5;
            #region 与盗贼潜伏有关的所有效果，包括伤害、恢复速度、潜伏条等
            player.GetDamage<RogueDamageClass>() += EAccsStats.Damage;
            player.GetCritChance<RogueDamageClass>() += EAccsStats.Crits;
            calPlayer.stealthStrikeHalfCost = true;
            calPlayer.rogueVelocity += 0.15f;
            calPlayer.stealthGenMoving += 0.5f;
            calPlayer.stealthGenStandstill += 0.5f;
            #endregion

        }
        public static void FuckRecipe_Hook(EclipseMirror self)
        {
            self.CreateRecipe().
                AddIngredient<SoulPrestigeRogue>().
                AddIngredient<AbyssalMirror>().
                AddIngredient<StatisNinjaBelt>().
                AddIngredient<GalacticaSingularity>(5).
                AddIngredient<RuinousSoul>(5).
                AddTile<CosmicAnvil>().
                Register();   
        }
    }
}
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
    public class ReworkDarkMatterSheath
    {
        public static void Load()
        {
            MethodInfo fuckRecipe = typeof(DarkMatterSheath).GetMethod(nameof(DarkMatterSheath.AddRecipes));
            MethodInfo fuckUpdate = typeof(DarkMatterSheath).GetMethod(nameof(DarkMatterSheath.UpdateAccessory));
            MonoModHooks.Add(fuckRecipe, FuckRecipe_Hook);
            MonoModHooks.Add(fuckUpdate, FuckUpdateAcc_Hook);
        }
        public static void FuckUpdateAcc_Hook(DarkMatterSheath self, Player player, bool hideVisual)
        {
            var calPlayer = player.Calamity();
            var usPlayer = player.Soul();
            player.GetDamage<RogueDamageClass>() += 0.10f;
            player.GetCritChance<RogueDamageClass>() += 8f;
            usPlayer.SheathLevel = 2;
            calPlayer.rogueStealthMax += 0.15f;
            calPlayer.stealthStrikeHalfCost = true;
        }
        public static void FuckRecipe_Hook(DarkMatterSheath self)
        {
            self.CreateRecipe().
                AddIngredient<SilencingSheath>().
                AddIngredient<RuinMedallion>().
                AddIngredient<ScoriaBar>(5).
                AddTile(TileID.MythrilAnvil).
                Register();
        }
    }
}
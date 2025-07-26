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
    public class ReworkAbyssalMirror
    {
        public static void Load()
        {
            MethodInfo fuckRecipe = typeof(AbyssalMirror).GetMethod(nameof(AbyssalMirror.AddRecipes));
            MethodInfo fuckUpdate = typeof(AbyssalMirror).GetMethod(nameof(AbyssalMirror.UpdateAccessory));
            MonoModHooks.Add(fuckRecipe, FuckRecipe_Hook);
            MonoModHooks.Add(fuckUpdate, FuckUpdateAcc_Hook);
        }
        public static void FuckUpdateAcc_Hook(AbyssalMirror self, Player player, bool hideVisual)
        {
            player.Soul().MirrorLevel = 2;
        }
        public static void FuckRecipe_Hook(AbyssalMirror self)
        {
            self.CreateRecipe().
                AddIngredient<MirageMirror>().
                AddIngredient<InkBomb>().
                AddIngredient<AshesofCalamity>(5).
                AddTile(TileID.MythrilAnvil).
                Register();
        }
    }
}
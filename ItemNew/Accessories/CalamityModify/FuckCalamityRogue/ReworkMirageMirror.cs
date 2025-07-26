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
    public class ReworkMirageMirror
    {
        public static void Load()
        {
            MethodInfo fuckRecipe = typeof(MirageMirror).GetMethod(nameof(MirageMirror.AddRecipes));
            MethodInfo fuckUpdate = typeof(MirageMirror).GetMethod(nameof(MirageMirror.UpdateAccessory));
            MonoModHooks.Add(fuckRecipe, FuckRecipe_Hook);
            MonoModHooks.Add(fuckUpdate, FuckUpdateAcc_Hook);
        }
        public static void FuckUpdateAcc_Hook(MirageMirror self, Player player, bool hideVisual)
        {
            player.Soul().MirrorLevel = 1;
        }
        public static void FuckRecipe_Hook(MirageMirror self)
        {
            self.CreateRecipe().
                AddIngredient(ItemID.MagicMirror).
                AddIngredient(ItemID.BlackLens).
                AddIngredient<AerialiteBar>(4).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
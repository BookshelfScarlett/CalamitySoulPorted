using System.Reflection;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamityMod.Projectiles.Melee;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalamitySoulPorted.ItemNew.Accessories.Prestige;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew
{
    public class FuckEGauntletRecipe
    {
        public static void Load()
        {
            MethodInfo fuck = typeof(ElementalGauntlet).GetMethod(nameof(ElementalGauntlet.AddRecipes));
            MonoModHooks.Add(fuck, FuckRecipe_Hook);
        }
        public static void FuckRecipe_Hook(ElementalGauntlet self)
        {
            self.CreateRecipe().
                AddIngredient<SoulPrestigeMelee>().
                AddIngredient<GalacticaSingularity>(5).
                AddIngredient<CosmiliteBar>(5).
                AddTile<CosmicAnvil>().
                Register();
        }
    }
    public class FuckEQuiverRecipe
    {
        public static void Load()
        {
            MethodInfo fuck = typeof(ElementalQuiver).GetMethod(nameof(ElementalQuiver.AddRecipes));
            MonoModHooks.Add(fuck, FuckRecipe_Hook);
        }
        public static void FuckRecipe_Hook(ElementalQuiver fuck)
        {
            fuck.CreateRecipe().
                AddIngredient<SoulPrestigeRanged>().
                AddIngredient<GalacticaSingularity>(5).
                AddIngredient<CosmiliteBar>(5).
                AddTile<CosmicAnvil>().
                Register();
        }
    }
    public class FuckETailsmanRecipe
    {
        public static void Load()
        {
            MethodInfo fuck = typeof(EtherealTalisman).GetMethod(nameof(EtherealTalisman.AddRecipes));
            MonoModHooks.Add(fuck, FuckRecipe_Hook);
        }
        public static void FuckRecipe_Hook(EtherealTalisman fuck)
        {
            fuck.CreateRecipe().
                AddIngredient<SoulPrestigeMagic>().
                AddRecipeGroup("AnyManaFlower").
                AddIngredient<GalacticaSingularity>(5).
                AddIngredient<CosmiliteBar>(5).
                AddTile<CosmicAnvil>().
                Register();
        }
    }
    public class FuckNuclerRecipe
    {
        public static void Load()
        {
            MethodInfo fuck = typeof(Nucleogenesis).GetMethod(nameof(Nucleogenesis.AddRecipes));
            MonoModHooks.Add(fuck, FuckRecipe_Hook);
        }
        public static void FuckRecipe_Hook(Nucleogenesis fuck)
        {
            fuck.CreateRecipe().
                AddIngredient<SoulPrestigeSummon>().
                AddIngredient(ItemID.BerserkerGlove).
                AddIngredient<GalacticaSingularity>(5).
                AddIngredient<CosmiliteBar>(5).
                AddTile<CosmicAnvil>().
                Register();
        }
    }
    public class FuckEMirrorRecipe
    {
        public static void Load()
        {
            MethodInfo fuck = typeof(EclipseMirror).GetMethod(nameof(EclipseMirror.AddRecipes));
            MonoModHooks.Add(fuck, FuckRecipe_Hook);
        }
        public static void FuckRecipe_Hook(EclipseMirror fuck)
        {
            fuck.CreateRecipe().
                AddIngredient<SoulPrestigeRogue>().
                AddIngredient<StatisVoidSash>().
                AddIngredient<GalacticaSingularity>(5).
                AddIngredient<CosmiliteBar>(5).
                AddTile<CosmicAnvil>().
                Register();
        }
    }

}
using System.Reflection;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamityMod.Tiles.Furniture.CraftingStations;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.CalamityModify
{
    public class ReworkChaliceGod
    {
        public static void Load()
        {
            MethodInfo fuckRecipe = typeof(ChaliceOfTheBloodGod).GetMethod(nameof(ChaliceOfTheBloodGod.AddRecipes));
            MethodInfo fuckAcc = typeof(ChaliceOfTheBloodGod).GetMethod(nameof(ChaliceOfTheBloodGod.UpdateAccessory));

            MonoModHooks.Add(fuckRecipe, FuckRecipe_Hook);
            MonoModHooks.Add(fuckAcc, FuckUpdateAcc_Hook);
        }
        public static void FuckUpdateAcc_Hook(ChaliceOfTheBloodGod self, Player player, bool hideVisual)
        {
            player.Calamity().chaliceOfTheBloodGod = true;
            player.Calamity().healingPotionMultiplier += 0.30f;
            player.GetDamage<GenericDamageClass>() += 0.12f;
            player.endurance += 0.10f;
        }
        public static void FuckRecipe_Hook(ChaliceOfTheBloodGod self)
        {
            self.CreateRecipe().
                AddIngredient<BloodflareCore>().
                AddIngredient<BloodyWormScarf>().
                AddIngredient<BloodstoneCore>(5).
                AddIngredient<AscendantSpiritEssence>(5).
                AddTile<CosmicAnvil>().
                Register();
        }
    }
}
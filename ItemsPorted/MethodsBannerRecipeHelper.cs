using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted
{
    public class MethodsBannerRecipeHelper : ModSystem
    {
        public override void AddRecipes()
        {
            base.AddRecipes();
        }


        //快速注册旗帜合成表方法
        public static Recipe AddBannerRecipeSingle<ResultItem>(int banner, int resultCount = 1, int wantedTile = TileID.Solidifier, int bannerCounts = 1) where ResultItem : ModItem =>
            Recipe.Create(ModContent.ItemType<ResultItem>(), resultCount).
                AddIngredient(banner, bannerCounts).
                AddTile(wantedTile).
                Register();
        public static Recipe AddBannerRecipeGroup<ResultItem>(string bannerGroup, int resultCount = 1, int wantedTile = TileID.Solidifier, int bannerCounts = 1) where ResultItem : ModItem =>
            Recipe.Create(ModContent.ItemType<ResultItem>(), resultCount).
                AddRecipeGroup(bannerGroup, bannerCounts).
                AddTile(wantedTile).
                Register();
    }
   
}
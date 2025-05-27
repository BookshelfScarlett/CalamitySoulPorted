using System;
using System.Collections.Generic;
using System.Linq;
using CalamityMod.Items.TreasureBags;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.NPCs.DevourerofGods;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted
{
    public class MethodsSingleItemRecipeHelper : ModSystem
    {
        #region 建表
        public static List<int> DevourerofGodsBagDrop = [];
        #endregion
        public override void Load()
        {
            DevourerofGodsBagDrop = [];
            base.Load();
        }
        public override void Unload()
        {
            DevourerofGodsBagDrop = null;
        }
        public override void PostAddRecipes()
        {
            //宝藏袋合成表
            TreasureBagRecipe();
        }

        public static void TreasureBagRecipe()
        {
            //神长的表单, 并去重
            DevourerofGodsBagDrop.AddRange(SoulMethod.GetBossDrop(Boss<DevourerofGodsHead>()).Where(id => !DevourerofGodsBagDrop.Contains(id)).Distinct());
            //注册神长合成表。
            foreach (int DoGItem in DevourerofGodsBagDrop)
                QuickRecipeSingle(DoGItem, Item<DevourerofGodsBag>(), default, Tile<CosmicAnvil>());
        }

        public static int Item<T>() where T : ModItem => ModContent.ItemType<T>();
        public static int Boss<T>() where T : ModNPC => ModContent.NPCType<T>();
        public static int Tile<T>() where T : ModTile => ModContent.TileType<T>();

        public static Recipe QuickRecipeSingle(int result, int ingre, int resultCount = 1, int wantedTile = TileID.Solidifier, int ingreCounts = 1) =>
            RegisterRecipe(result, ingre, resultCount, wantedTile, ingreCounts);
        public static Recipe QuickRecipeSingleMod<ResultItem>(int ingre, int resultCount = 1, int wantedTile = TileID.Solidifier, int ingrecounts = 1) where ResultItem : ModItem =>
            RegisterRecipe(Item<ResultItem>(), ingre, resultCount, wantedTile, ingrecounts);

        public static Recipe QuickRecipeGroup<ResultItem>(string bannerGroup, int resultCount = 1, int wantedTile = TileID.Solidifier, int bannerCounts = 1) where ResultItem : ModItem =>
            Recipe.Create(ModContent.ItemType<ResultItem>(), resultCount).
                AddRecipeGroup(bannerGroup, bannerCounts).
                AddTile(wantedTile).
                Register();
        public static Recipe RegisterRecipe(int result, int ingre, int resultCount, int wantedTile, int ingreCounts) =>
            Recipe.Create(result, resultCount).
                AddIngredient(ingre, ingreCounts).
                AddTile(wantedTile).
                Register();
    }
   
}
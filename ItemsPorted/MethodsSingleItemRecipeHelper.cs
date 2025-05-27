using System.Collections.Generic;
using System.Linq;
using CalamityMod.Items.TreasureBags;
using CalamityMod.NPCs.AquaticScourge;
using CalamityMod.NPCs.AstrumAureus;
using CalamityMod.NPCs.BrimstoneElemental;
using CalamityMod.NPCs.Bumblebirb;
using CalamityMod.NPCs.CalClone;
using CalamityMod.NPCs.CeaselessVoid;
using CalamityMod.NPCs.Crabulon;
using CalamityMod.NPCs.Cryogen;
using CalamityMod.NPCs.DesertScourge;
using CalamityMod.NPCs.DevourerofGods;
using CalamityMod.NPCs.HiveMind;
using CalamityMod.NPCs.Leviathan;
using CalamityMod.NPCs.OldDuke;
using CalamityMod.NPCs.Perforator;
using CalamityMod.NPCs.PlaguebringerGoliath;
using CalamityMod.NPCs.Polterghast;
using CalamityMod.NPCs.Providence;
using CalamityMod.NPCs.Ravager;
using CalamityMod.NPCs.Signus;
using CalamityMod.NPCs.SlimeGod;
using CalamityMod.NPCs.StormWeaver;
using CalamityMod.NPCs.Yharon;
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
        public static List<int> BagDropDesertScourge = [];
        public static List<int> BagDropCrabulon = [];
        public static List<int> BagDropHiveMind = [];
        public static List<int> BagDropPerf = [];
        public static List<int> BagDropSlimeGod = [];
        public static List<int> BagDropAquaticScourge = [];
        public static List<int> BagDropBrimstoneElemental = [];
        public static List<int> BagDropCryogen = [];
        public static List<int> BagDropCalamitasClone = [];
        public static List<int> BagDropLeviAndAnahita = [];
        public static List<int> BagDropAstrum = [];
        public static List<int> BagDropDeus = [];
        public static List<int> BagDropPlagueBringer = [];
        public static List<int> BagDropRavager = [];
        public static List<int> BagDropProvidence = [];
        public static List<int> BagDropCeaselessVoid = [];
        public static List<int> BagDropDragonfolly = [];
        public static List<int> BagDropSignus = [];
        public static List<int> BagDropStormWeaver = [];
        public static List<int> BagDropPolterghast = [];
        public static List<int> BagDropOldDuke = [];
        public static List<int> BagDropDevourerofGods = [];
        public static List<int> BagDropYharon = [];
        public override void Load()
        {
            List<int>[] list =
            [
                BagDropDesertScourge,
                BagDropCrabulon,
                BagDropHiveMind,
                BagDropPerf,
                BagDropSlimeGod,
                BagDropCryogen,
                BagDropAquaticScourge,
                BagDropBrimstoneElemental,
                BagDropCalamitasClone,
                BagDropLeviAndAnahita,
                BagDropAstrum,
                BagDropPlagueBringer,
                BagDropRavager,
                BagDropDeus,
                BagDropProvidence,
                BagDropDragonfolly,
                BagDropSignus,
                BagDropCeaselessVoid,
                BagDropStormWeaver,
                BagDropPolterghast,
                BagDropOldDuke,
                BagDropDevourerofGods,
                BagDropYharon
            ];
            for (int i = 0; i < list.Length; i++)
                list = [];
        }
        public override void Unload()
        {
            List<int>[] list =
            [
                BagDropDesertScourge,
                BagDropCrabulon,
                BagDropHiveMind,
                BagDropPerf,
                BagDropSlimeGod,
                BagDropCryogen,
                BagDropAquaticScourge,
                BagDropBrimstoneElemental,
                BagDropCalamitasClone,
                BagDropLeviAndAnahita,
                BagDropAstrum,
                BagDropPlagueBringer,
                BagDropRavager,
                BagDropDeus,
                BagDropProvidence,
                BagDropDragonfolly,
                BagDropSignus,
                BagDropCeaselessVoid,
                BagDropStormWeaver,
                BagDropPolterghast,
                BagDropOldDuke,
                BagDropDevourerofGods,
                BagDropYharon
            ];
            for (int i = 0; i < list.Length; i++)
                list = null;
          
        }
        #endregion
        public override void PostAddRecipes()
        {
            //宝藏袋合成表
            TreasureBagRecipe();
        }

        public static void TreasureBagRecipe()
        {
            #region 灾厄mod所有Boss的boss掉落物注册表单，并去重
            QuickBagList<DesertScourgeHead>(BagDropDesertScourge);
            QuickBagList<Crabulon>(BagDropCrabulon);
            QuickBagList<HiveMind>(BagDropHiveMind);
            QuickBagList<PerforatorHive>(BagDropPerf);
            QuickBagList<SlimeGodCore>(BagDropSlimeGod);
            QuickBagList<Cryogen>(BagDropCryogen);
            QuickBagList<BrimstoneElemental>(BagDropBrimstoneElemental);
            QuickBagList<AquaticScourgeHead>(BagDropAquaticScourge);
            QuickBagList<CalamitasClone>(BagDropCalamitasClone);
            QuickBagList<Leviathan>(BagDropLeviAndAnahita);
            QuickBagList<AstrumAureus>(BagDropAstrum);
            QuickBagList<PlaguebringerGoliath>(BagDropPlagueBringer);
            QuickBagList<RavagerHead>(BagDropRavager);
            QuickBagList<Providence>(BagDropProvidence);

            //草泥马灾厄
            QuickBagList<Bumblefuck>(BagDropDragonfolly);

            QuickBagList<CeaselessVoid>(BagDropCeaselessVoid);
            QuickBagList<Signus>(BagDropSignus);
            QuickBagList<StormWeaverHead>(BagDropStormWeaver);
            QuickBagList<Polterghast>(BagDropPolterghast);
            QuickBagList<OldDuke>(BagDropOldDuke);
            QuickBagList<DevourerofGodsHead>(BagDropDevourerofGods);
            QuickBagList<Yharon>(BagDropYharon);
            #endregion 妈的这也太坐牢了

            #region 注册所有合成表
            //注宝藏袋合成表，这一合成将会把范围扩展至所有给灾厄Boss添加武器掉落的模组
            //nmb的这也太坐牢了，虽然我已经尽可能地写了一堆方便的方法了，但是还是太坐牢了
            foreach (int DS in BagDropDesertScourge)
                QuickRecipeSingle(DS, Item<DesertScourgeBag>());
            foreach (int Crab in BagDropCrabulon)
                QuickRecipeSingle(Crab, Item<CrabulonBag>());
            foreach (int Perf in BagDropPerf)
                QuickRecipeSingle(Perf, Item<PerforatorBag>());
            foreach (int HM in BagDropHiveMind)
                QuickRecipeSingle(HM, Item<HiveMindBag>());
            foreach (int SG in BagDropSlimeGod)
                QuickRecipeSingle(SG, Item<SlimeGodBag>(), Tile<StaticRefiner>());
            foreach (int AS in BagDropAquaticScourge)
                QuickRecipeSingle(AS, Item<AquaticScourgeBag>(), Tile<StaticRefiner>());
            foreach (int Ice in BagDropCryogen)
                QuickRecipeSingle(Ice, Item<CryogenBag>(), Tile<StaticRefiner>());
            foreach (int CC in BagDropCalamitasClone)
                QuickRecipeSingle(CC, Item<CalamitasCloneBag>(), Tile<StaticRefiner>());
            foreach (int LA in BagDropLeviAndAnahita)
                QuickRecipeSingle(LA, Item<LeviathanBag>(), Tile<StaticRefiner>());
            foreach (int AA in BagDropAstrum)
                QuickRecipeSingle(AA, Item<AstrumAureusBag>(), Tile<StaticRefiner>());
            foreach (int PBG in BagDropPlagueBringer)
                QuickRecipeSingle(PBG, Item<PlaguebringerGoliathBag>(), Tile<StaticRefiner>());
            foreach (int R in BagDropRavager)
                QuickRecipeSingle(R, Item<RavagerBag>(), Tile<StaticRefiner>());
            foreach (int D in BagDropDeus)
                QuickRecipeSingle(D, Item<AstrumDeusBag>(), Tile<StaticRefiner>());
            foreach (int Provi in BagDropProvidence)
                QuickRecipeSingle(Provi, Item<ProvidenceBag>(), TileID.LunarCraftingStation);
            foreach (int Bird in BagDropDragonfolly)
                QuickRecipeSingle(Bird, Item<DragonfollyBag>(), TileID.LunarCraftingStation);
            foreach (int CV in BagDropCeaselessVoid)
                QuickRecipeSingle(CV, Item<CeaselessVoidBag>(), TileID.LunarCraftingStation);
            foreach (int Sig in BagDropSignus)
                QuickRecipeSingle(Sig, Item<SignusBag>(), TileID.LunarCraftingStation);
            foreach (int SW in BagDropStormWeaver)
                QuickRecipeSingle(SW, Item<StormWeaverBag>(), TileID.LunarCraftingStation);
            foreach (int Ghost in BagDropPolterghast)
                QuickRecipeSingle(Ghost, Item<PolterghastBag>(), TileID.LunarCraftingStation);
            foreach (int OD in BagDropOldDuke)
                QuickRecipeSingle(OD, Item<OldDukeBag>(), TileID.LunarCraftingStation);
            foreach (int DoG in BagDropDevourerofGods)
                QuickRecipeSingle(DoG, Item<DevourerofGodsBag>(), Tile<CosmicAnvil>());
            foreach (int Dragon in BagDropYharon)
                QuickRecipeSingle(Dragon, Item<YharonBag>(), Tile<CosmicAnvil>());
            
            #endregion
        }
        public static void QuickBagList<T>(List<int> list) where T : ModNPC => list.AddRange(SoulMethod.GetBossDrop(Boss<T>()).Where(id => !list.Contains(id)).Distinct());
        public static int Item<T>() where T : ModItem => ModContent.ItemType<T>();
        public static int Boss<T>() where T : ModNPC => ModContent.NPCType<T>();
        public static int Tile<T>() where T : ModTile => ModContent.TileType<T>();

        public static Recipe QuickRecipeSingle(int result, int ingre, int wantedTile = TileID.Solidifier, int resultCount = 1, int ingreCounts = 1) =>
            RegisterRecipe(result, ingre, resultCount, wantedTile, ingreCounts);
        public static Recipe QuickRecipeSingleMod<ResultItem>(int ingre, int wantedTile = TileID.Solidifier, int resultCount = 1, int ingrecounts = 1) where ResultItem : ModItem =>
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
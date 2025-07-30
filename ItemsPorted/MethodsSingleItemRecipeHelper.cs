using System;
using System.Collections.Generic;
using System.Linq;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Pets;
using CalamityMod.Items.TreasureBags;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.NPCs.AquaticScourge;
using CalamityMod.NPCs.AstrumAureus;
using CalamityMod.NPCs.AstrumDeus;
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
using CalamityMod.Projectiles.Typeless;
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
        #region 宝藏袋
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
        public static List<int> BagDropCatalystSlime = [];
        public static List<int> BagDropInhertianceYharon = [];
        //熵
        public static List<int> BagDropEntropyWhiteBoss = [];
        public static List<int> BagDropEntropyButterfly = [];
        public static List<int> BagDropEntropyPurpleWorm = [];
        public static List<int> BagDropEntropyWTFTwin = [];
        public static List<int> FuckYouGoozma = [];
        #endregion
        #region 纪念章
        public static List<int> TrophyDesertScourge = [];
        public static List<int> TrophyCrabulon = [];
        public static List<int> TrophyHiveMind = [];
        public static List<int> TrophyPerf = [];
        public static List<int> TrophySG = [];
        public static List<int> TrophyAquaticScourge = [];
        public static List<int> TrophyCryogen = [];
        public static List<int> TrophyBrimstoneElemental = [];
        public static List<int> TrophyCalamitasClone = [];
        //兄弟纪念章
        public static List<int> TrophyCatastropheClone = [];
        public static List<int> TrophyCatalycsmClone = [];
        #endregion
        public override void Load()
        {
            List<int>[] bagList =
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
                BagDropYharon,
                BagDropInhertianceYharon,
                BagDropCatalystSlime,

                BagDropEntropyButterfly,
                BagDropEntropyPurpleWorm,
                BagDropEntropyWhiteBoss,
                BagDropEntropyWTFTwin,
                FuckYouGoozma

            ];
            for (int i = 0; i < bagList.Length; i++)
                bagList[i] = [];
        }
        public override void Unload()
        {
            List<int>[] bagList =
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
                BagDropYharon,

                BagDropInhertianceYharon,
                BagDropEntropyButterfly,
                BagDropEntropyPurpleWorm,
                BagDropEntropyWhiteBoss,
                BagDropEntropyWTFTwin,
                BagDropCatalystSlime,
                FuckYouGoozma
            ];
            for (int i = 0; i < bagList.Length; i++)
                bagList[i] = null;
        }
        #endregion
        public override void PostAddRecipes()
        {
            //宝藏袋合成表
            TreasureBagRecipe();
            //纪念章
            TrophyRecipe();
        }
        public override void AddRecipes()
        {
            
        }

        public void TrophyRecipe()
        {
            QuickRecipeGroup<TheAtomSplitter>(SoulRecpieGroupID.TrophyExoTwin, wantedTile: Tile<DraedonsForge>());
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
            QuickBagList<AstrumDeusHead>(BagDropDeus);
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
            #endregion

            #region 注册所有合成表
            //注宝藏袋合成表，这一合成将会把范围扩展至所有给灾厄Boss添加武器掉落的模组
            //nmb的这也太坐牢了，虽然我已经尽可能地写了一堆方便的方法了，但是还是太坐牢了
            int staticRef = Tile<StaticRefiner>();
            int lunar = TileID.LunarCraftingStation;
            foreach (int DS in BagDropDesertScourge)
                QuickRecipeSingle(DS, Item<DesertScourgeBag>());
            foreach (int Crab in BagDropCrabulon)
                QuickRecipeSingle(Crab, Item<CrabulonBag>());
            foreach (int Perf in BagDropPerf)
                QuickRecipeSingle(Perf, Item<PerforatorBag>());
            foreach (int HM in BagDropHiveMind)
                QuickRecipeSingle(HM, Item<HiveMindBag>());
            foreach (int SG in BagDropSlimeGod)
                QuickRecipeSingle(SG, Item<SlimeGodBag>(), staticRef);
            foreach (int AS in BagDropAquaticScourge)
                QuickRecipeSingle(AS, Item<AquaticScourgeBag>(), staticRef);
            foreach (int Ice in BagDropCryogen)
                QuickRecipeSingle(Ice, Item<CryogenBag>(), staticRef);
            foreach (int BE in BagDropBrimstoneElemental)
                QuickRecipeSingle(BE, Item<BrimstoneWaifuBag>(), staticRef);
            foreach (int CC in BagDropCalamitasClone)
                QuickRecipeSingle(CC, Item<CalamitasCloneBag>(), staticRef);
            foreach (int LA in BagDropLeviAndAnahita)
                QuickRecipeSingle(LA, Item<LeviathanBag>(), staticRef);
            foreach (int AA in BagDropAstrum)
                QuickRecipeSingle(AA, Item<AstrumAureusBag>(), staticRef);
            foreach (int PBG in BagDropPlagueBringer)
                QuickRecipeSingle(PBG, Item<PlaguebringerGoliathBag>(), staticRef);
            foreach (int R in BagDropRavager)
                QuickRecipeSingle(R, Item<RavagerBag>(), staticRef);
            foreach (int D in BagDropDeus)
                QuickRecipeSingle(D, Item<AstrumDeusBag>(), staticRef);
            foreach (int Provi in BagDropProvidence)
                QuickRecipeSingle(Provi, Item<ProvidenceBag>(), lunar);
            foreach (int Bird in BagDropDragonfolly)
                QuickRecipeSingle(Bird, Item<DragonfollyBag>(), lunar);
            foreach (int CV in BagDropCeaselessVoid)
                QuickRecipeSingle(CV, Item<CeaselessVoidBag>(), lunar);
            foreach (int Sig in BagDropSignus)
                QuickRecipeSingle(Sig, Item<SignusBag>(), lunar);
            foreach (int SW in BagDropStormWeaver)
                QuickRecipeSingle(SW, Item<StormWeaverBag>(), lunar);
            foreach (int Ghost in BagDropPolterghast)
                QuickRecipeSingle(Ghost, Item<PolterghastBag>(), lunar);
            foreach (int OD in BagDropOldDuke)
                QuickRecipeSingle(OD, Item<OldDukeBag>(), lunar);
            foreach (int DoG in BagDropDevourerofGods)
                QuickRecipeSingle(DoG, Item<DevourerofGodsBag>(), Tile<CosmicAnvil>());
            foreach (int Dragon in BagDropYharon)
                QuickRecipeSingle(Dragon, Item<YharonBag>(), Tile<CosmicAnvil>());

            #endregion
            //模组联动
            CrossModSupport();
            
        }
        #region 宝藏袋合成表的模组联动
        //TODO: 灾劫、狩猎
        public static void CrossModSupport()
        {

            if (CalamitySoulPorted.Inhertiance != null)
                InheritanceCrossModSupport();
            if (CalamitySoulPorted.Hunt != null)
                HuntCrossModSupport();
            if (CalamitySoulPorted.Catalyst != null)
                CatalystCrossModSupport();
            //什么我叫引用了空成员？
            if (CalamitySoulPorted.Entropy != null)
                EntropyCrossModSupport(CalamitySoulPorted.Entropy);
        }
        //这么多mod为什么就熵报错了？
        public static void EntropyCrossModSupport(Mod mod)
        {
            //怎么只有先知的袋子和boss会空引用啊？
            // ModNPC boss1 = mod.TryFindBetter<ModNPC>("TheProphet");
            // QuickBagList(BagDropEntropyWhiteBoss, boss1.Type);
            // ModItem bag1 = mod.TryFindBetter<ModItem>("TheProphetBag");
            // foreach (int b1 in BagDropEntropyWhiteBoss)
            //     QuickRecipeSingle(b1, bag1.Type, Tile<StaticRefiner>());

            ModNPC boss2 = mod.TryFindBetter<ModNPC>("NihilityActeriophage");
            ModNPC boss3 = mod.TryFindBetter<ModNPC>("Luminaris");
            ModNPC boss4 = mod.TryFindBetter<ModNPC>("CruiserHead");
            ModItem bag2 = mod.TryFindBetter<ModItem>("NihilityTwinBag");
            ModItem bag3 = mod.TryFindBetter<ModItem>("LuminarisBag");
            ModItem bag4 = mod.TryFindBetter<ModItem>("CruiserBag");
            QuickBagList(BagDropEntropyWTFTwin, boss2.Type);
            QuickBagList(BagDropEntropyButterfly, boss3.Type);
            QuickBagList(BagDropEntropyPurpleWorm, boss4.Type);

            foreach (int b2 in BagDropEntropyWTFTwin)
                QuickRecipeSingle(b2, bag2.Type, TileID.LunarCraftingStation);
            foreach (int b3 in BagDropEntropyButterfly)
                QuickRecipeSingle(b3, bag3.Type, Tile<StaticRefiner>());
            foreach (int b4 in BagDropEntropyPurpleWorm)
                QuickRecipeSingle(b4, bag4.Type, Tile<CosmicAnvil>());
        }

        public static void CatalystCrossModSupport()
        {
            Mod mod = CalamitySoulPorted.Catalyst;
            ModNPC boss = mod.TryFindBetter<ModNPC>("Astrageldon");
            ModItem bag = mod.TryFindBetter<ModItem>("AstrageldonBag");
            QuickBagList(BagDropCatalystSlime, boss.Type);
            foreach (int fuckYouCata in BagDropCatalystSlime)
                QuickRecipeSingle(fuckYouCata, bag.Type, TileID.LunarCraftingStation);

        }

        public static void HuntCrossModSupport()
        {
            Mod mod = CalamitySoulPorted.Hunt;
            ModNPC fuckGoozma = mod.TryFindBetter<ModNPC>("Goozma");
            //嘿嘿，我也要学goozma一样整随机度
            QuickBagList(FuckYouGoozma, fuckGoozma.Type);
            foreach (int b in FuckYouGoozma)
            {
                Recipe.Create(b).
                    AddRecipeGroup(SoulRecpieGroupID.FuckingGoozma).
                    AddTile<CosmicAnvil>().
                    DisableDecraft().
                    Register();
            }
            
        }

        public static void InheritanceCrossModSupport()
        {
            // Mod inhertianceMod = CalamitySoulPorted.Inhertiance;
            // ModItem getYharonTreasureBag = inhertianceMod.QuickCrossModItem("YharonTreasureBagLegacy");
            // // ModNPC yharonLegacy = inhertianceMod.QuickCrossModNPC("YharonLegacy");
            // //虽然这个大哥99%不会出现问题，但是我还是决定……just in case了
            // if (getYharonTreasureBag == null)
            //     return;
            // QuickRecipeSingle(ItemID.SoulofNight, getYharonTreasureBag.Type);

            // QuickBagListID(BagDropInhertianceYharon, yharonLegacy.NPC.type);

            // foreach (int DragonLegacy in BagDropInhertianceYharon)
            //     QuickRecipeSingle(DragonLegacy, getYharonTreasureBag.Item.type, Tile<CosmicAnvil>());
            Mod mod = CalamitySoulPorted.Inhertiance;
            ModItem essence = mod.TryFindModItem("CalamitousEssence");
            //TODO:给灾眼一个宝藏袋，让宝藏袋替代直接制作魔影武器的效果，然后做掉灾厄精华除直接出魔影锭以外的合成表
            if (essence != null)
            {
                //换50个魔影锭（因为会考虑上调灾眼难度）
                QuickRecipeSingle(Item<ShadowspecBar>(), essence.Type, Tile<CosmicAnvil>(), 50);
            }
        }
        #endregion
        #region 快捷方法
        public static void QuickBagList<T>(List<int> list) where T : ModNPC => list.AddRange(SoulMethod.GetBossDrop(Boss<T>()).Where(id => !list.Contains(id)).Distinct());
        public static void QuickBagList(List<int> list, int npcID) => list.AddRange(SoulMethod.GetBossDrop(npcID).Where(id => !list.Contains(id)).Distinct());
        public static int Item<T>() where T : ModItem => ModContent.ItemType<T>();
        public static int Boss<T>() where T : ModNPC => ModContent.NPCType<T>();
        public static int Tile<T>() where T : ModTile => ModContent.TileType<T>();
        #endregion
        #region 快捷注册物品合成表
        public static Recipe QuickRecipeSingle(int result, int ingre, int wantedTile = TileID.Solidifier, int resultCount = 1, int ingreCounts = 1) =>
            RegisterRecipe(result, ingre, resultCount, wantedTile, ingreCounts);
        public static Recipe QuickRecipeSingleMod<ResultItem>(int ingre, int wantedTile = TileID.Solidifier, int resultCount = 1, int ingrecounts = 1) where ResultItem : ModItem =>
            RegisterRecipe(Item<ResultItem>(), ingre, resultCount, wantedTile, ingrecounts);

        public static Recipe QuickRecipeGroup<ResultItem>(string bannerGroup, int resultCount = 1, int wantedTile = TileID.Solidifier, int bannerCounts = 1) where ResultItem : ModItem =>
            Recipe.Create(ModContent.ItemType<ResultItem>(), resultCount).
                AddRecipeGroup(bannerGroup, bannerCounts).
                DisableDecraft().
                AddTile(wantedTile).
                Register();
        public static Recipe RegisterRecipe(int result, int ingre, int resultCount, int wantedTile, int ingreCounts) =>
            Recipe.Create(result, resultCount).
                AddIngredient(ingre, ingreCounts).
                DisableDecraft().
                AddTile(wantedTile).
                Register();
        #endregion
        #region CrossMod方法
        
        #endregion
    }
   
}
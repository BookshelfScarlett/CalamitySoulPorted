using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalamityMod.Items.Materials;
using CalamityMod.Tiles.Ores;
using CalamitySoulPorted.ItemNew;
using CalamitySoulPorted.ItemNew.Accessories.CalamityModify;
using CalamitySoulPorted.ItemNew.Accessories.CalamityModify.FuckCalamityRogue;
using CalamitySoulPorted.SoulTile;
using CalamitySoulPorted.SoulTile.AutoSmeltList;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class CalamitySoulPorted : Mod
	{
		public static Mod Calamity => ModLoader.GetMod("CalamityMod");
		//熵联动相关
		public static Mod Entropy => ModLoader.GetMod("CalamityEntropy");
		//灾厄遗产联动相关
		public static Mod Inhertiance => ModLoader.GetMod("CalamityInhertiance");



        public static CalamitySoulPorted Instance { get => instance; set => instance = value; }

        private static CalamitySoulPorted instance;
        public override void Load()
		{
			FuckRecipeHooks();
			FuckCalamityStealthRogue();
			base.Load();
		}

        private void FuckCalamityStealthRogue()
        {
			//灾厄日蚀魔镜
			ReworkEclipseMirror.Load();
			//灾厄暗物质剑鞘
			ReworkDarkMatterSheath.Load();
			//灾厄毁灭勋章
			ReworkRuinMedallion.Load();
			//灾厄纳米技术
			ReworkNanotech.Load();
			//灾厄深渊魔镜
			ReworkAbyssalMirror.Load();
			//灾厄幻影魔镜
			ReworkMirageMirror.Load();
			//灾厄寂静刀鞘
			ReworkSilenceSheath.Load();
        }

        public static void FuckRecipeHooks()
		{
			//灾厄核子之源
			ReworkNucleogenesis.Load();
			//灾厄元素手套
			ReworkElementalGauntlet.Load();
			//灾厄元素箭袋
			ReworkElementalQuiver.Load();
			//灾厄空灵护符
			ReworkEtherealTalisman.Load();
		}
        public override void PostSetupContent()
        {
			//首先刷新一次表单
			SmeltList.ClearOreList();
			//其次开始添加矿石与对应的矿锭
			if (SmeltList.OreType != null && SmeltList.OreType.Count == 0 && SmeltList.BarType != null && SmeltList.BarType.Count == 0)
			{
				//初始化原版矿物表单
				//这个写法其实有点风险的，如果表单不能一一对应就出事
				//后面在考虑改写，先实现效果
				for (int i = 0; i < SmeltList.VanillaOres.Length; i++)
				{
					SmeltList.AddOres(SmeltList.VanillaOres[i], SmeltList.VanillaBars[i]);
				}
				#region 灾厄的矿物表单
				SmeltList.AddOres(Tile<AerialiteOre>(), Item<AerialiteBar>());
				//我草，灾厄为什么要写一个没激活的天蓝矿
				SmeltList.AddOres(Tile<AerialiteOreDisenchanted>(), Item<AerialiteBar>());
				SmeltList.AddOres(Tile<InfernalSuevite>(), Item<UnholyCore>());
				SmeltList.AddOres(Tile<CryonicOre>(), Item<CryonicBar>());
				//我草，灾厄几把写的神圣矿干啥
				SmeltList.AddOres(Tile<HallowedOre>(), ItemID.HallowedBar);
				SmeltList.AddOres(Tile<PerennialOre>(), Item<PerennialBar>());
				SmeltList.AddOres(Tile<ScoriaOre>(), Item<ScoriaBar>());
				SmeltList.AddOres(Tile<AstralOre>(), Item<AstralBar>());
				SmeltList.AddOres(Tile<UelibloomOre>(), Item<UelibloomBar>());
				SmeltList.AddOres(Tile<AuricOre>(), Item<AuricBar>());

				#endregion
				//TODO: 这里要几把加一个灾劫的星凝矿😅

			}
        }
		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			ModPacket packet = GetPacket();

			if (Main.netMode == NetmodeID.Server)
			{
				ushort x = reader.ReadUInt16(), y = reader.ReadUInt16();
				ushort chance = reader.ReadUInt16();
				ushort targetType = reader.ReadUInt16();
				packet.Write(x);
				packet.Write(y);
				packet.Write(chance);
				packet.Send(-1, whoAmI);
				SoulGlobalTile autoSmelt = ModContent.GetInstance<SoulGlobalTile>();
				autoSmelt.SmeltOres(x, y, chance, targetType);
			}
			else
			{
				ushort x = reader.ReadUInt16(), y = reader.ReadUInt16();
				ushort chance = reader.ReadUInt16();
				ushort targetType = reader.ReadUInt16();
				SoulGlobalTile autoSmelt = ModContent.GetInstance<SoulGlobalTile>();
				autoSmelt.SmeltOres(x, y, chance,targetType);
			}
		}
		public override void Unload()
		{
			Instance = null;
			base.Unload();
		}
		public static int Tile<T>() where T : ModTile => ModContent.TileType<T>();
		public static int Item<T>() where T : ModItem => ModContent.ItemType<T>();
	}
}

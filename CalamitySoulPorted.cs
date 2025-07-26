using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalamitySoulPorted.ItemNew;
using CalamitySoulPorted.ItemNew.Accessories.CalamityModify;
using CalamitySoulPorted.ItemNew.Accessories.CalamityModify.FuckCalamityRogue;
using Terraria.ModLoader;

namespace CalamitySoulPorted
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class CalamitySoulPorted : Mod
	{
		public static Mod Calamity => ModLoader.GetMod("CalamityMod");

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
		public override void Unload()
		{
			Instance = null;
			base.Unload();
		}
	}
}

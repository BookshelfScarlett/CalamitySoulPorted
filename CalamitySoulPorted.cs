using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalamitySoulPorted.ItemNew;
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
			base.Load();
		}
		public static void FuckRecipeHooks()
		{
			//草飞灾厄元素手套的合成表
			FuckEGauntletRecipe.Load();
			//草飞灾厄元素箭袋的合成表
			FuckEQuiverRecipe.Load();
			//草飞灾厄空灵护符的合成表
			FuckETailsmanRecipe.Load();
			//草飞灾厄核子之源的合成表
			FuckNuclerRecipe.Load();
			//草飞灾厄日蚀魔镜的合成表
			FuckEMirrorRecipe.Load();
		}
		public override void Unload()
		{
			Instance = null;
			base.Unload();
		}
	}
}

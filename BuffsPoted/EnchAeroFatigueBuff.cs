using CalamitySoulPorted.ItemsPorted.Enchs.PreHM;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.BuffsPoted
{
    public class EnchAeroFatigueBuff : ModBuff
    {
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Fatigue");
			// Description.SetDefault("You jumped too much and is tired now");
			// DisplayName.AddTranslation(GameCulture.Chinese, "疲乏");
			// Description.AddTranslation(GameCulture.Chinese, "你跳的太多了，现在很累");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = true;
		}
        public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
		{
			int index = -1;
			for (int i = 0; i < Main.LocalPlayer.buffTime.Length; i++)
			{
				if (Main.LocalPlayer.buffType[i] == Type && Main.LocalPlayer.buffTime[i] > 0)
				{
					index = i;
					break;
				}
			}
			if (index == -1) return;
			int time = Main.LocalPlayer.buffTime[index];
			float amt = time / 600f;
			if (amt > MaxDamageReduced) amt = MaxDamageReduced;
			amt = (int)(amt * 100f);
			amt = (int)(amt / 10f) * 10f;
			//冲多了的时候准备开始替换原本的文本
			tip = time < ExhaustedTime ? NotExhaustedTextRoute : ExhaustedTextRoute;
		}
		public override void Update(Player player, ref int buffIndex)
		{
			int curBuffTime = Main.LocalPlayer.buffTime[buffIndex];
			if (curBuffTime < ExhaustedTime)
				return;
			float reducedAmount = curBuffTime / 600f;
			if (reducedAmount > MaxDamageReduced)
				reducedAmount = MaxDamageReduced;
			reducedAmount = (int)(reducedAmount * 100f);
			reducedAmount = (int)(reducedAmount / 10f) / 10f;
			player.Soul().GetDamageMult *= 1f - reducedAmount;
		}
		public static string ExhaustedTextRoute => SoulMethod.EnchantMentTextHandler("AerospecEnchant", 1) + "Exhausted";
		public static string NotExhaustedTextRoute => SoulMethod.EnchantMentTextHandler("AerospecEnchant", 1) + "NotExhausted";
		private const float MaxDamageReduced = 1f;
		private const int ExhaustedTime = 180;
    }
}
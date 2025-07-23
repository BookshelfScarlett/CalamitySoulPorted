using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulMethods
{
    public static partial class SoulMethod
    {
        public static int ConvertToInt(this float arg) => (int)(arg * 100f);
        
        /// <typeparam name="T">指定的mod物品</typeparam>
        /// <returns>返回这个物品的名称</returns>
        public static LocalizedText GetModItemName<T>() where T : ModItem => GetTextModItemName(ModContent.ItemType<T>(), "DisplayName");
        //获取特定物品id
        public static LocalizedText GetTextModItemName(int itemID, string suffix) => ItemLoader.GetItem(itemID).GetLocalization(suffix);
        public static string LocalizedTextHandler(string text) => "Mods.CalamitySoulPorted" + "." + text;
        const int EnchPreHardMode = 1;
        const int EnchHardMode = 2;
        /// <summary>
        /// 返回魂石物品在本地化内的位置
        /// </summary>
        /// <param name="wantedEnch">需要的魂石</param>
        /// <param name="whatTierEnch">该魂石属于哪个阶段，1：肉前。2：肉后。其他：默认月后</param>
        /// <returns>返回这个本地化位置的字符串</returns>
        public static string EnchantMentTextHandler(string wantedEnch, int whatTierEnch)
        {
            return whatTierEnch switch
            {
                EnchPreHardMode => LocalizedTextHandler("Items.Enchs.PreHardMode" + "." + wantedEnch),
                EnchHardMode => LocalizedTextHandler("Items.Enchs.HardMode" + "." + wantedEnch),
                _ => LocalizedTextHandler("Items.Enchs.PostML" + "." + wantedEnch),
            };
        }

    }
}
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

    }
}
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted
{
    public partial class SoulShopValue : GlobalItem
    {
        private static readonly int Rarity1 = Item.buyPrice(0,5,0,0);
        private static readonly int Rarity2 = Item.buyPrice(0,25,0,0);
        private static readonly int Rarity3 = Item.buyPrice(0,50,0,0);
        private static readonly int Rartiy4 = Item.buyPrice(2,0,0,0);
        public static int EnchPreHardMode => Rarity1;
        public static int EnchHardMode => Rarity2;
        public static int EnchPostML => Rarity3;
        public static int Force => Rartiy4;

    }
}
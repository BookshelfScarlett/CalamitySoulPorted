using CalamitySoulPorted.RarityCustom;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PreHM
{
    public class DesertProwlerEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => PreHardMode;
        public override int GiveValue => base.GiveValue;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = SoulShopValue.EnchPreHardMode;
            Item.rare = ModContent.RarityType<EnchHardMode>();
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().DesertProwlerEnch = true;
        public override void AddRecipes()
        {
            base.AddRecipes();
        }
    }
}
using CalamitySoulPorted.SoulMethods;
using CalamitySoulPorted.RarityCustom;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PreHM
{
    public class StatigelEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => PreHardMode;
        public override int GiveValue => base.GiveValue;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<EnchPreHardMode>();
            Item.value = SoulShopValue.EnchPreHardMode;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().StatigelEnch = true;
        public override void AddRecipes()
        {
            base.AddRecipes();
        }
    }
}
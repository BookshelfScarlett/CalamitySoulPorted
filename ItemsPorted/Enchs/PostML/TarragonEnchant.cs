using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;
using CalamitySoulPorted.RarityCustom;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PostML
{
    public class TarragonEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => PostML;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = SoulShopValue.EnchPostML;
            Item.rare = ModContent.RarityType<EnchPostML>();
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().EnchTarragon = true;
        public override void AddRecipes()
        {
            base.AddRecipes();
        }
    }
}
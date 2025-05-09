using CalamityMod.Items;
using CalamitySoulPorted.ItemsPorted.Enchs.PreHM;
using CalamitySoulPorted.RarityCustom;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.Ancients
{
    public class AncientVictideEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => PreHardMode;
        public override int GiveValue => CalamityGlobalItem.RarityGreenBuyPrice;
        public override void SetStaticDefaults()
        {
            Type.ShimmerEach<VictideEnchant>();
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<EnchPreHardMode>();
            Item.value = SoulShopValue.EnchPreHardMode;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().VictideEnch = true;
    }
}
using CalamitySoulPorted.RarityCustom;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PreHM
{
    public class OldHunterEnchant : GenericEnchant ,ILocalizedModType
    {
        public override string Category => PreHardMode;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = SoulShopValue.EnchPreHardMode;
            Item.rare = ModContent.RarityType<EnchPreHardMode>();
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().OldHunterEnch = true;
    }
}
using CalamitySoulPorted.RarityCustom;
using CalamitySoulPorted.SoulMethods;
using Newtonsoft.Json.Serialization;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PostML
{
    public class DemonshadeEnchant : GenericEnchant ,ILocalizedModType
    {
        public override string Category => PostML;
        public override void SetDefaults()
        {
            Item.value = SoulShopValue.EnchPostML;
            Item.rare = ModContent.RarityType<EnchPostML>();
            base.SetDefaults();
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().EnchDemonshade = true;
    }
}
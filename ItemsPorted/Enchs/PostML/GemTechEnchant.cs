using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;
using CalamitySoulPorted.RarityCustom;
using CalamityMod.Items.Accessories;
using System.Linq;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PostML
{
    public class GemTechEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => PostML;
        public override void SetDefaults()
        {
            Item.value = SoulShopValue.EnchPostML;
            Item.rare = ModContent.RarityType<EnchPostML>();
            base.SetDefaults();
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().EnchGemTech = true;
    }
}
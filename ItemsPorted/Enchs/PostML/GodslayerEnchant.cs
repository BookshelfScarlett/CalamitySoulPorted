using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;
using CalamitySoulPorted.RarityCustom;
using CalamityMod;
using System.Text.RegularExpressions;
using CalamityMod.CalPlayer.Dashes;
using CalamitySoulPorted.PlayerSoul.SoulDashesManage;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PostML
{
    public class GodslayerEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => PostML;
        public override void SetDefaults()
        {
            Item.value = SoulShopValue.EnchPostML;
            Item.rare = ModContent.RarityType<EnchPostML>();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var usPlayer = player.Soul();
            var calPlayer = player.Calamity();
            usPlayer.EnchGodSlayer = true;
            if (usPlayer.GodSlayerEnchantDashKeyPressed || player.dashDelay != 0 && calPlayer.LastUsedDashID == GodslayerArmorDash.ID)
            {
                calPlayer.DeferredDashID = GodslayerArmorDash.ID;
                player.dash = 0;
            }
        }
    }
}
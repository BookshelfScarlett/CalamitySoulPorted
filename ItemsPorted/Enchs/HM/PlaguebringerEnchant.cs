using CalamityMod.Items.Armor.Plaguebringer;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Summon;
using CalamitySoulPorted.RarityCustom;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.HM
{
    public class PlaguebringerEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => HardMode;
        public override int GiveRare => ModContent.RarityType<EnchHardMode>();
        public override int GiveValue => SoulShopValue.EnchHardMode;
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().PlaguebringerEnch = true;
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<PlaguebringerVisor>().
                AddIngredient<PlaguebringerPistons>().
                AddIngredient<PlaguebringerCarapace>().
                AddIngredient<InfectedRemote>().
                AddIngredient<PlagueStaff>().
                AddIngredient<BlightSpewer>().
                DisableDecraft().
                AddTile(TileID.MythrilAnvil).
                Register();
        }
    }
}
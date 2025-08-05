using CalamityMod.Items.Materials;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalamitySoulPorted.RarityCustom;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PostML
{
    public class ExoEnchant : GenericEnchant, ILocalizedModType
    {
        public const int ShieldActiveDamage = 50;
        public override string Category => PostML;
        public override void SetDefaults()
        {
            Item.value = SoulShopValue.EnchPostML;
            Item.rare = ModContent.RarityType<EnchPostML>();
            base.SetDefaults();
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().EnchExo = true;
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<PhotonRipper>().
                AddIngredient<SpineOfThanatos>().
                AddIngredient<TheJailor>().
                AddIngredient<AtlasMunitionsBeacon>().
                AddIngredient<TheAtomSplitter>().
                AddIngredient<MiracleMatter>().
                AddTile<DraedonsForge>().
                Register();
        }
    }
}
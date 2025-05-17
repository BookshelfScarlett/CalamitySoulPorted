using CalamityMod.Items.Armor.Empyrean;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using CalamitySoulPorted.RarityCustom;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PostML
{
    public class EmpyreanEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => PostML;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = SoulShopValue.EnchPostML;
            Item.rare = ModContent.RarityType<EnchPostML>();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Soul().EmpyreanEnch = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<EmpyreanMask>().
                AddIngredient<EmpyreanCloak>().
                AddIngredient<EmpyreanCuisses>().
                AddIngredient<StarofDestruction>().
                AddIngredient<ShardofAntumbra>(100).
                AddIngredient<DeadSunsWind>().
                AddTile(TileID.LunarCraftingStation).
                Register();
        }
        
    }
}
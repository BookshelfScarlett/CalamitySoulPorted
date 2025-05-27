using System.Net.Sockets;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Vanity;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalamitySoulPorted.RarityCustom;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.Ancients
{
    //Todo: 远古弑神综合自活 + 旧弑神大冲
    public class AncientGodSlayerEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => PostML;
        public override int GiveValue => SoulShopValue.EnchPostML;
        public override int GiveRare => ModContent.RarityType<EnchPostML>();
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().EnchAncientGodSlayer = true;
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<AncientGodSlayerHelm>().
                AddIngredient<AncientGodSlayerChestplate>().
                AddIngredient<AncientGodSlayerLeggings>().
                AddIngredient<CosmicDischarge>().
                AddIngredient<Murasama>().
                AddIngredient<NebulousCore>().
                AddTile<CosmicAnvil>().
                Register();
        }
    }
}
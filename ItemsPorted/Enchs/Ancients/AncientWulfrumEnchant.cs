using CalamityMod.Items.Armor.Wulfrum;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Tools;
using CalamityMod.Items.Weapons.Summon;
using CalamitySoulPorted.ItemsPorted.Enchs.PreHM;
using CalamitySoulPorted.RarityCustom;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.Ancients
{
    public class AncientWulfrumEnchant : GenericEnchant, ILocalizedModType    
    {
        public override string Category => PreHardMode;
        public override int GiveValue => base.GiveValue;
        public override void SetStaticDefaults()
        {
            Type.ShimmerEach<WulfrumEnchant>();
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ModContent.RarityType<EnchPreHardMode>();
            Item.value = SoulShopValue.EnchPreHardMode;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().WulfrumEnch = true;
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<WulfrumHat>().
                AddIngredient<WulfrumJacket>().
                AddIngredient<WulfrumOveralls>().
                AddIngredient<WulfrumController>().
                AddIngredient<WulfrumDrill>().
                AddIngredient<WulfrumMetalScrap>(25).
                DisableDecraft().
                AddTile(TileID.DemonAltar).
                Register();
        }
    }
}
using CalamityMod.Items.Armor.Bloodflare;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Summon;
using CalamitySoulPorted.RarityCustom;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PostML
{
    public class BloodflareEnchant : GenericEnchant, ILocalizedModType
    {
        public const int OverSaturationTime = 60;
        public const int MinusHealAmount = 75;
        public const int MininumHealAmount = 1;
        public const float ExtraHealAmt = 2.0f;
        public const int AntiHealingAfterOverSaturationTime = 30;
        public const int SpawnHealingChance = 7;
        public override string Category => PostML;
        public override void SetDefaults()
        {
            Item.value = SoulShopValue.EnchPostML;
            Item.rare = ModContent.RarityType<EnchPostML>();
            base.SetDefaults();
        }
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ExtraHealAmt.FloatToInt(), MinusHealAmount ,MininumHealAmount);
        public override void UpdateAccessory(Player player, bool hideVisual) => player.Soul().EnchBloodflare = true;
        public override void AddRecipes()
        {
            CreateRecipe().
                AddRecipeGroup(SoulRecpieGroupID.BloodflareHead).
                AddIngredient<BloodflareBodyArmor>().
                AddIngredient<BloodflareCuisses>().
                AddIngredient<TheMutilator>().
                AddIngredient<BloodBoiler>().
                AddIngredient<SanguineFlare>().
                AddIngredient<DragonbloodDisgorger>().
                AddIngredient<BloodsoakedCrasher>().
                AddIngredient<BloodOrb>(100).
                AddTile(TileID.LunarCraftingStation).
                Register();
        }
    }
}
using System.Collections.Generic;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Tiles.Furniture.CraftingStations;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.Prestige
{
    public class SoulPrestigeRangedII : GenericPrestige
    {
        public static readonly int AttackSpeed = 15;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.width = Item.height = 82;
            Item.value = ValuePrestigeII;
            Item.rare = RarityPrestigeII;
            Item.defense = DefensePrestigeII;
            Item.accessory = true;
        }
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(QuickCrtis, AttackSpeed);
        public override void ExtraUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<RangedDamageClass>() += QuickDamage;
            player.GetCritChance<RangedDamageClass>() += QuickCrtis;
            player.GetAttackSpeed<RangedDamageClass>() += AttackSpeed * 0.01f;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<ElementalQuiver>().
                AddIngredient<QuiverofNihility>().
                AddIngredient<Phangasm>().
                AddIngredient<SDFMG>().
                AddIngredient<ThePack>().
                AddIngredient<ChickenCannon>().
                AddIngredient<CleansingBlaze>().
                AddIngredient<AuricBar>(5).
                AddTile<CosmicAnvil>().
                Register();
        }
    }
}
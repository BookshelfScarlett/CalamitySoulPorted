using System.Collections.Generic;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalamitySoulPorted.SoulMethods;
using Steamworks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.Prestige
{
    public class SoulPrestigeMeleeII : GenericPrestige, ILocalizedModType
    {
        public const int AttackSpeed = 30; 
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.width = 72;
            Item.height = 62;
            Item.value = ValuePrestigeII;
            Item.defense = DefensePrestigeII;
            Item.rare = RarityPrestigeII;
            Item.accessory = true;
        }
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(QuickCrtis, AttackSpeed);
        public override void ExtraUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<MeleeDamageClass>() += QuickDamage;
            player.GetCritChance<MeleeDamageClass>() += QuickCrtis;
            player.GetAttackSpeed<MeleeDamageClass>() += AttackSpeed * 0.01f;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<ElementalGauntlet>().
                AddIngredient<BadgeofBravery>().
                AddIngredient<DragonRage>().
                AddIngredient<CosmicShiv>().
                AddIngredient<Nadir>().
                AddIngredient<DragonPow>().
                AddIngredient<GalaxySmasher>().
                AddIngredient<TheOracle>().
                AddTile<CosmicAnvil>().
                Register();
        }
    }
}
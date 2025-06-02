using System.Collections.Generic;
using CalamityMod.Items.Weapons.Melee;
using CalamitySoulPorted.SoulMethods;
using Steamworks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.Prestige
{
    public class SoulPrestigeMelee : GenericPrestige, ILocalizedModType
    {
        public const int AttackSpeed = 30; 
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
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
            base.ModifyTooltips(tooltips);
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.WarriorEmblem).
                AddIngredient(ItemID.FireGauntlet).
                AddIngredient(ItemID.TerraBlade).
                AddIngredient<ElementalShiv>().
                AddRecipeGroup(SoulRecpieGroupID.ElementalLance).
                AddIngredient(ItemID.Flairon).
                AddIngredient<StellarContempt>().
                AddIngredient(ItemID.Terrarian).
                AddIngredient(ItemID.LunarBar, 15).
                AddTile(TileID.LunarCraftingStation).
                Register();
        }
    }
}
using CalamityMod.Items.Weapons.Melee;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.Prestige
{
    public class SoulPrestigeMelee : GenericPrestige, ILocalizedModType
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
        }
        public override void ExtraUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<MeleeDamageClass>() += QuickDamage;
            player.GetCritChance<MeleeDamageClass>() += QuickCrtis;
            player.GetAttackSpeed<MeleeDamageClass>() += 0.30f;
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
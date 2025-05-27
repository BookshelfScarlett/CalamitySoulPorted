using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.Prestige
{
    public class SoulPrestigeRogue : GenericPrestige
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
            player.GetDamage<RogueDamageClass>() += QuickDamage;
            player.GetCritChance<RogueDamageClass>() += QuickCrtis;
            player.Calamity().rogueStealthMax += 0.30f;
            player.Calamity().rogueVelocity += 0.15f;
            player.Calamity().stealthStrikeHalfCost = true;
            player.Calamity().wearingRogueArmor = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<RogueEmblem>().
                AddIngredient<DarkMatterSheath>().
                AddIngredient<RaidersTalisman>().
                AddIngredient<TotalityBreakers>().
                AddIngredient<ElementalDisk>().
                AddIngredient<StormfrontRazor>().
                AddIngredient<SpearofDestiny>().
                AddIngredient<CelestialReaper>().
                AddIngredient(ItemID.LunarBar, 15).
                AddTile(TileID.LunarCraftingStation).
                Register();
        }
    }
}
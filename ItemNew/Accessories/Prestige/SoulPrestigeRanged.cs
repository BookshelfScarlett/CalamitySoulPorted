using CalamityMod.Items.Weapons.Ranged;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.Prestige
{
    public class SoulPrestigeRanged : GenericPrestige
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
            player.GetDamage<RangedDamageClass>() += QuickDamage;
            player.GetCritChance<RangedDamageClass>() += QuickCrtis;
            player.GetAttackSpeed<RangedDamageClass>() += 0.15f;
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.RangerEmblem).
                AddIngredient(ItemID.ReconScope).
                AddIngredient(ItemID.Phantasm).
                AddIngredient<ConferenceCall>().
                AddIngredient<Scorpio>().
                AddIngredient<ElementalEruption>().
                AddIngredient(ItemID.StakeLauncher).
                AddIngredient(ItemID.LunarBar, 15).
                AddTile(TileID.LunarCraftingStation).
                Register();
        }
    }
}
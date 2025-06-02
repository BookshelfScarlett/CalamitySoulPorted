using System.Collections.Generic;
using CalamityMod.Items.Weapons.Ranged;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.Prestige
{
    public class SoulPrestigeRanged : GenericPrestige
    {
        public static readonly int AttackSpeed = 15;
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
            player.GetDamage<RangedDamageClass>() += QuickDamage;
            player.GetCritChance<RangedDamageClass>() += QuickCrtis;
            player.GetAttackSpeed<RangedDamageClass>() += AttackSpeed * 0.01f;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
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
using System.Collections.Generic;
using CalamityMod;
using CalamityMod.Items.Accessories;
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
            Item.width = Item.height = 42;
            Item.value = ValuePrestigeI;
            Item.rare = RarityPrestigeI;
            Item.defense = DefensePrestigeI;
            Item.accessory = true;
        }
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(PrestigeIDamage * 100, PrestigeICrits, AttackSpeed);
        public override void ExtraUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<RangedDamageClass>() += PrestigeIDamage;
            player.GetCritChance<RangedDamageClass>() += PrestigeICrits;
            player.GetAttackSpeed<RangedDamageClass>() += AttackSpeed * 0.01f;
            player.Calamity().deadshotBrooch = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<DeadshotBrooch>().
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
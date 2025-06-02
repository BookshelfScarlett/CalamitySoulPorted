using System.Collections.Generic;
using System.Data;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.Prestige
{
    public class SoulPrestigeRogue : GenericPrestige
    {
        public static readonly int MaxStealth = 30;
        public static readonly int Velocity = 15;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
        }
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxStealth, QuickCrtis, Velocity);
        public override void ExtraUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<RogueDamageClass>() += QuickDamage;
            player.GetCritChance<RogueDamageClass>() += QuickCrtis;
            player.Calamity().rogueStealthMax += MaxStealth * 0.01f;
            player.Calamity().rogueVelocity += Velocity * 0.01f;
            player.Calamity().stealthStrikeHalfCost = true;
            player.Calamity().wearingRogueArmor = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
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
using System.Collections.Generic;
using System.Data;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Tiles.Furniture.CraftingStations;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.Prestige
{
    public class SoulPrestigeRogueII : GenericPrestige
    {
        public static readonly int MaxStealth = 40;
        public static readonly int Velocity = 25;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.width = 94;
            Item.height = 58;
            Item.value = ValuePrestigeII;
            Item.rare = RarityPrestigeII;
            Item.defense = DefensePrestigeII;
            Item.accessory = true;
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
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<EclipseMirror>().
                AddIngredient<EclipsesFall>().
                AddIngredient<Wrathwing>().
                AddIngredient<GodsParanoia>().
                AddIngredient<ExecutionersBlade>().
                AddIngredient<AuricBar>(5).
                AddTile<CosmicAnvil>().
                Register();
        }
    }
}
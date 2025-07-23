using System.Collections.Generic;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.Prestige
{
    public class SoulPrestigeSummonII : GenericPrestige
    {
        public static readonly int MinionSlotII = 6;
        public static readonly int SentrySlotII = 5;
        public static readonly int WhipRangeII = 100;
        public static readonly int WhipSpeed = 75;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.width = 62;
            Item.height = 70;
            Item.value = ValuePrestigeII;
            Item.rare = RarityPrestigeII;
            Item.defense = DefensePrestigeII;
            Item.accessory = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
        }
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(QuickCrtis, MinionSlotII, SentrySlotII, QuickCrtis, WhipRangeII, WhipSpeed);
        public override void ExtraUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<SummonDamageClass>() += QuickDamage;
            player.Soul().GetSummonCrits += QuickCrtis;
            player.maxMinions += MinionSlotII;
            player.maxTurrets += SentrySlotII;
            player.whipRangeMultiplier += WhipRangeII * 0.01f;
            player.GetAttackSpeed<SummonMeleeSpeedDamageClass>() += WhipSpeed * 0.01f;
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<Nucleogenesis>().
                AddIngredient<DarkSunRing>().
                AddIngredient<MirrorofKalandra>().
                AddIngredient<MidnightSunBeacon>().
                AddIngredient<YharonsKindleStaff>().
                AddIngredient<CorvidHarbringerStaff>().
                AddIngredient<AuricBar>(5).
                AddTile<CosmicAnvil>().
                Register();
        }
    }
}
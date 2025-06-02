using System.Collections.Generic;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Ranged;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.Prestige
{
    public class SoulPrestigeSummon : GenericPrestige
    {
        public static readonly int MinionSlot = 3;
        public static readonly int SentrySlot = 2;
        public static readonly int WhipRange = 50;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
        }
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(QuickCrtis, MinionSlot, SentrySlot, QuickCrtis, WhipRange);
        public override void ExtraUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<SummonDamageClass>() += QuickDamage;
            player.Soul().GetSummonCrits += QuickCrtis;
            player.maxMinions += MinionSlot;
            player.maxTurrets += SentrySlot;
            player.whipRangeMultiplier += WhipRange * 0.01f;
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.SummonerEmblem).
                AddIngredient<StatisCurse>().
                AddIngredient(ItemID.EmpressBlade).
                AddIngredient(ItemID.StardustDragonStaff).
                AddIngredient(ItemID.MoonlordTurretStaff).
                AddIngredient(ItemID.RainbowCrystalStaff).
                AddIngredient(ItemID.LunarBar, 15).
                AddTile(TileID.LunarCraftingStation).
                Register();
        }
    }
}
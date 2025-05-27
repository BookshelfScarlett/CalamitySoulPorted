using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Ranged;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.Prestige
{
    public class SoulPrestigeSummon : GenericPrestige
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
            player.GetDamage<SummonDamageClass>() += QuickDamage;
            player.Soul().GetSummonCrits += QuickCrtis;
            player.maxMinions += 3;
            player.maxTurrets += 2;
            player.whipRangeMultiplier += 0.50f;
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
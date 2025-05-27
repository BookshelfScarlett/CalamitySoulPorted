using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Ranged;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.Prestige
{
    public class SoulPrestigeMagic : GenericPrestige
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
            player.GetDamage<MagicDamageClass>() += QuickDamage;
            player.GetCritChance<MagicDamageClass>() += QuickCrtis;
            player.statManaMax2 += 150;
            player.manaCost -= 0.20f;
            player.GetAttackSpeed<MagicDamageClass>() += 0.15f;
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.SorcererEmblem).
                AddIngredient(ItemID.CelestialEmblem).
                AddIngredient(ItemID.NebulaBlaze).
                AddIngredient<ElementalRay>().
                AddIngredient<TheSwarmer>().
                AddIngredient<AuguroftheElements>().
                AddIngredient<ChronomancersScythe>().
                AddIngredient(ItemID.LunarBar, 15).
                AddTile(TileID.LunarCraftingStation).
                Register();
        }
    }
}
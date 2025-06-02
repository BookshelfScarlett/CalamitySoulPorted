using System.Collections.Generic;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Ranged;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.Prestige
{
    public class SoulPrestigeMagic : GenericPrestige
    {
        public const int ManaCount = 150;
        public const int ManaCost = 20;
        public static readonly int AttackSpeed = 15;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
        }
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(QuickCrtis, ManaCost, ManaCount, AttackSpeed);
        public override void ExtraUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<MagicDamageClass>() += QuickDamage;
            player.GetCritChance<MagicDamageClass>() += QuickCrtis;
            player.statManaMax2 += ManaCount;
            player.manaCost -= ManaCost / 100f;
            player.GetAttackSpeed<MagicDamageClass>() += AttackSpeed / 100f;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
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
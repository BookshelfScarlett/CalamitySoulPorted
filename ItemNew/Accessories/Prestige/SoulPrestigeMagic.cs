using System.Collections.Generic;
using CalamityMod.Items.Accessories;
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
        public const int ManaCost = 15;
        public static readonly int AttackSpeed = 10;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 42;
            Item.rare = RarityPrestigeI;
            Item.defense = DefensePrestigeI;
            Item.value = ValuePrestigeI;
            Item.accessory = true;
        }
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(PrestigeIDamage * 100, PrestigeICrits, ManaCost, ManaCount, AttackSpeed);
        public override void ExtraUpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<MagicDamageClass>() += PrestigeIDamage;
            player.GetCritChance<MagicDamageClass>() += PrestigeICrits;
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
                AddIngredient<SigilofCalamitas>().
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
using System.Collections.Generic;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Tiles.Furniture.CraftingStations;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories.Prestige
{
    public class SoulPrestigeMagicII : GenericPrestige
    {
        public const int ManaCount = 300;
        public const int ManaCost = 30;
        public static readonly int AttackSpeed = 25;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.width = 72;
            Item.height = 68;
            Item.rare = RarityPrestigeII;
            Item.defense = DefensePrestigeII;
            Item.value = ValuePrestigeII;
            Item.accessory = true;
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
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<EtherealTalisman>().
                AddIngredient<ManaPolarizer>().
                AddIngredient<EventHorizon>().
                AddIngredient<NebulousCataclysm>().
                AddIngredient<PhoenixFlameBarrage>().
                AddIngredient<AetherfluxCannon>().
                AddTile<CosmicAnvil>().
                Register();
        }
    }
}
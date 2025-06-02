using System.Collections.Generic;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Accessories
{
    public abstract class GenericPrestige : ModItem
    {
        public override string LocalizationCategory => "Items.Prestige";
        public string GeneralTooltipHelper => "Mods.CalamitySoulPorted.Items.Prestige.GenericTooltip";
        public const float QuickDamage = 0.30f;
        public const int QuickCrtis = 30;
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.rare = ItemRarityID.Purple;
            Item.value = Item.buyPrice(platinum: 1);
            Item.accessory = true;
            Item.defense = 5;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Soul().GuarrantedPrestige = true;
            ExtraUpdateAccessory(player, hideVisual);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string key = Language.GetTextValue($"{GeneralTooltipHelper}");
            tooltips.Add(new TooltipLine(Mod, "Generic", key));
            ExtraToolTip(tooltips);
        }
        public virtual void ExtraToolTip(List<TooltipLine> tooltips)
        {

        }
        public virtual void ExtraUpdateAccessory(Player player, bool hideVisual)
        {

        }
    }
}
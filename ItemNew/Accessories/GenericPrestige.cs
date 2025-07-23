using System.Collections.Generic;
using CalamitySoulPorted.RarityCustom;
using CalamitySoulPorted.SoulMethods;
using Microsoft.Build.Tasks;
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
        public const float PrestigeIDamage = 0.20f;
        public const int PrestigeICrits = 15;
        public const float QuickDamage = 0.30f;
        public const int QuickCrtis = 30;
        public int RarityPrestigeI = ItemRarityID.Purple;
        public int RarityPrestigeII = ModContent.RarityType<Force>();
        public int ValuePrestigeI = Item.buyPrice(platinum: 1);
        public int ValuePrestigeII = Item.buyPrice(platinum: 10);
        public int DefensePrestigeI = 5;
        public int DefensePrestigeII = 30;
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            ItemID.Sets.ItemNoGravity[Type] = true;
        }
        public override void SetDefaults()
        {
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
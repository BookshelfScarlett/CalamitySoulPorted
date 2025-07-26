using System;
using System.Collections.Generic;
using System.Linq;
using CalamityMod.Items.Accessories;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew
{
    public class CalamityAccessoriesModify : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override void SetDefaults(Item entity)
        {
            int[] eAccs =
            [
                ModContent.ItemType<ElementalGauntlet>(),
                ModContent.ItemType<ElementalQuiver>(),
                ModContent.ItemType<EtherealTalisman>(),
                ModContent.ItemType<Nucleogenesis>(),
                ModContent.ItemType<EclipseMirror>()
            ];
            foreach (var elemAcc in eAccs)
            {
                if (entity.type == elemAcc)
                    entity.defense = 10;
            }
            if (entity.Same<CoinofDeceit>())
                entity.defense = 3;
            if (entity.Same<RuinMedallion>())
                entity.defense = 5;
            if (entity.Same<DarkMatterSheath>())
                entity.defense = 8;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string GeneralAccModify = SoulMethod.LocalizedTextHandler("CalamityTweaks.Accessories");
            string thisLocal = GeneralAccModify + ".";
            //这tm居然跑起来了！
            FuckCalamityAcc(item, tooltips);
            
        }

        internal static void FuckCalamityAcc(Item item, List<TooltipLine> tooltips)
        {
            string GeneralAccModify = SoulMethod.LocalizedTextHandler("CalamityTweaks.Accessories");
            string thisLocal = GeneralAccModify + ".";
            //这tm居然跑起来了！
            if (item.Same<EclipseMirror>())
                tooltips.FuckThisTooltipAndRewrote(thisLocal + "EclipseMirrorRework");

            if (item.Same<ElementalGauntlet>())
                tooltips.FuckThisTooltipAndRewrote(thisLocal + "ElementalGauntletRework");

            if (item.Same<ElementalQuiver>())
                tooltips.FuckThisTooltipAndRewrote(thisLocal + "ElementalQuiverRework");

            if (item.Same<EtherealTalisman>())
                tooltips.FuckThisTooltipAndRewrote(thisLocal + "EtherealTalismanRework");

            if (item.Same<Nucleogenesis>())
                tooltips.FuckThisTooltipAndRewrote(thisLocal + "NucleogenesisRework");

            if (item.Same<DarkMatterSheath>())
                tooltips.FuckThisTooltipAndRewrote(thisLocal + "DarkMatterSheathRework");

            if (item.Same<RuinMedallion>())
                tooltips.FuckThisTooltipAndRewrote(thisLocal + "RuinMedallionRework");

            if (item.Same<Nanotech>())
                tooltips.FuckThisTooltipAndRewrote(thisLocal + "NanotechRework");

            if (item.Same<SilencingSheath>())
                tooltips.FuckThisTooltipAndRewrote(thisLocal + "SilencedSheathRework");

            if (item.Same<CoinofDeceit>())
                tooltips.FuckThisTooltipAndRewrote(thisLocal + "CoinofDeceitRework");
                
            if (item.Same<MirageMirror>())
                tooltips.FuckThisTooltipAndRewrote(thisLocal + "MirageMirrorRework");

            if (item.Same<AbyssalMirror>())
                tooltips.FuckThisTooltipAndRewrote(thisLocal + "AbyssalMirrorRework");
        }

        public override void UpdateAccessory(Item item, Player p, bool hideVisual)
        {
            base.UpdateAccessory(item, p, hideVisual);
        }
    }
    public static class SimpleMethod
    {
        public static bool Same<T>(this Item item) where T : ModItem => Same(item, ModContent.ItemType<T>());
        public static bool Same(this Item item, int itemID) => item.type == itemID;
        public static bool ShouldRemoved<T>(this Recipe rec) where T : ModItem => ShouldRemoved(rec, ModContent.ItemType<T>());
        public static bool ShouldRemoved(this Recipe rec, int type) => rec.HasIngredient(type);
        public static void RemoveIngredient<T>(this Recipe rec) where T : ModItem => rec.RemoveIngredient(ModContent.ItemType<T>());
        public static void FuckThisTooltipAndRewrote(this List<TooltipLine> tooltips, string replacedTooltipAddress)
        {
            tooltips.RemoveAll((line) => line.Mod == "Terraria" && line.Name != "Tooltip0" && line.Name.StartsWith("Tooltip"));
            TooltipLine getTooltip = tooltips.FirstOrDefault((x) => x.Name == "Tooltip0" && x.Mod == "Terraria");
            if (getTooltip != null)
                getTooltip.Text = Language.GetTextValue(replacedTooltipAddress);
        }
    }
}
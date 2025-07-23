using System;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamitySoulPorted.ItemNew.Accessories.Prestige;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew
{
    public class CalamityAccessoriesModify : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override void UpdateAccessory(Item item, Player p, bool hideVisual)
        {
            const float elementalDamage = 0.10f;
            const float elementalCrit = 15;
            #region 元素系列饰品增强
            if (item.Same<ElementalGauntlet>())
            {
                p.GetDamage<MeleeDamageClass>() += elementalDamage;
                p.GetCritChance<MeleeDamageClass>() += elementalCrit;
                p.Soul().GuarrantedPrestige = true;
            }
            if (item.Same<ElementalQuiver>())
            {
                p.GetDamage<RangedDamageClass>() += elementalDamage;
                p.GetCritChance<RangedDamageClass>() += elementalCrit;
                p.Soul().GuarrantedPrestige = true;
            }
            if (item.Same<EtherealTalisman>())
            {
                p.GetDamage<MagicDamageClass>() += elementalDamage;
                p.GetCritChance<MagicDamageClass>() += elementalCrit;
                p.statManaMax2 += 50;
                p.manaCost -= 0.15f;
                p.Soul().GuarrantedPrestige = true;
            }
            if (item.Same<Nucleogenesis>())
            {
                p.GetDamage<SummonDamageClass>() += elementalDamage;
                p.maxTurrets += 4;
                p.maxMinions += 1;
                p.whipRangeMultiplier += 0.75f;
                p.Soul().GetSummonCrits += 20;
                p.Soul().GuarrantedPrestige = true;
            }
            if (item.Same<EclipseMirror>())
            {
                //byd你家职业饰品6%伤6%暴
                p.GetDamage<RogueDamageClass>() += 0.24f;
                p.GetCritChance<RogueDamageClass>() += 24;
                p.Calamity().rogueStealthMax += 0.20f;
                p.Calamity().rogueVelocity += 0.15f;
                p.Calamity().wearingRogueArmor = true;
                p.Soul().GuarrantedPrestige = true;
            }
            #endregion
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
    }
}
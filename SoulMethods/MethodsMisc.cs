using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using CalamityMod;
using CalamityMod.Projectiles.Ranged;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;

namespace CalamitySoulPorted.SoulMethods
{
    public static partial class SoulMethod
    {
        /// <summary>
        /// 将Boss掉落物存入列表内
        /// 从灾遗抄过来的，但好像不能这么个抄法
        /// </summary>
        /// <param name="type">NPC类型</param>
        /// <returns></returns>
        public static List<int> GetBossDrop(int type)
        {
            var list = new List<int>();

            List<IItemDropRule> checkNPCLootRules = Main.ItemDropsDB.GetRulesForNPCID(type, false);
            List<DropRateInfo> dropRateList = [];
            DropRateInfoChainFeed rates = new(1f);
            foreach (var rule in checkNPCLootRules)
            {
                if (rule is LeadingConditionRule lCR && lCR.condition == DropHelper.GFB)
                    continue;
                rule.ReportDroprates(dropRateList, rates);
            }
            list.AddRange(dropRateList.Where(i => NoMaterial(ContentSamples.ItemsByType[i.itemId])).Select(item2 => item2.itemId));

            List<int> getBagDrop = [];
            foreach (var bag in list)
            {
                var bagList = Main.ItemDropsDB.GetRulesForItemID(bag);
                if (bagList.Count > 0)
                {
                    List<DropRateInfo> list3 = [];
                    foreach (var rule in bagList)
                    {
                        if (rule is LeadingConditionRule lCR && lCR.condition == DropHelper.GFB)
                            rule.ReportDroprates(list3, rates);
                    }
                    getBagDrop.AddRange(list3.Where(i => NoMaterial(ContentSamples.ItemsByType[i.itemId])).Select(item3 => item3.itemId));
                }
            }
            list.AddRange(getBagDrop);
            return list;
        }
        /// <summary>
        /// 检查这个物品是否是一个材料
        /// </summary>
        /// <param name="item"></param>
        /// <param name="stopCheck"></param>
        /// <returns></returns>
        public static bool NoMaterial(Item item, bool stopCheck = false)
        {
            //影响全局
            if (item.ModItem == null)
                return false;
            if (stopCheck)
                return true;
            if (item.damage > 0 && item.ammo <= 0)
                return true;
            if (item.accessory || item.headSlot > 0 || item.bodySlot > 0 || item.legSlot > 0)
                return false;
            return false;
        }
    }
}
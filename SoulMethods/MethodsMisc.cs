using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using CalamityMod;
using CalamityMod.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulMethods
{
    public static partial class SoulMethod
    {
        public static float DistFromRectan(Vector2 pos, Rectangle rect)
        {
            return Math.Min(Math.Min(Vector2.Distance(pos, rect.TopLeft()), Vector2.Distance(pos, rect.TopRight())),
                            Math.Min(Vector2.Distance(pos, rect.BottomLeft()), Vector2.Distance(pos, rect.BottomRight())));
        }
        public static void GiveImmnueTime(this Player player, int amt)
        {
            if (player.immuneTime < amt)
            {
                player.immune = true;
                player.immuneTime = amt;
                for (int i = 0; i < player.hurtCooldowns.Length; i++)
                    player.hurtCooldowns[i] = amt;
            }
        }
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
        public static bool FindInventoryItem(ref Player p, int tar, int count = 1)
        {
            bool flag = false;
            for (int i = 0; i < p.inventory.Length; i++)
            {
                if (p.inventory[i].type == tar && p.inventory[i].stack >= count)
                    flag = true;
            }
            return flag;
        }
        /// <summary>
        /// 获取指定类型中指定名称的方法信息
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="methodName">方法名称</param>
        /// <returns>方法信息，如果找不到则返回null</returns>
        public static MethodInfo GetMethod<T>(this string methodName)
        {
            return typeof(T).GetMethod(methodName);
        }
        /// <summary>
        /// 重载方法
        /// </summary>
        public static MethodInfo GetMethod<T>(this string methodName, Type[] paramTypes)
        {
            return typeof(T).GetMethod(methodName, paramTypes);
        }
        /// <summary>
        /// 快速挂钩子，结合上方的获取钩子方法用
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="methodName">方法名称param>
        /// <param name="hookName">需要挂的钩钩子名/param>
        public static void QuickHook<T>(this string methodName, Delegate hookName)
        {
            MethodInfo getMethod = methodName.GetMethod<T>();
            MonoModHooks.Add(getMethod, hookName);
        }
        public static void QuickHook<T>(this string methodName, Delegate hookName, Type[] paramTypes)
        {
            MethodInfo getMethod = methodName.GetMethod<T>(paramTypes);
            MonoModHooks.Add(getMethod, hookName);
        }
        /// <summary>
        /// CD是否转好，懒了打了
        /// </summary>
        /// <param name="counter"></param>
        /// <returns></returns>
        public static bool IsDone(this int counter) => counter == 0;
        public static bool IsLoad(this Mod mod) => mod != null;
    }
}
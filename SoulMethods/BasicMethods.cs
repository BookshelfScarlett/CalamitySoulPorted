using System;
using System.Data;
using CalamityMod;
using CalamityMod.NPCs.ExoMechs.Ares;
using CalamityMod.NPCs.SlimeGod;
using CalamitySoulPorted.ItemsPorted;
using CalamitySoulPorted.PlayerSoul;
using CalamitySoulPorted.SoulProjectiles;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace CalamitySoulPorted.SoulMethods
{
    public static partial class SoulMethod
    {
        public static SoulPlayer Soul(this Player player) => player.GetModPlayer<SoulPlayer>();
        public static SoulGlobalItem Soul(this Item item) => item.GetGlobalItem<SoulGlobalItem>();
        public static SoulGlobalProjectiles Soul(this Projectile proj) => proj.GetGlobalProjectile<SoulGlobalProjectiles>();
        //用于查看NPC类型
        public static bool CheckSame<T>(this NPC wanted) where T : ModNPC => wanted.type == ModContent.NPCType<T>();
        //注册合成组名字
        public static void NameHelperGroup(this RecipeGroup group, string name) => RecipeGroup.RegisterGroup("Soul:" + "Any" + name, group);
        //获取合成组名字
        public static string GetNameGroup(this string name) => "Soul:" + "Any" + name;
        public static ModKeybind BindKeyBetter(this Mod mod, string name, Keys key) => KeybindLoader.RegisterKeybind(mod, name, key);
        public static bool CheckStealth(this Player player) => player.Calamity().StealthStrikeAvailable();
        /// <summary>
        /// 确认是否为Boss单位，去掉了火星飞碟
        /// </summary>
        /// <param name="npc">npc</param>
        /// <returns></returns>
        public static bool CheckBoss(this NPC npc)
        {
            //第一步，去掉火星飞碟
            if (npc.type == NPCID.MartianSaucerCore)
                return false;
            //第二部：判定为npc
            if (npc.boss)
                return true; 
            //第二步：特判星流阿瑞斯
            if (npc.CheckSame<AresGaussNuke>() || npc.CheckSame<AresLaserCannon>() || npc.CheckSame<AresPlasmaFlamethrower>() || npc.CheckSame<AresTeslaCannon>())
                return true;
            //第四步，包括圣卫
            if (npc.CheckSame<CrimulanPaladin>() || npc.CheckSame<EbonianPaladin>() || npc.CheckSame<SplitEbonianPaladin>() || npc.CheckSame<SplitCrimulanPaladin>())
                return true;

            //默认返回false
            return false;
        }
        //快速转微光
        public static void ShimmerEach<T>(this int result) where T : ModItem
        {
            ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<T>()] = result;
            ItemID.Sets.ShimmerTransformToItem[result] = ModContent.ItemType<T>();
        }
        /// <summary>
        /// 集成装箱/拆箱与类型选择的查阅伤害类型的方法
        /// </summary>
        /// <typeparam name="T">伤害类型</typeparam>
        /// <param name="item">任意具备伤害类型的实例</param>
        /// <returns>真：为你输入的伤害类型</returns>
        public static bool CountClassAs<T>(this object item) where T : DamageClass
        {
            //拆箱
            if (item is Item unbox)
                return unbox.CountsAsClass<T>();
            
            if (item is NPC.HitInfo hitBox)
                return hitBox.DamageType == ModContent.GetInstance<T>();

            if (item is Projectile projBox) 
                return projBox.CountsAsClass<T>();
            return false;
        }
        public static LocalizedText GetText(string value) => Language.GetOrRegister("Mods.CalamitySoulPorted.Cooldowns" + "." +  value);
        public static string CDPathValue(string wantedCooldowned) => "CalamitySoulPorted/SoulCooldowns" + "/" + wantedCooldowned;
        public static Mod CrossMod(string wantedMod)
        {
            if (ModLoader.TryGetMod(wantedMod, out Mod mod))
                return mod;
            else return null;
        }
        /// <summary>
        /// 用于检索被弱联动的模组物品
        /// </summary>
        public static ModItem QuickCrossModItem(this Mod mod, string wantedItemName)
        {
            if (mod.TryFind(wantedItemName, out ModItem itemID))
                return itemID;
            else return null;
        }
        /// <summary>
        /// 用于检索被弱联动的模组NPCID
        /// </summary>
        public static ModNPC QuickCrossModNPC(this Mod mod, string wantedNPCName)
        {
            if (mod.TryFind(wantedNPCName, out ModNPC npcID))
                return npcID;
            else return null;
        }
    }

}
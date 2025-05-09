using System;
using CalamityMod.NPCs.ExoMechs.Ares;
using CalamityMod.NPCs.SlimeGod;
using CalamitySoulPorted.ItemsPorted;
using CalamitySoulPorted.PlayerSoul;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace CalamitySoulPorted.SoulMethods
{
    public static class SoulMethod
    {
        public static SoulPlayer Soul(this Player player) => player.GetModPlayer<SoulPlayer>();
        public static SoulGlobalItem Soul(this Item item) => item.GetGlobalItem<SoulGlobalItem>();
        //用于查看NPC类型
        public static bool CheckSame<T>(this NPC wanted) where T : ModNPC => wanted.type == ModContent.NPCType<T>();
        //注册合成组名字
        public static void NameHelperGroup(this RecipeGroup group, string name) => RecipeGroup.RegisterGroup("Soul:" + "Any" + name, group);
        //获取合成组名字
        public static string GetNameGroup(this string name) => "Soul:" + "Any" + name;
        //查看是否为boss单位
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
        // public static bool MagicClass(this object item)
        // {
        //     //拆箱
        //     if (item is Item unbox)
        //         return unbox.CountsAsClass<MagicDamageClass>() || unbox.CountsAsClass<MagicSummonHybridDamageClass>();
            
        //     if (item is NPC.HitInfo hitBox)
        //         return hitBox.DamageType == DamageClass.Magic || hitBox.DamageType == DamageClass.MagicSummonHybrid;

        //     if (item is Projectile projBox) 
        //         return projBox.CountsAsClass<MagicDamageClass>() || projBox.CountsAsClass<MagicSummonHybridDamageClass>();
            
        //     return false;
        // }
    }

}
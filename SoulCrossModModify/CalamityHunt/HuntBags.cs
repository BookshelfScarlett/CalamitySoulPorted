using System;
using CalamityMod;
using CalamitySoulPorted.ItemNew;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulCrossModModify.CalamityHunt
{
    public partial class HuntModify: GlobalItem
    {
        public override bool InstancePerEntity => true;
        public static Mod Hunt => CalamitySoulPorted.Hunt;
        public static ModItem Trunk => Hunt.TryFindModItem("TreasureTrunk");
        public static ModItem Bucket => Hunt.TryFindModItem("TreasureBucket");
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (Hunt == null)
                return;
            
            if (Trunk != null)
                GuarrantedShogun(Trunk.Type, item, itemLoot);
            if (Bucket != null)
                GuarrantedShogun(Bucket.Type, item, itemLoot);
            base.ModifyItemLoot(item, itemLoot);
        }
        public static void GuarrantedShogun(int type ,Item item, ItemLoot looting)
        {
            if (item.Same(type))
            {
                //这里基本多此一举，不过说实话还是有点必要的
                bool foundHelm = Hunt.TryFind("ShogunHelm", out ModItem shouHelmetItem);
                bool foundChest = Hunt.TryFind("ShogunChestplate", out ModItem shouChestItem);
                bool foundPants = Hunt.TryFind("ShogunPants", out ModItem shouPantsItem);
                bool foundChaos = Hunt.TryFind("ChromaticMass", out ModItem massItem);
                //just in case.
                if (foundChaos)
                {
                    looting.Add(massItem.Type, 1, 50, 150);
                }
                if (foundHelm && foundChest && foundPants)
                {
                    //属于额外内容，确保玩家必定获得幕府将军套
                    looting.Add(shouHelmetItem.Type, 1);
                    looting.Add(shouChestItem.Type, 1);
                    looting.Add(shouPantsItem.Type, 1);
                }
            }
        }
    }
}
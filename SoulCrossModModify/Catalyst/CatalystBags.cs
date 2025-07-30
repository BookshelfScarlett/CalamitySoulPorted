using CalamityMod;
using CalamitySoulPorted.ItemNew;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulCrossModModify.Catalyst
{
    public class CatalystBags : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public static Mod Catalyst => CalamitySoulPorted.Catalyst;
        public static ModItem Bag => Catalyst.TryFindModItem("AstrageldonBag");
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (Catalyst is null)
                return;
            if (Bag != null && item.Same(Bag.Type))
            {
                bool jelly = Catalyst.TryFind("AstraJelly", out ModItem jellyItem);
                bool ores = Catalyst.TryFind("MetanovaOre", out ModItem oreItem);
                //确保玩家同时获得矿和这个果汁(200+)
                if (jelly && ores)
                {
                    itemLoot.Add(jellyItem.Type, 1, 1000, 1500);
                    itemLoot.Add(oreItem.Type, 1, 200, 250);
                }
            }

        }
    }
}
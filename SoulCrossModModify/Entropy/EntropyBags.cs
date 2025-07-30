using CalamityMod;
using CalamitySoulPorted.ItemNew;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulCrossModModify.Entropy
{
    public class EntropyBags: GlobalItem
    {
        public override bool InstancePerEntity => true;
        public static Mod Entropy => CalamitySoulPorted.Entropy;
        public static ModItem CruiserBag => Entropy.TryFindModItem("CruiserBag");
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (Entropy is null)
                return;
            if (CruiserBag != null && item.Same(CruiserBag.Type))
            {
                bool jelly = Entropy.TryFind("VoidScales", out ModItem jellyItem);
                //增加鳞片获取量
                if (jelly)
                {
                    itemLoot.Add(jellyItem.Type, 1, 45, 75);
                }
            }

        }
    }
}
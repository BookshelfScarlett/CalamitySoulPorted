using CalamityMod.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulCrossModModify.CalamityHunt
{
    public partial class HuntModify : GlobalItem
    {
        public override void SetStaticDefaults()
        {
            if (Hunt == null)
                return;
            if (Hunt.TryFind("ShogunHelm", out ModItem shogunHelmet) && Hunt.TryFind("ShogunChestplate", out ModItem shogunChest) && Hunt.TryFind("ShogunPants", out ModItem shogunPants))
            {
                ItemID.Sets.ShimmerTransformToItem[shogunHelmet.Type] = ModContent.ItemType<AuricBar>();
                ItemID.Sets.ShimmerTransformToItem[shogunChest.Type] = ModContent.ItemType<AuricBar>();
                ItemID.Sets.ShimmerTransformToItem[shogunPants.Type] = ModContent.ItemType<AuricBar>();
            }
        }
    }
}
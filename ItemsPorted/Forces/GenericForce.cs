using Terraria.ID;
using Terraria.ModLoader;
using CalamitySoulPorted.RarityCustom;

namespace CalamitySoulPorted.ItemsPorted.Forces
{
    public abstract class GenericForce : ModItem
    {
        public new string LocalizationCategory => "Items.Forces";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            ItemID.Sets.AnimatesAsSoul[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 52;
            Item.height = 52;
            Item.value = SoulShopValue.Force;
            Item.rare = ModContent.RarityType<Force>();
            Item.accessory = true;
        }
    }
}
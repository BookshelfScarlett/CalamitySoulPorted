using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Weapons
{
    public abstract class GenericRangedWeapon : ModItem
    {
        public new string LocalizationCategory => "Items.Weapons" + "." + "Ranged";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }
        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.RangedWeapon;
        }
    }
}
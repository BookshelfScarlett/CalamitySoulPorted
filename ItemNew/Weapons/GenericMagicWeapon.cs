using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Weapons
{
    public abstract class GenericMagicWeaponWeapon : ModItem
    {
        public new string LocalizationCategory => "Items.Weapons" + "." + "Magic";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }
        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.MagicWeapon;
        }
    }
}
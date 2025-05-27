using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Weapons
{
    public abstract class GenericMeleeWeapon : ModItem
    {
        public new string LocalizationCategory => "Items.Weapons" + "." + "Melee";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }
        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.MeleeWeapon;
        }
    }
}
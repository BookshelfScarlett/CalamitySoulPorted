using Terraria.ID;
using Terraria.ModLoader;
using CalamitySoulPorted.RarityCustom;

namespace CalamitySoulPorted.ItemsPorted.Enchs
{
    public abstract class GenericEnchant : ModItem
    {
        #region Category
        public static string PreHardMode => "PreHardMode"; 
        public static string HardMode => "HardMode";
        public static string PostML => "PostML";
        public virtual string Category{get;}
        #endregion
        #region Localization Suager
        public new string LocalizationCategory => "Items.Enchs" + "." + Category;
        
        #endregion
        public virtual int GiveValue => 100;
        public virtual int GiveRare => ItemRarityID.Green;
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            ItemID.Sets.AnimatesAsSoul[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 34;
            Item.value = GiveValue;
            Item.rare = GiveRare;
            Item.accessory = true;
        }
    }
}
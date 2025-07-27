using CalamityMod.Items.Materials;
using CalamityMod.Items.Placeables.Ores;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemNew.Weapons
{
    public class TesterSword : GenericMeleeWeapon, ILocalizedModType
    {
        public override void SetDefaults()
        {
            Item.width = Item.height = 80;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }
        public override bool? UseItem(Player player)
        {
            #region 自动合成
            /*
            int count = 5;
            int removedType = ModContent.ItemType<AuricOre>();
            bool removedDone = false;
            bool isCorretcd = SoulMethod.FindInventoryItem(ref player, removedType, count);
            if (isCorretcd)
            {
                for (int i = 0; i < count; i++)
                {
                    player.ConsumeItem(removedType, false, true);
                }
                removedDone = true;
            }
            if (removedDone)
            {
                player.QuickSpawnItem(player.GetSource_FromThis(), ModContent.ItemType<AuricBar>(), 1);
                Main.NewText("合成一个金源锭");
            }
            */
            #endregion
            #region 自裁
            player.Hurt(PlayerDeathReason.ByCustomReason($"{player.name}!不要自杀!"), Main.rand.Next(140, 400), 0);
            #endregion
            return base.UseItem(player);
        }
    }
}
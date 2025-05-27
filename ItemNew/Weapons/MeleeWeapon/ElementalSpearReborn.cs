using CalamityMod.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamitySoulPorted.SoulMethods;
using CalamityMod.Items.Weapons.Melee;
using CalamitySoulPorted.SoulProjectiles.Melee.Spear.ElementalSpearRebornProjectiles;

namespace CalamitySoulPorted.ItemNew.Weapons.MeleeWeapon
{
    public class ElementalSpearReborn : GenericMeleeWeapon, ILocalizedModType
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Type.ShimmerEach<ElementalLance>();
        }
        public override void SetDefaults()
        {
            Item.width = 88;
            Item.height = 88;
            Item.damage = 240;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            Item.useTurn = true;
            Item.noUseGraphic = true;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 15;
            Item.knockBack = 9.5f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.value = CalamityGlobalItem.RarityPurpleBuyPrice;
            Item.rare = ItemRarityID.Purple;
            Item.shoot = ModContent.ProjectileType<ElementalSpearRebornProj>();
            Item.shootSpeed = 12f;
        }
        public override bool CanUseItem(Player player) => player.ownedProjectileCounts[Item.shoot] <= 0;
    }
}
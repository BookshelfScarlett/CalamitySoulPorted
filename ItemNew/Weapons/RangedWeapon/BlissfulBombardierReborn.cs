using CalamityMod.Items;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Rarities;
using CalamitySoulPorted.ItemNew.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalamitySoulPorted.SoulMethods;
using CalamitySoulPorted.SoulSounds;
using CalamitySoulPorted.SoulProjectiles.Ranged.BlissfulBombardierRebornProjectiles;
namespace CalamitySoulPorted.ItemNew.Weapons.RangedWeapon
{
    public class BlissfulBombardierReborn : GenericRangedWeapon, ILocalizedModType
    {
        
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            Type.ShimmerEach<BlissfulBombardier>();
        }
        public override void SetDefaults()
        {
            //属性赋值的原灾的
            Item.width = 66;
            Item.height = 28;
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 270;
            Item.noMelee = true;
            Item.knockBack = 7.5f;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.rare = ModContent.RarityType<PureGreen>();
            Item.value = CalamityGlobalItem.RarityPureGreenBuyPrice;
            Item.autoReuse = true;
            Item.UseSound = SoulSoundID.SoundGrenadeLanucher;
            Item.shootSpeed = 45f;
            Item.shoot = ModContent.ProjectileType<BlissfulBombardierRebornNuke>();
            Item.useAmmo = AmmoID.Rocket;
        }

        public override Vector2? HoldoutOffset() => new Vector2(-10, 0);
        public int WhatRocket;
        public override void OnConsumeAmmo(Item ammo, Player player) => WhatRocket = ammo.type;
    }
}
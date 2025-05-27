using CalamityMod.Items.Accessories.Wings;
using CalamityMod.Items.Armor.Silva;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalamitySoulPorted.RarityCustom;
using CalamitySoulPorted.SoulMethods;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.ItemsPorted.Enchs.PostML
{
    [AutoloadEquip(EquipType.Wings)]
    public class SilvaEnchant : GenericEnchant, ILocalizedModType
    {
        public override string Category => PostML;
        public override void SetStaticDefaults()
        {
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(270, 10.5f, 2.8f);
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = SoulShopValue.EnchPostML;
            Item.rare = ModContent.RarityType<EnchPostML>();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //启用魂石效果
            player.Soul().EnchSilva = true;
            player.noFallDmg = true;
            //Wing's Effect
            if (player.controlJump && player.wingTime > 0f && player.jump == 0 && player.velocity.Y != 0f && !hideVisual)
            {
                int dustX = 4;
                if (player.direction == 1)
                    dustX = -40;
                int flyingDust = Dust.NewDust(new Vector2(player.Center.X + dustX, player.Center.Y - 15f), 30, 30, DustID.ChlorophyteWeapon, 0f, 0f, 100, new Color(Main.DiscoR, 203, 103), 1f);
                Main.dust[flyingDust].noGravity = true;
                Main.dust[flyingDust].velocity *= 0.3f;
                if (Main.rand.NextBool(10)) 
                    Main.dust[flyingDust].fadeIn = 2f;
                Main.dust[flyingDust].shader = GameShaders.Armor.GetSecondaryShader(player.cWings, player);
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddRecipeGroup(SoulRecpieGroupID.SilvaHead).
                AddIngredient<SilvaArmor>().
                AddIngredient<SilvaLeggings>().
                AddIngredient<SilvaWings>().
                AddIngredient<MadAlchemistsCocktailGlove>().
                AddIngredient<LightGodsBrilliance>().
                DisableDecraft().
                AddTile<CosmicAnvil>().
                Register();
        }
        #region Wing's Stat
        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.95f;
            ascentWhenRising = 0.16f;
            maxCanAscendMultiplier = 1.1f;
            maxAscentMultiplier = 3.2f;
            constantAscend = 0.145f;
        }
        #endregion
    }
}
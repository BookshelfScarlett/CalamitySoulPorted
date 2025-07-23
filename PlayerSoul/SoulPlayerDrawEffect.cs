// using System;
// using CalamitySoulPorted.SoulMethods;
// using Microsoft.Xna.Framework;
// using Microsoft.Xna.Framework.Graphics;
// using Terraria;
// using Terraria.DataStructures;
// using Terraria.GameContent;
// using Terraria.ModLoader;

// namespace CalamitySoulPorted.PlayerSoul
// {
//     public partial class SoulPlayer : ModPlayer
//     {
//         public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
//         {
//             Player drawPlayer = drawInfo.drawPlayer;
//             base.DrawEffects(drawInfo, ref r, ref g, ref b, ref a, ref fullBright);
//         }
//     }
//     public class SetLayerEffect : PlayerDrawLayer
//     {
//         public override Position GetDefaultPosition()
//         {
//             throw new System.NotImplementedException();
//         }
//         protected override void Draw(ref PlayerDrawSet drawInfo)
//         {
//             // EnchAeroJumpingDraw(ref drawInfo);
//             throw new System.NotImplementedException();
//         }

//         // private void EnchAeroJumpingDraw(ref PlayerDrawSet drawInfo)
//         // {
//         //     Player player = drawInfo.drawPlayer;
//         //     var mPlayer = player.Soul();
//         //     Vector2 drawPostion = drawInfo.Position + player.Hitbox.Size() / 2f;
//         //     if (mPlayer.EnchAeroJumpingEffect > 0)
//         //     {
//         //         Texture2D texture =  TextureAssets.
//         //     }
//         //     throw new NotImplementedException();
//         // }
//     }
// }
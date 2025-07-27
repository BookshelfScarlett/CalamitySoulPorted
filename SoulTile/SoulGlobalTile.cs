using CalamityMod.Projectiles.Rogue;
using CalamitySoulPorted.ItemsPorted.Enchs.PreHM;
using CalamitySoulPorted.SoulCustomSounds;
using CalamitySoulPorted.SoulMethods;
using CalamitySoulPorted.SoulTile.AutoSmeltList;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.RGB;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulTile
{
    public class SoulGlobalTile : GlobalTile
    {
        public int LastTile = -1;
        public int CurChance = 0;
        //熔炼去把孩子
        public void SmeltOres(int i, int j, int chance, int type)
        {
            Vector2 tileSoundPos = new(i * 16, j * 16);
            Rectangle tileRec = new(i * 16, j * 16, 16, 16);
            //玩家上一个挖掘的矿石不是同类矿，刷新熔炼矿石的可能性
            if (type != LastTile)
                CurChance = 0;
            for (int k = 0; k < SmeltList.OreType.Count; k++)
            {
                //不是我想要的，直接跳过
                if (type == SmeltList.OreType[k])
                {
                    if (Main.rand.Next(chance) - CurChance <= 0)
                    {
                        SoundEngine.PlaySound(SoulSoundID.SoundBell with { Volume = 0.7f }, tileSoundPos);
                        Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), tileRec, SmeltList.BarType[k]);
                        //触发熔炼效果则刷新概率次数
                        CurChance = 0;
                    }
                    //如果没触发熔炼效果，增加一次保底次数
                    else
                    {
                        CurChance++;
                    }
                    break;
                }
            }
        }
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            bool dummy = true;
            if (Main.gameMenu || fail || !CanKillTile(i, j, type, ref dummy))
                return;
            //netCode这一块。
            if (Main.netMode == NetmodeID.Server)
            {
                for (int t = 0; t < SmeltList.OreType.Count; t++)
                {
                    if (type == SmeltList.OreType[t])
                    {
                        noItem = true;
                        LastTile = type;
                    }
                }
                return;
            }
            //抄的，我其实看不懂物块更新
            Player usPlayer = Main.player[Main.myPlayer];
            var soulPlayer = usPlayer.Soul();
            if (Main.netMode != NetmodeID.Server && Main.LocalPlayer == usPlayer && !usPlayer.CCed && !usPlayer.noBuilding && !usPlayer.HasBuff(BuffID.DrillMount) && !usPlayer.noItems)
            {
                if (soulPlayer.EnchMarniteArchAutoSmelt)
                {
                    for (int k = 0; k < SmeltList.OreType.Count; k++)
                    {
                        if (type == SmeltList.OreType[k])
                        {
                            noItem = true;
                            PacketOres(i, j, MarniteArchitectEnchant.ChanceToSmeltEnch, type);
                            LastTile = type;
                            break;
                        }
                    }
                }
            }
        }
        public void PacketOres(int i, int j, int chance,int type)
        {
            //处于多人服务器的情况下得手动发送数据包了
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                ModPacket pack = ModContent.GetInstance<CalamitySoulPorted>().GetPacket();
                pack.Write((ushort)i);
                pack.Write((ushort)j);
                pack.Write((ushort)chance);
                pack.Write((ushort)type);
                pack.Send();
            }
            //其他情况就，随便吧
            else if (Main.netMode == NetmodeID.SinglePlayer)
            {
                SmeltOres(i, j, chance, type);
            }
        }
    }
}
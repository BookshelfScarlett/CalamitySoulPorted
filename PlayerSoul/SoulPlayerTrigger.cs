using System;
using CalamitySoulPorted.BuffsPoted;
using CalamitySoulPorted.ItemsPorted.Enchs.PostML;
using CalamitySoulPorted.SoulBuildUp;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySoulPorted.PlayerSoul
{
    public partial class SoulPlayer: ModPlayer
    {
        public bool GodSlayerEnchantDashKeyPressed = false;

        public void ResetTrigger()
        {
            GodSlayerEnchantDashKeyPressed = false;
        }
        public void UpdateDeadTrigger()
        {
            GodSlayerEnchantDashKeyPressed = false;
        }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            //弑神魔石大冲。
            GodSlayerEnchantDashTrigger(triggersSet);
            AerospecEnchantJump(triggersSet);
            if (EnchBloodflareOverSatu)
            {
                if (PlayerInput.Triggers.JustPressed.QuickHeal && !Player.IsFullHP())
                {
                    bool isGrantedBuff = Player.HasBuff<EnchBloodflareOverSatuBuff>();
                    if (!isGrantedBuff)
                    {
                        Player.AddBuff<EnchBloodflareOverSatuBuff>(BloodflareEnchant.OverSaturationTime.IntToFrames());
                        Player.HandlePotionSick();
                    }
                    else
                        EnchBloodflareReducedHealing += 1;
                }
            }
        }

        private void AerospecEnchantJump(TriggersSet triggersSet)
        {
            if (!EnchAerospec)
                return;
            if (SoulKeybind.EnchAeroDashKey.JustPressed && EnchAeroJumpingEffect <= 0)
            {
                int fatigue = ModContent.BuffType<EnchAeroFatigueBuff>();
                int fatigueIndex = Player.FindBuffIndex(fatigue);

                if (fatigueIndex == -1)
                {
                    Player.AddBuff(fatigue, 180);
                    SoulDebug.DebugText("提供天蓝累死人Buff");
                }
                else if (Player.buffTime[fatigueIndex] < 1200)
                {
                    Player.buffTime[fatigueIndex] += 180;
                    SoulDebug.DebugText("延长天蓝累死人Buff");
                }
                Player.dashDelay = EnchAeroJumpingEffect = 10;
                EnchAeroJumpingDir = Player.AngleTo(Main.MouseWorld);
                SoulDebug.DebugText("天蓝冲刺成功");
                SoundEngine.PlaySound(SoundID.Item29, Player.Center);
            }
        }

        private void GodSlayerEnchantDashTrigger(TriggersSet triggersSet)
        {
            if (!EnchGodSlayer)
                return;

            if (SoulKeybind.GodSlayerEnchantDash.JustPressed)
            {
                if (AllowTriggerDash())
                    GodSlayerEnchantDashKeyPressed = true; 
            }
        }
        //确认是否具备冲刺条件
        public bool AllowTriggerDash() => !Player.pulley && Player.dashTime != 0;
    }
}
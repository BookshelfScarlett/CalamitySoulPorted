using CalamitySoulPorted.SoulBuildUp;
using Terraria.GameInput;
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
            
            base.ProcessTriggers(triggersSet);
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
using Terraria.ModLoader;

namespace CalamitySoulPorted.PlayerSoul
{
    public partial class SoulPlayer : ModPlayer
    {
        public const int EnchSilvaRebornDuration = 900;
        public const int EnchSilvaForceHealDuration = 60;
        public int EnchSilvaRebornCounter = EnchSilvaRebornDuration;
        //林海强起
        public int EnchSilvaForceHealCounter = 0;
        public int EnchSilvaForceHealCD = 0;
        public void EnchCounters()
        {
            //林海强起 
            if (EnchSilvaForceHealCD > 0)
                EnchSilvaForceHealCD--;
        }
    }
}
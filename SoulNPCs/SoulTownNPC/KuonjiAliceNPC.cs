/*using CalamitySoulPorted.SoulMethods;
using Mono.Cecil.Cil;
using Terraria;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace CalamitySoulPorted.SoulNPCs.SoulTownNPC
{
    [AutoloadHead]
    public class KuonjiAliceNPC : ModNPC
    {
        internal int chatting = 4;
        public Player player = Main.player[Main.myPlayer];
        public static string VoicelineDia => SoulMethod.LocalizedTextHandler("TownNPC.Voiceline");
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 5;
            NPCID.Sets.DangerDetectRange[NPC.type] = 3000;
            NPCID.Sets.AttackType[NPC.type] = 2;
            NPCID.Sets.AttackTime[NPC.type] = 10;
            NPCID.Sets.AttackAverageChance[NPC.type] = 1;
            NPCID.Sets.ShimmerTownTransform[Type] = false;
            NPC.Happiness.
                SetBiomeAffection<ForestBiome>(AffectionLevel.Love).
                SetBiomeAffection<SnowBiome>(AffectionLevel.Hate).
                SetNPCAffection(NPCID.Princess, AffectionLevel.Like).
                SetNPCAffection(NPCID.Truffle, AffectionLevel.Like).
                SetNPCAffection(NPCID.ArmsDealer, AffectionLevel.Hate);
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.defense =
            NPC.lifeMax = 324590;
            NPC.aiStyle = 7;
            AnimationType = NPCID.Dryad;
        }
        public override void AI()
        {
            var soulPlayer = player.Soul();
            int 
        }
        public override string GetChat()
        {
            var soulPlayer = player.Soul();
            WeightedRandom<string> list = new WeightedRandom<string>();
            if (NPC.homeless)
            {
                
            }
        }

    }
}
*/
using CalamityMod;
using CalamitySoulPorted.SoulMethods;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulCrossModModify.Inheritance
{
    public class SCalEyeDrop : GlobalNPC
    {
        public static Mod Inheritance => CalamitySoulPorted.Inhertiance;
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (!Inheritance.IsLoad())
                return;
            bool foundEye = Inheritance.TryFind("SupremeCalamitasLegacy", out ModNPC scalEye);
            bool foundEssence = Inheritance.TryFind("CalamitousEssence", out ModItem essence);
            if (foundEye && foundEssence && npc.type == scalEye.Type)
            {
                //这个将会使灾厄精华掉量暴涨至150+
                //这里是故意的，因为后面会大幅度上调遗产的灾眼难度
                npcLoot.Add(essence.Type, 1, 50, 150);
            }

        }
    }
}
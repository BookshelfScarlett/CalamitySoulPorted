using Microsoft.CodeAnalysis.CSharp.Syntax;
using Terraria.ModLoader;

namespace CalamitySoulPorted.SoulMethods
{
    public partial class SoulMethod
    {
        public static T TryFindBetter<T>(this Mod mod, string name) where T : IModType
        {
            if (mod.TryFind<T>(name, out T type))
                return type;
            return default;
        }
        public static ModItem TryFindModItem(this Mod mod, string name) => TryFindBetter<ModItem>(mod, name);
    }
}
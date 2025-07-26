using Terraria.Audio;

namespace CalamitySoulPorted.SoulCustomSounds
{
    public class SoulCustomSound
    {
        public static string SoundPath => "CalamitySoulPorted/SoulCustomSounds";
        public static readonly SoundStyle SoundSlasher = new($"{SoundPath}/HitSound/Slasher") {Volume = 0.85f, Pitch = 0.6f};
    }
}
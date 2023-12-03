// using 
using Microsoft.Xna.Framework.Audio;
using MonoSound;
using MonoSound.Streaming;

namespace Engine;

public class Audio {
    public static SoundEffectInstance CreateSound(string s) {
        SoundEffect sfx = EffectLoader.GetEffect(s);
        return sfx.CreateInstance();
    }

    public static SoundEffectInstance PlaySound(string s, float volume = 1, float pan = 0, bool looped=false) {
        SoundEffectInstance sfxInstance = CreateSound(s);
        sfxInstance.Volume = volume;
        sfxInstance.Pan = pan;
        sfxInstance.IsLooped = looped;
        sfxInstance.Play();
        return sfxInstance;
    }

    public static void DisposeSound(SoundEffectInstance sfxInstance) {
        sfxInstance.Stop();
        sfxInstance.Dispose();
    }

    public StreamPackage CreateStream(string s, bool looping) {
        return StreamLoader.GetStreamedSound(s, looping);
    }

    public StreamPackage PlayStream(string s, bool looping) {
        StreamPackage sp = CreateStream(s, looping);
        sp.Play();
        return sp;
    }
}
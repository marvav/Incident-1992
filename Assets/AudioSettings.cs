using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Core Core;
    public Slider PlayerSounds;
    public Slider Music;
    public Slider VoiceOver;
    public Slider Ambient;
    public float PlayerVolume;
    public float MusicVolume;
    public float VoiceVolume;
    public float AmbientVolume;

    void Start()
    {
        Core.ChangeVolume("PlayerSounds", PlayerVolume);
        Core.ChangeVolume("Music", MusicVolume);
        Core.ChangeVolume("Voice", VoiceVolume);
        Core.ChangeVolume("Ambient", AmbientVolume);
        PlayerSounds.value = PlayerVolume;
        Music.value = MusicVolume;
        VoiceOver.value = VoiceVolume;
        Ambient.value = AmbientVolume;
    }

    void Update()
    {
        if(PlayerSounds.value != PlayerVolume)
        {
            Core.ChangeVolume("PlayerSounds", PlayerSounds.value);
            PlayerVolume = PlayerSounds.value;
        }

        if (VoiceOver.value != VoiceVolume)
        {
            Core.ChangeVolume("Voice", VoiceOver.value);
            VoiceVolume = VoiceOver.value;
        }

        if (MusicVolume != Music.value)
        {
            Core.ChangeVolume("Music", Music.value);
            MusicVolume = Music.value;
        }

        if (AmbientVolume != Ambient.value)
        {
            Core.ChangeVolume("Ambient", Ambient.value);
            AmbientVolume = Ambient.value;
        }
    }

    public void forceSettings()
    {
        Core.ChangeVolume("PlayerSounds", PlayerSounds.value);
        Core.ChangeVolume("Voice", VoiceOver.value);
        Core.ChangeVolume("Music", Music.value);
        Core.ChangeVolume("Ambient", Ambient.value);
        PlayerVolume = PlayerSounds.value;
        VoiceVolume = VoiceOver.value;
        MusicVolume = Music.value;
        AmbientVolume = Ambient.value;
    }
}

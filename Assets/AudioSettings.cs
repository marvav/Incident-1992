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
    public float PlayerVolume;
    public float MusicVolume;
    public float VoiceVolume;

    void Start()
    {
        Core.ChangeVolume("PlayerSounds", PlayerVolume);
        Core.ChangeVolume("Music", MusicVolume);
        Core.ChangeVolume("Voice", VoiceVolume);
        PlayerSounds.value = PlayerVolume;
        Music.value = MusicVolume;
        VoiceOver.value = VoiceVolume;
    }

    // Update is called once per frame
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
    }
}

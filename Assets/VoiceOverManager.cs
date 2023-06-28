using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VoiceOverManager
{
    private static bool[] voiceOvers;

    public static bool WasPlayed(int index)
    {
        return voiceOvers[index];
    }

    public static void SetPlayed(int index)
    {
        voiceOvers[index] = true;
    }

    public static void InitializeVoiceOverManager()
    {
        voiceOvers = new bool[128];
        for (int i = 0; i < 128; i++)
        {
            voiceOvers[i] = false;
        }
    }
}

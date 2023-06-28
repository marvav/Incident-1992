using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;
using static VoiceOverManager;

public class VoiceOver : MonoBehaviour
{
    public Core Core;
    public GameObject replacementDescription;
    public int clipID;
    public int progressNumber = 0;
    public AudioClip[] clips;
    public string[] subtitlesEN;
    public float[] timestampsEN;
    public string[] subtitlesCZ;
    public float[] timestampsCZ;
    private bool isPlaying = false;

    // Update is called once per frame
    void Update()
    {
        if (WasPlayed(clipID))
        {
            this.gameObject.GetComponent<VoiceOver>().enabled = false;
            if (replacementDescription!=null)
                replacementDescription.SetActive(true);
        }

        if (!Core.VoiceOver.isRunning)
        {
            if (isPlaying)
                SetPlayed(clipID);

            if (!isPlaying && CanInteract(this.gameObject, 4.0f, 40.0f))
            {
                switch (Core.GetLanguage())
                {
                    case 0:
                        {
                            Core.VoiceOver.InitiateVoiceOver(clips[0], subtitlesEN, timestampsEN, progressNumber);
                            break;
                        }
                    case 1:
                        {
                            Core.VoiceOver.InitiateVoiceOver(clips[1], subtitlesCZ, timestampsCZ, progressNumber);
                            break;
                        }
                }
                isPlaying = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;
using static VoiceOverManager;

public class VoiceOver : MonoBehaviour
{
    public Core Core;
    public AudioClip[] clips;
    public int clipID;
    private bool isPlaying = false;

    // Update is called once per frame
    void Update()
    {
        //if (WasPlayed(clipID))
          //  this.gameObject.GetComponent<VoiceOver>().enabled = false;

        if (!Core.VoiceOver.isPlaying)
        {
            if (isPlaying)
            {
                SetPlayed(clipID);
            }

            if (!isPlaying && CanInteract(this.gameObject, 4.0f, 40.0f))
            {
                Core.VoiceOver.clip = clips[Core.GetLanguage()];
                Core.VoiceOver.Play();
                isPlaying = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using static Core_Utils;
using static Inventory;

public class WalkieTalkie : MonoBehaviour
{
    public Core Core;
    public GameObject enemyCamp;
    public GameObject ThreeBoulders;
    public float availableTime;
    public int eventChance;
    public AudioSource buzzingSource;
    public AudioClip[] Buzz;
    public AudioClip[] VoiceOver;
    public int minimalTimeBeforeRecordingStarts = 30;
    private int index = 0;
    private float timer = 0;
    private bool wasPlayed = false;
    private bool recordingIsHappening = false;
    private List<GameObject> recordings;

    void Start()
    {
        recordings = CountChildren(this.gameObject);
    }

    void Update()
    {
        if (!wasPlayed)
        {
            if (index == 0 && isCloseToPlayer(enemyCamp.transform, 125.0f))
                return;

            if (index == 1 && isCloseToPlayer(ThreeBoulders.transform, 125.0f))
                return;

            if (!recordingIsHappening && rand.Next(0, eventChance) == 1)
            {
                if (Inventory.InHand != null && Inventory.InHand.name == "WalkieTalkie")
                {
                    recordings[index].SetActive(true);
                    wasPlayed = true;
                    recordingIsHappening = false;
                }
                else
                {
                    buzzingSource.clip = Buzz[rand.Next(0, Buzz.Length)];
                    buzzingSource.Play();
                    recordingIsHappening = true;
                }
            }
            if (recordingIsHappening)
            {
                if (Inventory.InHand != null && Inventory.InHand.name == "WalkieTalkie")
                {
                    recordings[index].SetActive(true);
                    wasPlayed = true;
                    recordingIsHappening = false;
                }
                else
                    timer += Time.deltaTime;
            }

            if (timer > availableTime)
            {
                recordingIsHappening = false;
                timer = 0;
            }
        }
    }

    public void NextRecording()
    {
        Invoke(nameof(delayRecording), minimalTimeBeforeRecordingStarts);
    }

    public void delayRecording()
    {
        wasPlayed = false;
        index++;
    }
}

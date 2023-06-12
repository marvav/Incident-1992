using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    public Core Core;
    public GameObject GoodMonster;
    public GameObject BadMonster;
    public GameObject entranceBarrier;
    public GameObject gate;
    public GameObject bandit;
    public GameObject deadBandit;
    public AudioSource banditLaugh;
    public GameObject Knife;
    private bool hasPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        if (Core.ProgressManager.vanSabotaged)
        {
            gate.SetActive(true);
            bandit.SetActive(true);
        }
        else
        {
            entranceBarrier.SetActive(true);
            BadMonster.SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Core.ProgressManager.vanSabotaged)
        {
            if (hasPlayed && !banditLaugh.isPlaying)
            {
                GoodMonster.SetActive(true);
            }
            if (!hasPlayed)
            {
                banditLaugh.Play();
                hasPlayed = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    public Core Core;
    public GameObject GoodMonster;
    public GameObject BadMonster;
    public GameObject ropeExit;
    public GameObject Rope;
    public GameObject cutRope;
    public GameObject bandit;
    public GameObject deadBandit;
    public AudioSource banditShout;
    // Start is called before the first frame update
    void Start()
    {
        if (Core.ProgressManager.vanSabotaged)
        {
            Rope.SetActive(false);
            cutRope.SetActive(true);
            banditShout.Play();
        }
        else
        {
            ropeExit.SetActive(false);
            BadMonster.SetActive(true);
        }
    }
    void Update()
    {
        if (!banditShout.isPlaying)
        {
            deadBandit.SetActive(true);
        }
    }
}

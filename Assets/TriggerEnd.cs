using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    public Core Core;
    public GameObject BadMonster;
    public GameObject ropeExit;
    public GameObject Rope;
    public GameObject cutRope;
    public GameObject bandit;
    public GameObject deadBandit;
    public AudioSource banditShout;
    private bool wasActivated;
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
            BadMonster.transform.position = new Vector3(436.7f, -16.7f, 635.4f);
        }
    }
    void Update()
    {
        if (!wasActivated && Core.ProgressManager.vanSabotaged && !banditShout.isPlaying)
        {
            deadBandit.SetActive(true);
            wasActivated = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceRecordings : MonoBehaviour
{
    public AudioSource Sound;
    public System.Random rand;
    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rand.Next(0,5000)==1)
        {
            Sound.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource Sound;
    public System.Random rand;
    Rigidbody rb;
    public int stepLength;
    private int currentStepLength;
    private int counter;
    private int leg;
    // Start is called before the first frame update
    void Start()
    {
        currentStepLength = stepLength;
        Sound = GetComponent<AudioSource>();
        rand = new System.Random();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    currentStepLength = stepLength /= 2;
        //    Debug.Log("faster");
        //}
        //else
        //    currentStepLength = stepLength;

        if (counter>=currentStepLength)
        {
            counter = 0;
            if (Sound.panStereo>0)
            {
                Sound.clip = audioClips[rand.Next(audioClips.Length/2, audioClips.Length)];
            }
            else
            {
                Sound.clip = audioClips[rand.Next(0, audioClips.Length / 2)];
            }
            Sound.panStereo *= -1;
            Sound.Play();
        }
        if (GetComponent<Rigidbody>().velocity.magnitude > 2)
        {
            counter += 1;
        }
        else
        {
            counter = 0;
        }
    }
}

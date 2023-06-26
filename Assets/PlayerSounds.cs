using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class PlayerSounds : MonoBehaviour
{
    public PlayerMovementDen Player;
    public AudioClip[] audioClips;
    public AudioSource Sound;
    Rigidbody rb;
    public int stepLength;
    private float counter;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counter >= stepLength && !Sound.isPlaying && Player.isMoving() && Player.grounded)
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
        if (rb.velocity.magnitude == 0)
            counter = 0;
        else
            counter += rb.velocity.magnitude;
    }
}

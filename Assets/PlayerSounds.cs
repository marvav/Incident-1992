using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class PlayerSounds : MonoBehaviour
{
    public PlayerMovementDen Player;
    public AudioClip[] audioClips;
    public AudioClip[] woodSteps;
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
            switch (Player.GetFloor())
            {
                case "Wood":
                    ChooseLeg(woodSteps);
                    break;
                default:
                    ChooseLeg(audioClips);
                    break;
            }
            Sound.Play();
        }
        if (rb.velocity.magnitude == 0)
            counter = 0;
        else
            counter += rb.velocity.magnitude;
    }

    void ChooseLeg(AudioClip[] clips)
    {
        if (Sound.panStereo > 0)
            Sound.clip = clips[rand.Next(clips.Length / 2, clips.Length)];
        else
            Sound.clip = clips[rand.Next(0, clips.Length / 2)];

        Sound.panStereo *= -1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class PlayerSounds : MonoBehaviour
{
    public PlayerMovementDen Player;
    public AudioClip[] audioClips;
    public float pitch;
    public AudioClip[] woodSteps;
    public float woodPitch;
    public AudioClip[] asphaltSteps;
    public float asphaltPitch;
    public AudioClip[] waterSteps;
    public float waterPitch;
    public AudioClip[] splashSounds;
    public float splashPitch;
    public AudioSource Sound;
    public Rigidbody rb;
    public int stepLength;
    private float counter;
    private string floorType = "";

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counter >= stepLength && !Sound.isPlaying && Player.isMoving() && Player.grounded)
        {
            counter = 0;
            string currentFloor = Player.GetFloor();
            switch (currentFloor)
            {
                case "Asphalt":
                    {
                        ChooseLeg(asphaltSteps);
                        Sound.pitch = asphaltPitch;
                        break;
                    }
                case "Wood":
                    {
                        ChooseLeg(woodSteps);
                        Sound.pitch = woodPitch;
                        break;
                    }
                case "Water":
                    {
                        ChooseLeg(waterSteps);
                        Sound.pitch = waterPitch;
                        break;
                    }
                default:
                    {
                        ChooseLeg(audioClips);
                        Sound.pitch = pitch;
                        break;
                    }
            }
            Sound.Play();
            if(currentFloor!=floorType)
            {
                floorType = currentFloor;
                counter = stepLength - 1; // So the step is performed upon start of the movement
                return;
            }
        }
        if (rb.velocity.magnitude < 0.1f)
            counter = stepLength - 1; // So the step is performed upon start of the movement
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

    public void FallSound(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Water":
                {
                    ChooseLeg(splashSounds);
                    Sound.pitch = splashPitch;
                    Sound.Play();
                    break;
                }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class monsterFollow : MonoBehaviour
{
    public Core Core;
    public GameObject monsterSubtitles;
    public GameObject eyes;
    public Light flashlight;
    public float speedUpWhenFlashlightOn;
    public GameObject death;
    public AudioSource buzzing;
    public AudioSource Damage;
    public AudioClip[] audioClips;
    public AudioClip[] cryingClips;
    public Animation animation;
    public GameObject[] monsterClamps;
    CharacterController charControl;
    public AudioSource Sound;
    public AudioSource CryingAudio;

    public float speed;
    public float gravityScale;
    public Phase phase;
    public int messageDistance;
    public int revealDistance;
    public int respawnDistance;
    public Vector3[] spawnPlaces;

    private int monsterDirection;
    private float distance;
    private Vector3 blankVector = new Vector3(0, 0, 0);

    public enum Phase
    {
        FollowClose,
        FollowMessaging,
        Follow,
        Clamp,
        SafeZone
    }

    void Start()
    {
        monsterDirection = 1;
        charControl = gameObject.GetComponent<CharacterController>();
        Sound = gameObject.GetComponent<AudioSource>();
        phase = Phase.Follow;
    }

    void FixedUpdate()
    {
        if (Core.PlayerDen.isPlayerInSafeZone())
        {
            phase = Phase.SafeZone;
            RandomTeleport();
        }
        UpdateAudio();
        switch (phase)
        {
            case Phase.FollowMessaging:
                Core.ProgressManager.monsterFound = true;
                ChangeVisibility(distance);
                MonsterFollow();
                break;
            case Phase.FollowClose:
                ChangeVisibility(distance);
                MonsterFollow();
                break;
            case Phase.Follow:
                ChangeVisibility(distance);
                MonsterFollow();
                break;
            case Phase.Clamp:
                break;
            case Phase.SafeZone:

                if (!Core.PlayerDen.isPlayerInSafeZone())
                {
                    phase = Phase.Follow;
                }
                break;
        }
    }

    void MonsterFollow()
    {
        distance = Vector3.Distance(Core.Player.transform.position, transform.position);
        monsterSubtitles.SetActive(Phase.FollowMessaging == phase);
        if (distance < 1 && rand.Next(0, 25) == 1)
        {
            Damage.Play();
            Core.Hurt(4);
        }

        //Debug.Log(distance);

        if (distance > respawnDistance)
        {
            RandomTeleport();
        }
        else
        {
            Move();
        }
    }

    void MonsterClamp()
    {
        
    }

    void ChangeVisibility(float distance)
    {
        if (phase == Phase.FollowClose)
        {
            eyes.SetActive(true);
            animation.Play("monster_final");
        }
        else
        {
            eyes.SetActive(!flashlight.enabled);
            if (flashlight.enabled && animation.IsPlaying("monster_final")) animation.Stop("monster_final");
            else if (!animation.IsPlaying("monster_final")) animation.Play("monster_final");
        }
    }

    void UpdateAudio()
    {
        switch (phase) {
            case Phase.FollowClose:
                if (!buzzing.isPlaying)
                {
                    buzzing.Play();
                }
                if (!Sound.isPlaying)
                {
                    Sound.clip = audioClips[rand.Next(0, audioClips.Length)];
                    Sound.Play();
                }
                break;
            case Phase.FollowMessaging:
                buzzing.Stop();
                Sound.Stop();
                if (!CryingAudio.isPlaying && rand.Next(0, 2500) == 1)
                {
                    CryingAudio.clip = cryingClips[rand.Next(0, cryingClips.Length)];
                    CryingAudio.Play();
                }
                break;
            default:
                buzzing.Stop();
                Sound.Stop();
                CryingAudio.Stop();
                break;
        }
    }

    void Move()
    {
        charControl.Move(monsterDirection * transform.up * gravityScale * Time.deltaTime);
        transform.LookAt(Core.Player.transform);
        Vector3 movement = monsterDirection * transform.forward * Time.deltaTime * speed;

        if (flashlight.enabled)
            movement *= speedUpWhenFlashlightOn;

        charControl.Move(movement);

        if (distance > messageDistance)
        {
            phase = Phase.Follow;
        }
        else {
            phase = distance > revealDistance 
                ? Phase.FollowMessaging 
                : Phase.FollowClose;
        }
    }

    private void RandomTeleport()
    {
        if (rand.Next(0, 50) == 1) //Chance to spawn directly behind player
        {
            int random = rand.Next(0, 4);
            if (random == 0)
                Teleport(Core.Player.transform.position, new Vector3(-20, 0, 0));
            if (random == 1)
                Teleport(Core.Player.transform.position, new Vector3(20, 0, 0));
            if (random == 2)
                Teleport(Core.Player.transform.position, new Vector3(0, 0, -20));
            if (random == 3)
                Teleport(Core.Player.transform.position, new Vector3(0, 0, 20));
        }
        else //Spawns on one of locations
        {
            transform.position = spawnPlaces[rand.Next(0, spawnPlaces.Length)];
        }
    }

    // Public Methods

    public int GetMonsterDistance()
    {
        return (int) distance;
    }

    public void ToggleMonster()
    {
        monsterDirection *= -1;
    }

    public void Teleport(Vector3 position, Vector3 offset)
    {
        transform.position = new Vector3(position.x + offset.x,position.y + offset.y,position.z + offset.z);
    }
    public bool MonsterIsClose()
    {
        return phase == Phase.FollowClose;
    }

}

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
    public Phase phase = Phase.Follow;
    public int messageDistance;
    public int revealDistance;
    public int respawnDistance;
    public int teleportChance;
    public int cryingChance;
    public Vector3[] spawnPlaces;

    private int monsterDirection = 1;
    private float distance;
    private Vector3 blankVector = new Vector3(0, 0, 0);

    public enum Phase
    {
        FollowClose,
        FollowMessaging,
        Follow,
        Waiting,
        SafeZone
    }

    void Start()
    {
        charControl = gameObject.GetComponent<CharacterController>();
        Sound = gameObject.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (Core.PlayerDen.isPlayerInSafeZone())
        {
            if(phase != Phase.SafeZone)
            {
                monsterSubtitles.SetActive(false);
                RandomTeleport();
            }
            phase = Phase.SafeZone;
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
            case Phase.Waiting:
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
        if (distance < 1 && rand.Next(0, 22) == 1)
        {
            Damage.Play();
            Core.Hurt(4, Core.DeathType.Monster);
        }

        //Debug.Log(distance);

        if (distance > respawnDistance && rand.Next(0, teleportChance) == 1)
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
                if (!CryingAudio.isPlaying && rand.Next(0, cryingChance) == 1)
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
        if (rand.Next(0, 40) == 1) //Chance to spawn directly behind player
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

    public void triggerMonster()
    {
        phase = Phase.Follow;
    }

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
        return phase == Phase.FollowClose && this.gameObject.activeSelf;
    }

}

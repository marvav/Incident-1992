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
    public Transform followTransform;
    public GameObject death;
    public AudioSource buzzing;
    public AudioSource Damage;
    public AudioClip[] audioClips;
    public Animation animation;
    public GameObject[] monsterClamps;
    CharacterController charControl;
    AudioSource Sound;

    public float speed;
    public float gravityScale;
    public Phase phase;
    public int messageDistance;
    public int revealDistance;
    public int respawnDistance;
    public Vector3[] spawnPlaces;

    private int monsterDirection;

    private float distance;
    private bool isClose = false;
    private bool messaging = true;
    private Vector3 blankVector = new Vector3(0, 0, 0);

    public enum Phase
    {
        Follow,
        Clamp
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
        switch (phase)
        {
            case Phase.Follow:
                MonsterFollow();
                break;
            case Phase.Clamp:
                break;
        }
    }

    void MonsterFollow()
    {
        distance = Vector3.Distance(followTransform.position, transform.position);
        monsterSubtitles.SetActive(messaging && distance < messageDistance);
        if (distance < 1 && rand.Next(0, 25) == 1)
        {
            Damage.Play();
            Core.Hurt(4);
        }
        if (distance < messageDistance)
            Core.ProgressManager.monsterFound = true;
        else
        {
            messaging = true;
            if (!buzzing.isPlaying)
                buzzing.Play();
        }

        Debug.Log(distance);

        if (distance > respawnDistance)
        {
            if (rand.Next(0, 50) == 1) //Chance to spawn directly behind player
            {
                int random = rand.Next(0, 4);
                if (random == 0)
                    Teleport(followTransform.position, new Vector3(-20, 0, 0));
                if (random == 1)
                    Teleport(followTransform.position, new Vector3(20, 0, 0));
                if (random == 2)
                    Teleport(followTransform.position, new Vector3(0, 0, -20));
                if (random == 3)
                    Teleport(followTransform.position, new Vector3(0, 0, 20));
                buzzing.Pause();
                messaging = false;
            }
            else //Spawns on one of locations
            {
                transform.position = spawnPlaces[rand.Next(0, spawnPlaces.Length)];
            }
        }
        else
            Move();
        ChangeVisibility(distance);
    }

    void MonsterClamp()
    {
        
    }

    void ChangeVisibility(float distance)
    {
        if (distance < revealDistance)
        {
            messaging = true;
            if (!buzzing.isPlaying)
                buzzing.Play();
            if (!isClose)
            {
                Sound.clip = audioClips[rand.Next(0, audioClips.Length)];
                Sound.Play();
                isClose = true;
            }
            else
            {
                if (rand.Next(0, 100) == 1)
                {
                    Sound.clip = audioClips[rand.Next(0, audioClips.Length)];
                    Sound.Play();
                }
            }
            eyes.SetActive(true);
            animation.Play("monster_final");
        }
        else
        {
            eyes.SetActive(!flashlight.enabled);
            isClose = false;
            if (flashlight.enabled && animation.IsPlaying("monster_final")) animation.Stop("monster_final");
            else if (!animation.IsPlaying("monster_final")) animation.Play("monster_final");
        }
    }
    void Move()
    {
        charControl.Move(monsterDirection * transform.up * gravityScale * Time.deltaTime);
        transform.LookAt(followTransform);
        Vector3 movement = monsterDirection * transform.forward * Time.deltaTime * speed;
        if (flashlight.enabled)
            movement *= speedUpWhenFlashlightOn;
        charControl.Move(movement);
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

}

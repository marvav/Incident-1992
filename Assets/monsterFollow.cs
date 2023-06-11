using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class monsterFollow : MonoBehaviour
{
    public Core Core;
    CharacterController charControl;
    public MeshRenderer eyes;
    public Light flashlight;
    public Transform followTransform;
    public GameObject death;
    public GameObject deathControls;
    public AudioSource DeathMusic;
    public AudioSource Sound;
    public AudioClip[] audioClips;

    public int speed;
    public float gravityScale;
    public bool follow;
    public int messageDistance;
    public int revealDistance;
    public int respawnDistance;
    public string[] messages;
    public Vector3[] spawnPlaces;

    private System.Random rand;
    private float distance;
    private bool isClose;
    // Start is called before the first frame update
    void Start()
    {
        charControl = gameObject.GetComponent<CharacterController>();
        rand = new System.Random();
        isClose = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(follow)
        {
            distance = Vector3.Distance(followTransform.position, transform.position);
            if (distance < 1 && rand.Next(0, 10) == 1)
            {
                Core.Hurt(4);
                if(Core.PlayerHP <= 0)
                {
                    DeathMusic.Play();
                    Time.timeScale = 0;
                    death.SetActive(true);
                    deathControls.SetActive(true);
                    ToggleCursor();
                    return;
                }
            }
            if(distance < messageDistance)
            {
                Core.ProgressManager.monsterFound = true;
                if (rand.Next(0, 50) == 1)
                    Core.Description.text = messages[rand.Next(0, messages.Length)];
                else
                    Core.Description.text = "";
            }
            Debug.Log(distance);
            if (distance > respawnDistance)
            {
                if(rand.Next(0,100) == 1) //Chance to spawn directly behind player
                {
                    transform.position = followTransform.position + new Vector3(-50, 0, 0);
                }
                else //Spawns on one of locations
                {
                    transform.position = spawnPlaces[rand.Next(0, spawnPlaces.Length)];
                }
            }
            else
            {
                Move();
            }
            ChangeVisibility(distance);
        }
    }

    void ChangeVisibility(float distance)
    {
        if (distance < revealDistance)
        {
            if(!isClose)
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
            eyes.enabled = true;
        }
        else
        {
            eyes.enabled = !flashlight.enabled;
            isClose = false;
        }
    }
    void Move()
    {
        charControl.Move(transform.up * gravityScale * Time.deltaTime);
        transform.LookAt(followTransform);
        charControl.Move(transform.forward * Time.deltaTime * speed);
    }

}

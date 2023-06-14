using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class BadMonsterEnding : MonoBehaviour
{
    public Core Core;
    CharacterController charControl;
    public MeshRenderer eyes;
    public Light flashlight;
    public GameObject knife;
    public Transform playerTransform;
    public GameObject death;
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

    private Transform followTransform;
    private System.Random rand;
    private float distance;
    private bool isClose;
    private bool foundKnife = false;
    // Start is called before the first frame update
    void Start()
    {
        followTransform = knife.transform;
        charControl = gameObject.GetComponent<CharacterController>();
        rand = new System.Random();
        isClose = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(followTransform.position);
        if (follow)
        {
            distance = Vector3.Distance(followTransform.position, transform.position);
            if (distance < 0.5f)
            {
                if (foundKnife)
                {
                    DeathMusic.Play();
                    Time.timeScale = 0;
                    death.SetActive(true);
                    Core.DeathHUD.SetActive(true);
                    ToggleCursor();
                    return;
                }
                else
                {
                    knife.SetActive(false);
                    followTransform = playerTransform;
                    foundKnife = true;
                    speed = 20;
                }
            }
            if (distance < messageDistance)
            {
                Core.ProgressManager.monsterFound = true;
                if (rand.Next(0, 10) == 1)
                    Core.Description.text = messages[rand.Next(0, messages.Length)];
                else
                    Core.Description.text = "";
            }
            Move();
            ChangeVisibility(distance);
        }
    }

    void ChangeVisibility(float distance)
    {
        if (distance < revealDistance)
        {
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

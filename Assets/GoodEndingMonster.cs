using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class GoodEndingMonster : MonoBehaviour
{
    public Core Core;
    CharacterController charControl;
    public MeshRenderer eyes;
    public Light flashlight;
    public Transform followTransform;
    public GameObject deadBandit;
    public GameObject bandit;
    public AudioSource DeathMusic;
    public AudioSource Sound;
    public AudioClip[] audioClips;

    public int speed;
    public float gravityScale;
    public bool follow;
    public int messageDistance;
    public int revealDistance;
    public string[] messages;

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
        if (follow)
        {
            distance = Vector3.Distance(followTransform.position, transform.position);
            if (distance < 1)
            {
                bandit.SetActive(false);
                deadBandit.SetActive(true);
                DeathMusic.Play();
                this.gameObject.SetActive(false);
                //Time.timeScale = 0;
                //death.SetActive(true);
                //deathNewspaper.SetActive(true);
                //ToggleCursor();
                return;
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

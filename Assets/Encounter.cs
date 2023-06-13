using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class Encounter : MonoBehaviour
{
    public Core Core;
    public AudioSource WalkieTalkie;
    public bool isWithCar;
    public GameObject death;
    public GameObject encounter;
    public GameObject car;
    public GameObject carFire;
    public Rigidbody player;
    public AudioSource gun;
    public GameObject ShootHim;
    public GameObject AreYouBlind;
    public AudioClip[] gunshots;
    private bool isHappening = false;
    private int counter = 0;
    public System.Random rand;

    void Start()
    {
        rand = new System.Random();
    }

    void Update()
    {
        if(isHappening)
        {
            if (counter == 4)
            {
                AreYouBlind.SetActive(true);
            }
            if (!gun.isPlaying)
            {
                gun.clip = gunshots[counter];
                counter++;
                gun.Play();
                if (player.velocity.magnitude < 7)
                {
                    Core.Hurt(5);
                    if (Core.PlayerHP <= 0)
                    {
                        death.SetActive(true);
                        Time.timeScale = 0;
                        ToggleCursor();
                    }
                    return;
                }
                if (counter >= gunshots.Length-1)
                {
                    if (isWithCar)
                    {
                        car.SetActive(false);
                        carFire.SetActive(true);
                    }
                    Core.ProgressManager.changeObjective(9);
                    encounter.SetActive(false);
                }
            }
        }
        else
            {
                if (isCloseToPlayer(transform, 20) && !WalkieTalkie.isPlaying && rand.Next(0,500)==1)
                {
                    ShootHim.SetActive(true);
                    gun.Play();
                    isHappening = true;
            }
        }
    }
}
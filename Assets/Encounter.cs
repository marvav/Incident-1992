using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class Encounter : MonoBehaviour
{
    public Core Core;
    public bool isWithCar;
    public GameObject death;
    public GameObject encounter;
    public GameObject car;
    public GameObject carFire;
    public Rigidbody player;
    public AudioSource gun;
    public AudioClip[] gunshots;
    private bool isHappening;
    private int counter;

    void Start()
    {
        isHappening = false;
        counter = 0;
    }

    void FixedUpdate()
    {
        if(isHappening)
        {
            if (!gun.isPlaying)
            {
                gun.clip = gunshots[counter];
                counter++;
                gun.Play();
                if (player.velocity.magnitude < 2)
                {
                    death.SetActive(true);
                    Time.timeScale = 0;
                    ToggleCursor();
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
                if (isCloseToPlayer(transform, 10))
                {
                    gun.Play();
                    Debug.Log("Encounter");
                    isHappening = true;
            }
        }
    }
}

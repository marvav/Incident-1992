using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;
using static Inventory;

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
    public GameObject ShootHim;
    public GameObject AreYouBlind;
    public AudioClip[] gunshots;
    private bool isHappening = false;
    private int counter = 0;

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
                        Core.DeathHUD.SetActive(true);
                        death.SetActive(true);
                        Time.timeScale = 0;
                        ToggleCursor();
                        this.gameObject.SetActive(false);
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
                if (isCloseToPlayer(transform, 20) && Inventory.InHand != "WalkieTalkie" && rand.Next(0,1500)==1)
                {
                    ShootHim.SetActive(true);
                    gun.Play();
                    isHappening = true;
            }
        }
    }
}

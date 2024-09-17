using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;
using static Inventory;

public class Encounter : MonoBehaviour
{
    public Core Core;
    public int chance;
    public int carChance;
    public GameObject death;
    public GameObject car;
    public GameObject carFire;
    public Rigidbody player;
    public AudioSource gun;
    public GameObject ShootHim;
    public GameObject AreYouBlind;
    public AudioClip[] gunshots;
    private bool isHappening = false;
    private int counter = 0;

    void FixedUpdate()
    {
        if(isHappening)
        {
            performEncounter();
            return;
        }
        if (!Core.PlayerDen.isPlayerInSafeZone())
        {
            if (rand.Next(0, chance) == 1 || (isCloseToPlayer(car.transform, 50) && rand.Next(0, carChance) == 1))
            {
                ShootHim.SetActive(true);
                gun.Play();
                isHappening = true;
            }
        }
    }

    void performEncounter()
    {
        if (counter == 4)
            AreYouBlind.SetActive(true);

        if (!gun.isPlaying)
        {
            gun.clip = gunshots[counter];
            counter++;
            gun.Play();
            //gun.volume = rand.Next(5, 10) / 10;
            if (player.velocity.magnitude < 7)
            {
                Core.Hurt(5);
                if (Core.PlayerHP <= 0)
                {
                    death.SetActive(true);
                    this.gameObject.SetActive(false);
                }
                return;
            }
            if (counter >= gunshots.Length - 1)
            {
                if (isCloseToPlayer(car.transform, 50))
                {
                    car.SetActive(false);
                    carFire.SetActive(true);
                }
                Core.ProgressManager.changeObjective(9);
                this.gameObject.SetActive(false);
            }
        }
    }
}

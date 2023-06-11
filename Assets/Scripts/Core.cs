using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;

public class Core : MonoBehaviour
{
    public GameObject Player;
    public int PlayerMaxHP = 10;
    public int PlayerHP = 10;
    public GameObject HurtScreen;
    public GameObject DeathHUD;
    public PlayerMovementDen PlayerDen;
    public GameObject Inventory;
    public GameObject PickUpItem;
    public GameObject Click;
    public GameObject Note;
    public GameObject NoteText;
    public TMP_Text Description;
    public AudioSource PickUpSound;
    public ProgressManager ProgressManager;
    private float delay;

    void Start()
    {
        delay = Time.realtimeSinceStartup;
    }
    void FixedUpdate()
    {
        Debug.Log(PlayerHP);
        if (PlayerHP < PlayerMaxHP && Time.realtimeSinceStartup-delay > 30)
        {
            PlayerHP = PlayerMaxHP;
        }
    }

    public void Hurt(int damage)
    {
        PlayerHP -= damage;
        HurtScreen.SetActive(true);
        delay = Time.realtimeSinceStartup;
    }
}
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
    public float startingGamma;
    public VolumeEffects effects;
    public GameObject HurtScreen;
    public GameObject DeathHUD;
    public PlayerMovementDen PlayerDen;
    public GameObject Inventory;
    public GameObject PickUpItem;
    public GameObject Click;
    public GameObject Note;
    public GameObject NoteText;
    public TMP_Text Description;
    public AudioSource GeneralAudio;
    public AudioSource GeneralMusic;
    public AudioSource VoiceOver;
    public AudioSource PickUpSound;
    public AudioSource DeathSound;
    public ProgressManager ProgressManager;
    private float delay;

    void Start()
    {
        delay = Time.realtimeSinceStartup;
        RenderSettings.ambientLight = new Color(startingGamma, startingGamma, startingGamma, 1.0f);
    }
    void Update()
    {
        if (PlayerHP < PlayerMaxHP && Time.realtimeSinceStartup-delay > 15)
        {
            PlayerHP = PlayerMaxHP;
            effects.chromaticAnimation = false;
        }

    }

    public void Hurt(int damage)
    {
        effects.chromaticAnimation = true;
        PlayerHP -= damage;
        HurtScreen.SetActive(true);
        delay = Time.realtimeSinceStartup;
        if (PlayerHP <= 0)
        {
            DeathSound.Play();
        }
    }
}
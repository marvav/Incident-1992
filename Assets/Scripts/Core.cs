using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using static Core_Utils;
using static Archive;
using static Inventory;
using static VoiceOverManager;

public class Core : MonoBehaviour
{
    public GameObject Player;
    public GameObject Hand;
    public GameObject Camera;
    public monsterFollow Monster;
    public int PlayerMaxHP = 10;
    public int PlayerHP = 10;
    public float startingGamma;
    public VolumeEffects effects;
    public GameObject HurtScreen;
    public GameObject DeathHUD;
    public PlayerMovementDen PlayerDen;
    public GameObject PickUpItem;
    public GameObject Click;
    public GameObject Note;
    public GameObject NoteText;
    public TMP_Text Subtitles;
    public TMP_Text Description;
    public TMP_Text CasetteCode;
    public AudioSource GeneralAudio;
    public AudioSource GeneralMusic;
    public VoiceOverSubtitles VoiceOver;
    public AudioSource PickUpSound;
    public AudioSource DeathSound;
    public CombinationLock Lock;
    public ProgressManager ProgressManager;
    public InteractionManager InteractionManager;
    private float delay;
    private int Localization = 0;


    void Start()
    {

        Core_Utils.Player = Player;
        Core_Utils.Hand = Hand;
        Core_Utils.Camera = Camera;

        Archive.InitializeArchive();
        Inventory.InitializeInventory();
        VoiceOverManager.InitializeVoiceOverManager();
        GenerateCode();

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

    public void ChangeLanguage(int value)
    {
        InteractionManager.ChangeLanguage();
        if (value != Localization)
        {
            Localization = value;
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Localization");
            foreach (GameObject gameobject in objects)
            {
                Debug.Log(gameobject.name);
                Multitext text = gameobject.GetComponent<Multitext>();
                text.ChangeLanguage(Localization);
            }
        }
    }

    public void ChangeVolume(string tag, float volume)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject gameobject in objects)
        {
            AudioSource audio = gameobject.GetComponent<AudioSource>();
            audio.volume = volume;
        }
    }

    public int GetLanguage()
    {
        return Localization;
    }

    public void GenerateCode()
    {
        CasetteCode.text = "";
        for (int i = 0; i < 4; i++)
        {
            Lock.correctDigits[i] = rand.Next(0,10);
            CasetteCode.text += Lock.correctDigits[i].ToString();
        }
    }
}
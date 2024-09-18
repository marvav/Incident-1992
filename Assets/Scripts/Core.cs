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
    public GameObject CameraMover;
    public FadeInScene DeathManager;
    public monsterFollow Monster;
    public AudioManager AudioManager;
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
    public TMP_Text DescriptionUI;
    public TMP_Text CasetteCode;
    public AudioSource GeneralAudio;
    public VoiceOverSubtitles VoiceOver;
    public AudioSource PickUpSound;
    public AudioSource DeathSound;
    public CombinationLock Lock;
    public ProgressManager ProgressManager;
    public InteractionManager InteractionManager;
    public EnvironmentCollisionSounds EnvironmentCollisionSounds;
    public RollingText RollingText;
    private int Localization = 0;
    private Coroutine playerHealAfterDamage;
    public enum DeathType
    {
        Monster,
        Shot,
        Fall,
    }


    void Start()
    {
        Core_Utils.Player = Player;
        Core_Utils.Hand = Hand;
        Core_Utils.Camera = Camera;

        Archive.InitializeArchive();
        Inventory.InitializeInventory();
        VoiceOverManager.InitializeVoiceOverManager();
        GenerateCode();

        RenderSettings.ambientLight = new Color(startingGamma, startingGamma, startingGamma, 1.0f);
    }

    public void Hurt(int damage, DeathType deathType)
    {
        effects.SetChromaticAberrationAnimation(true);
        PlayerHP -= damage;
        HurtScreen.SetActive(true);

        if (playerHealAfterDamage != null) {
            StopCoroutine(playerHealAfterDamage);
        }
        playerHealAfterDamage = StartCoroutine(Heal(15.0f));


        if (PlayerHP <= 0)
        {
            DeathSound.Play();
            Monster.gameObject.SetActive(false);
            CameraMover.gameObject.SetActive(false);
            StopPlayer();
            switch (deathType)
            {
                case DeathType.Shot:
                    DeathManager.YouGotShotEndingScreen();
                    break;
                case DeathType.Fall:
                    DeathManager.BadEndingScreen();
                    break;
                case DeathType.Monster:
                    DeathManager.BadEndingScreen();
                    break;
            }
            ToggleCursor();
        }
    }

    public void StopPlayer()
    {
        Hand.SetActive(false);
        Player.SetActive(false);
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

    private IEnumerator Heal(float waitBefore)
    {
        yield return new WaitForSeconds(waitBefore);
        PlayerHP = PlayerMaxHP;
        effects.SetChromaticAberrationAnimation(false);
    }
}
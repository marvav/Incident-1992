using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;

public class Core : MonoBehaviour
{
    public GameObject Player;
    public PlayerMovementDen PlayerDen;
    public GameObject Inventory;
    public GameObject PickUpItem;
    public GameObject Click;
    public GameObject ItemInHand;
    public GameObject Note;
    public GameObject NoteText;
    public TMP_Text Description;
    public TMP_Text Objective;
    public AudioSource PickUpSound;
    public ProgressManager ProgressManager;
}
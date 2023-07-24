using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Core_Utils;

public class InteractionTeleport : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject icon;
    public Core Core;
    public GameObject Destination;
    public AudioSource MovementSound;
    public void Teleport()
    {
        MovementSound.Play();
        Core.Player.transform.position = Destination.transform.position;
    }
}

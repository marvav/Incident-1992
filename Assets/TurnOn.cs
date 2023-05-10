using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour
{
    public Core Core;
    public GameObject Lamp;
    public GameObject LightUp;
    public GameObject LightOff;
    private float PlayerHeight;
    private GameObject currentIcon;
    private GameObject Player;
    private bool isHidden;
    private bool isOn;
    private bool isReleased;
    // Start is called before the first frame update
    void Start()
    {
        currentIcon = LightUp;
        //PlayerHeight = Player.GetComponent<PlayerMovementDen>().playerHeight;
        PlayerHeight = 2;
        Player = Core.Player;
        isHidden = true;
        isReleased = true;
        isOn = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position + new Vector3(0, PlayerHeight, 0), Player.transform.position) < 1.5f
            || Vector3.Distance(transform.position, Player.transform.position) < 1.5f)
        {
            isHidden = false;
            currentIcon.SetActive(true);
            if (isReleased && Input.GetButton("Pick Up"))
            {
                currentIcon.SetActive(false);
                if (!isOn)
                {
                    Lamp.SetActive(true);
                    currentIcon = LightOff;
                    isOn = true;
                }
                else
                {
                    isOn = false;
                    Lamp.SetActive(false);
                    currentIcon = LightUp;
                }
                isReleased = false;
            }
        }
        else
        {
            if (!isHidden)
            {
                currentIcon.SetActive(false);
                isHidden = true;
                isReleased = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Core_Utils;

public class EndingLoadScene : MonoBehaviour
{
    // Start is called before the first frame update

    public Core Core;
    public TMP_Text text;
    public AudioSource sound;
    public AudioSource LoadingScreen;
    public GameObject Teleport;
    public GameObject WellRegularEntrance;
    public string[] lines;
    private int start = 1;
    private bool isHidden = true;
    // Update is called once per frame
    void Start()
    {
        text.text = lines[0];
        LoadingScreen.Play();
    }
    void Update()
    {
        if (isHidden && Input.GetMouseButtonDown(0))
        {
            sound.Play();
            if (start >= lines.Length - 1)
            {
                text.text = "";
                Core.Player.transform.position = Teleport.transform.position;
                WellRegularEntrance.SetActive(true);
                this.gameObject.SetActive(false);
                return;
            }
            text.text = lines[start];
            start++;
            isHidden = false;
        }
        else
        {
            isHidden = true;
        }
    }
}

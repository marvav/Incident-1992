using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpeningScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Core Core;
    public GameObject scene;
    public TMP_Text text;
    public AudioSource sound;
    public string[] lines;
    private int start;
    private bool isHidden;
    // Update is called once per frame
    void Start()
    {
        isHidden = true;
        text.text = lines[0];
        start = 1;

    }
    void Update()
    {
        if(isHidden && Input.GetMouseButtonDown(0))
        {
            sound.Play();
            if (start >= lines.Length-1)
            {
                text.text = "";
                scene.SetActive(false);
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

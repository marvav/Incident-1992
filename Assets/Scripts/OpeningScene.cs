using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpeningScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Core Core;
    public GameObject scene;
    public string[] lines;
    private int start;
    private bool isHidden;
    // Update is called once per frame
    void Start()
    {
        start = 0;
        isHidden = true;

    }
    void Update()
    {
        if(isHidden && Input.GetMouseButtonDown(0))
        {
            if (start >= lines.Length-1)
            {
                Core.Description.text = "";
                scene.SetActive(false);
                return;
            }
            Core.Description.text = lines[start];
            start++;
            isHidden = false;
        }
        else
        {
            isHidden = true;
        }
    }
}

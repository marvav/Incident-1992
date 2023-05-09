using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpeningScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scene;
    public string[] lines;
    public TMP_Text line;
    private int start;
    // Update is called once per frame
    void Start()
    {
        start = 0;

    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (start >= lines.Length)
            {
                scene.SetActive(false);
            }
            line.text = lines[start];
            start++;
        }
    }
}

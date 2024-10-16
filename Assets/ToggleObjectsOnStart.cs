using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjectsOnStart : MonoBehaviour
{
    public GameObject[] toggleOn;
    public GameObject[] toggleOff;

    void Start()
    {
        foreach (GameObject obj in toggleOn){
            obj.SetActive(true);
        }
        foreach (GameObject obj in toggleOff)
        {
            obj.SetActive(false);
        }
    }
}

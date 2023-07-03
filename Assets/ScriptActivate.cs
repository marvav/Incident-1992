using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptActivate : MonoBehaviour
{
    public PlayerMovementDen Player;
    // Start is called before the first frame update
    void Start()
    {
        Player.enabled = true;
    }
}

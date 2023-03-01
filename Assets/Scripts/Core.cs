using UnityEngine;
using System.Collections;
using System;

namespace CoreImport
{
    public class Object
    {
        public static GameObject Player;
    }
}

public class Core : MonoBehaviour
{

    void Start()
    {
        CoreImport.Object.Player = this.gameObject;
    }
}
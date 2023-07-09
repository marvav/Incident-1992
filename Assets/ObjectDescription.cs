using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class ObjectDescription : MonoBehaviour
{
    public string[] contents;

    public string GetText(int index)
    {
        return contents[index];
    }
}

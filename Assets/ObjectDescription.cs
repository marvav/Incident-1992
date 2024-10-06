using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class ObjectDescription : MonoBehaviour
{
    public string[] contents;
    public int clueID = 0;

    public string GetText(int index)
    {
        return contents[index];
    }

    public int GetClue()
    {
        return clueID;
    }
}

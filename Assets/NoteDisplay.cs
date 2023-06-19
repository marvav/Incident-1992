using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteDisplay : MonoBehaviour
{
    public ReadableNote note;
    public TMP_Text text;

    void Start()
    {
        text.text = note.content;
    }
}

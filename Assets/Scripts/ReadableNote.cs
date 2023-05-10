using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Core_Utils;
public class ReadableNote : MonoBehaviour
{
    public Core Core;
    public string content;
    public string NewObjective;
    private bool isHidden;
    private bool objectiveChanged;
    // Start is called before the first frame update
    void Start()
    {
        isHidden = true;
        objectiveChanged = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isCloseToPlayer(transform, Core.Player))
        {
            isHidden = false;
            Core.PickUpItem.SetActive(true);
            if (Input.GetButton("Pick Up"))
            {
                Core.NoteText.GetComponent<TMP_Text>().text = content;
                Core.Note.SetActive(true);
                Core.PickUpItem.SetActive(false);
                if(NewObjective!="" && !objectiveChanged)
                {
                    Core.Objective.text = NewObjective;
                    objectiveChanged = true;
                }
                return;
            }
        }
        else
        {
            if (!isHidden)
            {
                Core.PickUpItem.SetActive(false);
                isHidden = true;
            }
        }
    }
}
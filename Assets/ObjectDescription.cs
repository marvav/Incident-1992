using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class ObjectDescription : MonoBehaviour
{
    public Core Core;
    public string[] contents;
    public int clueID;
    private bool isHidden = true;

    // Update is called once per frame
    void Update()
    {
        if (CanInteract(this.gameObject, 1.0f, 35.0f))
        {
            if (isHidden)
            {
                Core.Description.text = contents[Core.GetLanguage()];
                Core.ProgressManager.changeObjective(clueID);
                isHidden = false;
            }
        }
        else
        {
            if (!isHidden)
            {
                Core.Description.text = "";
                Core.PickUpItem.SetActive(false);
                isHidden = true;
            }
        }
    }
}

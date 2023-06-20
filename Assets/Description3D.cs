using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class Description3D : MonoBehaviour
{
    public Core Core;
    public string text;
    public float range = 2.0f;
    public bool isClue;
    public int clueID = 0;
    public Renderer renderer;
    private bool isHidden = true;

    void Update()
    {
        if ((renderer != null && renderer.isVisible) && CanInteract(this.gameObject, range))
        {
            if (isHidden)
            {
                Core.Description.text = text;
                isHidden = false;
                if(isClue)
                    Core.ProgressManager.changeObjective(clueID);
            }
        }
        else
        {
            if (!isHidden)
            {
                isHidden = true;
                Core.Description.text = "";
            }
        }
    }
}

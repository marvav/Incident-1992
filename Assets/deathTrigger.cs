using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathTrigger : MonoBehaviour
{
    // Start is called before the first frame update
   private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
        {
            if(other.gameObject.GetComponent<BadEnding>())
            {
                other.gameObject.GetComponent<BadEnding>().TriggerEnd();
            }
        }
    }
}

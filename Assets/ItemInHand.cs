using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;

public class ItemInHand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            this.gameObject.SetActive(false);
            Inventory.InHand = null;
        }
        if (Input.GetMouseButtonDown(0))
        {
        }
    }
}

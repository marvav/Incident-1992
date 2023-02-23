using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryItems : MonoBehaviour
{
    public int batteries = 0;
    public HashSet<string> Items = new HashSet<string>();
    public GameObject[] icons;
    public GameObject BatteryCount;
    private TMP_Text BatteryCountText;

    // Start is called before the first frame update
    void Start()
    {
        BatteryCountText = BatteryCount.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(batteries);
        BatteryCountText.text = "Batteries: " + batteries.ToString();
    }
}

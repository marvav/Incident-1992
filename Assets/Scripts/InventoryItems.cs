using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace InventoryAPI
{
    public class Inventory
    {
        public List<Item> Items;
        public int size;
        public int current_size;
        public Inventory()
        {
            this.Items = new List<Item>();
            this.size = 7; //It's actually 8, Index starts from 0;
            this.current_size = 0;
        }

        public void Add(Item item)
        {
            if(size == current_size)
            {
                return; // Inventory is full
            }
            for (int i = 0; i < current_size; i++)
            {
                if (item.name == Items[i].name)// Same item is already in the inventory. You now have 2 of them.
                {
                    Items[i].count += 1;
                    return;
                }
            }
            Items.Add(item);
            current_size += 1;
            return;
        }

        public Item Find_by_name(string name)
        {
            foreach(Item item in Items)
            {
                if (item.name.Equals(name))
                    return item;
            }
            return null;
        }
    }
    public class Item
    {
        public string name;
        public int count;

        public Item(string name)
        {
            this.name = name;
            this.count = 1;
        }
    }
}

public class InventoryItems : MonoBehaviour
{
    public InventoryAPI.Inventory Inventory = new InventoryAPI.Inventory();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}

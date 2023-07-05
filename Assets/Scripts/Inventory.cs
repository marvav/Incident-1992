using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    public static List<Item> Items;
    public static int size = 0;
    public static GameObject InHand;

    public static void Add(Item item)
    {
        foreach (Item slot in Items)
        {
            if (slot!= null && item.name == slot.name)// Same item is already in the inventory. You now have 2 of them.
            {
                slot.count += 1;
                return;
            }
        }

        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i] == null)// Same item is already in the inventory. You now have 2 of them.
            {
                Items[i] = item;
                return;
            }
        }
        return;
    }

    public static void Add(string item)
    {
        Add(new Item(item));
    }

    public static void Remove(string name)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i]!=null && name == Items[i].name)// Same item is already in the inventory. You now have 2 of them.
            {
                Items[i].count -= 1;
                if (Items[i].count == 0)
                    Items[i] = null;
                    return;
            }
        }
        return;
    }

    public static Item Find_by_name(string name)
    {
        foreach (Item item in Items)
        {
            if (item!=null && item.name.Equals(name))
                return item;
        }
        return null;
    }

    public static bool isInHand(GameObject item)
    {
        return InHand == item;
    }

    public static void InitializeInventory()
    {
        Items = new List<Item> { null, null, null, null, null, null, null };
        size = Items.Count;
        InHand = null;
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

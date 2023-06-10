using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    public static List<Item> Items = new List<Item> {null, null , null , null , null , null };
    public static int size = Items.Count;
    public static string InHand = "";

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

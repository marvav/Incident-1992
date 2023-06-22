using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Archive
{
    public static List<NoteItem> Notes;

    public static void Add(NoteItem note)
    {
        for (int i = 0; i < Notes.Count; i++)
        {
            if (Notes[i] == null)
            {
                Notes[i] = note;
                return;
            }
        }
        return;
    }
    public static void InitializeArchive(){
        Notes = new List<NoteItem> { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
    }
}

public class NoteItem
{
    public string name;
    public string content;

    public NoteItem(string name, string content)
    {
        this.name = name;
        this.content = content;
    }
}
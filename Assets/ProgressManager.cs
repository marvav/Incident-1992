using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;

public class ProgressManager : MonoBehaviour
{
    public Core Core;
    public GameObject knife;
    public GameObject monster;

    public int objectiveID;
    const int START = 0;
    const int CABIN_NOTE_READ = 1;
    const int CULTIST_NOTE_READ = 2;
    const int LOST_FLASHLIGHT_FOUND = 3;
    const int CABIN_AND_CULTIST_NOTE_READ = 4;
    // Start is called before the first frame update
    void Start()
    {
        objectiveID = 0;
    }
    public void changeObjective(int id, string objective)
    {
        if(objective=="" || objectiveID >= id)
        {
            return;
        }
        switch (id)
        {
            case START:
                break;
            case CABIN_NOTE_READ:
                {
                    knife.SetActive(true);
                    Core.Objective.text = objective;
                    return;
                }
            case CULTIST_NOTE_READ:
            case LOST_FLASHLIGHT_FOUND:
                {
                    knife.SetActive(true);
                    Core.Objective.text = objective;
                    monster.SetActive(true);
                    break;
                }



        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public Core Core;
    public GameObject knife;
    public GameObject monster;

    public int objectiveID = 0;
    const int START = 0;
    const int CABIN_NOTE_READ = 1;
    const int CULTIST_NOTE_READ = 2;
    const int LOST_FLASHLIGHT_FOUND = 3;
    const int CABIN_AND_CULTIST_NOTE_READ = 4;
    const int VAN_FOUND = 5;
    const int RADIO_FOUND = 6;

    public bool noteFound = false;
    public bool knifeSet = false;
    public bool cabinBroken = false;
    public bool deerFound = false;
    public bool knifeFound = false;
    public bool vanFound = false;
    public bool campFound = false;

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
                    setKnife();
                    noteFound = true;
                    Core.Objective.text = objective;
                    return;
                }
            case CULTIST_NOTE_READ:
            case LOST_FLASHLIGHT_FOUND:
            case CABIN_AND_CULTIST_NOTE_READ:
            case VAN_FOUND:
            case RADIO_FOUND:
                {
                    knife.SetActive(true);
                    Core.Objective.text = objective;
                    monster.SetActive(true);
                    break;
                }



        }
    }
    public void setKnife()
    {
        if(!knifeSet)
        {
            knife.SetActive(true);
            knifeSet = true;
        }
    }

    public string getClues()
    {
        string result = "";
        if (!noteFound)
            result += "I should hurry up to see my friends!\n";
        else
            result += "I can't believe they argued and left this fast... Maybe they can't be helped\n";

        if (cabinBroken)
            result += "David's cabin looks somewhat empty... and tidy?\n";

        if (deerFound)
            result += "David got into hunting...probably\n";

        if (knifeFound)
            result += "Someone put knife into my car.\n";

        if (vanFound && !campFound)
            result += "Why would someone hide van in a forest?\n";

        if(!vanFound && campFound)
            result += "There is a suspicious camp on a hill. I am not alone out there!\n";

        if (vanFound && campFound)
            result += "There is a suspicious van and camp on a hill. I am not alone out there!\n";
        return result;
    }
}

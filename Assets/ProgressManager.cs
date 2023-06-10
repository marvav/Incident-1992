using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public Core Core;
    public GameObject knife;
    public GameObject monster;
    public GameObject encounters;
    public GameObject murder;
    public VoiceRecordings recordings;
    public AudioClip second_recording;

    const int START = 0;
    const int CABIN_NOTE_READ = 1;
    const int LOCKED_CAVE_FOUND = 2;
    const int LOST_FLASHLIGHT_FOUND = 3;
    const int DEER_FOUND = 4;
    const int VAN_FOUND = 5;
    const int RADIO_FOUND = 6;
    const int FIRST_RECORDING_LISTENED = 7;
    const int REVOLVER_FOUND = 8;
    const int ENCOUNTER_SURVIVED = 9;
    const int SECOND_RECORDING_LISTENED = 10;
    const int BURNED_CAR = 11;
    const int AMMO_AQUIRED = 12;
    const int CAVE_UNLOCKED = 14;

    public bool noteFound = false;
    public bool lockedCaveFound = false;
    public bool monsterFound = false;
    public bool knifeSet = false;
    public bool lostFlashlightFound = false;
    public bool cabinBroken = false;
    public bool revolverFound = false;
    public bool deerFound = false;
    public bool knifeFound = false;
    public bool vanFound = false;
    public bool campFound = false;
    public bool firstRecordingListened = false;
    public bool encounterSurvived = false;
    public bool secondRecordingListened = false;
    public bool carIsBurned = false;
    public bool ammoAquired = false;

    public void changeObjective(int id)
    {
        if(id == CABIN_NOTE_READ && !noteFound)
        {
            if (!knifeFound)
                knife.SetActive(true);
            noteFound = true;
        }
        if(id==LOCKED_CAVE_FOUND && !lockedCaveFound)
        {
            lockedCaveFound = true;
        }
        if(id == LOST_FLASHLIGHT_FOUND && !lostFlashlightFound)
        {
            if (!knifeFound)
                knife.SetActive(true);
            lostFlashlightFound = true;
        }
        if(id== DEER_FOUND && !deerFound)
            deerFound = true;
        if(id== RADIO_FOUND && !campFound)
        {
            monster.SetActive(true);
            if (!knifeFound)
                knife.SetActive(true);
            campFound = true;
        }
        if(id == FIRST_RECORDING_LISTENED && !firstRecordingListened)
        {
            encounters.SetActive(true);
            firstRecordingListened = true;
        }
        if (id == REVOLVER_FOUND)
            revolverFound = true;
        if (id == ENCOUNTER_SURVIVED)
        {
            recordings.NewRecording(second_recording,10);
            encounterSurvived = true;
        }
        if (id == SECOND_RECORDING_LISTENED && !secondRecordingListened)
        {
            secondRecordingListened = true;
            murder.SetActive(true);
        }
        if(id==BURNED_CAR && !carIsBurned)
        {
            carIsBurned= true;
        }
        if(id== AMMO_AQUIRED &&!ammoAquired)
        {
            ammoAquired = true;
        }
    }


    public string getClues()
    {
        string result = "";
        if (!noteFound)
            result += "I should hurry up to see my friends!\n\n";

        if(noteFound && !firstRecordingListened)
            result += "I can't believe they argued and left this fast... Maybe they can't be helped\n\n";

        if (lockedCaveFound)
            result += "The Hájenka cave is locked, but there is light inside?!\n\n";

        if (lostFlashlightFound)
            result += "Can someone be in such a hurry to lose a flashlight at night?\n\n";

        if (monsterFound)
            result += "I feel... breeze, shivers down my spine and... presence? Like in a horror movie before the action happens.\n\n";

        if (cabinBroken)
            result += "David's cabin looks somewhat empty... and tidy?\n\n";

        if (deerFound && !revolverFound)
            result += "David got into hunting...probably\n\n";

        if (revolverFound && !ammoAquired)
            result += "Having a gun is nice, but I'm missing an ammo\n\n";
        if (ammoAquired && !revolverFound)
            result += "Having ammo is nice, but I'm missing a gun\n\n";
        if (ammoAquired && revolverFound)
            result += "My revolver is now loaded\n\n";

        if (knifeFound)
            result += "Someone put knife into my car.\n\n";

        if (!encounterSurvived)
        {
            if (vanFound && !campFound)
                result += "Why would someone hide van in a forest?\n\n";

            if (!vanFound && campFound)
                result += "There is a suspicious camp on a hill.\n\n";

            if (vanFound && campFound)
                result += "There is a suspicious van and camp on a hill.\n\n";
        }
        else
            result += "The killers have a van out there. Why don't they just leave?\n\n";

        if (firstRecordingListened && !encounterSurvived)
            result += "Am I being paranoid or did they talk about me on the radio?!\n\n";

        if (encounterSurvived && !secondRecordingListened)
            result += "I've never been shot at before. I need to know their plans\n\n";

        if (secondRecordingListened && !ammoAquired)
            result += "Did the 'monster' kill one of the guys? I should find out. He said he was at Three...what\n\n";
        if (carIsBurned)
            result += "My car is burned down... \n\n";
        return result;
    }
}

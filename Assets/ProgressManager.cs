using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public Core Core;
    public GameObject WalkieTalkie;
    public GameObject dummyDoor;
    public GameObject ClosedDoor;
    public GameObject knife;
    public GameObject monster;
    public GameObject encounters;
    public GameObject murder;
    public GameObject van;
    public GameObject wellEntrance;
    public monsterFollow monsterStats;
    public WalkieTalkie recordings;
    public int fasterMonsterSpeed = 3;

    const int START = 0;
    const int CABIN_NOTE_READ = 1;
    const int LOCKED_CAVE_FOUND = 2;
    const int LOST_FLASHLIGHT_FOUND = 3;
    const int DEER_FOUND = 4;
    const int TRACKS_FOUND = 5;
    const int RADIO_FOUND = 6;
    const int FIRST_RECORDING_LISTENED = 7;
    const int REVOLVER_FOUND = 8;
    const int ENCOUNTER_SURVIVED = 9;
    const int SECOND_RECORDING_LISTENED = 10;
    const int BURNED_CAR = 11;
    const int AMMO_AQUIRED = 12;
    const int CAVE_UNLOCKED = 14;
    const int VAN_SABOTAGED = 15;
    const int KNIFE_FOUND = 13;
    const int ROPE_FOUND = 16;
    const int WELL_ENTERED = 17;
    const int BURNED_CASETTES_FOUND = 20;
    const int CASETTE_FOUND = 18;
    const int CASETTE_PLAYED = 19;
    const int RADIO_EQUIPMENT_FOUND = 21;
    const int HOLE_FOUND = 24;

    public bool noteFound = false;
    public bool lockedCaveFound = false;
    public bool monsterFound = false;
    public bool knifeSet = false;
    public bool lostFlashlightFound = false;
    public bool cabinBroken = false;
    public bool revolverFound = false;
    public bool deerFound = false;
    public bool knifeFound = false;
    public bool tracksFound = false;
    public bool campFound = false;
    public bool firstRecordingListened = false;
    public bool encounterSurvived = false;
    public bool secondRecordingListened = false;
    public bool carIsBurned = false;
    public bool ammoAquired = false;
    public bool vanSabotaged = false;
    public bool ropeFound = false;
    public bool wellEntered = false;
    public bool casetteFound = false;
    public bool casettePlayed = false;
    public bool burnedCasettesFound = false;
    public bool radioEquipmentFound = false;
    public bool holeFound = false;

    public void changeObjective(int id)
    {
        if(id == CABIN_NOTE_READ && !noteFound)
        {
            dummyDoor.SetActive(false);
            ClosedDoor.SetActive(true);
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
        if (id == TRACKS_FOUND && !tracksFound)
            tracksFound = true;
        if (id == KNIFE_FOUND && !knifeFound)
        {
            monster.SetActive(true);
            knifeFound = true;
        }
        if(id== DEER_FOUND && !deerFound)
            deerFound = true;
        if(id== RADIO_FOUND && !campFound)
        {
            monster.SetActive(true);
            WalkieTalkie.SetActive(true);
            if (!knifeFound)
            {
                knife.SetActive(true);
            }
            campFound = true;
        }
        if(id == FIRST_RECORDING_LISTENED && !firstRecordingListened)
        {
            encounters.SetActive(true);
            firstRecordingListened = true;
        }
        if (id == REVOLVER_FOUND && !revolverFound)
        {
            monster.SetActive(true);
            revolverFound = true;
        }
        if (id == ENCOUNTER_SURVIVED)
        {
            recordings.NextRecording();
            encounterSurvived = true;
            monsterStats.speed = fasterMonsterSpeed;
        }
        if (id == SECOND_RECORDING_LISTENED && !secondRecordingListened)
        {
            secondRecordingListened = true;
            murder.SetActive(true);
            if (!vanSabotaged)
                van.SetActive(false);
        }
        if(id==BURNED_CAR && !carIsBurned)
        {
            carIsBurned= true;
        }
        if(id== AMMO_AQUIRED &&!ammoAquired)
        {
            ammoAquired = true;
        }
        if (id == VAN_SABOTAGED)
        {
            vanSabotaged = true;
        }
        if (id == ROPE_FOUND)
        {
            ropeFound = true;
            wellEntrance.SetActive(true);
        }
        if (id == WELL_ENTERED && !wellEntered)
            wellEntered = true;
        if (id == CASETTE_FOUND && !casetteFound)
            casetteFound = true;
        if (id == CASETTE_PLAYED && !casettePlayed)
        {
            casettePlayed = true;
            monster.SetActive(true);
        }
        if(id== BURNED_CASETTES_FOUND && !burnedCasettesFound)
            burnedCasettesFound = true;
        if (id == RADIO_EQUIPMENT_FOUND && !radioEquipmentFound)
            radioEquipmentFound = true;
        if(id == HOLE_FOUND && !holeFound)
            holeFound = true;
    }


    public string getClues()
    {
        string result = "";
        if (!noteFound)
            result += "I should hurry up to the Hájenka cabin. I don't want to miss the reunion. It's somewhere on the blue trail.\n\n";

        if(noteFound && !firstRecordingListened)
            result += "I can't believe they argued and left this fast... Maybe they can't be helped\n\n";

        if (lockedCaveFound && !ropeFound)
            result += "There is a light on in Hájenka cave. Someone must have been there recently!\n\n";

        if (monsterFound)
            result += "I feel... breeze, shivers down my spine and... presence? Like in a horror movie before the action happens.\n\n";

        if (cabinBroken && !firstRecordingListened)
            result += "David's cabin looks somewhat empty... and tidy?\n\n";
        if (tracksFound && !campFound)
            result += "There are fresh tire tracks in the grass near camp site.\n\n";
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

        if (campFound && !secondRecordingListened)
            result += "I stole a walkie talkie from the creepy camp I found. Maybe I'll hear someone talking.\n\n";
        if (encounterSurvived && !vanSabotaged)
            result += "The killers have a van out there. Why don't they just leave?\n\n";

        if (firstRecordingListened && !encounterSurvived)
            result += "Am I being paranoid or did they talk about me on the radio?!\n\n";

        if (encounterSurvived && !secondRecordingListened)
            result += "I've never been shot at before. I need to know their plans\n\n";

        if (secondRecordingListened && !ammoAquired)
            result += "Did the 'monster' kill one of the guys? I should find out. He said he was at Three...what\n\n";
        if (carIsBurned)
            result += "My car is burned down... \n\n";
        if (vanSabotaged)
            result += "I cut their tires open. Now they can't just run away\n\n";
        if (ropeFound && !wellEntered)
            result += "I've found rope with other climbing equipment. Maybe I could descend somewhere?!\n\n";
        if (wellEntered)
            result += "Who would have thought the old well was secret entrance?! I bet no-one was there for at least 500 years! Except for David I guess...\n\n";
        if (casetteFound && !casettePlayed)
            result += "I found mysterious casette in David's car player. I need to find a way to listen to it.\n\n";
        if (casettePlayed && !wellEntered)
            result += "Oh my God, what was David talking about?! Excavation?! Ice Singing Lady? Entrace hidden with contaminated water note. He can't be serious\n\n";
        if (burnedCasettesFound && !casettePlayed)
            result += "Someone burned a lot of casettes near David's cabin. Why?!\n\n";
        if (radioEquipmentFound && !casettePlayed)
            result += "There is radio equipment in the station on the hill. But it needs electricity\n\n";
        if (lostFlashlightFound && !holeFound)
            result += "Someone must have been in such a hurry he lost a flashlight at night\n\n";
        if (holeFound)
            result += "Someone have been digging near David's cabin very recently\n\n";
        return result;
    }
}

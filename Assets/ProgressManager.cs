using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public Core Core;
    public AudioClip NewNoteSound;
    public GameObject WalkieTalkie;
    public GameObject knife;
    public GameObject encounters;
    public GameObject murder;
    public GameObject van;
    public GameObject wellEntrance;
    public CombinationLock combinationLock;
    public monsterFollow monsterStats;
    public WalkieTalkie recordings;
    public GameObject PhoneBoothCall;
    public float fasterMonsterSpeed = 4.0f;

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
    const int REVOLVER_USED = 23;
    const int LADY_FOUND = 22;
    const int CABIN_ENTERED = 25;
    const int REAL_DAVID_NOTE_FOUND = 26;
    const int BROKEN_LIGTHNING_ROD = 27;
    const int SECOND_CASETTE_PLAYED = 28;
    const int PHONE_BOOTH_CALL = 29;

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
    public bool revolverUsed = false;
    public bool realDavidNoteFound = false;
    public bool ladyFound = false;
    public bool brokenLightningRod = false;
    public bool secondCasettePlayed = false;
    public bool phoneBoothCall = false;

    public bool[] id_list = new bool[50];

    private int clueCount = 29;

    public void changeObjective(int id)
    {
        if (id == 0)
        {
            if (id_list[id] != true)
            {
                id_list[id] = true;
                Core.RollingText.RollText("I should hurry up to the Hajenka cabin. It lies somewhere on the blue trail.", 5, 2);
            }

            return; //Stop
        }

        if (id_list[id] != true)
        {
            Invoke(nameof(MakeNewNoteSound), 2);
        }

        id_list[id] = true;


        if (id == CABIN_NOTE_READ && !noteFound)
        {
            if (!knifeFound)
                knife.SetActive(true);
            noteFound = true;
            if (!realDavidNoteFound)
            {
                Core.RollingText.RollText("What?! David left? Then what the hell am I doing here?.", 1);
            }
            else
            {
                Core.RollingText.RollText("This sounds completely different to the note I found upstairs. Was it even written by the same person?", 1);
            }
        }

        lockedCaveFound = id == LOCKED_CAVE_FOUND;

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
            monsterStats.triggerMonster();
            knifeFound = true;
            Core.RollingText.RollText("I don't remember carrying a buthcer knife in my car...", 1);
        }
        if(id== DEER_FOUND && !deerFound)
            deerFound = true;
        if(id== RADIO_FOUND && !campFound)
        {
            monsterStats.triggerMonster();
            WalkieTalkie.SetActive(true);
            if (!knifeFound)
            {
                knife.SetActive(true);
            }
            campFound = true;
            Core.RollingText.RollText("Portable radio? Alone in the woods? Maybe I'll hear someone talking...", 1);
        }
        if(id == FIRST_RECORDING_LISTENED && !firstRecordingListened)
        {
            encounters.SetActive(true);
            firstRecordingListened = true;
        }
        if (id == REVOLVER_FOUND && !revolverFound)
        {
            monsterStats.triggerMonster();
            revolverFound = true;
            if(revolverFound && ammoAquired)
            {
                Core.RollingText.RollText("I loaded the revolver.", 1);
            }
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
            Core.RollingText.RollText("Did the monster just kill one of the guys?!", 1);
            if (!vanSabotaged)
                van.SetActive(false);
        }
        if(id==BURNED_CAR && !carIsBurned)
        {
            carIsBurned= true;
            Core.RollingText.RollText("Oh my GOD. That was my fucking CAR!", 1);
        }
        if(id== AMMO_AQUIRED &&!ammoAquired)
        {
            ammoAquired = true;
            Core.RollingText.RollText("I don't really feel pity for a guy that tried to shoot me.", 1);
            if (revolverFound && ammoAquired)
            {
                Core.RollingText.RollText("I loaded the revolver.", 10);
            }
        }
        if (id == VAN_SABOTAGED)
        {
            vanSabotaged = true;
            Core.RollingText.RollText("Cutting things open makes me very happy.", 1);
        }
        if (id == ROPE_FOUND)
        {
            ropeFound = true;
            wellEntrance.SetActive(true);
            Core.RollingText.RollText("That's a good 15 meters worth of rope.", 1);
        }
        if (id == WELL_ENTERED && !wellEntered)
        {
            Core.RollingText.RollText("The breeze is so cold.", 5);
            Core.AudioManager.PlayMusic(Core.AudioManager.CaveMusic);
            wellEntered = true;
        }
        if (id == CASETTE_FOUND && !casetteFound)
            casetteFound = true;
        if (id == CASETTE_PLAYED && !casettePlayed)
        {
            casettePlayed = true;
            monsterStats.triggerMonster();
            Core.RollingText.RollText("Did David discover something that's worth a lot of money? Why did he sound so paranoid?", 1);
        }
        if(id== BURNED_CASETTES_FOUND && !burnedCasettesFound)
            burnedCasettesFound = true;
        if (id == RADIO_EQUIPMENT_FOUND && !radioEquipmentFound)
        {
            Core.RollingText.RollText("Radio? Maybe I'll hear someone talking...", 1);
            radioEquipmentFound = true;
        }
        if(id == HOLE_FOUND && !holeFound)
            holeFound = true;
        revolverUsed = id == REVOLVER_USED && !revolverUsed;

        if (id == REAL_DAVID_NOTE_FOUND)
        {
            Core.RollingText.RollText("David... What have you gotten yourself into?", 1);
            PhoneBoothCall.SetActive(true);
            realDavidNoteFound = true;
            monsterStats.triggerMonster();
        }
        if(id == BROKEN_LIGTHNING_ROD)
        {
            Core.RollingText.RollText("Looks like a solid piece of steel.", 1);
            brokenLightningRod = true;
        }

        if (id == LADY_FOUND)
        {
            Core.RollingText.RollText("What the fuck is this?!", 1);
            ladyFound = true;
        }

        if(id == SECOND_CASETTE_PLAYED && !secondCasettePlayed)
        {
            secondCasettePlayed = true;
            Core.RollingText.RollText("Well, it appears David has gone underground. Should I follow him?", 1);
        }


        if (id == PHONE_BOOTH_CALL && !phoneBoothCall)
        {
            phoneBoothCall = true;
            Core.RollingText.RollText("Well, David did not go to the musem. Something is very wrong here", 2);
        }
    }


    public string getClues()
    {
        string result = "";
        if (!noteFound)
            if (Core.GetLanguage() == 0)
                result += "I should hurry up to the Hajenka cabin. It's somewhere on the blue trail.\n\n";
            else
                result += "Mìl bych si pohnout do Davidovy chaty. Mìlo by to být nìkde na modré trase.\n\n";

        if (noteFound && !realDavidNoteFound)
            if (Core.GetLanguage() == 0)
                result += "Where the hell is David?! Did I actually drive here for nothing?\n\n";
            else
                result += "\n\n";
        if (realDavidNoteFound && !firstRecordingListened)
            if (Core.GetLanguage() == 0)
                result += "What thing did David discover that he risks his life for it?! The note sounded like he was in some kind of danger.\n\n";
            else
                result += "\n\n";
        if (lockedCaveFound && !ropeFound)
            if (Core.GetLanguage() == 0)
                result += "There is a light on in Hájenka cave. Someone must have been there recently!\n\n";
            else
                result += "V jeskyni Hájence je nìjaké svìtlo. Asi tam nìkdo je nebo aspoò byl.\n\n";
        if (cabinBroken && !firstRecordingListened)
            if (Core.GetLanguage() == 0)
                result += "David's cabin looks somewhat empty... and tidy?\n\n";
            else
                result += "Davidova chata vypadá podivnì poloprázdnì.\n\n";
        if (tracksFound && !campFound)
            if (Core.GetLanguage() == 0)
                result += "There are fresh tire tracks in the grass on red track.\n\n";
            else
                result += "Našel jsem èerstvé stopy kol v trávì na èervené stezce.\n\n";
        if (deerFound && !revolverFound)
            if (Core.GetLanguage() == 0)
                result += "David got into hunting. Maybe he has a hunting lookout nearby.\n\n";
            else
                result += "Vypadá to, že se David zaèal zajímat o lov.\n\n";
        if (revolverFound && !ammoAquired)
            if (Core.GetLanguage() == 0)
                result += "Having a gun is nice, but I'm missing an ammo.\n\n";
            else
                result += "Je super mít zbraò, ale víc bych si ji užil, kdybych mìl náboje.\n\n";
        if (ammoAquired && !revolverFound)
            if (Core.GetLanguage() == 0)
                result += "Having ammo is nice, but I'm missing a gun\n\n";
            else
                result += "Je super mít náboje, ale víc bych si je užil, kdybych mìl taky èím støílet.\n\n";
        if (ammoAquired && revolverFound && !revolverUsed)
            if (Core.GetLanguage() == 0)
                result += "My revolver is now loaded\n\n";
            else
                result += "Mùj revolver je teï pøipraven ke støelbì.\n\n";

        if (knifeFound && !encounterSurvived)
            if (Core.GetLanguage() == 0)
                result += "Someone put knife into my car.\n\n";
            else
                result += "Nìkdo mi schoval do auta nùž.\n\n";
        if(encounterSurvived && knifeFound)
            if (Core.GetLanguage() == 0)
                result += "Why would these mad fuckers put knife in my car?\n\n";
            else
                result += "Proè by mi ti vrahouni schovávali do auta nùž?\n\n";

        if (campFound && !secondRecordingListened)
            if (Core.GetLanguage() == 0)
                result += "I stole a portable radio from the creepy camp I found. I should listen closely.\n\n";
            else
                result += "Šlohnul jsem vysílaèku z toho podivného táboøištì s dodávkou. Tøeba nìkoho uslyším.\n\n";
        if (encounterSurvived && !vanSabotaged)
            if (Core.GetLanguage() == 0)
                result += "The killers have a van out there. Why don't they just leave?\n\n";
            else
                result += "Proè ti kreténi prostì neodjedou, když tady mají auto?\n\n";

        if (firstRecordingListened && !encounterSurvived)
            if (Core.GetLanguage() == 0)
                result += "Am I being paranoid or did they talk about me on the radio?!\n\n";
            else
                result += "Jsem jenom paranoidní, nebo se teï právì 2 cápci s vysílaèkama bavili o mnì?!\n\n";

        if (encounterSurvived && !secondRecordingListened)
            if (Core.GetLanguage() == 0)
                result += "I've never been shot at before. I need to know their plans\n\n";
            else
                result += "Ještì nikdy na mì nikdo nestøílel... Co když nìco udìlali Davidovi a Brandonovi\n\n";

        if(phoneBoothCall && !secondCasettePlayed)
        {
            result += "David did not go to the museum. Then he must be somewhere around, but where?!\n\n";
        }

        if (secondRecordingListened && !ammoAquired)
            if (monsterFound)
            {
                if (Core.GetLanguage() == 0)
                    result += "Did the 'monster' kill one of the guys? I should find out. He said he was at Three...what\n\n";
                else
                    result += "Opravdu teï to monstrum zabilo jednoho z tìch vrahù?. Øíkal že je u Tøí...cože\n\n";
            }
            else
            {
                if (Core.GetLanguage() == 0)
                    result += "Did something kill one of the guys? I should find out. He said he was at Three...what\n\n";
                else
                    result += "Opravdu teï nìco zabilo jednoho z tìch vrahù?. Øíkal že je u Tøí...cože\n\n";
            }
        if (carIsBurned)
            if (Core.GetLanguage() == 0)
                result += "My car is burned down... \n\n";
            else
                result += "Vyhoøelo mi auto... \n\n";
        if (vanSabotaged)
            if (Core.GetLanguage() == 0)
                result += "I cut their tires open. Now they can't just run away\n\n";
            else
                result += "Pøeøezal jsem jim pneumatiky. Teï se odtud jen tak nedostanou\n\n";
        if (ropeFound && !wellEntered)
            if (Core.GetLanguage() == 0)
                result += "I've found rope and other climbing equipment. Maybe I could descend somewhere?!\n\n";
            else
                result += "Našel jsem horolezecké lano a další vybavení. Možná bych ho mohl nìjak využít...\n\n";
        if (wellEntered)
            if (Core.GetLanguage() == 0)
                result += "Who would have thought the old well is a secret entrance?! I bet no-one was there for at least 500 years! Except for David I guess...\n\n";
            else
                result += "Kdo by si pomyslel, že ta stará studna je tajným vchodem. Vsadil bych se, že tu nikdo nebyl alespoò 500 let! Kromì Davida teda...\n\n";
        if (casetteFound && !casettePlayed)
            if (Core.GetLanguage() == 0)
                result += "I found mysterious casette in David's car player. I need to find a way to listen to it.\n\n";
            else
                result += "Našel jsem podezøelou kazetu v Davidovì starém autì. Možná bych si ji mìl nìjak pøehrát.\n\n";
        if (casettePlayed && !wellEntered)
            if (Core.GetLanguage() == 0)
                result += "Oh my God, what was David talking about?! Excavation?! Ice Singing Lady? Entrace hidden with contaminated water note. He can't be serious\n\n";
            else
                result += "Proboha, o èem to sakra David mluvil? Výzkum? Dáma ze Zpívaného Ledu? Tajný vchod maskovaný zkazkou o kontaminované vodì?! To nemùže myslet vážnì!\n\n";
        if (casettePlayed && !ladyFound)
            if (Core.GetLanguage() == 0)
                result += "The code on the casette I played was "+ combinationLock.getCode() + "\n\n";
            else
                result += "Proboha, o èem to sakra David mluvil? Výzkum? Dáma ze Zpívaného Ledu? Tajný vchod maskovaný zkazkou o kontaminované vodì?! To nemùže myslet vážnì!\n\n";
        if (burnedCasettesFound && !casettePlayed)
            if (Core.GetLanguage() == 0)
                result += "Someone burned a lot of casettes near David's cabin. Why?!\n\n";
            else
                result += "Nìkdo v lese spálil spoustu kazetek i s rádiem. Proè?\n\n";
        if (radioEquipmentFound && !casettePlayed)
            if (Core.GetLanguage() == 0)
                result += "There is radio equipment in the station on the hill. But it needs electricity\n\n";
            else
                result += "V rádiové stanici je funkèní vybavení, ale potøebuje elektøinu\n\n";
        if (lostFlashlightFound && !holeFound)
            if (Core.GetLanguage() == 0)
                result += "Someone must have been in such a hurry he lost a flashlight at night\n\n";
            else
                result += "Nìkdo musel mít tak naspìch, že ztratil baterku... V noci?!\n\n";
        if (holeFound)
            if (Core.GetLanguage() == 0)
                result += "Someone has been digging near David's cabin very recently. The soil is fresh.\n\n";
            else
                result += "Nìkdo v lese vykopal podezøele velkou díru. Je èerstvá.\n\n";
        if (secondCasettePlayed)
        {
            result += "Now I know where to find David. Well, not exactly, but I know it's somewhere underground.\n\n";
        }
        return result;
    }

    public int getFoundCluesCount()
    {
        int count = 0;
        foreach(bool clue in id_list)
        {
            count += clue ? 1 : 0;
        }
        return count;
    }
    public int AllClueCount() {
        return clueCount;
    }

    public int playedCasettesCount()
    {
        return (casettePlayed ? 1 : 0) + (secondCasettePlayed ? 1 : 0);
    }

    void MakeNewNoteSound()
    {
        Core.GeneralAudio.clip = NewNoteSound;
        Core.GeneralAudio.Play();
    }
}

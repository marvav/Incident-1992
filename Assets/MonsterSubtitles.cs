using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Core_Utils;

public class MonsterSubtitles : MonoBehaviour
{
    public string[] phrases;
    public monsterFollow monster;
    public TMP_Text subtitle;
    public RectTransform subtitle_position;
    private int width = Screen.width;
    private int height= Screen.height;

    void Update()
    {
        if (rand.Next(0, monster.GetMonsterDistance()) == 1)
        {
            subtitle.text = phrases[rand.Next(0, phrases.Length)];
            subtitle_position.anchoredPosition = new Vector3(rand.Next(-width, width), rand.Next(-height, height), 0);
        }
        else
            subtitle.text = "";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static Core_Utils;

public class StaticNoiseUIAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int particleSize = 5;
    public int widthRange = 0;
    public int heightRange = 0;
    public float hoverGain = 0.05f;
    //public float speed = 1.0f;
    public GameObject Particles;
    public bool isText = true;
    private List<RectTransform> images = new List<RectTransform>();
    private RectTransform transform;
    private TMP_Text text;
    private float scale;
    private bool animationStart = false;
    private float delay;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<RectTransform>();
        scale = transform.localScale.x;
        if (widthRange == 0)
            widthRange = (int)transform.sizeDelta.x / 2;
        if (heightRange == 0)
            heightRange = (int)transform.sizeDelta.y / 2;
        //delay = Time.realtimeSinceStartup;
        if (isText)
            text = GetComponent<TMP_Text>();

        foreach (GameObject image in CountChildren(Particles))
            images.Add(image.GetComponent<RectTransform>());
    }

    // Update is called once per frame
    void Update()
    {
        if (animationStart)
        {
            //delay = Time.realtimeSinceStartup;
            foreach (RectTransform image in images)
            {
                image.sizeDelta = new Vector2(rand.Next(particleSize, particleSize * 2), rand.Next(particleSize, particleSize * 2));
                int random_x = rand.Next((int)(transform.anchoredPosition.x - widthRange), (int)(transform.anchoredPosition.x + widthRange));
                int random_y = rand.Next((int)(transform.anchoredPosition.y - heightRange), (int)(transform.anchoredPosition.y + heightRange));
                image.anchoredPosition = new Vector3(random_x, random_y, 0);
            }
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Particles.SetActive(true);
        Particles.transform.SetParent(this.transform, false);
        Particles.transform.localPosition = new Vector2(-this.transform.localPosition.x, -this.transform.localPosition.y);
        animationStart = true;
        if(isText)
            text.fontStyle = (FontStyles)FontStyle.Bold;
        else
            transform.localScale = new Vector3(transform.localScale.x + hoverGain, transform.localScale.y + hoverGain, transform.localScale.z + hoverGain);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Particles.SetActive(false);
        animationStart = false;
        if (isText)
            text.fontStyle = (FontStyles)FontStyle.Normal;
        else
            transform.localScale = new Vector3(scale, scale, scale);
    }
}

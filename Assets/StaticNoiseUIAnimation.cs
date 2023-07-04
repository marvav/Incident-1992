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
    public GameObject Particles;
    public bool makeTextBold = true;
    private List<RectTransform> images = new List<RectTransform>();
    private RectTransform transform;
    private TMP_Text text;
    private bool animationStart = false;
    // Start is called before the first frame update
    void Start()
    {
        if (makeTextBold)
            text = GetComponent<TMP_Text>();

        transform = GetComponent<RectTransform>();
        foreach (GameObject image in CountChildren(Particles))
            images.Add(image.GetComponent<RectTransform>());
    }

    // Update is called once per frame
    void Update()
    {
        if (animationStart)
        {
            foreach (RectTransform image in images)
            {
                image.sizeDelta = new Vector2(rand.Next(particleSize, particleSize * 2), rand.Next(particleSize, particleSize * 2));
                int random_x = rand.Next((int)(transform.anchoredPosition.x - transform.sizeDelta.x / 2), (int)(transform.anchoredPosition.x + transform.sizeDelta.x/2));
                int random_y = rand.Next((int)(transform.anchoredPosition.y - transform.sizeDelta.y / 2), (int)(transform.anchoredPosition.y + transform.sizeDelta.y/2));
                image.anchoredPosition = new Vector3(random_x, random_y, 0);
            }
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Particles.SetActive(true);
        Particles.transform.parent = this.transform;
        animationStart = true;
        if(makeTextBold)
            text.fontStyle = (FontStyles)FontStyle.Bold;
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Particles.SetActive(false);
        animationStart = false;
        if (makeTextBold)
            text.fontStyle = (FontStyles)FontStyle.Normal;
    }
}

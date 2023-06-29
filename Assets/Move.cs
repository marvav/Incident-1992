using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Move : MonoBehaviour, IPointerClickHandler
{
    public GameObject obj;
    public AudioSource sound;
    public Vector3 movement;
    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 1)
        {
            sound.Play();
            obj.transform.Rotate(movement.x, movement.y, movement.z);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Move : MonoBehaviour, IPointerClickHandler
{
    public GameObject obj;
    public AudioSource sound;
    public Vector3 movement;
    public int index;
    public CombinationLock Lock;
    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        switch (clickCount)
        {
            case 1:
                MoveOne();
                break;
        }
    }

    public void MoveOne()
    {
        sound.Play();
        obj.transform.Rotate(movement.x, movement.y, movement.z);
        if (movement.y > 0)
            Lock.changeDigit(index, -1);
        else
            Lock.changeDigit(index, 1);
    }


}

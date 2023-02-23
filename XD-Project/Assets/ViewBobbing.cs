using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class ViewBobbing : MonoBehaviour
{
    int count = 0;
    Player playerbody;
    // Start is called before the first frame update

void Start()
    {
        playerbody = GetComponentInParent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        if (playerbody.IsPlayerMoving())
        {
            switch (count)
            {
                case 0:
                case 1:
                    transform.position += new Vector3(0.1f, 0, 0.1f);
                    break;
                case 2:
                case 3:
                    transform.position += new Vector3(-0.1f, 0, 0.1f);
                    break;
                case 4:
                case 5:
                    transform.position += new Vector3(0.1f, 0, -0.1f);
                    break;
                case 6:
                case 7:
                    transform.position += new Vector3(-0.1f, 0, -0.1f);
                    break;
                case 8:
                    count = 0;
                    break;

            }
            count += 1;
        }

    }
}

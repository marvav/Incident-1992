using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionAnimation : MonoBehaviour
{
    public GameObject Gate;
    public int initial_rotation;
    public int desired_rotation;
    private bool play = true;
    void OnEnable()
    {
        play = true;
        Quaternion target = Quaternion.Euler(0, initial_rotation, 0);
        Gate.transform.rotation = Quaternion.Slerp(Gate.transform.rotation, target, Time.deltaTime);
    }
    void Update()
    {
        if (play)
        {
            if (Gate.transform.rotation.y > desired_rotation)
            {
                Quaternion target = Quaternion.Euler(0, -Time.deltaTime, 0);

                // Dampen towards the target rotation
                Gate.transform.rotation = Quaternion.Slerp(Gate.transform.rotation, target, Time.deltaTime);
            }
            else
                play = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            play = false;
        }
    }
}
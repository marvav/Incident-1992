using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class monsterFollow : MonoBehaviour
{
    CharacterController charControl;
    public MeshRenderer eyes;
    public Light flashlight;
    public Transform followTransform;
    public GameObject death;

    public int speed;
    public float gravityScale;
    public bool follow;
    public int respawnDistance;
    public Vector3[] spawnPlaces;

    private System.Random rand;
    private float distance;
    private Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        charControl = gameObject.GetComponent<CharacterController>();
        rand = new System.Random();
        lastPosition = followTransform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(follow)
        {
            distance = Vector3.Distance(followTransform.position, transform.position);
            if (distance < 0.3f)
            {
                death.SetActive(true);
                Time.timeScale = 0;
                ToggleCursor();
                return;
            }
            if (distance > respawnDistance)
            {
                if(rand.Next(0,10) == 1) //Chance to spawn directly behind player
                {
                    followTransform.position = followTransform.position + new Vector3(-50, 0, 0);
                }
                else //Spawns on one of locations
                {
                    followTransform.position = spawnPlaces[rand.Next(0, spawnPlaces.Length)];
                }
            }
            //Debug.Log(GetComponent<Collider>());
            ChangeVisibility(distance);
            Move();
        }
    }

    void ChangeVisibility(float distance)
    {
        if (distance < 15)
        {
            eyes.enabled = true;
        }
        else
        {
            eyes.enabled = !flashlight.enabled;
        }
    }
    void Move()
    {
        //distance = Vector3.Distance(new Vector3(transform.position.x, lastPosition.y, transform.position.z), transform.position);
        charControl.Move(transform.up * gravityScale * Time.deltaTime);
        transform.LookAt(followTransform);
        charControl.Move(transform.forward * Time.deltaTime * speed);
        lastPosition = transform.position;
    }

}

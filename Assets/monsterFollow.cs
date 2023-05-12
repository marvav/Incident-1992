using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterFollow : MonoBehaviour
{
    CharacterController charControl;
    public Transform followTransform;
    public float speed = 2f;
    public float gravityScale = -2f;
    public bool follow = true;
    // Start is called before the first frame update
    void Start()
    {
        charControl = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(follow)
        { 
            transform.LookAt(followTransform);
            charControl.Move(transform.forward * Time.deltaTime * speed);
            charControl.Move(transform.up * gravityScale * Time.deltaTime);
        }
    }

}

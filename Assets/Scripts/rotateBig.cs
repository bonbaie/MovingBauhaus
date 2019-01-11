using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateBig : MonoBehaviour {


    public float rotSpeed;
    public float zRotation;
    public float waitTime;

    [HideInInspector]
    public bool playerOnPlatform = false;

    private bool rotateTriangle = false;
    private float remainingWaitTime;

    Quaternion startRot;
    Quaternion desiredRot;

    private void Start()
    {
        remainingWaitTime = waitTime;
        startRot = transform.rotation;
    }

    void Update()
    {

        desiredRot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, zRotation);

        if (playerOnPlatform == true)
        {
            rotateTriangle = true;
        }
        else if (transform.rotation == desiredRot && playerOnPlatform == false)
        {
            rotateTriangle = false;
        }

        if (rotateTriangle == true)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
        }
        else if (rotateTriangle == false)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, startRot, rotSpeed * Time.deltaTime); ;
        }


    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        playerOnPlatform = true;
    //        remainingWaitTime = waitTime;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (remainingWaitTime > 0)
    //    {
    //        remainingWaitTime -= Time.deltaTime;
    //    }
    //    else
    //    {
    //        playerOnPlatform = false;
    //    }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateByPlayer : MonoBehaviour {


    public float rotSpeed;
    public float zRotation;
    public float waitTime;
    public Transform player;
    public Transform playerLock;

    [HideInInspector]
    public bool playerOnPlatform = false;

    private bool rotateTriangle = false;
    private Vector3 offset;
    private Vector3 lastRot;
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

        if (playerOnPlatform == true && transform.rotation != desiredRot)
        {
            rotateTriangle = true;
        }

        else if (transform.rotation.eulerAngles == lastRot)
        {
            rotateTriangle = false;          
        }

        if (rotateTriangle == true)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
            remainingWaitTime = waitTime;
        }
        else if (rotateTriangle == false && playerOnPlatform == false)
        {
            remainingWaitTime -= Time.deltaTime;
            if (remainingWaitTime <= 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, startRot, rotSpeed * Time.deltaTime);
            }

        }

        lastRot = transform.rotation.eulerAngles;
    }

    private void LateUpdate()
    {
        if (rotateTriangle == true)
        {
            Debug.Log(rotateTriangle);
            player.transform.position = playerLock.transform.position;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            remainingWaitTime = waitTime;
       }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerOnPlatform = false;

    }
}

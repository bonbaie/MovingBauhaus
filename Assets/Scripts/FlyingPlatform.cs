using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlatform : MonoBehaviour {

    public Transform player;
    public GameObject borders;

    public float flyingSpeed;
    public float yPosition;
    public float waitTime;

    private bool playerOnPlatform = false;
    private bool flying = false;
    private float remainingWaitTime;

    Vector3 startPos;
    Vector3 desiredPos;

    // Use this for initialization
    void Start () {
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z); ;
        remainingWaitTime = waitTime;
    }
	
	// Update is called once per frame
	void Update () {

        desiredPos =  new Vector3(transform.position.x, yPosition, transform.position.z);

        if (playerOnPlatform == true)
        {
            flying = true;
        }
        else if (transform.position.y >= yPosition -0.2f && playerOnPlatform == false)
        {
            Debug.Log("false");
            flying = false;
        }

        if (flying == true)
        {
            if (playerOnPlatform)
            {
                borders.SetActive(true);
            }
            transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * flyingSpeed);
        }
        else if (flying == false)
        {
            if (transform.position.y >= yPosition - 0.2f && remainingWaitTime > 0)
            {
                borders.SetActive(false);
                remainingWaitTime -= Time.deltaTime;
            }
            else if (transform.position.y <= startPos.y + 0.2f)
            {
                borders.SetActive(false);
                remainingWaitTime = waitTime;
            }
            else
            {
                borders.SetActive(false);
                transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime * flyingSpeed);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            player.transform.SetParent(transform);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {    
        playerOnPlatform = false;
        player.transform.SetParent(null);
    }
}

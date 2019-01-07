using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDarlCircle : MonoBehaviour {

    public float DarkCircleGravity = 5.0f;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Physics2D.gravity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DarkCircle")
        {
            Debug.Log("おｋ");
            Physics2D.gravity = new Vector2(0, DarkCircleGravity);
        }

       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DarkCircle")
        {
            Physics2D.gravity = new Vector2(0, -9.8f);
        }
    }
    
}

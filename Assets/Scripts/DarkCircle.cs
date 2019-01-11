using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkCircle : MonoBehaviour {

   // public float darkupspeed;

    void Start()
    {
        //darkrb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ColorCircle")
        {
           
        }
    }
}

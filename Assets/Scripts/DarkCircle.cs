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
            Debug.Log("あたった。");
            //this.gameObject.transform.Translate(0.7f, -3.0f * Time.deltaTime, 0.0f); 
        }
    }
}

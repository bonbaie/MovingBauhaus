using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryangleFalling : MonoBehaviour {

    Animator animatorCy;
	// Use this for initialization
	void Start () {

        this.animatorCy = GetComponent<Animator>();
        this.animatorCy.speed = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == ("Cycle"))
        {
            this.animatorCy.speed = 0.8f;
            Debug.Log("当たってはいる。");
           
        }
    }

    
}

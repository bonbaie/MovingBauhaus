using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JairoTest : MonoBehaviour {

    public float speed = 5.0f;

    void Update()
    {
        

        var dir = Vector2.zero;
        dir.x = Input.acceleration.x;
        dir.y = Input.acceleration.y;

        if(dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        }

        dir *= Time.deltaTime;

        transform.Translate(dir * speed);


    }
}

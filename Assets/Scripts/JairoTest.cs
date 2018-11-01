using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JairoTest : MonoBehaviour {

    private float speed = 10.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var dir = Vector2.zero;

        // ターゲット端末の縦横の表示に合わせてremapする
        dir.x = Input.acceleration.x;
        dir.y = Input.acceleration.y;

        // clamp acceleration vector to the unit sphere
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime;

        // Move object
        transform.Translate(dir * speed);

    }
}

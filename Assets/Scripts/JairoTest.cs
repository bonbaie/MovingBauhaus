using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JairoTest : MonoBehaviour {

    public float PlayerMoveSpeed;//This Variavle Speed Power;速度の変数です。

    void Start()
    {

    }
    void Update()
    {

        var dir = Vector3.zero;

        dir.x = Input.acceleration.x;

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;

        // Move object
        transform.Translate(dir * PlayerMoveSpeed);

    }
}

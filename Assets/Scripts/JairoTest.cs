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

        dir.x = (Input.acceleration.x + Input.acceleration.z) /2;

        if (dir.sqrMagnitude > 1)
           dir.Normalize();

        dir *= Time.deltaTime;
        Debug.Log("X = " + dir.x + " Z = " + dir.z);
        // Move object
        transform.Translate(dir * PlayerMoveSpeed);

    }
}

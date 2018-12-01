using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 5, -10);

        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, 5, -10);
        }

        if (transform.position.x >= 18)
        {
            transform.position = new Vector3(18, 5, -10);
        }
    }
}

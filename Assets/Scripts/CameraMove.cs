using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

<<<<<<< HEAD
    public GameObject player;

    // Use this for initialization
    void Start()
    {
=======
    public float dampTime = 0.125f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    public Transform target;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp (transform.position, desiredPosition,ref velocity, dampTime);
        transform.position = smoothedPosition;
>>>>>>> Simon

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

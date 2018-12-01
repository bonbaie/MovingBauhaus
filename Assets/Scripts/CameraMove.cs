using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float dampTime = 0.125f;
    public Vector3 offset;

    public Transform target;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, dampTime);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }

}

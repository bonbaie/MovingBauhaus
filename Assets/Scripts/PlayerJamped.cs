using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJamped : MonoBehaviour {

    [SerializeField] float jumpPower = 100f;
    bool jump;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        bool jump = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !jump)
        {
            rb.AddForce(Vector2.up * jumpPower);
            jump = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
    }
}

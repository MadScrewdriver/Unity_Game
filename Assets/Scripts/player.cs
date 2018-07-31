using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public Rigidbody rb;
    public int sidemovment = 1000;
    public bool right = false, left = false;
    public int forward = 1000;

	// Use this for initialization
	void Start ()
    {
	}

    void Update()
    {
        if (Input.GetKey("a"))
            left = true;

        if (Input.GetKey("d"))
            right = true;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        rb.AddForce(0, 0, forward * Time.deltaTime);

        if (right)
        {
            rb.AddForce(sidemovment * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            right = false;
        }

        if (left)
        {
            rb.AddForce(-sidemovment * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            left = false;
        }
    }
}

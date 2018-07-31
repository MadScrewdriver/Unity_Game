using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public Transform playerpos;
    public Vector3 camadd;

	// Update is called once per frame
	void Update () {
        transform.position = playerpos.position + camadd;
	}
}

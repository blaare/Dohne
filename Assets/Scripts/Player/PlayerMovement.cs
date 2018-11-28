using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float lateralMovementSpeed = 3f;
    public float longitudinalMovementSpeed = 3f;

    public float yRotationSensitivity = 10f;
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * lateralMovementSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * longitudinalMovementSpeed;

        transform.Translate(new Vector3(x, 0, z));

        var yRotation = Input.GetAxis("Mouse X") * Time.deltaTime * yRotationSensitivity;

        transform.Rotate(new Vector3(0, yRotation, 0));
	}
}

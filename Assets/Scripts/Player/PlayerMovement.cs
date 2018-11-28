using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float lateralMovementSpeed = 3f;
    public float longitudinalMovementSpeed = 3f;

    public float yRotationSensitivity = 10f;

    public float sprintModifier = 5f;
    public float sprintLookModifier = 2f;

    public float smoothing = 5f;

    // Update is called once per frame
    void Update () {
        //if the player gets knocked off center...
       


        var x = Input.GetAxis("Horizontal") * Time.deltaTime * lateralMovementSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * longitudinalMovementSpeed;

        var yRotation = Input.GetAxis("Mouse X") * Time.deltaTime * yRotationSensitivity;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            x *= sprintModifier;
            z *= sprintModifier;
            yRotation *= sprintModifier;
        }

        transform.Translate(new Vector3(x, 0, z));

        transform.Rotate(new Vector3(0, yRotation, 0));
	}
}

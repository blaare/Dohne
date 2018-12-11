using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    public Transform topPosition;
    private Vector3 originalPosition;
    private Vector3 goTo;
    public float pauseTime;
    private float startMovingTime;
    public float speed = 2f;
    private bool goingUp = true;

    private void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (startMovingTime < Time.time)
        {
            goTo = goingUp ? topPosition.position : originalPosition;

            transform.position = Vector3.MoveTowards(transform.position, goTo, speed * Time.deltaTime);

            if (transform.position == goTo)
            {
                startMovingTime = Time.time + pauseTime;
                goingUp = !goingUp;
            }
        }


	}
}

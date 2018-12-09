using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardDoor : Door {


    public override void Open(GameObject player)
    {
        if (!open && !opening)
        {
            opening = true;

            GetComponent<AudioSource>().Play();

        }
    }

    // Update is called once per frame
    void Update () {
        if (opening)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, destination.transform.position, openingSpeed);
            if(door.transform.position == destination.transform.position)
            {
                open = true;
                opening = false;
            }
        }
	}
}

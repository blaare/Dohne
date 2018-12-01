using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardDoor : Door {

    public string doorType;

    public override void Open(GameObject player)
    {
        if(player.GetComponent<KeyCardManager>().HasKeyCard(doorType))
            opening = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, destination.transform.position, openingSpeed);
            if (door.transform.position == destination.transform.position)
            {
                open = true;
                opening = false;
            }
        }
    }
}

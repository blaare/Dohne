using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var player = GameObject.Find("Player");
        player.transform.position = transform.position;
        player.transform.rotation = transform.rotation;

        player.GetComponent<KeyCardManager>().RemoveKeyCards();
	}

}

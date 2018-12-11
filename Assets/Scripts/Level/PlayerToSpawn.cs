using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("Player").transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

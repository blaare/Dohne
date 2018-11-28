using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Blaster currentBlaster;
	// Update is called once per frame

    void Start()
    {

    }

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            currentBlaster.Fire();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentBlaster.Reload();
        }
	}
}

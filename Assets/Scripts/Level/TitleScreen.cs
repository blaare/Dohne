﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        Cursor.visible = true;
        DontDestroyOnLoad(this);
        var player = GameObject.Find("Player");

        if (player != null)
            Destroy(player); 
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHider : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!Application.isEditor)
        {
            Cursor.visible = false;
        }
    }
}

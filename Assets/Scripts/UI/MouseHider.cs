using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHider : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!Application.isEditor)
        {
            HIDE_MOUSE();
        }
    }
    

    public static void SHOW_MOUSE()
    {
        Cursor.visible = true;
    }

    public static void HIDE_MOUSE()
    {
        Cursor.visible = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyPlayerPrefs : MonoBehaviour {

    public CanvasScaler scaler;

    void Update()
    {
        if (PlayerPrefs.HasKey("UI-Scale"))
        {
            scaler.scaleFactor = PlayerPrefs.GetFloat("UI-Scale");
        }
    }
}

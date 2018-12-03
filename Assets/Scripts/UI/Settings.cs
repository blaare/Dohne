using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {
    public CanvasScaler scaler;

    public void Start()
    {
        if (PlayerPrefs.HasKey("UI-Scale"))
        {
            scaler.scaleFactor = PlayerPrefs.GetFloat("UI-Scale");
        }
    }

    public void IncreaseUIScale(Slider slider)
    {
        scaler.scaleFactor = slider.value;
        PlayerPrefs.SetFloat("UI-Scale", scaler.scaleFactor);
    }
}

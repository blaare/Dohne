using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {
    public CanvasScaler scaler;

    public void IncreaseUIScale(Slider slider)
    {
        scaler.scaleFactor = slider.value;
    }
}

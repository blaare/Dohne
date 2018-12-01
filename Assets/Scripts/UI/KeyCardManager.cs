using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCardManager : MonoBehaviour {

    [Header("Set in Inspector")]
    public Image[] keyCardItems = new Image[3];
    public List<string> keyCardColorsObtained = new List<string>();

    /**
     * Function GotKeyCard
     * Goal:    add the keycarditem to inventory
     */ 
    public void GotKeyCard(KeyCardItem keyCardItem)
    {
        switch (keyCardItem.name)
        {
            case "RedKeyCard":
                keyCardItems[0].sprite = keyCardItem.icon;
                break;
            case "GreenKeyCard":
                keyCardItems[1].sprite = keyCardItem.icon;
                break;
            case "BlueKeyCard":
                keyCardItems[2].sprite = keyCardItem.icon;
                break;
        }
        keyCardColorsObtained.Add(keyCardItem.name);
    }

    /**
     * Function HasKeycard
     * Goal:    return if the keycard is in inventory
     *          this is for use with colored doors
     */ 
    public bool HasKeyCard(string keyCardName)
    {
        return keyCardColorsObtained.Contains(keyCardName);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseItem : Item {

    public string itemToEffectName;
    private bool hasCollided = false;

    public override bool Pickup(GameObject player)
    {

        if (hasCollided)
            return false;
        hasCollided = true;

        if(itemToEffectName == "Health")
        {
            if (player.GetComponent<PlayerDefenseManager>().IncreaseHealth(quantity))
            {
                Debug.Log("Player Healed");
                Destroy(gameObject);
                return false;
            } 
            return true;
        } else 
        {
            if(player.GetComponent<PlayerDefenseManager>().IncreaseArmor(quantity))
            {
                Debug.Log("Player Armor Increased");
                Destroy(gameObject);
                return false;
            }
            return true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseItem : Item {

    public string itemToEffectName;
    private bool hasCollided = false;

    public override void Pickup(GameObject player)
    {

        if (hasCollided)
            return;
        hasCollided = true;
        


        if (itemToEffectName == "Health")
        {
            if (player.GetComponent<PlayerDefenseManager>().IncreaseHealth(quantity))
            {
                Debug.Log("Player Healed");
                GetComponent<AudioSource>().Play();
                MoveFarAway();
                Destroy(gameObject, GetComponent<AudioSource>().clip.length);
                return;
            }
        } else 
        {
            if(player.GetComponent<PlayerDefenseManager>().IncreaseArmor(quantity))
            {
                Debug.Log("Player Armor Increased");
                GetComponent<AudioSource>().Play();
                MoveFarAway();
                Destroy(gameObject, GetComponent<AudioSource>().clip.length);
                return;
            }
        }
    }
}

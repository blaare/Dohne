using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmoItem : Item
{


    public override void Pickup(GameObject player)
    {

        WeaponSelector weaponSelector = player.GetComponent<WeaponSelector>();
        //Make sure that you don't add duplicate weapons to the player's weapons list
        foreach (GameObject weapon in weaponSelector.weapons)
        {
            if (weapon.gameObject.name == "Pistol")
            {
                weapon.GetComponent<Blaster>().IncreaseAmmo(quantity);
                Debug.Log("Increased Ammo Count by " + quantity.ToString());
                Destroy(gameObject);
                return;
            }
        }
    }
    

}

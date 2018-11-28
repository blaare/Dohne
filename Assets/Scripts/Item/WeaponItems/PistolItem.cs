using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolItem : Item
{
    public GameObject pistolPrefab;
    

    public override void Pickup(GameObject player)
    {
        Destroy(gameObject);
        //Get the player's WeaponSelector
        WeaponSelector weaponSelector = player.GetComponent<WeaponSelector>();

        //Make sure that you don't add duplicate weapons to the player's weapons list
        foreach (GameObject weapon in weaponSelector.weapons)
        {
            if(weapon.gameObject.name == "Pistol")
            {
                weapon.GetComponent<Blaster>().IncreaseAmmo(quantity);
                Debug.Log("Increased Ammo Count by " + quantity.ToString());
                return;
            }
        }

        weaponSelector.weapons.Add(pistolPrefab);



        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleItem : Item {
    
    public GameObject rifleBlasterPrefab;

    public override void Pickup(GameObject player)
    {
        Destroy(gameObject); 
        //Get the player's WeaponSelector
        WeaponSelector weaponSelector = player.GetComponent<WeaponSelector>();

        //Make sure that you don't add duplicate weapons to the player's weapons list
        foreach (GameObject weapon in weaponSelector.weapons)
        {
            if (weapon.gameObject.name == "Rifle")
            {
                weapon.GetComponent<Blaster>().IncreaseAmmo(quantity);
                Debug.Log("Increased Ammo Count by " + quantity.ToString());
                return;
            }
        }
        Debug.Log("Picked up Rifle");

        //Make sure the transforms are parented, correctly.
        GameObject weapons = player.transform.GetChild(2).gameObject;
        var newWeapon = Instantiate(rifleBlasterPrefab, weapons.transform);
 
        newWeapon.SetActive(false);
        weaponSelector.weapons.Add(newWeapon);


    }
}

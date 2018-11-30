using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseItem : Item {

    public string weaponName;
    private bool hasCollided = false;

    public override void Pickup(GameObject player)
    {

        if (hasCollided)
            return;
        hasCollided = true;

        WeaponSelector weaponSelector = player.GetComponent<WeaponSelector>();
        //Make sure that you don't add duplicate weapons to the player's weapons list
        foreach (GameObject weapon in weaponSelector.weapons)
        {
            if (weapon.gameObject.name == weaponName)
            {
                if (weapon.GetComponent<Blaster>().IncreaseAmmo(quantity))
                {
                    Destroy(gameObject);
                    Debug.Log("Increased Ammo Count by " + quantity.ToString());
                    return;
                }
                else
                {
                    hasCollided = false;
                    Debug.Log("Max Ammo Reached, Leaving object alone");
                    return;
                }
            }
        }
    }
}

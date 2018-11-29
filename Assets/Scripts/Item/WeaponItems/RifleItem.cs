using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleItem : Item {
    
    public GameObject rifleBlasterPrefab;
    private bool hasCollided = false;

    public override void Pickup(GameObject player)
    {
        if (hasCollided)
            return;
        hasCollided = true;
        //Get the player's WeaponSelector
        WeaponSelector weaponSelector = player.GetComponent<WeaponSelector>();

        //Make sure that you don't add duplicate weapons to the player's weapons list
        foreach (GameObject weapon in weaponSelector.weapons)
        {
            if (weapon.gameObject.name == "Rifle")
            {
                if (weapon.GetComponent<Blaster>().IncreaseAmmo(quantity))
                {
                    Destroy(gameObject);
                    Debug.Log("Increased Ammo Count by " + quantity.ToString());
                    return;
                } else
                {
                    Debug.Log("Max Ammo Reached, Leaving object alone");
                    hasCollided = false;
                    return;
                }
            }
        }
        Destroy(gameObject);
        Debug.Log("Picked up Rifle");

        //Make sure the transforms are parented, correctly.
        player.GetComponent<WeaponSelector>().weaponImages[weaponSelector.weapons.Count].sprite = icon;
        GameObject weapons = player.transform.GetChild(2).gameObject;
        var newWeapon = Instantiate(rifleBlasterPrefab, weapons.transform);
        //newWeapon.transform.localPosition = new Vector3(0, 0, 0);
        newWeapon.name = "Rifle";
        newWeapon.SetActive(false);
        weaponSelector.weapons.Add(newWeapon);


    }

}

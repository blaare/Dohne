using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherItem : Item {

    public GameObject rocketLauncherPrefab;
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
            if (weapon.gameObject.name == "RocketLauncher")
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
        Destroy(gameObject);
        Debug.Log("Picked up RocketLauncher");

        //Make sure the transforms are parented, correctly.
        //player.GetComponent<WeaponSelector>().weaponImages[weaponSelector.weapons.Count].sprite = icon;
        GameObject weapons = player.transform.GetChild(2).gameObject;
        var newWeapon = Instantiate(rocketLauncherPrefab, weapons.transform);
        //newWeapon.transform.localPosition = new Vector3(0, 0, 0);
        newWeapon.name = "RocketLauncher";
        newWeapon.SetActive(false);
        weaponSelector.weapons.Add(newWeapon);


    }
}

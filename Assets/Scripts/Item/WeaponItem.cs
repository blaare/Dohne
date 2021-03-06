﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : Item {

    public GameObject weaponPrefab;
    public string weaponName;
    private bool hasCollided = false;
    public Sprite icon;
    
    

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
            if (weapon.gameObject.name == weaponName)
            {
                if (weapon.GetComponent<Blaster>().IncreaseAmmo(quantity))
                {
                    GetComponent<AudioSource>().Play();
                    MoveFarAway();
                    Destroy(gameObject, GetComponent<AudioSource>().clip.length);
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

        GetComponent<AudioSource>().Play();
        MoveFarAway();
        Destroy(gameObject, GetComponent<AudioSource>().clip.length);
        Debug.Log("Picked up " + weaponName);

        //Make sure the transforms are parented, correctly.
        player.GetComponent<WeaponSelector>().weaponImages[weaponSelector.weapons.Count].sprite = icon;
        GameObject weapons = player.transform.GetChild(2).gameObject;
        var newWeapon = Instantiate(weaponPrefab, weapons.transform);
        //newWeapon.transform.localPosition = new Vector3(0, 0, 0);
        newWeapon.name = weaponName;
        newWeapon.SetActive(false);
        weaponSelector.weapons.Add(newWeapon);
        return;


    }
}

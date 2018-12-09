using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour {

    public Image[] weaponIcons;
    public Image[] weaponImages = new Image[5];
    public List<GameObject> weapons;

    public float hideTime = 5;
    private float nextHideTime;
    public bool changingWeapons = false;

    public int weaponIndex;

	// Use this for initialization
	void Start () {

        for(int i = 0; i < weapons.Count; i++)
        {
            if(i != weaponIndex)
            {
                weapons[i].SetActive(false);
            } else
            {
                SelectWeapon(i);
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
        //SCROLL WHEEL INPUT
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f || Input.GetKeyDown(KeyCode.E))
        {
            DeSelectWeapon(weaponIndex);
            weaponIndex = (weaponIndex + 1) % weapons.Count;
            SelectWeapon(weaponIndex);
            changingWeapons = true;
        }
        else if (d < 0f || Input.GetKeyDown(KeyCode.Q))
        {
            DeSelectWeapon(weaponIndex);
            weaponIndex = (weaponIndex - 1) % weapons.Count;
            if(weaponIndex < 0)
            {
                weaponIndex = weapons.Count - 1;
            }
            SelectWeapon(weaponIndex);
            changingWeapons = true;
        }

        //NUMBERS INPUT
        if(Input.GetKeyDown(KeyCode.Alpha1) && weapons.Count >= 1)
        {
            DeSelectWeapon(weaponIndex);
            weaponIndex = 0;
            SelectWeapon(weaponIndex);
            changingWeapons = true;
        } else if (Input.GetKeyDown(KeyCode.Alpha2) && weapons.Count >= 2)
        {
            DeSelectWeapon(weaponIndex);
            weaponIndex = 1;
            SelectWeapon(weaponIndex);
            changingWeapons = true;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && weapons.Count >= 3)
        {
            DeSelectWeapon(weaponIndex);
            weaponIndex = 2;
            SelectWeapon(weaponIndex);
            changingWeapons = true;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && weapons.Count >= 4)
        {
            DeSelectWeapon(weaponIndex);
            weaponIndex = 3;
            SelectWeapon(weaponIndex);
            changingWeapons = true;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && weapons.Count >= 5)
        {
            DeSelectWeapon(weaponIndex);
            weaponIndex = 4;
            SelectWeapon(weaponIndex);
            changingWeapons = true;

        }


        if(changingWeapons)
        {
            ShowWeaponIcons();

            nextHideTime = Time.time + hideTime;
            changingWeapons = false;
        }

        if(nextHideTime <= Time.time)
        {
            HideWeaponIcons();
        }

    }

    public void HideWeaponIcons()
    {
        for(int i = 0; i < weaponIcons.Length; i++)
        {
            weaponIcons[i].color = new Color(weaponIcons[i].color.r, weaponIcons[i].color.g, weaponIcons[i].color.b, weaponIcons[i].color.a != 0 ? 0.25f : 0);
            weaponImages[i].color = new Color(weaponImages[i].color.r, weaponImages[i].color.g, weaponIcons[i].color.b, 0.25f);
        }
    }

    public void ShowWeaponIcons()
    {
        for (int i = 0; i < weaponIcons.Length; i++)
        {
            weaponIcons[i].color = new Color(weaponIcons[i].color.r, weaponIcons[i].color.g, weaponIcons[i].color.b, weaponIcons[i].color.a != 0 ? 0.75f : 0);
            weaponImages[i].color = new Color(weaponIcons[i].color.r, weaponIcons[i].color.g, weaponIcons[i].color.b, .75f);
        }
    }

    /**
     * Function DeSelectWeapon
     * Goal:    to "unequip" the weapon.
     */ 
    public void DeSelectWeapon(int index)
    {
        weaponIcons[index].color = new Color(1,1,1,0);
        weapons[index].SetActive(false);
    }

    /**
     * Function SelectWeapon
     * Goal:    to "equip" the weapon.
     */ 
    public void SelectWeapon(int index)
    {
        weaponIcons[index].color = new Color(1, 1, 1, .75f); 
        weapons[index].SetActive(true);
        //weapons[index].transform.position = transform.GetChild(2).transform.position;

        //Update what the current weapon is.
        GetComponent<PlayerController>().currentBlaster = weapons[index].GetComponent<Blaster>();
    }

}

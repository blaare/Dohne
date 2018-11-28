using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour {

    public Image[] weapons;

    public int weaponIndex;

	// Use this for initialization
	void Start () {
        weaponIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {

        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            DeSelectWeapon(weaponIndex);
            weaponIndex = (weaponIndex + 1) % weapons.Length;
        }
        else if (d < 0f)
        {
            DeSelectWeapon(weaponIndex);
            weaponIndex = (weaponIndex - 1) % weapons.Length;
            if(weaponIndex < 0)
            {
                weaponIndex = weapons.Length - 1;
            }
        }
        SelectedWeapon(weaponIndex);
	}

    public void DeSelectWeapon(int index)
    {
        weapons[index].color = Color.white;
    }

    public void SelectedWeapon(int index)
    {
        weapons[index].color = Color.black;
    }
}

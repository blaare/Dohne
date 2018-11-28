using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour {

    public Image[] weaponIcons;
    public List<GameObject> weapons;



    public int weaponIndex;

	// Use this for initialization
	void Start () {

        for(int i = 0; i < weapons.Count; i++)
        {
            if(i != weaponIndex)
            {
                weapons[i].SetActive(false);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            DeSelectWeapon(weaponIndex);
            weaponIndex = (weaponIndex + 1) % weapons.Count;
        }
        else if (d < 0f)
        {
            DeSelectWeapon(weaponIndex);
            weaponIndex = (weaponIndex - 1) % weapons.Count;
            if(weaponIndex < 0)
            {
                weaponIndex = weapons.Count - 1;
            }
        }
        SelectWeapon(weaponIndex);
	}

    public void DeSelectWeapon(int index)
    {
        weaponIcons[index].color = Color.white;
        weapons[index].SetActive(false);
    }

    public void SelectWeapon(int index)
    {
        weaponIcons[index].color = Color.black;
        weapons[index].SetActive(true);
        this.GetComponent<PlayerController>().currentBlaster = weapons[index].GetComponent<Blaster>();
    }
}

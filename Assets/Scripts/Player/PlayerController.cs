using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Blaster currentBlaster;
    // Update is called once per frame

    public Text ammoCount;
    public Text ammoInClip;



	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            currentBlaster.Fire();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentBlaster.Reload();
        }

        UpdateUI();
	}

    public void UpdateUI()
    {
        ammoInClip.text = currentBlaster.ammoInClip.ToString();
        ammoCount.text = currentBlaster.currentAmmo.ToString();
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "item")
        {
            collision.gameObject.GetComponent<Item>().Pickup(gameObject);
        } 
    }

}

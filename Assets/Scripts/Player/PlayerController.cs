using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerController : MonoBehaviour {

    

    [Header("Set In Inspector")]
    public Text ammoCount;
    public Text ammoInClip;

    public Text currentHealth;
    public Text currentArmor;


    [Header("Dynamically Set")]
    public Blaster currentBlaster;
    public PlayerDefenseManager playerDefenseManager;
    public static bool gameIsPaused = false;

    void Start()
    {
        playerDefenseManager = GetComponent<PlayerDefenseManager>();
        
    }


	void Update () {
        if (!gameIsPaused)
        {

            if (Input.GetMouseButtonDown(0))
            {
                currentBlaster.Fire();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                currentBlaster.Reload();
            }

            if (Input.GetKeyDown(KeyCode.Escape) && !gameIsPaused)
            {
                GetComponent<PauseScreen>().PauseGame();
                gameIsPaused = true;
            }

            UpdateUI();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused)
            {
                GetComponent<PauseScreen>().ResumeGame();
                gameIsPaused = false;
            }
        }


        
	}

    public void UpdateUI()
    {
        ammoInClip.text     = currentBlaster.ammoInClip.ToString();
        ammoCount.text      = currentBlaster.currentAmmo.ToString();

        currentHealth.text  = playerDefenseManager.health.ToString();
        currentArmor.text   = playerDefenseManager.armor.ToString();
    }


    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "item")
        {
            collider.gameObject.GetComponent<Item>().Pickup(gameObject);
        } 

        if(collider.gameObject.tag == "door")
        {
            collider.gameObject.GetComponent<Door>().Open(gameObject);
        }
    }


}

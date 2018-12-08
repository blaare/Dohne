using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDefenseManager : MonoBehaviour {

    public int armor = 200;
    public const int MAX_ARMOR = 200;
    public int health = 100;
    public const int MAX_HEALTH = 100;

    public Image bloodImage;

    private bool tookDamage;

    void Update()
    {
        if (tookDamage)
        {
            //Add in the damage effect
            Color Opaque = new Color(1, 1, 1, 1);
            bloodImage.color = Color.Lerp(bloodImage.color, Opaque, 20 * Time.deltaTime);
            if (bloodImage.color.a >= 0.8) //Almost Opaque, close enough
            {
                tookDamage = false;
            }
        } else
        {
            Color Transparent = new Color(1, 1, 1, 0);
            bloodImage.color = Color.Lerp(bloodImage.color, Transparent, 20 * Time.deltaTime);
        }
    }

    /**
     * Function TakeDamage
     * Goal:    to handle when the player gets hurt
     */ 
    public void TakeDamage(int amount)
    {

        tookDamage = true;
        //Handle when the player has armor
        if (armor > 0) {

            //If this damage will reduce so much to effect health.
            if(armor - amount < 0)
            {
                amount -= armor;
                armor = 0;
            }
            else
            {
                armor -= amount;
                return;
            }
        }

        //Handle the case of player's health is effected.
        if(health - amount <= 0)
        {
            SceneManager.LoadScene(0);
            return;
        }
        else
        {
            health -= amount;
            Debug.Log("Player Hit");
        }
    }

    /**
     * Function IncreaseHealth
     * Goal:    to increase the player's health by some amount.
     * 
     */ 
    public bool IncreaseHealth(int amount)
    {
        if (health == MAX_HEALTH)
            return false;
        if (health + amount > MAX_HEALTH)
            health = MAX_HEALTH;
        else
            health += amount;
        return true;
    }

    /**
     * Function IncreaseArmor
     * Goal:    to increase the player's armor by some amount
     * 
     */ 
    public bool IncreaseArmor(int amount)
    {
        if (armor == MAX_ARMOR)
            return false;
        if (armor + amount > MAX_ARMOR)
            armor = MAX_ARMOR;
        else
            armor += amount;
        return true;
    }
}

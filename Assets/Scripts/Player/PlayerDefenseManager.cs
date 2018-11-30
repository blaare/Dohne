using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefenseManager : MonoBehaviour {

    public int armor = 200;
    public const int MAX_ARMOR = 200;
    public int health = 100;
    public const int MAX_HEALTH = 100;

    /**
     * Function TakeDamage
     * Goal:    to handle when the player gets hurt
     */ 
    public void TakeDamage(int amount)
    {
        //Handle when the player has armor
        if(armor > 0) {

            //If this damage will reduce so much to effect health.
            if(armor - amount < 0)
            {
                amount -= armor;
            }
            else
            {
                armor -= amount;
                return;
            }
        }

        //Handle the case of player's health is effected.
        if(health - amount < 0)
        {
            Debug.Log("Player Died");
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
    public void IncreaseHealth(int amount)
    {
        if (health + amount > MAX_HEALTH)
            health = MAX_HEALTH;
        else
            health += amount;
    }

    /**
     * Function IncreaseArmor
     * Goal:    to increase the player's armor by some amount
     * 
     */ 
    public void IncreaseArmor(int amount)
    {
        if (armor + amount > MAX_ARMOR)
            armor = MAX_ARMOR;
        else
            armor += MAX_ARMOR;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Blaster : MonoBehaviour {

    public float fireRate;
    public int damagePerShot;
    public string fireAnimationName;

    public int ammoInClip;
    public int clipSize;
    public int currentAmmo;
    public int maxAmmo;
    public float range;

    public ParticleSystem shotParticleSystem;

    public abstract void Fire();

    public abstract void Reload();


    public bool IncreaseAmmo(int amount)
    {
        if (currentAmmo == maxAmmo)
        {
            return false;
        }
        else if (currentAmmo + amount > maxAmmo)
        {
            currentAmmo = maxAmmo;
            return true;
        }
        else
        {
            currentAmmo += amount;
            return true;
        }
    }




}

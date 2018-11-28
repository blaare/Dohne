using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBlaster : Blaster
{
    public GameObject projectile;
    public float bulletSpeed = 20f;
    public Transform bulletSpawn;

    public override void Fire()
    {
        var bullet = (GameObject)Instantiate(
        projectile,
        bulletSpawn.position,
        bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

    public override void Reload()
    {
        //Handle if the user has no ammo
        if (currentAmmo == 0)
        {
            Debug.Log("NO AMMO");
            return;
        }
        //Handle if ammo is still in the clip
        if (ammoInClip > 0)
        {
            int difference = clipSize - ammoInClip;

            //Handle when the amount of ammo left is less than the size of the clip
            if (difference > currentAmmo)
            {
                ammoInClip += currentAmmo;
                currentAmmo = 0;
            }
            else
            {
                ammoInClip = clipSize;
                currentAmmo -= difference;
            }

        }
        //Handle when the amount of ammo left is less than the size of the clip
        else if (currentAmmo - clipSize < 0)
        {
            ammoInClip = currentAmmo;
            currentAmmo = 0;
        }
        //Handle when the amount of ammo left is greater than the size of the clip
        else
        {
            ammoInClip = clipSize;
            currentAmmo -= clipSize;
        }
    }
}

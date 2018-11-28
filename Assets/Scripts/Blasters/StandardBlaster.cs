using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlaster :  Blaster{


    public override void Fire()
    {
        //hit stuff in layer 10
        int layerMask = 1 << 10;

        //This hits everything except layer 10
        //layerMask = ~layerMask;

        if(ammoInClip > 0)
        {
            shotParticleSystem.Stop();
            shotParticleSystem.Play();
            RaycastHit hit;
            if ( Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range ,layerMask))
            {
                hit.collider.gameObject.GetComponent<Enemy>().TakeHit(damagePerShot);
                Debug.Log("HIT SOMETHING :D");
                
            } else
            {
                Debug.Log("MISSED SOMETHING D:");
            }

            //Reduce the number of available ammo
            ammoInClip--;
        } else
        {
            Debug.Log("EMPTY CLIP");

            //Handle Automatic Reloading
            if(currentAmmo > 0)
                Reload();
        }

    }

    public override void Reload()
    {
        //Handle if the user has no ammo
        if(currentAmmo == 0)
        {
            Debug.Log("NO AMMO");
            return;
        }
        //Handle if ammo is still in the clip
        if(ammoInClip > 0)
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
        else if(currentAmmo - clipSize < 0)
        {
            ammoInClip  = currentAmmo;
            currentAmmo = 0;
        }
        //Handle when the amount of ammo left is greater than the size of the clip
        else
        { 
            ammoInClip      = clipSize;
            currentAmmo     -= clipSize;
        }
    }
}

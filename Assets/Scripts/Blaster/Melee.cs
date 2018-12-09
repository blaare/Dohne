using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Blaster {

    public override void Fire()
    {
        //hit stuff in layer 10
        int layerMask = 1 << 10;
        if (GetComponent<Animation>().isPlaying)
            return;

        GetComponent<Animation>().Play(fireAnimationName);

        //This hits everything except layer 10
        //layerMask = ~layerMask;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, layerMask))
        {
            hit.collider.gameObject.GetComponent<Enemy>().TakeHit(damagePerShot);
            Debug.Log("HIT SOMETHING :D");

        }
        else
        {
                Debug.Log("MISSED SOMETHING D:");
        }

    }

    public override void Reload()
    {
        return;
        
    }

}

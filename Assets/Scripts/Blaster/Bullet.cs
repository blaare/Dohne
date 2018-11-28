using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damage;

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        //Perform the health reduction on the enemy
        if(collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeHit(damage);
        }
    }
}

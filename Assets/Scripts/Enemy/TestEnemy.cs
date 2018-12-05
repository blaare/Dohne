using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy {

    public override void TakeHit(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}

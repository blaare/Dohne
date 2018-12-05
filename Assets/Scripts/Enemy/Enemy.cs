using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    public int health;
    public int damagePerHit;
    public int hitsPerMinute;
    public float attackChance;

    public abstract void Die();

    public abstract void TakeHit(int damage);
}

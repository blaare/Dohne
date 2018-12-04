using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Based on this tutorial: https://www.youtube.com/watch?v=ovEIluVrQjY&feature=youtu.be&t=451
public class Robo01 : MonoBehaviour {
    public GameObject ThePlayer;
    public bool chase = false;
    public float SightRange = 20;
    public GameObject TheEnemy;
    public float EnemySpeed = 0.05f;
    public RaycastHit Shot;
    public int health;
    public int damagePerHit;
    public float attackSpeed;
    int layerMask = 1 << 14;

    void Update() {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot, SightRange, layerMask) ||
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out Shot, SightRange, layerMask) ||
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out Shot, SightRange, layerMask)) {
            transform.LookAt(ThePlayer.transform);
            chase = true;
            InvokeRepeating("Attack", 0f, attackSpeed);
        }
        else {
            if (chase) {
                transform.LookAt(ThePlayer.transform);
                TheEnemy.GetComponent<Animation>().Play("Robo1 Run(loop)");
                transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
            }
        }
    }

    public void TakeHit(int damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    public void Attack() {
        TheEnemy.GetComponent<Animation>().Play("Robo1 Attack(loop)");
        ThePlayer.GetComponent<PlayerDefenseManager>().TakeDamage(damagePerHit);
    }

    public void Die() {
        Destroy(gameObject);
    }
}
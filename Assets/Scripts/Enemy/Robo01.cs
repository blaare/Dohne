using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Based on this tutorial: https://www.youtube.com/watch?v=ovEIluVrQjY&feature=youtu.be&t=451
public class Robo01 : Enemy {
    public GameObject ThePlayer;
    public bool chase = false;
    public float attackRange = 20;
    public float sightRange = 30;
    public GameObject TheEnemy;
    public float EnemySpeed = 0.05f;
    public RaycastHit Shot;
    public float attackSpeed = 3;
    int layerMask = 1 << 14;

    void Update() {
        Vector3 targetDir = ThePlayer.transform.position - transform.position;
        float distance = Vector3.Distance(targetDir, transform.forward);
        float angle = Vector3.Angle(targetDir, transform.forward);
        if (angle < 30 && distance < sightRange && !chase) {
            chase = true;
        }
        if (chase) {
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot, attackRange)
                && Shot.transform.tag == "Player"){
                Attack();
            }
            else {
                transform.LookAt(ThePlayer.transform);
                TheEnemy.GetComponent<Animation>().Play("Robo1 Run(loop)");
                transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
            }
        }  
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

    public override void TakeHit(int damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    public override void Attack() {
        TheEnemy.GetComponent<Animation>().Play("Robo1 Attack(loop)");
        ThePlayer.GetComponent<PlayerDefenseManager>().TakeDamage(damagePerHit);
    }
}
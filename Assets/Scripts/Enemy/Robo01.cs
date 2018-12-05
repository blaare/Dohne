using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Based on this tutorial: https://www.youtube.com/watch?v=ovEIluVrQjY&feature=youtu.be&t=451
public class Robo01 : Enemy {
    public GameObject ThePlayer;
    public GameObject TheEnemy;
    RaycastHit Shot;
    private float attackDelayCounter = 0.0f;
    private bool chase = false;
    public float attackRange = 20;
    public float sightRange = 30;
    public float EnemySpeed = 0.05f;
    public float attackDelay = 1.0f;

    void Update() {
        Vector3 targetDir = ThePlayer.transform.position - transform.position;
        float distance = Vector3.Distance(targetDir, transform.forward);
        float angle = Vector3.Angle(targetDir, transform.forward);
        if (angle < 30 && distance < sightRange && !chase) {
            TheEnemy.GetComponent<Animation>().Play("Robo1 Run start");
            chase = true;
        }
        if (chase) {
            transform.LookAt(ThePlayer.transform);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot, attackRange)
                && Shot.transform.tag == "Player"){
                if (Time.time >= attackDelayCounter) {
                    TheEnemy.GetComponent<Animation>().Play("Robo1 Attack(loop)");
                    ThePlayer.GetComponent<PlayerDefenseManager>().TakeDamage(damagePerHit);
                    attackDelayCounter = Time.time + attackDelay;
                }
            }
            else {
                TheEnemy.GetComponent<Animation>().Play("Robo1 Run(loop)");
                transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
            }
        }  
    }

    public override void Die()
    {
        TheEnemy.GetComponent<Animation>().Play("Robo1 Die");
        Destroy(gameObject);
    }

    public override void TakeHit(int damage) {
        TheEnemy.GetComponent<Animation>().Play("Robo1 Getting damage");
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }
}
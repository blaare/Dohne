using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Based on this tutorial: https://www.youtube.com/watch?v=ovEIluVrQjY&feature=youtu.be&t=451
public class EnemyFollow : MonoBehaviour {
    public GameObject ThePlayer;
    public bool chase = false;
    public float TargetDistance;
    public float SightRange = 10;
    public GameObject TheEnemy;
    public float EnemySpeed = 0.05f;
    public int MeleeAttackTrigger;
    public RaycastHit Shot;
    int layerMask = 1 << 14;

    void Update() {
        if (chase) {
            EnemySpeed = 0.05f;
            transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
        }
        else {
            EnemySpeed = 0;
            //TheEnemy.GetComponent<Animation>().Play("Idle");
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot, SightRange, layerMask) ||
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out Shot, SightRange, layerMask) ||
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out Shot, SightRange, layerMask)) {
            transform.LookAt(ThePlayer.transform);
            if (MeleeAttackTrigger == 0) {
                //TheEnemy.GetComponent<Animation>().Play("Walking");
                chase = true;
            }
            // if (Shot.distance < AttackRange)
                 //TheEnemy.GetComponent<Animation>().Play("Attacking");
                 //Debug.Log("CUBE IS FIRING AT YOU.");
        }

        if (MeleeAttackTrigger == 1) {
            //TheEnemy.GetComponent<Animation>().Play("MeleeAttacking");
            Debug.Log("CUBE HAS ENGAGED IN MELEE COMBAT.");
        }
    }
    void OnTriggerEnter() {
        chase = false;
        MeleeAttackTrigger = 1;
    }
    void OnTriggerExit() {
        chase = true;
        MeleeAttackTrigger = 0;
    }
}
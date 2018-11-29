using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Based on this tutorial: https://www.youtube.com/watch?v=ovEIluVrQjY&feature=youtu.be&t=451

public class EnemyFollow : MonoBehaviour {

    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedRange = 10;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public int AttackTrigger;
    public RaycastHit Shot;
    RaycastHit Sight;
    public float SightRange = 30;

    void Update() {
        //see stuff in layer 14
        int layerMask = 1 << 14;

        //This hits everything except layer 10
        //layerMask = ~layerMask;

        // If player is within line of sight
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Sight, SightRange, layerMask)) {
            transform.LookAt(ThePlayer.transform);
            Debug.Log("THE CUBE HAS SPOTTED YOU.");
        }

        // If player is within range and can be "heard".
        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Shot)) {
            transform.LookAt(ThePlayer.transform);
            TargetDistance = Shot.distance;
            if (TargetDistance < AllowedRange) {
                EnemySpeed = 0.02f;
                if (AttackTrigger == 0) {
                    //TheEnemy.GetComponent<Animation>().Play("Walking");
                    transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
                }
            }
            else {
                EnemySpeed = 0;
                //TheEnemy.GetComponent<Animation>().Play("Idle");
            }
        }

        if(AttackTrigger == 1) {
            EnemySpeed = 0;
            //TheEnemy.GetComponent<Animation>().Play("Attacking");
            Debug.Log("CUBE HAS ENGAGED IN COMBAT.");
        }
    }

    void OnTriggerEnter() {
        AttackTrigger = 1;
    }

    void OnTriggerExit() {
        AttackTrigger = 0;
    }
}

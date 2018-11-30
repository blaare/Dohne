using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    public GameObject ThePlayer;
    public float DistanceFromHeardTarget;
    public float DistanceFromSeenTarget;
    public float HearingRange = 10;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public int AttackTrigger;
    public RaycastHit Hearing;
    RaycastHit Sight;
    public float SightRange = 20;

    void Update() {
        //see stuff in layer 14
        int layerMask = 1 << 14;

        // If player is within "hearing range" or within line of sight.
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hearing, HearingRange, layerMask) ||
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Sight, SightRange, layerMask)) {

            DistanceFromHeardTarget = Hearing.distance;
            DistanceFromSeenTarget = Sight.distance;

            if (DistanceFromHeardTarget < HearingRange || DistanceFromSeenTarget < SightRange) {
                Debug.Log("CUBE THINKS YOU HAVE TOO MANY DIMENSIONS.");
                transform.LookAt(ThePlayer.transform);
                EnemySpeed = 0.08f;
                if (AttackTrigger == 0) {
                    //TheEnemy.GetComponent<Animation>().Play("Walking");
                    transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
                }
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
        EnemySpeed = 0.02f;
    }
}

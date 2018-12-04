using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Based on this tutorial: https://www.youtube.com/watch?v=ovEIluVrQjY&feature=youtu.be&t=451
public class EnemyFollow : MonoBehaviour {
    public GameObject ThePlayer;
    public bool chase = false;
    public float TargetDistance;
    public float SightRange = 20;
    public GameObject TheEnemy;
    public float EnemySpeed = 0.05f;
    public RaycastHit Shot;
    int layerMask = 1 << 14;

    void Update() {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot, SightRange, layerMask) ||
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out Shot, SightRange, layerMask) ||
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out Shot, SightRange, layerMask)) {
            transform.LookAt(ThePlayer.transform);
            chase = true;
            TheEnemy.GetComponent<Animation>().Play("Robo1 Attack(loop)");
            Debug.Log("CUBE IS FIRING AT YOU.");
        }
        else {
            if (chase) {
                transform.LookAt(ThePlayer.transform);
                TheEnemy.GetComponent<Animation>().Play("Robo1 Run(loop)");
                Debug.Log("CUBE IS CHASING YOU");
                transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
            }
        }
    }
}
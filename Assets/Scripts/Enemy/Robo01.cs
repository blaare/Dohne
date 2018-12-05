using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Pathfinding {
    public class Robo01 : Enemy {
        public GameObject ThePlayer;
        public GameObject TheEnemy;
        public GameObject[] PatrolPoints;
        RaycastHit Shot;
        private bool dead = false;
        private bool stun = false;
        private float attackDelayCounter = 0.0f;
        private int patrolCycleCounter = 0;
        private bool chase = false;
        public float attackRange = 20;
        public float sightRange = 30;
        public float EnemySpeed = 0.05f;
        public float attackDelay = 1.0f;

        private void Start() {
            TheEnemy.GetComponent<Animation>().Play("Robo1 Walk start");
            GetComponent<AIDestinationSetter>().target = PatrolPoints[0].transform;
        }

        void Update() {
            if (!dead) {
                if (!stun) {
                    Vector3 targetDir = ThePlayer.transform.position - transform.position;
                    float distance = Vector3.Distance(targetDir, transform.forward);
                    float angle = Vector3.Angle(targetDir, transform.forward);
                    if (angle < 30 && distance < sightRange && !chase) {
                        TheEnemy.GetComponent<Animation>().Play("Robo1 Walk end");
                        TheEnemy.GetComponent<Animation>().Play("Robo1 Run start");
                        chase = true;
                    }
                    if (chase) {
                        transform.LookAt(ThePlayer.transform);
                        GetComponent<AIDestinationSetter>().target = ThePlayer.transform;
                        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot, attackRange)
                            && Shot.transform.tag == "Player") {
                            GetComponent<AIPath>().canMove = false;
                            if (Time.time >= attackDelayCounter) {
                                TheEnemy.GetComponent<Animation>().Play("Robo1 Attack(loop)");
                                ThePlayer.GetComponent<PlayerDefenseManager>().TakeDamage(damagePerHit);
                                attackDelayCounter = Time.time + attackDelay;
                            }
                        }
                        else {
                            TheEnemy.GetComponent<Animation>().Play("Robo1 Run(loop)");
                            GetComponent<AIPath>().canMove = true;
                        }
                    }
                    else {
                        TheEnemy.GetComponent<Animation>().Play("Robo1 Walk(loop)");
                        if (GetComponent<AIPath>().reachedDestination) {
                            if (PatrolPoints[patrolCycleCounter] != PatrolPoints.Last()) {
                                patrolCycleCounter++;
                            }
                            else {
                                patrolCycleCounter = 0;
                            }
                            GetComponent<AIDestinationSetter>().target = PatrolPoints[patrolCycleCounter].transform;
                        }
                    }
                }
                else {
                    TheEnemy.GetComponent<Animation>().Play("Robo1 Getting damage");
                    Invoke("ReleaseStun", .8f);
                }
            }
            else {
                TheEnemy.GetComponent<Animation>().Play("Robo1 Die");
                Invoke("Die", 0.82f);
            }
        }

        void ReleaseStun() {
            stun = false;
        }

        void Die() {
            Destroy(gameObject);
        }

        public override void TakeHit(int damage) {
            health -= damage;
            stun = true;
            chase = true;
            if (health <= 0) {
                dead = true;
            }
        }
    }
}
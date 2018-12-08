using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Pathfinding;

public class Enemy : MonoBehaviour {
    public  int                 health;
    public  int                 damagePerHit;
    public  float               attackRange;
    public  float               sightRange;
    public  float               sightFOV;
    public  float               EnemySpeed;
    public  float               attackDelay;
    public  float               stunDuration;
    public  string              patrolAnimation;
    public  string              chaseAnimation;
    public  string              attackAnimation;
    public  string              damageAnimation;
    public  string              dieAnimation;
    public  GameObject          Flash;
    public  GameObject          ThePlayer;
    public  GameObject          TheEnemy;
    public  GameObject[]        PatrolPoints;
    public  AudioSource         patrolSFX;
    public  AudioSource         beginChaseSFX;
    public  AudioSource         chaseSFX;
    public  AudioSource         attackSFX;
    public  AudioSource         dieSFX;
    public  AudioSource         damageSFX;
    private RaycastHit          Shot;
    private Animation           EnemyAnimations;
    private AIDestinationSetter PatrolDestination;
    private AIPath              AI;
    private bool                dead;
    private bool                stun;
    private bool                chase;
    private float               attackDelayCounter;
    private int                 patrolCycleCounter;

    private void Start() {
        EnemyAnimations          = TheEnemy.GetComponent<Animation>();
        AI                       = GetComponent<AIPath>();
        AI.maxSpeed              = EnemySpeed;
        PatrolDestination        = GetComponent<AIDestinationSetter>();
        PatrolDestination.target = PatrolPoints[0].transform;
    }

    private void Update() {
        if (!dead) {
            if (!stun) {
                SightCheck();
                if (chase)
                    ChasePlayer();
                else
                    Patrol();
            }
            else {
                EnemyAnimations.Play(damageAnimation);
                Invoke("ReleaseStun", stunDuration);
            }
        }
        else {
            EnemyAnimations.Play(dieAnimation);
            Invoke("Die", EnemyAnimations.GetClip(dieAnimation).length);
        }
    }

    private void SightCheck() {
        if (!chase) {
            Vector3 targetDir = ThePlayer.transform.position - transform.position;
            float distance = Vector3.Distance(targetDir, transform.forward);
            float angle = Vector3.Angle(targetDir, transform.forward);
            if (angle < sightFOV && distance < sightRange && !chase) {
                patrolSFX.Stop();
                beginChaseSFX.Play();
                chase = true;
            }
        }
    }

    private void ChasePlayer() {
        if (!chaseSFX.isPlaying)
            chaseSFX.Play();
        transform.LookAt(ThePlayer.transform);
        PatrolDestination.target = ThePlayer.transform;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot, attackRange)
            && Shot.transform.tag == "Player") {
            AttackPlayer();
        }
        else {
            EnemyAnimations.Play(chaseAnimation);
            AI.canMove = true;
            attackSFX.Stop();
        }
    }

    private void AttackPlayer() {
        AI.canMove = false;
        chaseSFX.Stop();
        if (Time.time >= attackDelayCounter) {
            attackSFX.Play();
            Flash.SetActive(true);
            Invoke("MuzzleOff", 0.12f);
            EnemyAnimations.Play(attackAnimation);
            ThePlayer.GetComponent<PlayerDefenseManager>().TakeDamage(damagePerHit);
            attackDelayCounter = Time.time + attackDelay;
        }
        else {
            if(!EnemyAnimations.IsPlaying(attackAnimation))
                EnemyAnimations.Play(chaseAnimation);
        }
    }

    private void stopAttackAnimation() {
        EnemyAnimations.Stop(attackAnimation);
    }

    private void Patrol() {
        EnemyAnimations.Play(patrolAnimation);
        if (!patrolSFX.isPlaying)
            patrolSFX.Play();
        if (AI.reachedDestination) {
            if (PatrolPoints[patrolCycleCounter] != PatrolPoints.Last())
                patrolCycleCounter++;
            else
                patrolCycleCounter = 0;
            PatrolDestination.target = PatrolPoints[patrolCycleCounter].transform;
        }
    }

    public void TakeHit(int damage) {
        health -= damage;
        StopAllSounds();
        if (health <= 0) {
            dead = true;
            dieSFX.Play();
        }
        else {
            if (!chase) {
                chase = true;
                beginChaseSFX.Play();
            }
            else {
                damageSFX.Play();
            }
            stun = true;
        }
    }

    private void StopAllSounds() {
        beginChaseSFX.Stop();
        attackSFX.Stop();
        patrolSFX.Stop();
        chaseSFX.Stop();
        damageSFX.Stop();
    }

    private void ReleaseStun() {
        stun = false;
    }

    private void MuzzleOff() {
        Flash.SetActive(false);
    }

    private void Die() {
        Destroy(gameObject);
    }
}

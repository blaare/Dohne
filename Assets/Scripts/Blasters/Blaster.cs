using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Blaster : MonoBehaviour {

    public int fireRate;
    public int damagePerShot;

    public int ammoInClip;
    public int clipSize;
    public int currentAmmo;
    public int maxAmmo;
    public float range;

    public ParticleSystem shotParticleSystem;

    public abstract void Fire();

    public abstract void Reload();




}

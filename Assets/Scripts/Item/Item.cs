using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Item : MonoBehaviour {

    public int quantity;

    public abstract void Pickup(GameObject player);
    
}

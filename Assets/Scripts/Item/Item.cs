using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Item : MonoBehaviour {

    public int quantity;

    public abstract void Pickup(GameObject player);

    void Update()
    {
        transform.Rotate(new Vector3(0, 50 * Time.deltaTime, 0));
    }
    
}

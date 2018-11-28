using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class Item : MonoBehaviour {

    public int quantity;

    public Image icon;

    public abstract void Pickup(GameObject player);

    void Update()
    {
        transform.Rotate(new Vector3(0, 50 * Time.deltaTime, 0));
    }
    
}

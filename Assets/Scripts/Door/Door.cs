using UnityEngine;

public abstract class Door : MonoBehaviour {

    public float openingSpeed;
    public Transform destination;
    public bool open;
    public bool opening;
    public GameObject door;

    public abstract void Open(GameObject player);
	
}

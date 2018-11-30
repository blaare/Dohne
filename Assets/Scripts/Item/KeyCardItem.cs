using UnityEngine;

public class KeyCardItem : Item {

    public Sprite icon;

    public override void Pickup(GameObject player)
    {
        Destroy(gameObject);
        player.GetComponent<KeyCardManager>().GotKeyCard(this);
        
        
    }
}

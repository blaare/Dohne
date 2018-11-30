using UnityEngine;

public class KeyCardItem : Item {

    public Sprite icon;
    private bool hasCollided = false;

    public override void Pickup(GameObject player)
    {
        if (hasCollided)
            return;
        hasCollided = true;
        
        player.GetComponent<KeyCardManager>().GotKeyCard(this);
        Destroy(gameObject);
    }
}

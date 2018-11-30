using UnityEngine;

public class KeyCardItem : Item {

    public Sprite icon;
    private bool hasCollided = false;

    public override bool Pickup(GameObject player)
    {
        if (hasCollided)
            return false;
        hasCollided = true;
        
        player.GetComponent<KeyCardManager>().GotKeyCard(this);
        Destroy(gameObject);
        return true;
    }
}

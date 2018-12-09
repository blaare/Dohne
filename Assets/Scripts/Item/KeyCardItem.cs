using UnityEngine;

public class KeyCardItem : Item {

    public Sprite icon;

    public override void Pickup(GameObject player)
    {
        GetComponent<AudioSource>().Play();
        MoveFarAway();
        Destroy(gameObject, GetComponent<AudioSource>().clip.length);
        

        player.GetComponent<KeyCardManager>().GotKeyCard(this);
        
        
    }
}

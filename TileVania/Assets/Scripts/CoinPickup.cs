using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    // Configuration Parameters
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;
    bool doubleGlictch = true;
    
    // Function that handles when a coin is picked up by the player
    private void OnTriggerEnter2D(Collider2D collision) {
        if(doubleGlictch == true) {
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            Destroy(gameObject);
            doubleGlictch = false;
        }
    }
}

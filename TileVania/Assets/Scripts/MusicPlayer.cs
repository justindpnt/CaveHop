using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Set up for the Singleton upon becoming awake
    private void Awake() {
        SetUpSingleton();
    }

    // Set up for the singleton structure to support the music soundtrack for the game
    private void SetUpSingleton() {
        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }
}

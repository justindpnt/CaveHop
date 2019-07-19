using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    // Configuration parameters
    [SerializeField] float LevelLoadDelay = 2f;
    [SerializeField] float LevelExitSlowMoFactor = 0.2f;

    [SerializeField] AudioClip nextLevelSound;
    [SerializeField] float nextLevelVolume = 1f;

    // Load the next level when the player touches the exit sprite
    private void OnTriggerEnter2D(Collider2D collision) {
        StartCoroutine(LoadNextLevel());
    }

    // The coroutine that loads the next level of the game after a 3 second delay and a slo-mo effect
    IEnumerator LoadNextLevel() {
        Time.timeScale = LevelExitSlowMoFactor;
        AudioSource.PlayClipAtPoint(nextLevelSound, Camera.main.transform.position, nextLevelVolume);
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

}

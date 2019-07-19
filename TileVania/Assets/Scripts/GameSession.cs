using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

     // Configuration Parameters
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;

    // Support for the singleton pattern to support the game session
    private void Awake() {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    // Add an input value to the current score
    public void AddToScore(int pointsToAdd) {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    // Function to handle the player death
    public void ProcessPlayerDeath() {
        if (playerLives > 1) {
            StartCoroutine(TakeLife());
        } else {
            StartCoroutine(ResetGameSession());
        }
    }

    // Reset the player to the beginning of the game, game over
    IEnumerator ResetGameSession() {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    // Subtract a life from the current player count and restart the level
    IEnumerator TakeLife() {
        yield return new WaitForSecondsRealtime(3);
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }
}

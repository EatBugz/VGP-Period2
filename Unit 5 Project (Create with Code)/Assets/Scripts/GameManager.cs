using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public bool gaming = true;
    
    [Header("UI")]
    public int score = 0;
    public GameObject title;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartBtn;

    [Header("Spawn vars")]
    public float spawnRate = 1f;

    [Header("Lives Vars")]
    public int lives = 0;
    public TextMeshProUGUI livesText;

    [Header("Pause Menu")]
    public KeyCode pauseKey;
    public GameObject menu;
    public bool paused = false;

    // pause menu input
    void Update() {
        if (Input.GetKeyDown(pauseKey)) {
            pauseGame();
        }
    }

    // spawns a target for the player
    public IEnumerator spawnTarget() {
        while (gaming) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    // updates the score
    public void updateScore(int add) {
        score += add;
        scoreText.text = "Score: " + score;
    }

    // updates lives
    public void updateLives(int num) {
        lives += num;
        livesText.text = "Lives: " + lives;
        if (lives <= 0) gameOver();
    }

    // pauses the game with a menu
    public void pauseGame() {
        paused = !paused;
        menu.SetActive(paused);

        if (paused) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    // starts the game
    public void startGame(int difficulty) {        
        gaming = true;
        spawnRate /= difficulty;
        StartCoroutine(spawnTarget());
        updateScore(0);
        updateLives(3);
        title.SetActive(false);
    }

    // shows the game over text
    public void gameOver() {
        gaming = false;
        gameOverText.gameObject.SetActive(true);
        restartBtn.gameObject.SetActive(true);
    }

    // restarts the game
    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

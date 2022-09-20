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
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartBtn;

    [Header("Spawn vars")]
    public float spawnRate = 1f;

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

    // starts the game
    public void startGame(int difficulty) {        
        gaming = true;
        spawnRate /= difficulty;
        StartCoroutine(spawnTarget());
        updateScore(0);
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

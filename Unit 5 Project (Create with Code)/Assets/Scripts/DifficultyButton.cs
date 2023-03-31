using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    // vars
    private Button btn;
    private GameManager gM;
    public int difficulty;

    // get stuff
    void Start()
    {
        gM = GameObject.Find("Game Manager").GetComponent<GameManager>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(setDifficulty);
    }

    // sets difficulty
    public void setDifficulty() {
        gM.startGame(difficulty);
    }
}

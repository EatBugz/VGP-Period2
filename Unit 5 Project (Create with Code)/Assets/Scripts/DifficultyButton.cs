using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button btn;
    private GameManager gM;
    public int difficulty;

    // Start is called before the first frame update
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

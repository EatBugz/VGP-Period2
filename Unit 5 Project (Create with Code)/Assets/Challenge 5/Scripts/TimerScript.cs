using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float maxTime;
    private TextMeshProUGUI timerText;
    private float timer;
    private GameManagerX gM;

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTime;
        gM = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        timerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gM.isGameActive) {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + ((int) timer);
        }
        else {
            timerText.text = "Time: 0";
        }

        if (timer <= 0) {
            gM.GameOver();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    private bool fingTime = false;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    // public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        timeRemaining = GameManager.hidingTime;
        GameManager.isHiding = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                if (fingTime)
                {
                    timeRemaining = 0;
                    timerIsRunning = false;
                    GameManager.isGameEnd = true;
                }
                else
                {
                    timeRemaining = GameManager.findingTime;
                    fingTime = true;
                    GameManager.isHiding = false;
                    GameManager.isFinding = true;
                }
            }
        }
        DisplayTime(timeRemaining);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

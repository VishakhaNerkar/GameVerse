using System;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{

    // Start is called before the first frame update

    public TextMeshProUGUI timerText;
    public static string winScreenTimerText;

    private float startTime;
    public static float timeElapsed = 0;
    public float timeTaken = timeElapsed;

    public float timeLeft;
    public bool timerOn = false;
    
    void Start()
    {
        winScreenTimerText = "";
        startTime = Time.time;
        timerOn = true;
    }

    public void RestartTimer ()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerOn) return;

        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
                updateWinScreenTimer();
            } else
            {
                timeLeft = 0;
                timerOn = false;
                SceneManager.LoadScene("Timeup Screen");
            }
        }
       

    }

    public void EndTimer()
    {
        timerOn = false;
    }

    public void updateWinScreenTimer()
    {
       float t = Time.time - startTime;
       timeElapsed = t;
       timeTaken = timeElapsed;

       string minutes = ((int)t / 60).ToString();
       string seconds = ((int)t % 60).ToString();

       if(seconds.Length < 2) seconds = "0" + seconds;
       if(minutes.Length < 2) minutes = "0" + minutes;


        winScreenTimerText = minutes + " : " + seconds ;
       
    }

    public void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}

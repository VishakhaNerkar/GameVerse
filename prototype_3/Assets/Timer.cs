using System;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;


public class Timer : MonoBehaviour
{

    // Start is called before the first frame update
    public Text timerText;
    private float startTime;
    private bool finished = false;
    
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (finished) return;

        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = ((int)t % 60).ToString();



        timerText.text = minutes + " : " + seconds ;

    }

    public void Finish()
    {
        finished = true;
        timerText.color = Color.yellow;
    }
}

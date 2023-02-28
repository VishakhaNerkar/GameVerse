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
    public static float timeElapsed = 0;
    public float timeTaken = timeElapsed;
    
    void Start()
    {
        startTime = Time.time;
    }

    public void RestartTimer ()
    {
        startTime = Time.time;
        CheckpointData checkpointData = gameObject.GetComponent<CheckpointData>();
        if (checkpointData != null)
        {
            checkpointData.lastcpTime = startTime;
            checkpointData.lastcpName = "start";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (finished) return;

        float t = Time.time - startTime;
        timeElapsed = t;
        timeTaken = timeElapsed;

        string minutes = ((int)t / 60).ToString();
        string seconds = ((int)t % 60).ToString();

        if(seconds.Length < 2) seconds = "0" + seconds;
        if(minutes.Length < 2) minutes = "0" + minutes;


        timerText.text = minutes + " : " + seconds ;

    }

    public void EndTimer()
    {
        finished = true;
        timerText.color = Color.yellow;
    }
}

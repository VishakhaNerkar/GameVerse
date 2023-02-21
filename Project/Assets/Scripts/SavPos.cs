using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavPos : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            CheckpointData checkpointData = col.gameObject.GetComponent<CheckpointData>();
            float lastcpTime = checkpointData.getLastcpTime();
            float currentcpTime = Time.time;
            string cpName = gameObject.name;
            checkpointData.updateCheckpointData(currentcpTime, cpName);
            sendCheckpointData(lastcpTime, currentcpTime, cpName);

        }
    }

    void sendCheckpointData(float lastcpTime, float currentcpTime, string cpName) 
    {
        float cpSpendTime = currentcpTime - lastcpTime;

        string minutes = ((int)cpSpendTime / 60).ToString();
        string seconds = ((int)cpSpendTime % 60).ToString();

        if (seconds.Length < 2) seconds = "0" + seconds;
        if (minutes.Length < 2) minutes = "0" + minutes;

        string timeText = minutes + " : " + seconds;

        print(cpName);
        print(timeText);
    }


}

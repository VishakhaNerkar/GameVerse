using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Globalization;
using UnityEngine.Networking;
using System.Diagnostics;
using System.Threading;

public class Finish : MonoBehaviour
{

    [SerializeField]
    public string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSeFdXylIKiPWuHQ2m9hdbRaK1hHstuWulbwfwRq8cb14sOR7w/formResponse";

    public string successStat = "win";
    public long sessionID;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.SendMessage("EndTimer");

            //int currentHealth = other.gameObject.GetComponent<Health>().currentHealth;
            //int maxHealth = other.gameObject.GetComponent<Health>().maxHealth;
            //int livesUsed = maxHealth - currentHealth;

            int attempt = other.gameObject.GetComponent<Health>().attempt;

            float timeTaken = other.gameObject.GetComponent<Timer>().timeTaken;

            successStat = "win";
            sessionID = other.gameObject.GetComponent<Health>().sessionID;
         
            StartCoroutine(Post(sessionID.ToString(), attempt.ToString(), successStat, timeTaken.ToString()));

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private IEnumerator Post(string sessionID, string attempt, string successStat, string timeTaken)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm();
        form.AddField("entry.187399815", sessionID);
        form.AddField("entry.1525527248", attempt);
        form.AddField("entry.721119709", timeTaken);
        form.AddField("entry.504638561", successStat);

        // Send responses and verify result
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                UnityEngine.Debug.Log(www.error);
            }
            else
            {
                UnityEngine.Debug.Log("Form upload complete!");
            }
        }
    }
}


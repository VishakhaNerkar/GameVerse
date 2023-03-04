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
    public GameObject confetti;
    public float nextSceneDelay;
    public static int sceneIndex;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(checkAllPlayersInside())
            {
                confetti.SetActive(true);
                StartCoroutine(LoadNextScence(nextSceneDelay));
            } else
            {
            }
            /*
            other.gameObject.SendMessage("EndTimer");

            int attempt = other.gameObject.GetComponent<Health>().attempt;

            float timeTaken = other.gameObject.GetComponent<Timer>().timeTaken;

            string obstacle1 = GameObject.Find("Obstacle1").GetComponent<SavPos>().obstacle1;
            string obstacle2 = GameObject.Find("Obstacle2").GetComponent<SavPos>().obstacle2;
            string obstacle3 = GameObject.Find("Obstacle3").GetComponent<SavPos>().obstacle3;
            string obstacle4 = GameObject.Find("Obstacle4").GetComponent<SavPos>().obstacle4;

            successStat = "win";
            sessionID = other.gameObject.GetComponent<Health>().sessionID;

            StartCoroutine(Post(sessionID.ToString(), attempt.ToString(), successStat, timeTaken.ToString(), "", "", obstacle1, obstacle2, obstacle3, obstacle4));

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            */
        }
    }

    IEnumerator LoadNextScence(float delayTime = 2f)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("Win Screen");
    }


    private bool checkAllPlayersInside()
    {
        GameObject[] gameCubes = GameObject.FindGameObjectsWithTag("Player");
        Collider collider = GetComponent<Collider>();
        for (int i=0; i<gameCubes.Length; i++)
        {
            Vector3 playerPosition = gameCubes[i].transform.position;

            if(playerPosition.x < collider.bounds.min.x || playerPosition.x > collider.bounds.max.x)
            {
                return false;
            }

            if (playerPosition.z < collider.bounds.min.z - 1.5f || playerPosition.z > collider.bounds.max.z)
            {
                return false;
            }

        }

        return true;
    }

    private IEnumerator Post(string sessionID, string attempt, string successStat, string timeTaken, string x_pos, string z_pos, string obstacle1, string obstacle2, string obstacle3, string obstacle4)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm();
        form.AddField("entry.187399815", sessionID);
        form.AddField("entry.1525527248", attempt);
        form.AddField("entry.721119709", timeTaken);
        form.AddField("entry.504638561", successStat);
        form.AddField("entry.1568785842", x_pos);
        form.AddField("entry.1440234542", z_pos);
        form.AddField("entry.227985466", obstacle1);
        form.AddField("entry.1919252074", obstacle2);
        form.AddField("entry.1373993647", obstacle3);
        form.AddField("entry.1409553061", obstacle4);

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


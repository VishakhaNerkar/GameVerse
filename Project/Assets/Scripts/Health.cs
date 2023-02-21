using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Globalization;
using UnityEngine.Networking;
using System.Diagnostics;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSeFdXylIKiPWuHQ2m9hdbRaK1hHstuWulbwfwRq8cb14sOR7w/formResponse";

    public int maxHealth = 3;
    public int currentHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public string successStat = "fail";
    public long sessionID;
    public int attempt = 1;

    void Start()
    {
        currentHealth = maxHealth;
        sessionID = DateTime.Now.Ticks;
        attempt = 1;

    }

    public void TakeDamage(int amount, Vector3 fallCoordinates)
    {
        currentHealth -= amount;
        successStat = "fail";
        
        float timeTaken = this.gameObject.GetComponent<Timer>().timeTaken;

        string x_pos = fallCoordinates.x.ToString();
        string y_pos = fallCoordinates.y.ToString();
        print(x_pos);
        print(y_pos);

        StartCoroutine(Post(sessionID.ToString(), attempt.ToString(), successStat, timeTaken.ToString()));

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }

        attempt += 1;
    }


    void Update()
    {
        for (int i = 0; i < hearts.Length; i++) {

            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            } else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            } 
            else
            {
                hearts[i].enabled = false;
            }
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

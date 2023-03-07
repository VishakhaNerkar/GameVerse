using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public int levelIndex;
    public string sceneName;

    void Start() {
        levelIndex =  SceneManager.GetActiveScene().buildIndex;
        sceneName = SceneManager.GetActiveScene().name;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(Finish.sceneIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(Finish.sceneIndex);
    }

    public void RestartLevelIndex()
    {
        print("Btn Clicked");
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadLevelSelection()
    {
        SceneManager.LoadScene(1);
    }

    void FixedUpdate() {
        if(sceneName == "Win Screen") {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(Finish.sceneIndex + 1);
            }
        }

        if(sceneName == "Timeup Screen" || sceneName == "NoHealth Screen") {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(Finish.sceneIndex);
            }     

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(1);
            }    


        }
    }

}

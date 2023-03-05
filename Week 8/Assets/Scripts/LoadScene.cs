using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public int levelIndex;

    void Start() {
        levelIndex =  SceneManager.GetActiveScene().buildIndex;
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
}

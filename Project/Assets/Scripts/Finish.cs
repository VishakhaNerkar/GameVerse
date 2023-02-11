using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject Pole;
    public float threshold = 0.1f;
	public GameObject Player;

    private void Update()
    {
        Vector3 polePosition = Pole.transform.position;
        Vector3 playerPosition = Player.transform.position;
		//Debug.Log(polePosition.z,playerPosition.z);

        if (Mathf.Abs(playerPosition.z - polePosition.z) < threshold)
        {
          Player.gameObject.SendMessage("EndTimer");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}


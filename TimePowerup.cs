using UnityEngine;
using System.Collections;

public class TimePowerup : MonoBehaviour {
public int extraTime = 20;

void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Player")) {
        
        GameTimer gameTimer = other.GetComponent<GameTimer>();
        gameTimer.AddTime(extraTime);

       
        Destroy(gameObject);
    }
}

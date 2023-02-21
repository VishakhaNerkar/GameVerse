using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutralize : MonoBehaviour
{

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject playerGameObj = other.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
            PowerUpTags powerUpTags = other.gameObject.GetComponent<PowerUpTags>();
            powerUpTags.EmptyPowerUps();
            playerGameObj.GetComponent<SkinnedMeshRenderer>().material = powerUpTags.GetDefaultMaterial();
            
   
        }
    }
}
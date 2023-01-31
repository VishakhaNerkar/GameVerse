using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public Transform[] spawnLocations;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
        
            other.GetComponent<Renderer>().material.color = GetComponent<SpriteRenderer>().color;


            Vector3 newPosition= spawnLocations[UnityEngine.Random.Range(0, spawnLocations.Length)].position;

            transform.position = new Vector3(newPosition.x, newPosition.y, 0);


            //transform.position = spawnLocations[UnityEngine.Random.Range(0, spawnLocations.Length)].position

            //SpawnObj();
        }
    }

   

    void OnDisable()
    {
        SpawnObj();
    }


    void SpawnObj()
    {
        UnityEngine.Debug.Log("Powerup Generated");
        Instantiate(gameObject, spawnLocations[UnityEngine.Random.Range(0, spawnLocations.Length)]);
    }
}

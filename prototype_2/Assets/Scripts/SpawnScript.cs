using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public Transform[] spawnLocations;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObj();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            SpawnObj();
        }
    }

    void SpawnObj()
    {
        Instantiate(spawnObjects[UnityEngine.Random.Range(0, spawnObjects.Length)], spawnLocations[UnityEngine.Random.Range(0, spawnLocations.Length)]);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class HideoutScript : MonoBehaviour
{
    private GameObject myGameObject;

    // Start is called before the first frame update
    void Start()
    {
        myGameObject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D (Collision2D other) 
    {
        //if (other.gameObject.tag != "Player") return;

        //myGameObject.SetActive(false);

        //Invoke(nameof(RestoreObj), 3.0f);

        //UnityEngine.Debug.Log(other.gameObject.tag);
    }

    void RestoreObj ()
    {
        myGameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Player Has Entered");
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("...");
            myGameObject.GetComponent<Renderer>().enabled = false;
            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Player Has Exited");
            myGameObject.GetComponent<Renderer>().enabled = true;
            //Invoke(nameof(RestoreObj), 3.0f);

        }
    }
}

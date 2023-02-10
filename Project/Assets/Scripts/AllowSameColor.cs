using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowSameColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(other.gameObject.GetComponent<MeshRenderer>().material.color == GetComponent<Renderer>().material.color)
            {
                Debug.Log("Same Color");
                GetComponent<Collider>().isTrigger = true;
            } else
            {
                GetComponent<Collider>().isTrigger = false;
                Debug.Log("Different Color");
            }
        }

    }
}

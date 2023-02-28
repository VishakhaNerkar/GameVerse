using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowSameColor : MonoBehaviour
{

    public Material myMaterial;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            string playerMaterial = other.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.name;
            string gameObjMaterial = myMaterial.name;
            if (gameObjMaterial.Contains(playerMaterial))
            {
                print("Don't Lose Life");
            }
            else
            {
                Vector3 damageCoordinates = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
                print(damageCoordinates);
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                for(int i = 0; i < players.Length; i++)
                {
                    players[i].gameObject.GetComponent<Health>().TakeDamage(1, damageCoordinates);
                }

            }
        }
    }
}

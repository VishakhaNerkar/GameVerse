using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private float moveSpeed = 4;
    private bool movingLeft;
 
    void Start()
    {
        movingLeft = true;
    }
    void Update()
     {
         if (movingLeft == true)
         {
             transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
             if (transform.position.x <= - 1) movingLeft = false;
         }
         else
         {
             transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
             if (transform.position.x >= + 8) movingLeft = true;
         }
     }
     private void OnCollisionEnter(Collision collision)
     {
        if(collision.gameObject.tag=="Player")
        {
            Destroy(collision.gameObject);
        }
     }
}

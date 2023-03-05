using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    void Awake()
    {
        Destroy(gameObject, life);

    }
    void onCollisionEnter(Collision collision)
    {
        print("Player touches bullet");
        Destroy(gameObject);
    }
}

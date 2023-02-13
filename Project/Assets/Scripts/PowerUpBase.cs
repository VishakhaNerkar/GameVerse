using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PowerUpBase : MonoBehaviour
{

    public virtual void OnPickup()
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            Material gameObjMaterial = meshRenderer.material;
            UnityEngine.Debug.Log("Applied Material: " + gameObjMaterial.name);
            
            GameObject rig = other.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject; 
            rig.GetComponent<SkinnedMeshRenderer>().material = gameObjMaterial;

            //OnPickup();
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

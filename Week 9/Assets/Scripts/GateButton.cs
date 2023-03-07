using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gate;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            gameObject.transform.position -= new Vector3(0f, 0.4f, 0f);
            gate.GetComponent<GateScale>().isScale = true;
        }
    }

    void OnTriggerExit(Collider other) {
    if (other.gameObject.tag == "Player") {
            gameObject.transform.position += new Vector3(0f, 0.4f, 0f);
            gate.GetComponent<GateScale>().isScale = false;
        }
    }
}

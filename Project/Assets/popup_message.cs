using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popup_message : MonoBehaviour
{
    public GameObject uiobj;
    // Start is called before the first frame update
    void Start()
    {
        uiobj.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag=="Player")
        {
            uiobj.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(8);
        uiobj.SetActive(false);
    }
}

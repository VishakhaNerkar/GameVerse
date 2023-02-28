using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class RotateGameCube : MonoBehaviour
{
    public GameObject[] gameCubes;
    public float y_RoationAngle;
    public float rotationSpeed;

    // Press Button
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.transform.localScale -= new Vector3(0f, 0.2f, 0f);
            for(int i=0; i<gameCubes.Length; i++)
            {
                StartCoroutine(RotateMe(Vector3.right * 90, 0.3f, gameCubes[i].transform));
            }
        }
    }

    // Release Button
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.transform.localScale += new Vector3(0f, 0.2f, 0f);
            for (int i = 0; i < gameCubes.Length; i++)
            {
                StartCoroutine(RotateMe(Vector3.right * 90, 0.3f, gameCubes[i].transform));
            }
        }
    }


    IEnumerator RotateMe(Vector3 byAngles, float inTime, Transform transform)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, rotationSpeed * t);
            yield return null;
        }
    }


}

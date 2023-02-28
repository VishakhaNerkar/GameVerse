using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class RotateGameCube : MonoBehaviour
{
    public GameObject[] gameCubes;
    public float y_RoationAngle;
    public float rotationSpeed;
    private bool isBtnPressed;

    void Start()
    {
        isBtnPressed = false;
    }

    // Press Button
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isBtnPressed= true;
            gameObject.transform.localScale -= new Vector3(0f, 0.2f, 0f);
            other.gameObject.GetComponent<CharacterControls>().speed -= 3f;
            for(int i=0; i<gameCubes.Length; i++)
            {
                StartCoroutine(RotateMe(Vector3.right * 90, 0.3f, gameCubes[i].transform.GetChild(3).transform));
                RotateCenter(gameCubes[i]);
                
            }
        }
    }

    // Release Button
    void OnTriggerExit(Collider other)
    {
        isBtnPressed = false;
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterControls>().speed += 3f;
            gameObject.transform.localScale += new Vector3(0f, 0.2f, 0f);
            for (int i = 0; i < gameCubes.Length; i++)
            {
                StartCoroutine(RotateMe(Vector3.right * 90, 0.3f, gameCubes[i].transform.GetChild(3).transform));
                RotateCenter(gameCubes[i]);
            }
        }
    }

    void RotateCenter(GameObject gameCube) 
    {
        if(isBtnPressed)
        {
            string frontColor = gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().front;
            string topColor = gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().top;
            string temp = frontColor;
            gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().front = topColor;
            gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().top = temp;
            gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().back = topColor;
            gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().bottom = temp;

            //Material topMaterial = gameCube.transform.GetChild(3).GetChild(2).GetComponent<Renderer>().material;
            //gameCube.transform.GetChild(0).GetComponent<Renderer>().material = topMaterial;
        } else
        {
            string frontColor = gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().front;
            string topColor = gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().top;
            string temp = frontColor;
            gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().front = topColor;
            gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().top = temp;
            gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().back = topColor;
            gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().bottom = temp;
            //Material frontMaterial = gameCube.transform.GetChild(3).GetChild(1).GetComponent<Renderer>().material;
            //gameCube.transform.GetChild(0).GetComponent<Renderer>().material = frontMaterial;
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

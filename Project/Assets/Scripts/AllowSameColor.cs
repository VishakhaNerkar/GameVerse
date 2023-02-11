using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowSameColor : MonoBehaviour
{
	public float fadeTime = 0.5f;
    private Renderer rend;
    private Color originalColor;
    private bool fading;
    // Start is called before the first frame update
    void Start()
    {
		rend = GetComponent<Renderer>();
        originalColor = rend.material.color; 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private IEnumerator FadeOut()
    {
        fading = true;
        float elapsedTime = 0f;
        while (elapsedTime < fadeTime)
        {
            rend.material.color = Color.Lerp(originalColor, Color.clear, elapsedTime / fadeTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
	
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(other.gameObject.GetComponent<MeshRenderer>().material.color == GetComponent<Renderer>().material.color)
            {
                Debug.Log("Same Color");
				if (!fading)
			{
            StartCoroutine(FadeOut());
			}
                GetComponent<Collider>().isTrigger = true;
            } else
            {
                GetComponent<Collider>().isTrigger = false;
                Debug.Log("Different Color");
            }
        }

    }
}

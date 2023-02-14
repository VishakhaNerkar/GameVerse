using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowShrink : MonoBehaviour
{
    public float maxScale = 2.0f;
    public float minScale = 0.5f;
    public float speed = 1.0f;
    public Color minEmissionColor = Color.black;
    public Color maxEmissionColor = Color.white;

    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        float scale = Mathf.PingPong(Time.time * speed, maxScale - minScale) + minScale;
        transform.localScale = new Vector3(scale, scale, scale);
        renderer.material.SetColor("_EmissionColor", Color.Lerp(minEmissionColor, maxEmissionColor, (scale - minScale) / (maxScale - minScale)));
    }
}
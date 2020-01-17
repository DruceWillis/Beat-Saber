using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerper : MonoBehaviour
{
    public float speed = 1.0f;
    public Color startColor;
    public Color endColor;
    float startTime;

    void Start()
    {
        startTime = Time.time;
        // print(this.GetComponent<Renderer>().);
    }


    void Update()
    {
        float t = (Mathf.Sin(Time.time - startTime) * speed);
        var color = Color.Lerp(startColor, endColor, t);
        this.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", color);
    }
}

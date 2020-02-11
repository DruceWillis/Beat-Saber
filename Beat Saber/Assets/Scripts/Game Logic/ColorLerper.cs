using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerper : MonoBehaviour
{
    [SerializeField] Color startColor;
    [SerializeField] Color endColor;
    
    public float speed = 1.0f;
    
    float startTime;

    void Start()
    {
        startTime = Time.time;
    }


    void Update()
    {
        LerpColors();
    }

    private void LerpColors()
    {
        float t = (Mathf.Sin(Time.time - startTime) * speed);
        var color = Color.Lerp(startColor, endColor, t);
        this.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", color);
    }
}

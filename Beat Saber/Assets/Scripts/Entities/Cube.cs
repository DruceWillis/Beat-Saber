using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, ICube, IHittable
{
    public Vector3 SpawnPosition {get; set;}
    public Color color;

    void Start()
    {
        if (SpawnPosition.x == 1)
        {
            this.GetComponent<MeshRenderer>().material = FindObjectOfType<ColorContainer>().blue;
            color = Color.blue;
        }
        else if (SpawnPosition.x == 2)
        {
            if (FindObjectOfType<CubeSpawner>().makeRedColor)
            {
                this.GetComponent<MeshRenderer>().material = FindObjectOfType<ColorContainer>().red;
                color = Color.red;
            }
            else
            {
                this.GetComponent<MeshRenderer>().material = FindObjectOfType<ColorContainer>().blue;
                color = Color.blue;
            }
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = FindObjectOfType<ColorContainer>().red;
            color = Color.red;
        }
    }

    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 12f * Time.deltaTime);
    }

    void OnMouseDown() {
        Destroy(gameObject);    
    }
}

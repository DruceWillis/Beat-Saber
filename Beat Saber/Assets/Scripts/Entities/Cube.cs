using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, ICube
{
    public Vector3 SpawnPosition {get; set;}
    public Color color;

    MeshRenderer meshRenderer;
    ColorContainer colorContainer;

    void Start()
    {
        if (GetComponent<MeshCollider>() != null || GetComponent<BoxCollider>() == null)
        {
            Destroy(this.gameObject, 1f);
            return;
        }
        
        meshRenderer = GetComponent<MeshRenderer>();
        colorContainer = FindObjectOfType<ColorContainer>();
        DecideCubeColor(); 
    }

    void Update()
    {
        MoveCube();
    }

    private void DecideCubeColor()
    {
        if (SpawnPosition.x == 1)
        {
            meshRenderer.material = colorContainer.blue;
            color = Color.blue;
        }
        else if (SpawnPosition.x == 2)
        {
            if (FindObjectOfType<CubeSpawner>().makeMiddleCubeRed)
            {
                meshRenderer.material = colorContainer.red;
                color = Color.red;
            }
            else
            {
                meshRenderer.material = colorContainer.blue;
                color = Color.blue;
            }
        }
        else
        {
            meshRenderer.material = colorContainer.red;
            color = Color.red;
        }
    }

    private void MoveCube()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 6f * Time.deltaTime);
    }
}

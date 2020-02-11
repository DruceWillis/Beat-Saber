using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionRaycast : MonoBehaviour
{
    [SerializeField] GameObject plane;

    void Start()
    {
        
    }


    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            plane.transform.position = selection.position;
            print (selection.name);
        }

    }
}

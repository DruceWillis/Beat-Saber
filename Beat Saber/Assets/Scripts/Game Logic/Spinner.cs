using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public bool rotateRight;

    void Update()
    {
        RotateDecoration();
    }

    private void RotateDecoration()
    {
        if (rotateRight)
        {
            transform.Rotate(Vector3.right * 50f * Time.deltaTime);
        }
        else
            transform.Rotate(Vector3.left * 50f * Time.deltaTime);
    }
}

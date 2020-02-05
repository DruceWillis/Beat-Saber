using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IWall
{

    public int cubesMissed {get; set;}

    void Start()
    {
        cubesMissed = 0;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.GetComponent<Cube>() == null)
            return;
        print("Counter dropped to 0");
        FindObjectOfType<ComboCounter>().counter = 0;
        cubesMissed++;
        Destroy(other.gameObject);
    }
}

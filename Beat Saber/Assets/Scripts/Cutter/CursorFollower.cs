using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollower : MonoBehaviour
{

    void Update()
    {
        followCursor();
    }

    private void followCursor()
    {
        float posX = Input.mousePosition.x;
        float posY = Screen.height / 3;

        float posZ = 3f;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(posX, posY, posZ));
    }

    private void OnDrawGizmos() {
        // Gizmos.DrawWireCube(transform.position, new Vector3(0.001f, 1f, 0.01f) * 2f);
    }
}

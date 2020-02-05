using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollower : MonoBehaviour
{

    Vector3 prevPos;
    Vector3 currPos;
    Vector3 direction;
    Rigidbody rigidbody;
    float width;
    float height;
    float angle;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        width = Screen.width;
        height = Screen.height;
        print(width);
    }

    void Update()
    {
        followCursor();
    }

    private void followCursor()
    {
        // Vector3 newRotation = new Vector3(angle, transform.rotation.y, transform.rotation.z);
        // transform.rotation = Quaternion.Euler(angle, -90f, -90f);

        float posX = Input.mousePosition.x;
        // float posY = Screen.height / 3;
        float posY = Input.mousePosition.y;

        if (posX < width / 3)
            angle = (Mathf.Atan2(posY - Screen.height * 0.49f, posX - Screen.width * 0.31f)) * 180 / Mathf.PI;
        else if (posX > width / 3 && posX < width * 2 / 3)
            angle = (Mathf.Atan2(posY - Screen.height * 0.49f, posX - Screen.width * 0.50f)) * 180 / Mathf.PI;
        else
            angle = (Mathf.Atan2(posY - Screen.height * 0.49f, posX - Screen.width * 0.68f)) * 180 / Mathf.PI;

        transform.rotation = Quaternion.Euler(angle, -90f, -90f);

        // print(angle + 90f);

        float posZ = 2f;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(posX, posY, posZ));

    }

    private void OnDrawGizmos() {
        // Gizmos.DrawWireCube(transform.position, new Vector3(0.001f, 1f, 0.01f) * 2f);
    }
}

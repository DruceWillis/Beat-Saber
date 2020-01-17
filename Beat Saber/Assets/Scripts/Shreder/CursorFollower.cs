using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollower : MonoBehaviour
{
    // Vector3 checkingVectorZ;
    // Vector3 checkingVectorX;


    void Update()
    {
        Cursor cursor = FindObjectOfType<Cursor>();
        // Vector3 pos = new Vector3 ((cursor.point.x - Camera.main.transform.localPosition.x) * 4f + cursor.point.x, cursor.point.y * 4f, cursor.point.z + 1f);
        // Vector3 pos = Input.mousePosition;
        // pos.y = 2f;
        // pos.z = 3f;
        float posX = Input.mousePosition.x;
        // float posY = 350f;
        float posY = Screen.height / 3;

        float posZ = 3f;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(posX, posY, posZ));
        
        // if (cursor.inLowerPart)
        //     transform.eulerAngles = new Vector3(cursor.alpha * 60f, -90, -90);
        // else
        //     transform.eulerAngles = new Vector3(-cursor.alpha * 60f, -90, -90);
        // print(transform.eulerAngles);

        // Vector3 additionVectorY = new Vector3(-Input.GetAxis("Mouse Y") * 5, 0, 0);

        // checkingVectorZ = transform.eulerAngles + additionVectorX;
        // checkingVectorX = transform.eulerAngles + additionVectorY;


        // // Debug.Log(string.Format("Euls: {0}, Add: {1}, CheckZ: {2}", transform.eulerAngles.z, additionVectorX.z, checkingVectorZ.z));

        // if (!(checkingVectorZ.z > 45f && checkingVectorZ.z < 315f))
        //     transform.eulerAngles += additionVectorX;
        

    }

    private void OnDrawGizmos() {
        // Gizmos.DrawWireCube(transform.position, new Vector3(0.001f, 1f, 0.01f) * 2f);
    }
}

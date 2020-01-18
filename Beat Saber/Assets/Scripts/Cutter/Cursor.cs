using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour, ICursor
{
    Camera cam;
    
    public Vector3 point {get; set;}
    public float alpha {get; set;}
    public bool inLowerPart {get; set;}

    Vector2 mousePos;


    void Start()
    {
        point = new Vector3();
        mousePos = new Vector2();
        cam = Camera.main;
    }


    void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
        // Debug.DrawRay(point, transform.TransformDirection(Vector3.forward) * 5, Color.green);
        alpha = Mathf.Abs(Mathf.Atan2(mousePos.y - cam.pixelHeight / 2, mousePos.x - cam.pixelWidth / 2));
        
        if (mousePos.y < cam.pixelHeight / 2)
            inLowerPart = true;
        else
            inLowerPart = false;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        // Gizmos.DrawRay(point, transform.TransformDirection(Vector3.forward) * 5);
    }

    void OnGUI()
    {
        
        Event   currentEvent = Event.current;
        

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        // GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        // GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        // GUILayout.Label("Mouse position: " + mousePos);
        // GUILayout.Label("World position: " + point.ToString("F3"));
        // GUILayout.EndArea();
    }
}

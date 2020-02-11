using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    void Update()
    {
        if (FindObjectOfType<CanvasController>().songWasChosen)
            this.gameObject.SetActive(false);
    }
}

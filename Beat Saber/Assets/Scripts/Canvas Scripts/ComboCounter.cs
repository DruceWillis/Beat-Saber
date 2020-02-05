using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboCounter : MonoBehaviour, IComboCounter
{
    TextMeshProUGUI text;

    public int counter { get; set; }

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        text.text = "\n" + counter;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Accuracy : MonoBehaviour, IAccuracy
{
    TextMeshProUGUI text;

    public int totalHitCounter {get; set;}

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        float accuracy = CalculateAccuracy();
        text.text = "\n" + accuracy + "%";
    }

    float CalculateAccuracy()
    {
        if (totalHitCounter + FindObjectOfType<Wall>().cubesMissed == 0)
            return 0;

        return (totalHitCounter * 100) / (totalHitCounter + FindObjectOfType<Wall>().cubesMissed);
    }
}

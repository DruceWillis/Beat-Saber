using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Accuracy : MonoBehaviour, IAccuracy
{
    TextMeshProUGUI text;

    public int totalHitCounter {get; set;}
    
    float accuracy;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        accuracy = CalculateAccuracy();
        text.text = "\n" + accuracy + "%";
    }

    float CalculateAccuracy()
    {
        if (totalHitCounter + FindObjectOfType<Wall>().cubesMissed == 0)
            return 0;

        var accuracy = (totalHitCounter * 100) / (totalHitCounter + FindObjectOfType<Wall>().cubesMissed);
        return accuracy == null ? 0 : accuracy;
    }
}

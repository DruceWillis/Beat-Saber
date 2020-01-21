using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreMultiplier : MonoBehaviour, IScoreMultiplier
{
    TextMeshProUGUI text;

    public int multiplier {get; set;}

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        multiplier = 1;
    }


    void Update()
    {
        multiplier = (FindObjectOfType<ComboCounter>().counter / 25) + 1;
        text.text = "" + multiplier;
    }
}

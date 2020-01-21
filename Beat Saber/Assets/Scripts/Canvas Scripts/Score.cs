using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour, IScore
{
    TextMeshProUGUI text;

    public int scorePerCube {get; set;}
    public int totalScore {get; set;}
    

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        totalScore = 0;    
        scorePerCube = 10;
    }


    void Update()
    {
        if (totalScore >= 10000 && totalScore < 100000)
            text.text = "______" + "\n " + totalScore;
        else if (totalScore >= 1000 && totalScore < 10000)
            text.text = "______" + "\n  " + totalScore;
        else if (totalScore < 1000 && totalScore >= 100)
            text.text = "______" + "\n   " + totalScore;
        else if (totalScore < 100 && totalScore >= 0)
            text.text = "______" + "\n    " + totalScore;
        else
            text.text = "______" + "\n" + totalScore;
    }

    public void AddPoints()
    {
        totalScore += (scorePerCube * FindObjectOfType<ScoreMultiplier>().multiplier);
    }
}

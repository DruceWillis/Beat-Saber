using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasController : MonoBehaviour
{
    [SerializeField] GameObject chooseSongButton;
    [SerializeField] GameObject audio;
    [SerializeField] GameObject[] gameplayText;

    public bool songWasChosen = false;

    void Update()
    {
        if (songWasChosen)
            ShowScores(true);
        else
            ShowScores(false);

        if (audio.GetComponent<AudioSource>().clip != null)
        {
            chooseSongButton.SetActive(false);
            songWasChosen = true;
        }
    }

    void ShowScores(bool setActive)
    {
        foreach(GameObject text in gameplayText)
            text.gameObject.SetActive(setActive);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PathText : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        var songNAudio = FindObjectOfType<SongNAudio>();

        text.text =
            songNAudio.url + "\n" +
            "\n" +
            (songNAudio.audioSource.clip == null ? "No Clip" : songNAudio.audioSource.time.ToString());
    }
}

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
        text.text = FindObjectOfType<SongNAudio>().path + "\n" + ((FindObjectOfType<SongNAudio>().audioSource.clip == null) ? "\nNo Clip" : FindObjectOfType<SongNAudio>().audioSource.time.ToString());  
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongNAudio : MonoBehaviour
{
    public string path = null;
    private AudioSource audioSource = null;
    bool startedPlaying = false;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        StartCoroutine(LoadSongCoroutine());    
    }

    private IEnumerator LoadSongCoroutine()
    {
        string url = string.Format("file://{0}", path);
        WWW www = new WWW(url);
        yield return www;

        audioSource.clip = www.GetAudioClip(false, true);
        audioSource.Play();
    }

    // void Update()
    // {
    //     if (path == null || startedPlaying)
    //         return;
    //     else
    //     {
    //         startedPlaying = true;
    //         print("STARTING");
    //         StartCoroutine(LoadSongCoroutine());    
    //     }

    // }
}

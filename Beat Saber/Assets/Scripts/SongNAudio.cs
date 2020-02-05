using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SongNAudio : MonoBehaviour
{
    public string path = null;
    public AudioSource audioSource;
    // Action<AudioClip> response;


    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        StartCoroutine(LoadSong());
        
    }

    private IEnumerator LoadSong()
    {
        string url = path;

        var request = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);

        yield return request.SendWebRequest();

        if (!request.isHttpError && !request.isNetworkError)
        {
            audioSource.clip = (DownloadHandlerAudioClip.GetContent(request));
            path += string.Format("\n I got here");
            audioSource.Play();
        }
        else
        {
            Debug.LogErrorFormat("error request [{0}, {1}]", url, request.error);
            path += string.Format("error request [{0}, {1}]", url, request.error);
        }

        // request.Dispose();
    }
}

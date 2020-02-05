using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;


public class SongNAudio : MonoBehaviour
{
    public string url;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(LoadSong());
    }

    private IEnumerator LoadSong()
    {
        using (var request = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.UNKNOWN))
        {
            yield return request.SendWebRequest();
    
            if (!request.isHttpError && !request.isNetworkError)
            {
                audioSource.clip = DownloadHandlerAudioClip.GetContent(request);
                audioSource.Play();
            }
            else
            {
                Debug.LogErrorFormat("error request [{0}, {1}]", url, request.error);
            }
        }
    }
}
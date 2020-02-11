using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendSong : MonoBehaviour
{
    
    public void OnButtonClickSendSong()
    {
        var audioclip = GetComponent<ButtonText>().audioClip;

        FindObjectOfType<AudioSource>().GetComponent<AudioSource>().clip = audioclip;
        FindObjectOfType<AudioSpectrum>().enabled = true;
        // FindObjectOfType<CanvasController>().songWasChosen = true;
    }
}

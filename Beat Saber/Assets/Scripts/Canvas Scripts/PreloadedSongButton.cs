using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PreloadedSongButton : MonoBehaviour
{
    [SerializeField] GameObject loadCustomSongButton;
    [SerializeField] GameObject songButtonsPanel;


    public void OnClickOpenCustomSongs()
    {
        DisableButton();
        
        songButtonsPanel.SetActive(true);
        loadCustomSongButton.SetActive(false);

        // this.gameObject.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        // for (int i = 0; i < this.transform.childCount; i++)
        // {
        //     var child = this.transform.GetChild(i);
        //     if (child.GetComponent<SendSong>() != null)
        //     {
        //         child.gameObject.SetActive(true);
        //         var childPosition = child.gameObject.transform.position;
        //         child.gameObject.transform.position = new Vector3(childPosition.x, (float)(Screen.height / 16 * (16 - i)), childPosition.z);
        //         // print((float)(Screen.height / 10 * (10 - i)));
        //     }
        // }
    }

    void Update()
    {
        if (FindObjectOfType<CanvasController>().songWasChosen)
            DisableButton();
    }

    void DisableButton()
    {
        this.gameObject.GetComponent<Button>().enabled = false;
        this.gameObject.GetComponent<Image>().enabled = false;
        this.gameObject.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
    }
}

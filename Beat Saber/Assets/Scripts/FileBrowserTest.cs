using UnityEngine;
using System.Collections;
using System.IO;
using SimpleFileBrowser;
using UnityEditor;


public class FileBrowserTest : MonoBehaviour
{
	IEnumerator ShowLoadDialogCoroutine()
	{
		yield return FileBrowser.WaitForLoadDialog(false, null, "Load File", "Load");

		if (!FileBrowser.Success)
			yield break;

		var songNAudio = FindObjectOfType<SongNAudio>();

		songNAudio.url = "file://" + FileBrowser.Result;
		//songNAudio.bytes = FileBrowserHelpers.ReadBytesFromFile(FileBrowser.Result);
		songNAudio.enabled = true;
	}

	public void OpenBrowser()
	{
		FileBrowser.SetFilters(
			true, 
			new FileBrowser.Filter("Audio", ".mp3", ".wav")
		);

		FileBrowser.SetDefaultFilter(".mp3");

		StartCoroutine( ShowLoadDialogCoroutine() );
	}

}
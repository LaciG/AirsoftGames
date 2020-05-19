using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class IntroVideoPlayer : MonoBehaviour
{
	public RawImage rawImage;
	public VideoPlayer videoPlayer;
	public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(PlayVideo());
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel("Menu");
		}
    }

	IEnumerator PlayVideo() {
		videoPlayer.Prepare();
		WaitForSeconds waitForSeconds = new WaitForSeconds(1);
		while(!videoPlayer.isPrepared) {
			yield return waitForSeconds;
			break;
		}
		rawImage.texture = videoPlayer.texture;
		videoPlayer.Play();
		audioSource.Play();
		videoPlayer.loopPointReached += CheckOver;
	}

	void CheckOver(UnityEngine.Video.VideoPlayer videoPlayer) {
        Application.LoadLevel("Menu");//the scene that you want to load after the video has ended.
    }
}

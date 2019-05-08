using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class PlayUiVideo : MonoBehaviour
{
    public RawImage uiImage;
    public VideoPlayer uiVideo;
    public AudioSource uiAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StreamVideo());

    }

    IEnumerator StreamVideo()
    {
        uiVideo.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);

        while (!uiVideo.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }

        uiImage.texture = uiVideo.texture;
        uiVideo.Play();
        uiAudio.Play();
    }

}

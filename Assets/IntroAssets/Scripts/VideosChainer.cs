using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideosChainer : MonoBehaviour
{
    // create a public to hold a list of videos
    public List<VideoClip> videos;
    private VideoPlayer videoPlayer;
    private bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        // get the video player component
        videoPlayer = GetComponent<VideoPlayer>();

        // set the video player's clip to the first video in the list
        videoPlayer.clip = videos[0];

        // set the video player's loop point to the end of the video
        videoPlayer.isLooping = false;

        // subscribe to the end reached event
        videoPlayer.loopPointReached += EndReached;

        // assure that the video player is ready to play
        videoPlayer.Prepare();
        if (videoPlayer.isPrepared)
        {
            videoPlayer.Play();
        }
    }

    void Update()
    {
        // if any key is pressed, load the main menu
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (isPlaying == false)
        {
            if (videoPlayer.isPrepared)
            {
                videoPlayer.Play();
                isPlaying = true;
            }
        }
    }

    //end reached
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // get the index of the current video
        int index = videos.IndexOf(videoPlayer.clip);

        // if the index is less than the number of videos in the list
        if (index < videos.Count - 1)
        {
            // set the video player's clip to the next video in the list
            videoPlayer.clip = videos[index + 1];
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }

        // play the video
        videoPlayer.Play();
    }
}

using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StartupVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();
    }

    void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene("MainMenu");
    }
}



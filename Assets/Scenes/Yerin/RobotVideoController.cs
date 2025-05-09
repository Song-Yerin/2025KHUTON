using UnityEngine;
using UnityEngine.Video;

public class RobotVideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject displayObject;

    public void PlayVideo()
    {
        displayObject.SetActive(true);  // 화면 보이게
        videoPlayer.Play();
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
        displayObject.SetActive(false); // 화면 끄기
    }
}

using UnityEngine;
using UnityEngine.Video;

public class RobotVideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject displayObject;

    public void PlayVideo()
    {
        displayObject.SetActive(true);  // ȭ�� ���̰�
        videoPlayer.Play();
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
        displayObject.SetActive(false); // ȭ�� ����
    }
}

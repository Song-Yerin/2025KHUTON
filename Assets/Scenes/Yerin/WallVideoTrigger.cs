using UnityEngine;
using UnityEngine.Video;

public class WallVideoTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer;       // 벽에서 재생될 VideoPlayer
    public Material wallMaterialDefault;  // 흰 벽 머티리얼
    public Material wallMaterialVideo;    // 영상 출력용 머티리얼 (RenderTexture 포함)

    private Renderer wallRenderer;

    void Start()
    {
        wallRenderer = GetComponent<Renderer>();
        wallRenderer.material = wallMaterialDefault; // 시작할 때 흰 벽
    }

    void OnMouseDown()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
            wallRenderer.material = wallMaterialDefault;
            Debug.Log("영상 정지 및 흰 벽 복귀");
        }
        else
        {
            wallRenderer.material = wallMaterialVideo;
            videoPlayer.Play();
            Debug.Log("영상 재생 시작");
        }
    }
}

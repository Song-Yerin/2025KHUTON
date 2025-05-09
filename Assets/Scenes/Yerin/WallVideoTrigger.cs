using UnityEngine;
using UnityEngine.Video;

public class WallVideoTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer;       // ������ ����� VideoPlayer
    public Material wallMaterialDefault;  // �� �� ��Ƽ����
    public Material wallMaterialVideo;    // ���� ��¿� ��Ƽ���� (RenderTexture ����)

    private Renderer wallRenderer;

    void Start()
    {
        wallRenderer = GetComponent<Renderer>();
        wallRenderer.material = wallMaterialDefault; // ������ �� �� ��
    }

    void OnMouseDown()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
            wallRenderer.material = wallMaterialDefault;
            Debug.Log("���� ���� �� �� �� ����");
        }
        else
        {
            wallRenderer.material = wallMaterialVideo;
            videoPlayer.Play();
            Debug.Log("���� ��� ����");
        }
    }
}

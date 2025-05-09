using UnityEngine;
using UnityEngine.Video;

public class WallVideoTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer;       // ������ ����� VideoPlayer
    public Material wallMaterialDefault;  // �� �� ��Ƽ����
    public Material wallMaterialVideo;    // ���� ��¿� ��Ƽ���� (RenderTexture ����)

    private bool hasPlayed = false;

    private Renderer wallRenderer;

    void Start()
    {
        wallRenderer = GetComponent<Renderer>();
        wallRenderer.material = wallMaterialDefault; // ������ �� �� ��
    }

    void OnMouseDown()
    {
        if (!hasPlayed)
        {
            hasPlayed = true;

            wallRenderer.material = wallMaterialVideo; // ��Ƽ���� ��ü
            videoPlayer.Play();                        // ���� ���
            Debug.Log("�� Ŭ����: ���� ��� ����");
        }
    }
}

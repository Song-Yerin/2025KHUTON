using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections.Generic;

public class SeasonInfoPanel : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descText;
    public Image seasonImage;
    public VideoPlayer seasonVideo;

    private Dictionary<string, string> descriptions = new Dictionary<string, string>()
    {
        {"����", "������ ���� ������ �˸��� �����Դϴ�."},
        {"���", "����� ���� ��� ���� ������ �����Դϴ�."},
        // ...
    };

    private Dictionary<string, Sprite> images = new Dictionary<string, Sprite>();
    private Dictionary<string, VideoClip> videos = new Dictionary<string, VideoClip>();

    // �̹���, ���� ��� (Start���� ����ϰų� �ܺο��� �ҷ����� ����)
    public Sprite ipchunImage;
    public Sprite usuImage;
    //public VideoClip ipchunVideo;
    //public VideoClip usuVideo;

    void Start()
    {
        images["����"] = ipchunImage;
        images["���"] = usuImage;
        //videos["����"] = ipchunVideo;
        //videos["���"] = usuVideo;
    }

    public void ShowSeasonInfo(string seasonName)
    {
        titleText.text = seasonName;

        // �ؽ�Ʈ ����
        if (descriptions.ContainsKey(seasonName))
            descText.text = descriptions[seasonName];
        else
            descText.text = "������ �����ϴ�.";

        // �̹��� ǥ��
        if (images.ContainsKey(seasonName))
        {
            seasonImage.sprite = images[seasonName];
            seasonImage.gameObject.SetActive(true);
        }
        else
        {
            seasonImage.gameObject.SetActive(false);
        }

        // ���� ���
        //if (videos.ContainsKey(seasonName))
        //{
        //    seasonVideo.clip = videos[seasonName];
        //    seasonVideo.Play();
        //}
        //else
        //{
        //    seasonVideo.Stop();
        //    seasonVideo.clip = null;
        //}
    }
}

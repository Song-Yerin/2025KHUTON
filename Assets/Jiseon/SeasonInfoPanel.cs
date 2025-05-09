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

    private Dictionary<string, string> displayNames = new Dictionary<string, string>()
    {
        {"����", "���� (ء��)"},
        {"���", "��� (���)"}
        // ...
    };

    private Dictionary<string, string> descriptions = new Dictionary<string, string>()
    {
        {"����", "������ ���� ������ �˸��� �����, ���̿����� ���� ���� �½��� �����ϸ� ��� �غ� �����մϴ�. ���ڳ� ������ �۹��� ������ �����ϰ� ������ �⸣�� �۾��� ���������� �̷�����ϴ�."},
        {"���", "����� ���� ��� �� ���� ���� Ǯ���� �����, ��� ����� ���������� ���õǴ� �ñ��Դϴ�. ����� ���� ����, ����, ���� �� �� �۹��� ���� �غ�� ���� �۹��� ���� ������ �̷�����ϴ�."}
        // ...
    };

    private Dictionary<string, Sprite> images = new Dictionary<string, Sprite>();
    private Dictionary<string, VideoClip> videos = new Dictionary<string, VideoClip>();

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
        ShowSeasonInfo("����"); // ó�� ���� �� �ڵ����� ���� ���� ǥ��
    }
    

    public void ShowSeasonInfo(string seasonKey)
    {
        // ���� ǥ�� (���� ����)
        if (displayNames.ContainsKey(seasonKey))
            titleText.text = displayNames[seasonKey];
        else
            titleText.text = seasonKey;

        // �ؽ�Ʈ ����
        if (descriptions.ContainsKey(seasonKey))
            descText.text = descriptions[seasonKey];
        else
            descText.text = "������ �����ϴ�.";

        // �̹��� ǥ��
        if (images.ContainsKey(seasonKey))
        {
            seasonImage.sprite = images[seasonKey];
            seasonImage.gameObject.SetActive(true);
        }
        else
        {
            seasonImage.gameObject.SetActive(false);
        }

        // ���� ��� (�ּ� ���� �� ����)
        //if (videos.ContainsKey(seasonKey))
        //{
        //    seasonVideo.clip = videos[seasonKey];
        //    seasonVideo.Play();
        //}
        //else
        //{
        //    seasonVideo.Stop();
        //    seasonVideo.clip = null;
        //}
    }
}

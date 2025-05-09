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
        {"입춘", "입춘은 봄의 시작을 알리는 절기입니다."},
        {"우수", "우수는 눈이 녹고 봄비가 내리는 절기입니다."},
        // ...
    };

    private Dictionary<string, Sprite> images = new Dictionary<string, Sprite>();
    private Dictionary<string, VideoClip> videos = new Dictionary<string, VideoClip>();

    // 이미지, 비디오 등록 (Start에서 등록하거나 외부에서 불러오기 가능)
    public Sprite ipchunImage;
    public Sprite usuImage;
    //public VideoClip ipchunVideo;
    //public VideoClip usuVideo;

    void Start()
    {
        images["입춘"] = ipchunImage;
        images["우수"] = usuImage;
        //videos["입춘"] = ipchunVideo;
        //videos["우수"] = usuVideo;
    }

    public void ShowSeasonInfo(string seasonName)
    {
        titleText.text = seasonName;

        // 텍스트 설명
        if (descriptions.ContainsKey(seasonName))
            descText.text = descriptions[seasonName];
        else
            descText.text = "설명이 없습니다.";

        // 이미지 표시
        if (images.ContainsKey(seasonName))
        {
            seasonImage.sprite = images[seasonName];
            seasonImage.gameObject.SetActive(true);
        }
        else
        {
            seasonImage.gameObject.SetActive(false);
        }

        // 영상 재생
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

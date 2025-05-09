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
        {"입춘", "입춘 (立春)"},
        {"우수", "우수 (雨水)"}
        // ...
    };

    private Dictionary<string, string> descriptions = new Dictionary<string, string>()
    {
        {"입춘", "입춘은 봄의 시작을 알리는 절기로, 농촌에서는 밭을 갈고 온실을 점검하며 농사 준비를 시작합니다. 감자나 조생종 작물의 씨앗을 선별하고 모종을 기르는 작업이 본격적으로 이루어집니다."},
        {"우수", "우수는 눈이 녹고 비가 내려 땅이 풀리는 절기로, 농사 기반이 본격적으로 마련되는 시기입니다. 논밭을 갈고 감자, 마늘, 양파 등 봄 작물의 파종 준비와 월동 작물의 생육 관리가 이루어집니다."}
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
        images["입춘"] = ipchunImage;
        images["우수"] = usuImage;
        //videos["입춘"] = ipchunVideo;
        //videos["우수"] = usuVideo;
        ShowSeasonInfo("입춘"); // 처음 시작 시 자동으로 입춘 정보 표시
    }
    

    public void ShowSeasonInfo(string seasonKey)
    {
        // 제목 표시 (한자 포함)
        if (displayNames.ContainsKey(seasonKey))
            titleText.text = displayNames[seasonKey];
        else
            titleText.text = seasonKey;

        // 텍스트 설명
        if (descriptions.ContainsKey(seasonKey))
            descText.text = descriptions[seasonKey];
        else
            descText.text = "설명이 없습니다.";

        // 이미지 표시
        if (images.ContainsKey(seasonKey))
        {
            seasonImage.sprite = images[seasonKey];
            seasonImage.gameObject.SetActive(true);
        }
        else
        {
            seasonImage.gameObject.SetActive(false);
        }

        // 영상 재생 (주석 유지 시 생략)
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

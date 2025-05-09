using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshProUGUI를 사용하기 위해 필요

public class RegionInfoPanel : MonoBehaviour
{
    public TextMeshProUGUI regionTitleText;
    public TextMeshProUGUI cropsText;
    public TextMeshProUGUI methodText;
    public TextMeshProUGUI techText;

    public Image image1;
    public Image image2;

    public Sprite gyeongjuImg1;
    public Sprite gyeongjuImg2;
    public Sprite chungbukImg1;
    public Sprite chungbukImg2;

    public void SetRegionData(string regionName)
    {
        if (regionName == "경상북도_경주")
        {
            regionTitleText.text = "경상북도 경주";
            cropsText.text = "한라봉, 천혜향, 레드향, 카라향, 온주밀감 등 만감류";
            methodText.text = "경주는 전통적으로 벼농사를 중심으로 한 농업이 발달하였으며, 최근에는 기후 변화에 대응하여 아열대 과수 재배로 전환하고 있습니다.";
            techText.text = "경주시는 '신농업혁신타운'을 조성하여 스마트농업 실현을 목표로 하고 있습니다. 이 타운은 과학영농실증교육관, 귀농귀촌웰컴팜지원센터, 아열대·치유농업관 등을 갖추고 있으며, 청년농업인을 위한 맞춤형 교육장도 조성되어 있습니다.";

            image1.sprite = gyeongjuImg1;
            image2.sprite = gyeongjuImg2;
        }
        else if (regionName == "충청북도")
        {
            regionTitleText.text = "충청북도";
            cropsText.text = "대추, 수박, 딸기, 포도, 마늘, 양파 등";
            methodText.text = "충북은 전통적으로 다양한 작물을 교차 재배하여 토양 건강을 유지하고 해충 피해를 줄이는 농법을 활용해 왔습니다.";
            techText.text = "충북농업기술원은 기후 변화에 대응하여 아열대 작물 재배 매뉴얼을 발간하고, 첨단 스마트팜 실증센터를 구축하여 지역 맞춤형 작물 재배를 연구하고 있습니다.";

            image1.sprite = chungbukImg1;
            image2.sprite = chungbukImg2;
        }
    }
}

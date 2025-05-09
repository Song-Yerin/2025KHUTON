using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshProUGUI�� ����ϱ� ���� �ʿ�

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
        if (regionName == "���ϵ�_����")
        {
            regionTitleText.text = "���ϵ� ����";
            cropsText.text = "�Ѷ��, õ����, ������, ī����, ���ֹа� �� ������";
            methodText.text = "���ִ� ���������� ����縦 �߽����� �� ����� �ߴ��Ͽ�����, �ֱٿ��� ���� ��ȭ�� �����Ͽ� �ƿ��� ���� ���� ��ȯ�ϰ� �ֽ��ϴ�.";
            techText.text = "���ֽô� '�ų������Ÿ��'�� �����Ͽ� ����Ʈ��� ������ ��ǥ�� �ϰ� �ֽ��ϴ�. �� Ÿ���� ���п������������, �ͳ������������������, �ƿ��롤ġ������� ���� ���߰� ������, û�������� ���� ������ �����嵵 �����Ǿ� �ֽ��ϴ�.";

            image1.sprite = gyeongjuImg1;
            image2.sprite = gyeongjuImg2;
        }
        else if (regionName == "��û�ϵ�")
        {
            regionTitleText.text = "��û�ϵ�";
            cropsText.text = "����, ����, ����, ����, ����, ���� ��";
            methodText.text = "����� ���������� �پ��� �۹��� ���� ����Ͽ� ��� �ǰ��� �����ϰ� ���� ���ظ� ���̴� ����� Ȱ���� �Խ��ϴ�.";
            techText.text = "��ϳ��������� ���� ��ȭ�� �����Ͽ� �ƿ��� �۹� ��� �Ŵ����� �߰��ϰ�, ÷�� ����Ʈ�� �������͸� �����Ͽ� ���� ������ �۹� ��踦 �����ϰ� �ֽ��ϴ�.";

            image1.sprite = chungbukImg1;
            image2.sprite = chungbukImg2;
        }
    }
}

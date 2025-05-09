using UnityEngine;

public class SeasonTrigger : MonoBehaviour
{
    public GameObject seasonUI; // WheelRoot ��ü UI ������Ʈ

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            seasonUI.SetActive(true); // �÷��̾� ���� �� UI Ȱ��ȭ
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            seasonUI.SetActive(false); // ����� UI ��Ȱ��ȭ
        }
    }
}

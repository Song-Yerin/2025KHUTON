using UnityEngine;

public class SeasonTrigger : MonoBehaviour
{
    public GameObject seasonUI; // WheelRoot 전체 UI 오브젝트

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            seasonUI.SetActive(true); // 플레이어 진입 시 UI 활성화
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            seasonUI.SetActive(false); // 벗어나면 UI 비활성화
        }
    }
}

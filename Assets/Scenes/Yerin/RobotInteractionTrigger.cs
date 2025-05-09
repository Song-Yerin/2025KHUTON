using UnityEngine;

public class RobotInteractionTrigger : MonoBehaviour
{
    public GameObject ePromptUI;  // E UI 오브젝트 연결용
    private bool isPlayerNearby = false;

    void Start()
    {
        ePromptUI.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E 키로 상호작용 실행됨");
            // 여기서 Interact() 호출 가능
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            ePromptUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            ePromptUI.SetActive(false);
        }
    }
}

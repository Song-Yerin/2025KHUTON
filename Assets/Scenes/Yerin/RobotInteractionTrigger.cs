using UnityEngine;

public class RobotInteractionTrigger : MonoBehaviour
{
    public GameObject ePromptUI;  // E UI ������Ʈ �����
    private bool isPlayerNearby = false;

    void Start()
    {
        ePromptUI.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Ű�� ��ȣ�ۿ� �����");
            // ���⼭ Interact() ȣ�� ����
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

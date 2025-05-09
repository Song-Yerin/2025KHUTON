using UnityEngine;

public class CuratorTrigger : MonoBehaviour
{
    public RobotCurator robot;


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ʈ���� �ȿ� �÷��̾� ����");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E Ű ����!");
                robot.Interact();
            }
            else if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("...E Ű ������� ����");  // ���� �־ ����
            }
        }
    }
}

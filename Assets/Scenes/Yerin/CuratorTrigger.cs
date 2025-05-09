using UnityEngine;

public class CuratorTrigger : MonoBehaviour
{
    public RobotCurator robot;


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("트리거 안에 플레이어 있음");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E 키 눌림!");
                robot.Interact();
            }
            else if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("...E 키 누르고는 있음");  // 눌고만 있어도 찍힘
            }
        }
    }
}

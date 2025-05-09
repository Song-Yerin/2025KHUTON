using UnityEngine;

public class CuratorTrigger : MonoBehaviour
{
    public RobotCurator robot;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            robot.Interact();
        }
    }
}

using UnityEngine;

public class RobotCuratorAnimator : MonoBehaviour
{
    public Transform player;           // �÷��̾� Transform
    public Animator animator;          // �κ� Animator
    public float updateRate = 0.1f;    // �Ÿ� ��� �ֱ� (��)

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= updateRate)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            animator.SetFloat("Distance", distance);
            timer = 0f;
        }
    }
    void LateUpdate()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0f; // ���Ʒ� ȸ�� ���� (Y�� ����)

        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }


}

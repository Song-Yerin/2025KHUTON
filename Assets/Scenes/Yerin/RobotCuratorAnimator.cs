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
}

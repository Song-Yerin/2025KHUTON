using UnityEngine;

public class RobotCuratorAnimator : MonoBehaviour
{
    public Transform player;           // 플레이어 Transform
    public Animator animator;          // 로봇 Animator
    public float updateRate = 0.1f;    // 거리 계산 주기 (초)

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

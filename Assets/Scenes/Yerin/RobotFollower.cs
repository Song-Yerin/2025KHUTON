using UnityEngine;
using System.Collections;

public class RobotFollower : MonoBehaviour
{
    public Transform player;
    public float walkSpeed = 2f;
    public float stopDistance = 3f;
    public float followStartDistance = 30f;   // 최대 반응 거리
    public float walkDistanceThreshold = 20f; // 걷기와 뛰기 기준
    public float followDelay = 1.0f;

    public Animator animator;

    private bool isFollowing = false;
    private Coroutine followCoroutine;
    private string currentState = "";


    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > followStartDistance)
        {
            StopFollowing();
            return;
        }

        if (distance <= stopDistance)
        {
            StopFollowing();
            SetAnimationTrigger("Idle");
            return;
        }

        // 20~30 사이면 Run
        if (distance > walkDistanceThreshold && distance <= followStartDistance)
        {
            SetAnimationTrigger("Run");


            // 움직임 추가할 수도 있음 (달리는 속도용)
            MoveToPlayer(distance, walkSpeed * 1.5f);
        }

        // 3~20 사이면 Walk
        if (distance <= walkDistanceThreshold && distance > stopDistance)
        {
            if (!isFollowing && followCoroutine == null)
                followCoroutine = StartCoroutine(FollowWithDelay(followDelay));

            if (isFollowing)
            {
                SetAnimationTrigger("Walk");
                MoveToPlayer(distance, walkSpeed);
  
            }
        }
    }

    void MoveToPlayer(float distance, float speed)
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0f;

        transform.position += direction * speed * Time.deltaTime;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    IEnumerator FollowWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isFollowing = true;
        followCoroutine = null;
    }

    void StopFollowing()
    {
        isFollowing = false;
        if (followCoroutine != null)
        {
            StopCoroutine(followCoroutine);
            followCoroutine = null;
        }
    }

    void SetAnimationTrigger(string newState)
    {
        if (currentState == newState) return;

        animator.ResetTrigger("Idle");
        animator.ResetTrigger("Walk");
        animator.ResetTrigger("Run");

        animator.SetTrigger(newState);
 

        currentState = newState;
    }

 
}


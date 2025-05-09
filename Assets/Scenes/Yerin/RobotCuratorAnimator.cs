using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotCuratorAnimator : MonoBehaviour
{
    public Transform player;           // 플레이어 Transform
    public Animator animator;          // 로봇 Animator
    public float updateRate = 0.1f;    // 거리 계산 주기 (초)

    private float timer = 0f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬이 바뀌면 플레이어 다시 연결
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

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
        direction.y = 0f; // 위아래 회전 제거 (Y축 고정)

        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }


}

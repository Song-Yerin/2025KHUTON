using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotCuratorAnimator : MonoBehaviour
{
    public Transform player;           // �÷��̾� Transform
    public Animator animator;          // �κ� Animator
    public float updateRate = 0.1f;    // �Ÿ� ��� �ֱ� (��)

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
        // ���� �ٲ�� �÷��̾� �ٽ� ����
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
        direction.y = 0f; // ���Ʒ� ȸ�� ���� (Y�� ����)

        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }


}

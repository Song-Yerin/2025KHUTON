using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string targetSceneName;
    private bool hasLoaded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasLoaded)
        {
            hasLoaded = true;

            DontDestroyOnLoad(GameObject.FindWithTag("Player")); // �÷��̾� ������ �ϸ� ��
            // ModularRobots�� ���� ������ DontDestroyOnLoad ó���� (�̱��� ����)

            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(targetSceneName);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        GameObject robot = GameObject.Find("ModularRobots");
        if (robot != null)
        {
            robot.transform.position = new Vector3(0, 0, 0); // �� �� �� ��ġ ������
        }
    }
}

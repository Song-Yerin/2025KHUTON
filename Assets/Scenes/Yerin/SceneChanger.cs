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

            DontDestroyOnLoad(GameObject.FindWithTag("Player")); // 플레이어 유지만 하면 됨
            // ModularRobots는 이제 스스로 DontDestroyOnLoad 처리함 (싱글톤 내부)

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
            robot.transform.position = new Vector3(0, 0, 0); // 새 씬 내 위치 재지정
        }
    }
}

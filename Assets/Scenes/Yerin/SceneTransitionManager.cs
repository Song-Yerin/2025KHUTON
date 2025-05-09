using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    public GameObject playerA;
    public GameObject robot;

    private bool goingToC = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void RegisterMainActors(GameObject player, GameObject robotObj)
    {
        playerA = player;
        robot = robotObj;

        DontDestroyOnLoad(playerA);
        DontDestroyOnLoad(robot);
    }

    public void MoveToScene(string sceneName, bool hideMainActors = false)
    {
        goingToC = hideMainActors;

        if (hideMainActors)
        {
            if (playerA != null) playerA.SetActive(false);
            if (robot != null) robot.SetActive(false);
        }

        SceneManager.LoadScene(sceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!goingToC && scene.name == "SceneB")
        {
            if (playerA != null) playerA.SetActive(true);
            if (robot != null) robot.SetActive(true);
        }

        goingToC = false;
    }
}

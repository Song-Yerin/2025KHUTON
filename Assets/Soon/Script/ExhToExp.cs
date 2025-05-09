using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExhToExp : MonoBehaviour
{
    public string targetSceneName;
    private bool hasLoaded = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            hasLoaded = true;
            DontDestroyOnLoad(GameObject.FindWithTag("Player"));
            DontDestroyOnLoad(GameObject.Find("ModularRobots"));
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
            robot.transform.position = new Vector3(0, 0, 0);
        }
    }
}

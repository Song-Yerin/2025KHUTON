using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularRobotsManager : MonoBehaviour
{
    private static ModularRobotsManager instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // 이미 존재하는 경우 중복 제거
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // 유지
    }
}

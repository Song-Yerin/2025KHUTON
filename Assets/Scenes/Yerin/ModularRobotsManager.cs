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
            Destroy(gameObject); // �̹� �����ϴ� ��� �ߺ� ����
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // ����
    }
}

using UnityEngine;

public class PlayerAInitializer : MonoBehaviour
{
    public GameObject robot; // 로봇 오브젝트를 Inspector에서 연결

    void Start()
    {
        SceneTransitionManager.Instance.RegisterMainActors(this.gameObject, robot);
    }
}


using UnityEngine;

public class PlayerAInitializer : MonoBehaviour
{
    public GameObject robot; // �κ� ������Ʈ�� Inspector���� ����

    void Start()
    {
        SceneTransitionManager.Instance.RegisterMainActors(this.gameObject, robot);
    }
}


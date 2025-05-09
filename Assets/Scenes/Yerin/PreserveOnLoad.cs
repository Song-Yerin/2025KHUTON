using UnityEngine;

public class PreserveOnLoad : MonoBehaviour
{
    void Awake()
    {
        Debug.Log($"{gameObject.name} �� DontDestroyOnLoad �����");
        DontDestroyOnLoad(gameObject);
    }
}

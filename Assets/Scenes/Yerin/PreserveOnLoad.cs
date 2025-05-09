using UnityEngine;

public class PreserveOnLoad : MonoBehaviour
{
    void Awake()
    {
        Debug.Log($"{gameObject.name} ¡æ DontDestroyOnLoad Àû¿ëµÊ");
        DontDestroyOnLoad(gameObject);
    }
}

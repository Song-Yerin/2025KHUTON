using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    [SerializeField] private float mouseSpeed = 8f;
    private float mouseX = 0f;
    private float mouseY = 0f;

    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSpeed;
        mouseY += Input.GetAxis("Mouse Y") * mouseSpeed;

        mouseY = Mathf.Clamp(mouseY, -50f, 30f);

        // ȸ���� ����, ��ġ�� ���� ���� �� ��
        transform.localEulerAngles = new Vector3(-mouseY, mouseX, 0f);
    }
}

using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    public Transform wheelRoot; // ȸ���� ��ü ���� UI (WheelRoot)

    void Update()
    {
        // ȸ�� ���� ���� (���콺 �¿�� ȸ��)
        float input = Input.GetAxis("Mouse X");
        wheelRoot.Rotate(0, 0, -input * 100 * Time.deltaTime);

        // ȸ���� ��������
        float rotationZ = wheelRoot.localEulerAngles.z;

        // �ڽĵ��� �ؽ�Ʈ�� ��� �ݴ�� ȸ�����Ѽ� �׻� ���ڼ� ����
        foreach (Transform child in wheelRoot)
        {
            Transform textObj = child.Find("Text");
            if (textObj != null)
            {
                // �ؽ�Ʈ�� �θ� ȸ������ �ݴ�� ȸ��
                textObj.localEulerAngles = new Vector3(0, 0, -rotationZ);
            }
        }
    }
}

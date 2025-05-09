using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    public Transform wheelRoot; // 회전할 전체 원형 UI (WheelRoot)

    void Update()
    {
        // 회전 조작 예시 (마우스 좌우로 회전)
        float input = Input.GetAxis("Mouse X");
        wheelRoot.Rotate(0, 0, -input * 100 * Time.deltaTime);

        // 회전값 가져오기
        float rotationZ = wheelRoot.localEulerAngles.z;

        // 자식들의 텍스트를 모두 반대로 회전시켜서 항상 정자세 유지
        foreach (Transform child in wheelRoot)
        {
            Transform textObj = child.Find("Text");
            if (textObj != null)
            {
                // 텍스트는 부모 회전값의 반대로 회전
                textObj.localEulerAngles = new Vector3(0, 0, -rotationZ);
            }
        }
    }
}

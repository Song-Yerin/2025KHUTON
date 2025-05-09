using UnityEngine;

public class DraggableTool : MonoBehaviour
{
    [Header("속도 설정")]
    public float rotateSpeed = 150f;    // 회전 민감도
    public float zoomSpeed = 2f;      // 확대/축소 민감도
    public float minScale = 0.5f;    // 최소 스케일
    public float maxScale = 3f;      // 최대 스케일

    bool isDetailMode = false;

    // DetailView 진입 시 호출
    public void EnableDetailMode()
    {
        isDetailMode = true;
    }

    // DetailView 종료 시 호출
    public void DisableDetailMode()
    {
        isDetailMode = false;
    }

    void Update()
    {
        if (!isDetailMode) return;

        // 1) 드래그로 회전
        if (Input.GetMouseButton(0))
        {
            float dx = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
            float dy = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
            // 카메라의 Up/Right 축 기준으로 돌리기
            transform.localRotation =
                           Quaternion.Euler(dy, -dx, 0) * transform.localRotation;
        }

        // 2) 스크롤로 확대/축소
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.001f)
        {
            Vector3 newScale = transform.localScale + Vector3.one * scroll * zoomSpeed;
            float clamped = Mathf.Clamp(newScale.x, minScale, maxScale);
            transform.localScale = Vector3.one * clamped;
        }
    }
}

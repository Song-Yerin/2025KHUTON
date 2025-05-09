using UnityEngine;

public class DetailToolController : MonoBehaviour
{
    public float rotateSpeed = 100f;
    public float zoomSpeed = 2f;
    private bool isDetailMode;

    void Update()
    {
        if (!isDetailMode) return;

        // 마우스 드래그로 회전
        if (Input.GetMouseButton(0))
        {
            float dx = Input.GetAxis("Mouse X");
            float dy = Input.GetAxis("Mouse Y");
            transform.Rotate(Vector3.up, -dx * rotateSpeed * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.right, dy * rotateSpeed * Time.deltaTime, Space.World);
        }
        // 휠로 확대/축소
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.01f)
        {
            transform.localScale += Vector3.one * scroll * zoomSpeed;
            transform.localScale = Vector3.Max(transform.localScale, Vector3.one * 0.5f);
            transform.localScale = Vector3.Min(transform.localScale, Vector3.one * 3f);
        }
    }

    public void EnableDetailMode()
    {
        isDetailMode = true;
    }
    public void DisableDetailMode()
    {
        isDetailMode = false;
    }
}

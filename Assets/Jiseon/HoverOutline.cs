using UnityEngine;
[RequireComponent(typeof(BoxCollider), typeof(Renderer))]
public class RaycastHoverTest : MonoBehaviour
{
    public Color hoverColor = Color.yellow;
    public Color clickColor = Color.red;

    private Renderer rend;
    private Color originalColor;
    private bool isHovered = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // 레이캐스트로 마우스가 이 오브젝트 위에 있는지 체크
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (!isHovered)
                {
                    rend.material.color = hoverColor;
                    isHovered = true;
                }

                // 클릭 시 색상 변경
                if (Input.GetMouseButtonDown(0)) // 좌클릭
                {
                    rend.material.color = clickColor;
                }

                return;
            }
        }

        // 마우스가 벗어나면 원래 색으로
        if (isHovered)
        {
            rend.material.color = originalColor;
            isHovered = false;
        }
    }
}

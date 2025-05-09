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

        // ����ĳ��Ʈ�� ���콺�� �� ������Ʈ ���� �ִ��� üũ
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (!isHovered)
                {
                    rend.material.color = hoverColor;
                    isHovered = true;
                }

                // Ŭ�� �� ���� ����
                if (Input.GetMouseButtonDown(0)) // ��Ŭ��
                {
                    rend.material.color = clickColor;
                }

                return;
            }
        }

        // ���콺�� ����� ���� ������
        if (isHovered)
        {
            rend.material.color = originalColor;
            isHovered = false;
        }
    }
}

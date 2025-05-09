using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Renderer))]
public class RaycastHoverTest : MonoBehaviour
{
    public Color hoverColor = Color.yellow;
    public Color clickColor = Color.red;
    public GameObject uiCanvas;

    private Renderer rend;
    private Color originalColor;
    private bool isHovered = false;
    private bool uiActive = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;

        if (uiCanvas != null)
            uiCanvas.SetActive(false);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (!isHovered)
                {
                    rend.material.color = hoverColor;
                    isHovered = true;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    rend.material.color = clickColor;

                    if (uiCanvas != null)
                    {
                        uiCanvas.SetActive(true);
                        uiActive = true;

                        // 지역 이름에 따라 데이터 채우기
                        string regionName = gameObject.name;
                        var panelUpdater = uiCanvas.GetComponent<RegionInfoPanel>();
                        if (panelUpdater != null)
                            panelUpdater.SetRegionData(regionName);
                    }
                }

                return;
            }
        }

        if (isHovered)
        {
            rend.material.color = originalColor;
            isHovered = false;
        }

        if (uiActive && Input.GetKeyDown(KeyCode.Z))
        {
            if (uiCanvas != null)
            {
                uiCanvas.SetActive(false);
                uiActive = false;
            }
        }
    }
}

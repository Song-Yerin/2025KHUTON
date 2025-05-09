using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ToolGazeInteractor : MonoBehaviour
{
    public CinemachineVirtualCamera mainVcam;    // 월드 뷰용 Virtual Cam
    public CinemachineVirtualCamera detailVcam;  // DetailView용 Virtual Cam

    public LayerMask interactableLayer;
    public float maxDistance = 5f;    // 중앙에서 최대 몇 미터까지 인식할지
    public string interactTag = "Interactable";

    public Interactable currentTool;

    public List<Interactable> allTools;

    private void Start()
    {

    }
    void Update()
    {
        CheckCenterGaze();
        HandleInput();
    }

    void CheckCenterGaze()
    {
        // 화면 정중앙 뷰포트 좌표 (0.5, 0.5)
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, interactableLayer))
        {
            if (hit.collider.CompareTag(interactTag))
            {
                if (currentTool != hit.collider.GetComponent<Interactable>())
                {
                    currentTool = hit.collider.GetComponent<Interactable>();
                    //currentTool.EnableOutline();
                    Debug.Log("Can F");
                    //UIManager.ShowPrompt("자세히 보기 (E)");
                }
                return;
            }
        }
        // 중앙에 아무것도 없거나, 태그가 다르면
        if (currentTool != null)
        {
            currentTool = null;           
            //UIManager.HidePrompt();
        }
    }

    void HandleInput()
    {
        if (currentTool != null && Input.GetKeyDown(KeyCode.F))
        {
            EnterDetailView(currentTool);
        }
    }

    void EnterDetailView(Interactable tool)
    {

        foreach (var t in allTools)
        {
            if (t != tool)
                t.deactive();
        }

        // Pivot(툴 중심)이 Pivot 오브젝트의 Transform이라 가정
        Transform pivot = tool.transform.Find("Pivot");

        // 1) DetailCam에 Follow·LookAt 동적으로 할당
        detailVcam.Follow = pivot;
        detailVcam.LookAt = pivot;

        // 2) 카메라 전환: Priority를 이용하거나 Enable/Disable
        detailVcam.Priority = 20;    // mainCam(10)보다 높이면 자동 전환


        // 이후 기존에 하던 툴 이동·스케일 세팅, UI 전환 로직…
        var draggable = tool.GetComponent<DraggableTool>();
        if (draggable != null)
            draggable.EnableDetailMode();
    }

    void ExitDetailView(Interactable tool)
    {
        // 복귀 시 Priority 낮춰서 메인으로 전환
        detailVcam.Priority = 0;

        // 툴·UI 원상복구…
    }

}

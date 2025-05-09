using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ToolGazeInteractor : MonoBehaviour
{
    [Header("Player Settings")]
    public MonoBehaviour playerMovement; // 플레이어 이동 스크립트(Inspector에 드래그)
    public Transform player;        // 플레이어 루트(transform)

    [Header("Cinemachine Cameras")]
    public CinemachineVirtualCamera mainVcam;   // 월드 뷰용 Virtual Cam
    public CinemachineVirtualCamera detailVcam; // 디테일 뷰용 Virtual Cam

    [Header("Interaction Settings")]
    public LayerMask interactableLayer;
    public float maxDistance = 5f;
    public string interactTag = "Interactable";

    [Header("All Tools in Scene")]
    public List<Interactable> allTools; // 모든 툴(Inspector에 드래그)

    // 런타임 상태
    private Interactable currentTool;
    private bool inDetailView = false;

    // 원상복구용 캐시
    private Vector3 origToolPos;
    private Quaternion origToolRot;
    private Vector3 origToolScale;
    private Quaternion origCamRot;

    void Start()
    {
        // 카메라 원래 회전 캐싱
        origCamRot = Camera.main.transform.rotation;

        // detailVcam은 우선순위를 main보다 낮게 시작
        detailVcam.Priority = mainVcam.Priority - 1;
    }

    void Update()
    {
        if (!inDetailView)
        {
            CheckCenterGaze();
            HandleInput();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ExitDetailView();
        }
    }

    void CheckCenterGaze()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, interactableLayer)
            && hit.collider.CompareTag(interactTag))
        {
            var hitTool = hit.collider.GetComponent<Interactable>();
            if (hitTool != currentTool)
            {
                currentTool = hitTool;
                // 여기서 Outline 켜거나 Prompt 띄워도 OK
            }
        }
        else
        {
            currentTool = null;
        }
    }

    void HandleInput()
    {
        if (currentTool != null && Input.GetKeyDown(KeyCode.F))
            EnterDetailView(currentTool);
    }

    void EnterDetailView(Interactable tool)
    {
        inDetailView = true;

        // 1) 플레이어 이동 잠금
        if (playerMovement != null)
            playerMovement.enabled = false;

        // 2) 툴 원상태 저장
        origToolPos = tool.transform.position;
        origToolRot = tool.transform.rotation;
        origToolScale = tool.transform.localScale;

        // 3) 나머지 툴 숨기기
        foreach (var t in allTools)
            if (t != tool)
                t.gameObject.SetActive(false);

        // 4) Pivot 찾기(없으면 툴 루트)
        Transform pivot = tool.transform.Find("Pivot") ?? tool.transform;

        // 5) 디테일 뷰 카메라 세팅
        detailVcam.Follow = pivot;
        detailVcam.LookAt = pivot;
        detailVcam.Priority = mainVcam.Priority + 1;

        // 6) 툴을 로컬 Z축 앞으로 1m 이동
        var pos = tool.transform.position;
        pos.z += 2f;
        tool.transform.position = pos;

        // 7) 드래그·줌 활성화
        var drag = tool.GetComponent<DraggableTool>();
        if (drag != null)
            drag.EnableDetailMode();
    }

    void ExitDetailView()
    {
        if (currentTool == null) return;

        // 1) 플레이어 이동 해제
        if (playerMovement != null)
            playerMovement.enabled = true;

        // 2) 툴 원상태 복원
        currentTool.transform.position = origToolPos;
        currentTool.transform.rotation = origToolRot;
        currentTool.transform.localScale = origToolScale;

        // 3) 숨겼던 툴들 다시 보이기
        foreach (var t in allTools)
            t.gameObject.SetActive(true);

        // 4) 디테일 카메라 Follow/LookAt 해제 & 우선순위 복원
        detailVcam.Follow = null;
        detailVcam.LookAt = null;
        detailVcam.Priority = mainVcam.Priority - 1;

        // 5) 드래그·줌 비활성화
        var drag = currentTool.GetComponent<DraggableTool>();
        if (drag != null)
            drag.DisableDetailMode();

        // 6) 카메라 회전 완벽 복원 (다음 프레임에)
        StartCoroutine(ResetCamRotationNextFrame());

        // 7) 상태 초기화
        currentTool = null;
        inDetailView = false;
    }

    IEnumerator ResetCamRotationNextFrame()
    {
        yield return null;
        Camera.main.transform.rotation = origCamRot;
    }
}

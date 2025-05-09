using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ToolGazeInteractor : MonoBehaviour
{
    [Header("Player")]
    public MonoBehaviour playerMovement;
    public Transform player;

    [Header("Cinemachine")]
    public CinemachineVirtualCamera mainVcam;
    public CinemachineVirtualCamera detailVcam;

    [Header("Interaction")]
    public LayerMask interactableLayer;
    public float maxDistance = 5f;
    public string interactTag = "Interactable";

    [Header("Tools (Inspector에 전부 드래그)")]
    public List<Interactable> allTools;

    // 런타임 상태
    Interactable currentTool;
    bool inDetailView = false;

    // 원상복구용 캐시
    Vector3 origToolPos;
    Quaternion origToolRot;
    Vector3 origToolScale;
    Quaternion camOrigRot;
    Quaternion playerOrigRot;

    void Start()
    {
        camOrigRot = Camera.main.transform.rotation;
        detailVcam.Priority = mainVcam.Priority - 1;
    }

    void Update()
    {
        if (!inDetailView)
        {
            CheckCenterGaze();
            if (currentTool != null && Input.GetKeyDown(KeyCode.F))
                EnterDetailView(currentTool);
        }
        else
        {
            // R 키 → 체험하기
            if (currentTool != null && Input.GetKeyDown(KeyCode.R))
                TryExperience(currentTool);

            // Q 키 → 디테일 나가기
            if (Input.GetKeyDown(KeyCode.Q))
                ExitDetailView();
        }
    }

    void CheckCenterGaze()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        if (Physics.Raycast(ray, out var hit, maxDistance, interactableLayer)
            && hit.collider.CompareTag(interactTag))
        {
            currentTool = hit.collider.GetComponent<Interactable>();
        }
        else currentTool = null;
    }

    void EnterDetailView(Interactable tool)
    {
        inDetailView = true;
        playerMovement.enabled = false;
        playerOrigRot = player.rotation;

        // 툴 원상태 저장
        origToolPos = tool.transform.position;
        origToolRot = tool.transform.rotation;
        origToolScale = tool.transform.localScale;

        // 나머지 숨기기
        foreach (var t in allTools) if (t != tool) t.gameObject.SetActive(false);

        // 카메라 바인딩
        var pivot = tool.transform.Find("Pivot") ?? tool.transform;
        detailVcam.Follow = pivot;
        detailVcam.LookAt = pivot;
        detailVcam.Priority = mainVcam.Priority + 1;

        // 툴 약간 앞으로
        var pos = tool.transform.position;
        pos.z += 2f;
        tool.transform.position = pos;

        // 드래그 활성
        if (tool.TryGetComponent<DraggableTool>(out var d)) d.EnableDetailMode();
    }

    void TryExperience(Interactable tool)
    {
        // 체험 스크립트가 붙어 있으면 실행
        if (tool.TryGetComponent<ExperienceTool>(out var exp))
            exp.DoExperience();
    }

    void ExitDetailView()
    {
        if (!inDetailView) return;
        inDetailView = false;

        // 플레이어 이동 / 회전 복원
        playerMovement.enabled = true;
        player.rotation = playerOrigRot;

        // 카메라 복원
        detailVcam.Follow = null;
        detailVcam.LookAt = null;
        detailVcam.Priority = mainVcam.Priority - 1;

        // 툴 원상태 & 드래그 / 체험 리셋
        if (currentTool != null)
        {
            // 체험 모드 리셋
            if (currentTool.TryGetComponent<ExperienceTool>(out var exp))
                exp.ResetExperience();

            // 드래그 모드 리셋
            if (currentTool.TryGetComponent<DraggableTool>(out var d))
                d.DisableDetailMode();

            // 위치/회전/스케일 원복
            currentTool.transform.SetPositionAndRotation(origToolPos, origToolRot);
            currentTool.transform.localScale = origToolScale;
        }

        // 숨긴 툴 복원
        foreach (var t in allTools) t.gameObject.SetActive(true);

        // 한 프레임 기다렸다가 카메라 원래 회전으로
        StartCoroutine(ResetCamRotation());
        currentTool = null;
    }

    IEnumerator ResetCamRotation()
    {
        yield return null;
        Camera.main.transform.rotation = camOrigRot;
    }
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class ExperienceTool : MonoBehaviour
{
    [Header("손에 든 위치·회전 (카메라 로컬)")]
    public Vector3 holdPosition = new Vector3(0.5f, -0.5f, 1f);
    public Vector3 holdEuler = new Vector3(0f, 0f, 0f);

    // 원상복구용 캐시
    Transform origParent;
    Vector3 origLocalPos;
    Quaternion origLocalRot;
    bool isHeld = false;

    /// <summary>
    /// R 키 눌러 호출 → 도구를 카메라 자식으로 옮겨 “들기”
    /// </summary>
    public void DoExperience()
    {
        if (isHeld) return;
        isHeld = true;

        // 캐시
        origParent = transform.parent;
        origLocalPos = transform.localPosition;
        origLocalRot = transform.localRotation;

        // 카메라 자식으로 붙이고, 로컬 위치/회전 세팅
        transform.SetParent(Camera.main.transform, worldPositionStays: false);
        transform.localPosition = holdPosition;
        transform.localRotation = Quaternion.Euler(holdEuler);
    }

    /// <summary>
    /// Q 키(또는 DetailView 종료) 시 호출 → 원래대로 돌려놓기
    /// </summary>
    public void ResetExperience()
    {
        if (!isHeld) return;
        isHeld = false;

        // 원래 부모(DetailView에서 세팅된 Pivot 하위)로 되돌리고
        transform.SetParent(origParent, worldPositionStays: false);
        transform.localPosition = origLocalPos;
        transform.localRotation = origLocalRot;
    }
}

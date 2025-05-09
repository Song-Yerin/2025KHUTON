using UnityEngine;
using System.Collections;

public class ExperienceMotion : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform cameraTransform;          // Camera.main.transform
    public Vector3 cameraBowOffset = new Vector3(0f, -0.4f, 0f);
    public Vector3 cameraBowEuler = new Vector3(15f, 0f, 0f);
    [Tooltip("카메라 숙이기 시간")]
    public float camBowTime = 0.25f;
    [Tooltip("카메라 복귀 시간")]
    public float camReturnTime = 0.35f;

    [Header("Hoe Swing Settings (호미질)")]
    public Transform toolTransform;            // 호미 오브젝트 Transform
    [Tooltip("처음 들린 각도")]
    public Vector3 hoeStartEuler = new Vector3(-30f, 0f, 0f);
    [Tooltip("땅 긁을 때 각도")]
    public Vector3 hoeHitEuler = new Vector3(10f, 0f, 0f);
    [Tooltip("한 번 클릭당 스윙 횟수")]
    public int swingCount = 2;
    [Tooltip("스윙 앞으로 가는 시간")]
    public float hoeSwingTime = 0.25f;
    [Tooltip("스윙 후 복귀 시간")]
    public float hoeReturnTime = 0.25f;

    // 내부 캐시
    Vector3 camOrigPos;
    Quaternion camOrigRot;
    Quaternion toolOrigRot;
    bool isAnimating = false;

    void Awake()
    {
        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;
        camOrigPos = cameraTransform.localPosition;
        camOrigRot = cameraTransform.localRotation;

        if (toolTransform != null)
            toolOrigRot = toolTransform.localRotation;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAnimating)
        {
            StartCoroutine(DoHoeMotion());
        }
    }

    IEnumerator DoHoeMotion()
    {
        isAnimating = true;

        // 1) 카메라 숙이기
        Vector3 targetCamPos = camOrigPos + cameraBowOffset;
        Quaternion targetCamRot = Quaternion.Euler(cameraBowEuler) * camOrigRot;
        yield return LerpCam(camOrigPos, camOrigRot, targetCamPos, targetCamRot, camBowTime);

        // 2) 호미질 스윙 반복
        Quaternion startRot = Quaternion.Euler(hoeStartEuler) * toolOrigRot;
        Quaternion hitRot = Quaternion.Euler(hoeHitEuler) * toolOrigRot;

        // 첫 클립: 미리 들고 있는 각도로 세팅
        toolTransform.localRotation = startRot;

        for (int i = 0; i < swingCount; i++)
        {
            // 앞으로 긁기
            yield return LerpRot(toolTransform, startRot, hitRot, hoeSwingTime);
            // 다시 들기
            yield return LerpRot(toolTransform, hitRot, startRot, hoeReturnTime);
        }

        // 3) 카메라 복귀
        yield return LerpCam(cameraTransform.localPosition, cameraTransform.localRotation, camOrigPos, camOrigRot, camReturnTime);

        // 툴 로테이션 원복
        toolTransform.localRotation = toolOrigRot;

        isAnimating = false;
    }

    // 카메라 이동·회전 헬퍼
    IEnumerator LerpCam(Vector3 p0, Quaternion r0, Vector3 p1, Quaternion r1, float time)
    {
        float t = 0f;
        while (t < time)
        {
            t += Time.deltaTime;
            float f = t / time;
            cameraTransform.localPosition = Vector3.Lerp(p0, p1, f);
            cameraTransform.localRotation = Quaternion.Slerp(r0, r1, f);
            yield return null;
        }
    }

    // 회전 헬퍼
    IEnumerator LerpRot(Transform target, Quaternion a, Quaternion b, float time)
    {
        float t = 0f;
        while (t < time)
        {
            t += Time.deltaTime;
            target.localRotation = Quaternion.Slerp(a, b, t / time);
            yield return null;
        }
    }
}

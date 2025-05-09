using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageEffect : MonoBehaviour
{
    [Range(0, 5)]
    public float time = 1f; // 색상 변화 속도 조절

    private float gradientWaveTime;
    private float curXNormalized;
    private Image image;
    private Gradient gradient;

    private void Awake()
    {
        image = GetComponent<Image>();

        // 노랑 → 연두 → 초록 그라데이션 생성
        gradient = new Gradient();

        GradientColorKey[] colorKeys = new GradientColorKey[3];
        colorKeys[0].color = new Color32(255, 243, 107, 255); // 노랑
        colorKeys[0].time = 0.0f;

        colorKeys[1].color = new Color32(191, 251, 124, 255); // 연두
        colorKeys[1].time = 0.5f;

        colorKeys[2].color = new Color32(52, 199, 89, 255); // 초록
        colorKeys[2].time = 1.0f;

        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0] = new GradientAlphaKey(1f, 0f);
        alphaKeys[1] = new GradientAlphaKey(1f, 1f);

        gradient.SetKeys(colorKeys, alphaKeys);
    }

    private void Update()
    {
        gradientWaveTime += Time.deltaTime;
        curXNormalized = Mathf.PingPong(gradientWaveTime / time, 1f); // 반복적으로 0~1 사이 왕복

        Color c = gradient.Evaluate(curXNormalized);
        image.color = c;
    }
}

using TMPro;
using UnityEngine;
using System.Collections;

public class RobotCurator : MonoBehaviour
{
    public GameObject dialogueUI; // 대화 UI 패널
    public TMP_InputField inputField;
    public TextMeshProUGUI responseText;
    private ChatGPTConnector gptConnector;

    void Start()
    {
        gptConnector = GetComponent<ChatGPTConnector>();
        dialogueUI.SetActive(false);
    }
    void Update()
    {
        if (dialogueUI != null && dialogueUI.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            SubmitQuestion();
        }

        if (dialogueUI != null && dialogueUI.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            dialogueUI.SetActive(false);
        }
    }
    public void Interact()
    {
        bool isActive = dialogueUI.activeSelf;
        dialogueUI.SetActive(!isActive);

        if (!isActive)
        {
            inputField.text = "";
            StartCoroutine(DelayFocus()); // 1프레임 뒤에 커서 활성화
        }
    }

    private IEnumerator DelayFocus()
    {
        yield return null; // 한 프레임 기다림
        inputField.Select();
        inputField.ActivateInputField();
    }

    public void SubmitQuestion()
    {
        string prompt = inputField.text.Trim();

        if (string.IsNullOrEmpty(prompt)) return;

        gptConnector.SendToChatGPT(); ;
        inputField.text = "";
        inputField.ActivateInputField();  // 커서 다시 활성화 (선택)
    }

    public void OnPlayerMessage(string message)
    {
        // "호미영상"이라는 말이 포함되면 영상만 재생하고 아무 응답도 하지 않음
        if (message.Contains("호미영상"))
        {

            if (dialogueUI != null)
            {
                dialogueUI.SetActive(false);    // 대화창 닫기
            }

            return; // GPT 응답 생략 (로봇은 말 안 함)
        }

        // 평소처럼 GPT 응답 처리
        //StartCoroutine(SendMessageToGPT(message));
    }

}
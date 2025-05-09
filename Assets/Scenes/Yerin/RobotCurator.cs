using TMPro;
using UnityEngine;
using System.Collections;

public class RobotCurator : MonoBehaviour
{
    public GameObject dialogueUI; // ��ȭ UI �г�
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
            StartCoroutine(DelayFocus()); // 1������ �ڿ� Ŀ�� Ȱ��ȭ
        }
    }

    private IEnumerator DelayFocus()
    {
        yield return null; // �� ������ ��ٸ�
        inputField.Select();
        inputField.ActivateInputField();
    }

    public void SubmitQuestion()
    {
        string prompt = inputField.text.Trim();

        if (string.IsNullOrEmpty(prompt)) return;

        gptConnector.SendToChatGPT(); ;
        inputField.text = "";
        inputField.ActivateInputField();  // Ŀ�� �ٽ� Ȱ��ȭ (����)
    }



}
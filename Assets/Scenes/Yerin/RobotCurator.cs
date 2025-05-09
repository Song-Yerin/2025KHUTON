using TMPro;
using UnityEngine;

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
        if (dialogueUI.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            SubmitQuestion();
        }
    }

    public void Interact()
    {
        dialogueUI.SetActive(true);
    }

    public void SubmitQuestion()
    {
        gptConnector.SendToChatGPT();
    }
}

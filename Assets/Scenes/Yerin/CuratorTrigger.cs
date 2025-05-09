using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CuratorTrigger : MonoBehaviour
{
    public Transform player;
    public GameObject ePromptUI;
    public GameObject dialogueUI;
    public TMP_InputField inputField;

    public float showDistance = 5f;

    private bool isPromptShown = false;
    private bool isDialogueOpen = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(DelayedFindPlayer());
    }

    IEnumerator DelayedFindPlayer()
    {
        yield return null; // �� ������ ��ٸ���
        GameObject found = GameObject.FindGameObjectWithTag("Player");
        if (found != null)
        {
            player = found.transform;
            Debug.Log("[CuratorTrigger] �÷��̾� �翬�� �Ϸ�: " + player.name);
        }
        else
        {
            Debug.LogWarning(" [CuratorTrigger] �÷��̾ ã�� ���߽��ϴ�.");
        }
    }

    void Update()
    {
        if (player == null || ePromptUI == null || dialogueUI == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= showDistance)
        {
            if (!isPromptShown)
            {
                ePromptUI.SetActive(true);
                isPromptShown = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleDialogue();
            }
        }
        else
        {
            if (isPromptShown)
            {
                ePromptUI.SetActive(false);
                isPromptShown = false;
            }

            if (isDialogueOpen)
            {
                dialogueUI.SetActive(false);
                isDialogueOpen = false;
            }
        }
    }

    void ToggleDialogue()
    {
        isDialogueOpen = !isDialogueOpen;
        dialogueUI.SetActive(isDialogueOpen);

        if (isDialogueOpen)
        {
            inputField.text = "";
            StartCoroutine(DelayFocus()); // ���⿡ ���� �ִ´�
        }
    }

    IEnumerator DelayFocus()
    {
        yield return null;
        inputField.Select();
        inputField.ActivateInputField();
    }

}

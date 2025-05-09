using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CuratorTrigger : MonoBehaviour
{
    public Transform player;
    public GameObject ePromptUI;
    public GameObject dialogueUI;
    public TMP_InputField inputField;

    public float showDistance = 5f;

    private bool isPromptShown = false;
    private bool isDialogueOpen = false;

    void Update()
    {
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
            StartCoroutine(DelayFocus()); // 여기에 직접 넣는다
        }
    }

    IEnumerator DelayFocus()
    {
        yield return null;
        inputField.Select();
        inputField.ActivateInputField();
    }

}

using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;
using System;

[Serializable]
public class APIKeyData
{
    public string openai_api_key;
}

public class ChatGPTConnector : MonoBehaviour
{
    public TMP_InputField userInput;
    public TextMeshProUGUI responseText;
    public string apiKey; // 이건 디버깅용

    void Awake()
    {
        LoadApiKey();
    }

    void LoadApiKey()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("api_key");
        if (jsonFile != null)
        {
            APIKeyData keyData = JsonUtility.FromJson<APIKeyData>(jsonFile.text);
            apiKey = keyData.openai_api_key;
        }
        else
        {
            Debug.LogError("API 키 파일(api_key.json)을 찾을 수 없습니다.");
        }
    }

    public void SendToChatGPT()
    {
        string prompt = userInput.text;
        StartCoroutine(SendRequest(prompt));
    }

    IEnumerator SendRequest(string prompt)
    {
        string apiUrl = "https://api.openai.com/v1/chat/completions";
        string jsonBody = JsonUtility.ToJson(new
        {
            model = "gpt-3.5-turbo",
            messages = new[] {
                new { role = "user", content = prompt }
            }
        });

        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + apiKey);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            string result = request.downloadHandler.text;
            var json = JsonUtility.FromJson<ChatGPTResponseWrapper>(result);
            responseText.text = json.choices[0].message.content.Trim();
        }
    }

    [System.Serializable]
    public class ChatGPTResponseWrapper
    {
        public Choice[] choices;
    }

    [System.Serializable]
    public class Choice
    {
        public Message message;
    }

    [System.Serializable]
    public class Message
    {
        public string content;
    }
}

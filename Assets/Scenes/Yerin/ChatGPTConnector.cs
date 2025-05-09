using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;
using System;
using UnityEngine.Video;

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

    public GameObject robot;
    private RobotVideoController robotVideoController;
    void Start()
    {
        robotVideoController = robot.GetComponent<RobotVideoController>();
    }
    void Awake()
    {
        Debug.Log("Awake() 실행됨");
        LoadApiKey();
    }

    void LoadApiKey()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("api_key");

        if (jsonFile != null)
        {
            Debug.Log("JSON 로드됨: " + jsonFile.text);
            APIKeyData keyData = JsonUtility.FromJson<APIKeyData>(jsonFile.text);
            apiKey = keyData.openai_api_key;
            Debug.Log("API 키: " + apiKey);
        }
        else
        {
            Debug.LogError("api_key.json을 Resources 폴더에서 찾을 수 없음");
        }
    }

    private bool isWaitingForResponse = false;

    public void SendToChatGPT()
    {
        if (isWaitingForResponse) return;
        string prompt = userInput.text;
        StartCoroutine(SendRequest(prompt));
    }

    IEnumerator SendRequest(string prompt)
    {
        isWaitingForResponse = true;
        string apiUrl = "https://api.openai.com/v1/chat/completions";

        // 직접 JSON 문자열 구성
        string jsonBody = @"{
        ""model"": ""gpt-3.5-turbo"",
        ""messages"": [
            { ""role"": ""user"", ""content"": """ + prompt.Replace("\"", "\\\"") + @""" }
        ]
    }";

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
            Debug.LogError("Raw Response: " + request.downloadHandler.text);  // 디버깅용
        }
        else if (request.responseCode == 429)
        {
            // 너무 많은 요청 에러 처리
            responseText.text = "요청이 너무 많아요. 잠시 후 다시 시도해주세요!";
            Debug.LogWarning("429 Too Many Requests - Rate limit exceeded");
        }
        else
        {
            Debug.Log("응답 수신: " + request.downloadHandler.text);
            var json = JsonUtility.FromJson<ChatGPTResponseWrapper>(request.downloadHandler.text);
            responseText.text = json.choices[0].message.content.Trim();
        }

        isWaitingForResponse = false;

        /*void HandleResponse(string response)
        {
            responseText.text = response;

            if (response.Contains("호미영상"))
            {
                robotVideoController.PlayVideo();
            }
            else if (response.Contains("영상꺼줘"))
            {
                robotVideoController.StopVideo();
            }

        }*/
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

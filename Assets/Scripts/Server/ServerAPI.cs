using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utilities;

//It must be non MonoBehaviour, but for it will be because it needs for curoutine
public class ServerAPI
{
    private const string baseUrl = "http://localhost:3000/players";

    private static ServerAPI instance;
    public static ServerAPI Instance => instance;

    private CoroutineRunner coroutineRunner;

    private ServerAPI(CoroutineRunner coroutineRunner)
    {
        this.coroutineRunner = coroutineRunner;
    }

    public static void Init(CoroutineRunner coroutineRunner)
    {
        instance = new(coroutineRunner);
    }

    public void GetPlayers()
    {
        coroutineRunner.Run(GetPlayersCoroutine());
    }

    public void AddPlayer(string name, int score)
    {
        coroutineRunner.Run(AddPlayerCoroutine(name, score));
    }

    private IEnumerator GetPlayersCoroutine()
    {
        UnityWebRequest www = UnityWebRequest.Get(baseUrl);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            // Обробка даних
        }
    }

    private IEnumerator AddPlayerCoroutine(string name, int score)
    {
        var postData = new Dictionary<string, string>
        {
            { "name", name },
            { "score", score.ToString() }
        };

        string json = JsonUtility.ToJson(postData);
        UnityWebRequest www = new UnityWebRequest(baseUrl, "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(json);
        www.uploadHandler = new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Player added successfully");
            Debug.Log(www.downloadHandler.text);
        }
    }
}
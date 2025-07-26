using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;

public class ApiManager : MonoBehaviour
{
    [Header("API Config")]
    private string baseUrl = "https://webhook.site";

    private void Awake()
    {
    }

    public void Get(string endpoint, Action<string> onSuccess, Action<string> onError = null)
    {
        StartCoroutine(GetRequestCoroutine(endpoint, onSuccess, onError));
    }

    private IEnumerator GetRequestCoroutine(string endpoint, Action<string> onSuccess, Action<string> onError)
    {
        string fullUrl = $"{baseUrl}/{endpoint}";
        using UnityWebRequest request = UnityWebRequest.Get(fullUrl);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)

        {
            onSuccess?.Invoke(request.downloadHandler.text);
        }
        else
        {
            Debug.LogWarning($"API GET Error: {request.error}");
            onError?.Invoke(request.error);
        }
    }
}

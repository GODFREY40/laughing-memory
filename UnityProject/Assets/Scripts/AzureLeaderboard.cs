using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Posts scores to an Azure Function (see azure/pipeline). Set the URL in the inspector.
public class AzureLeaderboard : MonoBehaviour
{
    [SerializeField] private string functionUrl = "https://<your-app>.azurewebsites.net/api/score";

    public void SubmitScore(string player, int score) => StartCoroutine(Post(player, score));

    private IEnumerator Post(string player, int score)
    {
        var json = JsonUtility.ToJson(new Score { player = player, score = score });
        using var req = new UnityWebRequest(functionUrl, "POST")
        {
            uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json)),
            downloadHandler = new DownloadHandlerBuffer()
        };
        req.SetRequestHeader("Content-Type", "application/json");
        yield return req.SendWebRequest();
        if (req.result != UnityWebRequest.Result.Success) Debug.LogWarning(req.error);
    }

    [System.Serializable] private struct Score { public string player; public int score; }
}

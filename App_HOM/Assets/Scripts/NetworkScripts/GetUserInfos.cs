using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetUserInfos : MonoBehaviour
{
    public PlayerData Data;

    private void Start()
    {


    }

    public void GetTheInfos(string url)
    {
        StartCoroutine(GetInfos(url));
    }

    public IEnumerator GetInfos(string url)
    {
        Debug.Log("Connecting");
        WWWForm form = new WWWForm();
        form.AddField("UserID", Data.data["UserID"]);
        UnityWebRequest request = UnityWebRequest.Post(url, form);
        yield return request.Send();
        if (request.isNetworkError || request.isHttpError)
        {
            //Warning.text = "Networkerror";
            Debug.LogError("Networkerror");
        }
        else
        {
            Debug.Log(request.downloadHandler.text + " vorhanden Sheets");
            //Test soll die ID von PHP bekommen
            // wird noch getestet und wo es hingehört
            Data.SaveDataString("UserCharSheets", request.downloadHandler.text);
            request.Dispose();
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetUserInfos : MonoBehaviour
{
    //hier werden alle Daten gespeichert und wiedergegeben
    public PlayerData Data;

    //startet Netzwerkaufbau
    public void GetTheInfos(string url)
    {
        StartCoroutine(GetInfos(url));
    }

    //erhält eine URl um die Infos aus der Datenbank zu erhalten
    public IEnumerator GetInfos(string url)
    {
        //benötigt nur die ID
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
            //Gibt die Anzahl der Sheets aus
            Data.SaveDataString("UserCharSheets", request.downloadHandler.text);
            request.Dispose();
        }
    }





}

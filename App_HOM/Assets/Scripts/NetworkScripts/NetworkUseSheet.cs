using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkUseSheet : MonoBehaviour
{
    //In Arbeit
    //Hier sollen alle Daten während der Arbeit am Bogen gespeichert und geladen werden können

    public PlayerData Data;


    public void GetMultipleObjectsData(string data)
    {
        if (data == "person")
        {

        }
        else if (data == "baseValue")
        {

        }
        else if (data == "item")
        {

        }
        else if (data == "modi")
        {

        }
        else if (data == "ambi")
        {

        }
        else if (data == "abil")
        {

        }
        else
            Debug.Log("Fail");
    }

    public IEnumerator GiveValues(string Url, int type)
    {
        Debug.Log("Connecting");
        WWWForm form = new WWWForm();
        form.AddField("UserID", Data.data["UserID"]);
        form.AddField("SheetNr", Data.data["SheetNr"]);
        UnityWebRequest request = UnityWebRequest.Post(Url, form);
        yield return request.Send();
        if (request.isNetworkError || request.isHttpError)
        {
            //Warning.text = "Networkerror";
            Debug.LogError("Networkerror");
        }
        else
        {
            string Texti = request.downloadHandler.text;
            ReadString(Texti, type);          
            request.Dispose();
        }
    }

    void ReadString(string Text, int type)
    {
        string[] textArray = Text.Split(" "[0]);
        if(type == 0)
        {
            for(int i = 0; i <= textArray.Length; i++)
            {

            }
        }
        Debug.Log(textArray.Length);
    }
}

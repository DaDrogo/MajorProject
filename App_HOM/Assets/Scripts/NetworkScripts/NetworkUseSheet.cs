using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkUseSheet : MonoBehaviour
{
    //In Arbeit
    //Hier sollen alle Daten während der Arbeit am Bogen gespeichert und geladen werden können

    public PlayerData Data;
    public CharSheetManager manage;


    public void GetMultipleObjectsData(string data)
    {
        if (data == "person")
        {
            StartCoroutine(GiveValues(UrlStrings.GET_PERSON, 0));
        }
        else if (data == "baseValue")
        {

            StartCoroutine(GiveValues(UrlStrings.GET_BASEVALUES, 1));
        }
        else if (data == "amounts")
        {

            StartCoroutine(GiveValues(UrlStrings.GET_BASEVALUES, 2));
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

    public IEnumerator GiveValues(string Url,int type)
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
            Debug.Log(Texti);
            ReadString(Texti, type);          
            request.Dispose();
        }
    }

    void ReadString(string Text, int type)
    {
        
        if(type == 0)
        {
            string[] textArray = Text.Split("|"[0]);
            for (int i = 0; i < textArray.Length; i++)
            {
                manage.PersonStrings[i] = textArray[i];
            }
        }
        else if(type == 1)
        {
            string[] textArray = Text.Split(" "[0]);
            for (int i = 0; i < textArray.Length; i++)
            {
                manage.baseValuesInt[i] = int.Parse(textArray[i]);
                Debug.Log(manage.baseValuesInt[i]);
                manage.MakebaseValues();
            }
        }
        else if (type == 2)
        {
            string[] textArray = Text.Split(" "[0]);
            for (int i = 0; i < textArray.Length; i++)
            {
                manage.amountsInt[i] = int.Parse(textArray[i]);
            }
        }
    }
}

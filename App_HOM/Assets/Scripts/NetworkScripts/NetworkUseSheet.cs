using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

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

    public void LoadObyekts(int obyekt)
    {
        if (obyekt == 0)
        {
            StartCoroutine(GiveValues(UrlStrings.LOAD_MODI, 3));
        }
        else if (obyekt == 1)
        {
            StartCoroutine(GiveValues(UrlStrings.LOAD_ABILITY, 4));
        }
        else if(obyekt == 2)
        {
            StartCoroutine(GiveValues(UrlStrings.LOAD_ITEM, 5));
        }
    }

    public void SafeObyekts(int obyekt)
    {
        if (obyekt == 0)
        {
            StartCoroutine(GiveValues(UrlStrings.SAFE_MODI, 0));
            
        }
        else if (obyekt == 1)
        {
            StartCoroutine(GiveValues(UrlStrings.SAFE_ABILITY, 1));
        }
        else if (obyekt == 2)
        {
            //speichern der daten
            manage.amountsInt[obyekt]++;
            foreach (TMP_InputField inp in manage.itemInputs)
            {
                Data.SaveDataInput(inp);
            }
            //verbindung zur datenbank
            StartCoroutine(DataObyektz(UrlStrings.SAFE_ITEM, 2));          
        }
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
            ReadString(Texti, type);          
            request.Dispose();
        }
    }

    public IEnumerator DataObyektz(string Url, int type)
    {
        Debug.Log("Connecting: "+ type);
        WWWForm form = new WWWForm();
        form.AddField("UserID", Data.data["UserID"]);
        form.AddField("SheetNr", Data.data["SheetNr"]);
        //modi
        if (type == 0)
        {
            form.AddField("modiNr", manage.amountsInt[type]+1);
        }
        //abil
        else if(type == 1)
        {
            form.AddField("abilNr", manage.amountsInt[type] + 1);
        }
        //item
        else if(type == 2)
        {
            Debug.Log(Data.data["ItemName"]);
            Debug.Log(manage.amountsInt[type]);

            Debug.Log(Data.data["ItemType"]);
            Debug.Log(Data.data["ItemWeight"]);
            Debug.Log(Data.data["ItemDescription"]);
            form.AddField("ItemNr", manage.amountsInt[type]);
            form.AddField("ItemName ", Data.data["ItemName"]);
            form.AddField("ItemType ", Data.data["ItemType"]);
            form.AddField("ItemWeight ", Data.data["ItemWeight"]);
            form.AddField("ItemDescription ", Data.data["ItemDescription"]);
        }
        UnityWebRequest request = UnityWebRequest.Post(Url, form);
        yield return request.Send();
        if (request.isNetworkError || request.isHttpError)
        {
            //Warning.text = "Networkerror";
            Debug.LogError("Networkerror");
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            request.Dispose();
        }
    }

    void ReadString(string Text, int type)
    {
        
        if(type == 0)
        {
            string[] textArray = Text.Split("|"[0]);
            for (int i = 0; i < manage.PersonStrings.Length; i++)
            {
                manage.PersonStrings[i] = textArray[i];
                
            }
            for (int i = 9; i < 13; i++)
            {
                manage.DestinyStrings[i-9] = textArray[i];

            }
            manage.MakeDestiny();
        }
        else if(type == 1)
        {
            string[] textArray = Text.Split(" "[0]);
            for (int i = 0; i < textArray.Length; i++)
            {
                manage.baseValuesInt[i] = int.Parse(textArray[i]);
                
            }
            manage.MakebaseValues();
        }
        else if (type == 2)
        {
            string[] textArray = Text.Split("|"[0]);
            for (int i = 0; i < textArray.Length; i++)
            {
                manage.amountsInt[i] = int.Parse(textArray[i]);
            }
            manage.StartAfterNetwork();
        }
    }
}

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

            StartCoroutine(GiveValues(UrlStrings.GET_AMOUNTS, 2));
        }
        else
            Debug.Log("Fail");
    }

    public void SaveMultipleObjectsData(string data)
    {
        if (data == "person")
        {
            StartCoroutine(UpdateValues(UrlStrings.UPDATE_PERSON, 0));
        }
        else if (data == "baseValue")
        {

            StartCoroutine(UpdateValues(UrlStrings.UPDATE_BASEVALUES, 1));
        }
        else if (data == "amounts")
        {

            StartCoroutine(UpdateValues(UrlStrings.UPDATE_AMOUNTS, 2));
        }
        else
            Debug.Log("Fail");
    }

    public void GetObyekts(int obyekt, int amount)
    {
        if (obyekt == 0)
        {
            Debug.Log("Loaded Modi");
            StartCoroutine(LoadObyektz(UrlStrings.LOAD_MODI, obyekt, amount));
        }
        else if (obyekt == 1)
        {
            Debug.Log("Loaded Ability");
            StartCoroutine(LoadObyektz(UrlStrings.LOAD_ABILITY, obyekt, amount));
        }
        else if(obyekt == 2)
        {
            Debug.Log("Loaded Item");
            StartCoroutine(LoadObyektz(UrlStrings.LOAD_ITEM,obyekt, amount));
        }
    }

    public void SafeObyekts(int obyekt)
    {

        if (obyekt == 0)
        {
            Data.SaveDataString("ModiPotenz", "0");
            Data.SaveDataString("ModiLvl", "0");
            foreach (TMP_InputField inp in manage.modiInputs)
            {
                Data.SaveDataInput(inp);
            }
            StartCoroutine(DataObyektz(UrlStrings.SAFE_MODI, 0));
            
        }
        else if (obyekt == 1)
        {
            Data.SaveDataText(manage.abiDropdown);
            foreach (TMP_InputField inp in manage.abiInputs)
            {
                Data.SaveDataInput(inp);
            }
            StartCoroutine(DataObyektz(UrlStrings.SAFE_ABILITY, 1));
        }
        else if (obyekt == 2)
        {
            //speichern der daten
            
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

    public IEnumerator UpdateValues(string Url, int type)
    {
        Debug.Log("Connecting");
        WWWForm form = new WWWForm();
        form.AddField("UserID", Data.data["UserID"]);
        form.AddField("SheetNr", Data.data["SheetNr"]);

        if(type == 2)
        {
            form.AddField("ModiAmount", manage.amountsInt[0]);
            form.AddField("AbilityAmount", manage.amountsInt[1]);
            form.AddField("ItemAmount", manage.amountsInt[2]);
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
    
            request.Dispose();
        }
    }


    public IEnumerator LoadObyektz(string Url, int type, int amount)
    {
        
        Debug.Log("Connecting Obyektz: " + type);
        WWWForm form = new WWWForm();
        form.AddField("UserID", Data.data["UserID"]);
        form.AddField("SheetNr", Data.data["SheetNr"]);
        //modi
        if (type == 0)
        {
            form.AddField("ModiNr", amount);
        }
        //abil
        else if (type == 1)
        {
            form.AddField("AbiNr", amount);
        }
        //item
        else if (type == 2)
        {
            form.AddField("ItemNr", amount);
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
            string Texti = request.downloadHandler.text;
            ReadObyektz(Texti, type, amount);
            Debug.Log(request.downloadHandler.text);
            request.Dispose();
        }
    }

    public IEnumerator DataObyektz(string Url, int type)
    {
        manage.amountsInt[type]++;

        Debug.Log("Connecting Obyektz: "+ type);
        WWWForm form = new WWWForm();
        form.AddField("UserID", Data.data["UserID"]);
        form.AddField("SheetNr", Data.data["SheetNr"]);
        //modi
        if (type == 0)
        {
            form.AddField("ModiNr", manage.amountsInt[type]);
            form.AddField("ModiName", Data.data["ModiName"]);
            form.AddField("ModiPotenz", Data.data["ModiPotenz"]);
            form.AddField("ModiLvl", Data.data["ModiLvl"]);
        }
        //abil
        else if(type == 1)
        {
            form.AddField("AbiNr", manage.amountsInt[type]);
            form.AddField("AbiName", Data.data["AbiName"]);
            form.AddField("AbiType", Data.data["AbiType"]);
            form.AddField("AbiSchool", Data.data["AbiSchool"]);
            form.AddField("AbiRange", Data.data["AbiRange"]);
            form.AddField("AbiCost", Data.data["AbiCost"]);
            form.AddField("AbiLength", Data.data["AbiLength"]);
            form.AddField("AbiEffect", Data.data["AbiEffect"]);
        }
        //item
        else if(type == 2)
        {
            form.AddField("ItemNr", manage.amountsInt[type]);
            form.AddField("ItemName", Data.data["ItemName"]);
            form.AddField("ItemType", Data.data["ItemType"]);
            form.AddField("ItemWeight", Data.data["ItemWeight"]);
            form.AddField("ItemDescription", Data.data["ItemDescription"]);
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

    void ReadObyektz(string text, int type, int amount)
    {
        string[] textArray = text.Split("|"[0]);
        //modi
        if (type == 0)
        {
            Debug.Log("ACHTUNG");
            Debug.Log(textArray[0]);
            Debug.Log(textArray[1]);
            manage.modis[amount - 1].Nr = textArray[0];
            manage.modis[amount - 1].Name = textArray[1];
            manage.modis[amount - 1].Potenzial = textArray[2];
            manage.modis[amount - 1].Rank = textArray[3];
            //form.AddField("ModiNr", Data.data["ModiNr"]);
        }
        //abil
        else if (type == 1)
        {
            manage.abilitys[amount - 1].Nr = textArray[0];
            manage.abilitys[amount - 1].Name = textArray[1];
            manage.abilitys[amount - 1].Type = textArray[2];
            manage.abilitys[amount - 1].School = textArray[3];
            manage.abilitys[amount - 1].Range = textArray[4];
            manage.abilitys[amount - 1].Length = textArray[5];
            manage.abilitys[amount - 1].Costs = textArray[6];
            manage.abilitys[amount - 1].Effect = textArray[7];
            //.AddField("AbiNr", Data.data["AbiNr"]);
        }
        //item
        else if (type == 2)
        {

            manage.items[amount - 1].Nr = textArray[0];
            manage.items[amount - 1].Name = textArray[1];
            manage.items[amount - 1].Type = textArray[2];
            manage.items[amount - 1].Weight = textArray[3];
            manage.items[amount - 1].Description = textArray[4];

        }
    }
}

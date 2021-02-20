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

    public void SaveMultipleObjectsData(int destroy)
    {
        StartCoroutine(UpdateValues(UrlStrings.UPDATE_AMOUNTS, destroy));
    }

    public void GetObyekts(int obyekt)
    {
        if (obyekt == 0)
        {
            Debug.Log("Loaded Modi");
            StartCoroutine(LoadObyektz(UrlStrings.LOAD_MODI, obyekt, 0));
        }
        else if (obyekt == 1)
        {
            Debug.Log("Loaded Ability");
            StartCoroutine(LoadObyektz(UrlStrings.LOAD_ABILITY, obyekt, 0));
        }
        else if(obyekt == 2)
        {
            Debug.Log("Loaded Item");
            StartCoroutine(LoadObyektz(UrlStrings.LOAD_ITEM,obyekt, 0));
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

    public void UpdateObyekts(int obyekt)
    {

        if (obyekt == 0)
        {
            foreach (TMP_InputField inp in manage.modiShow)
            {
                Data.SaveDataInput(inp);
            }
            StartCoroutine(WataObyektz(UrlStrings.UPDATE_MODI, obyekt));

        }
        else if (obyekt == 1)
        {

            foreach (TMP_InputField inp in manage.abiShow)
            {
                Data.SaveDataInput(inp);
            }
            StartCoroutine(WataObyektz(UrlStrings.UPDATE_ABILITY, obyekt));
        }
        else if (obyekt == 2)
        {
            //speichern der daten

            foreach (TMP_InputField inp in manage.itemShow)
            {
                Data.SaveDataInput(inp);
            }
            //verbindung zur datenbank
            StartCoroutine(WataObyektz(UrlStrings.UPDATE_ITEM, obyekt));
        }
    }

    public void DeleteObyekts(int obyekt)
    {
        manage.amountsInt[obyekt]--;
        int nr = manage.List[obyekt].value + 1;
        if (obyekt == 0)
        {
            StartCoroutine(LoadObyektz(UrlStrings.DELETE_MODI, obyekt,1));
        }
        else if (obyekt == 1)
        {
            StartCoroutine(LoadObyektz(UrlStrings.DELETE_ABILITY, obyekt, 1));
        }
        else if (obyekt == 2)
        {
            StartCoroutine(LoadObyektz(UrlStrings.DELETE_ITEM, obyekt, 1));
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
        form.AddField("ModiAmount", manage.amountsInt[0]);
        form.AddField("AbilityAmount", manage.amountsInt[1]);
        form.AddField("ItemAmount", manage.amountsInt[2]);        
        UnityWebRequest request = UnityWebRequest.Post(Url, form);
        yield return request.Send();
        if (request.isNetworkError || request.isHttpError)
        {
            //Warning.text = "Networkerror";
            Debug.LogError("Networkerror");
        }
        else
        {
            if (type == 3)
            {
                request.Dispose();
            }
            else
            {
                manage.RefreshDropdown(type);
            }
            
            
        }
    }


    public IEnumerator LoadObyektz(string Url, int type, int destroy)
    {
        int amount = 1;
        Debug.Log("Connecting Obyektz: " + type);
        WWWForm form = new WWWForm();
        form.AddField("UserID", Data.data["UserID"]);
        form.AddField("SheetNr", Data.data["SheetNr"]);
        //modi hier müssen die nummern derjänigen hin die gelöscht werden
        if (destroy == 1)
        {
            if (type == 0)
            {
                form.AddField("ModiNr", manage.modis[manage.List[type].value].Nr);
            }
            //abil
            else if (type == 1)
            {
                form.AddField("AbiNr", manage.abilitys[manage.List[type].value].Nr);
            }
            //item
            else if (type == 2)
            {
                form.AddField("ItemNr", manage.items[manage.List[type].value].Nr);
            }
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
            if(destroy == 0)
            {
                Debug.Log("yeah:"+request.downloadHandler.text);
                string Texti = request.downloadHandler.text;
                ReadObyektz(Texti, type);
                request.Dispose();
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
                SaveMultipleObjectsData(type);
                request.Dispose();
            }

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
            manage.RefreshDropdown(type);
            request.Dispose();
        }
    }

    public IEnumerator WataObyektz(string Url, int type)
    {
        int nr = manage.List[type].value + 1;
        Debug.Log("Connecting Obyektz: " + type);
        WWWForm form = new WWWForm();
        form.AddField("UserID", Data.data["UserID"]);
        form.AddField("SheetNr", Data.data["SheetNr"]);

        //modi
        if (type == 0)
        {
            form.AddField("ModiNr", nr);
            form.AddField("ModiName", Data.data["ModiName"]);
            form.AddField("ModiPotenz", Data.data["ModiPotenz"]);
            form.AddField("ModiLvl", Data.data["ModiLvl"]);
        }
        //abil
        else if (type == 1)
        {
            form.AddField("AbiNr", nr);
            form.AddField("AbiName", Data.data["AbiName"]);
            form.AddField("AbiType", Data.data["AbiType"]);
            form.AddField("AbiSchool", Data.data["AbiSchool"]);
            form.AddField("AbiRange", Data.data["AbiRange"]);
            form.AddField("AbiCost", Data.data["AbiCost"]);
            form.AddField("AbiLength", Data.data["AbiLength"]);
            form.AddField("AbiEffect", Data.data["AbiEffect"]);
        }
        //item
        else if (type == 2)
        {            
            form.AddField("ItemNr", nr);
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
            manage.RefreshDropdown(type);
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

    void ReadObyektz(string text, int type)
    {
        
        string[] textArray = text.Split("|"[0]);
        //modi
        if (type == 0)
        {
            manage.modis = new ModiInfos[manage.amountsInt[type] + 1];
            for (int i = 0; i < manage.amountsInt[type]; i++)
            {
                manage.modis[i] = new ModiInfos();
                manage.modis[i].Nr = textArray[0+(4*i)];
                manage.modis[i].Name = textArray[1 + (4 * i)];
                manage.modis[i].Potenzial = textArray[2 + (4 * i)];
                manage.modis[i].Rank = textArray[3 + (4 * i)];
            }            
            //form.AddField("ModiNr", Data.data["ModiNr"]);
        }
        //abil
        else if (type == 1)
        {
            manage.abilitys = new AbilitysInfos[manage.amountsInt[type] + 1];
            for (int i = 0; i < manage.amountsInt[type]; i++)
            {
                manage.abilitys[i] = new AbilitysInfos();
                manage.abilitys[i].Nr = textArray[0 + (8 * i)];
                manage.abilitys[i].Name = textArray[1 + (8 * i)];
                manage.abilitys[i].Type = textArray[2 + (8 * i)];
                manage.abilitys[i].School = textArray[3 + (8 * i)];
                manage.abilitys[i].Range = textArray[4 + (8 * i)];
                manage.abilitys[i].Length = textArray[5 + (8* i)];
                manage.abilitys[i].Costs = textArray[6 + (8 * i)];
                manage.abilitys[i].Effect = textArray[7 + (8 * i)];
            }            
            //.AddField("AbiNr", Data.data["AbiNr"]);
        }
        //item
        else if (type == 2)
        {
            manage.items = new ItemInfos[manage.amountsInt[type] + 1];
            for (int i = 0; i < manage.amountsInt[type]; i++)
            {
                manage.items[i] = new ItemInfos();
                manage.items[i].Nr = textArray[0 + (5 * i)];
                manage.items[i].Name = textArray[1 + (5 * i)];
                manage.items[i].Type = textArray[2 + (5 * i)];
                manage.items[i].Weight = textArray[3 + (5 * i)];
                manage.items[i].Description = textArray[4 + (5 * i)];

            }
        }
        manage.GiveDropdownsOptions(type);
    }
}

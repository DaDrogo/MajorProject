using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class NetworkCreateSheet : MonoBehaviour
{
    [SerializeField]
    private PlayerData Data;

    public void SafeSheet()
    {
        // außerdem fehlt hier noch eine Fehleranalyse
        StartCoroutine(SafeCharacterSheet());
        StartCoroutine(SaveInfos());
    }

    public void LoadSheet()
    {
        // außerdem fehlt hier noch eine Fehleranalyse
        StartCoroutine(LoadCharacterSheet());
    }

    public IEnumerator LoadCharacterSheet()
    {
        WWWForm form = new WWWForm();
        form.AddField("UserID", Data.data["UserID"]);
        form.AddField("CharSheetNr", Data.data["CharSheetNr"]);
        UnityWebRequest request = UnityWebRequest.Post(UrlStrings.LOAD_SHEET, form);
        yield return 0;

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError("Networkerror");
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            request.Dispose();
        }
    }

    //ToDo
    //soll später mit einer Datei gespeichert werden.
    //jetzt erstmal für den first case

    public IEnumerator SaveInfos()
    {
        Debug.Log("Connecting");
        WWWForm form = new WWWForm();
        form.AddField("UserID", Data.data["UserID"]);
        form.AddField("UserCharSheets ", Data.data["UserCharSheets"]);
        UnityWebRequest request = UnityWebRequest.Post(UrlStrings.SAVEUSERINFO, form);
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
            request.Dispose();
        }
    }

    public IEnumerator SafeCharacterSheet()
    {

        //sendet die Daten des Bogens an die Datenbank
        //Noch wurden diese nicht ausgewertet, sondern nur all Namen gespeichert um diese dann auch wieder im Bogen anzuzeigen
        //Im Bogen werden diese Namen dann ausgewertet
        WWWForm form = new WWWForm();
        //Person____________________________________

        //foreach (var key in Data.data.Keys)
        //{
        //    string value = "";
        //    Data.data.TryGetValue(key, out value);
        //
        //    form.AddField(key, value);
        //}
        Debug.Log(Data.data["UserID"]);
        form.AddField("UserID", Data.data["UserID"]);
        form.AddField("SheetNr", Data.data["SheetNr"]);
        form.AddField("CharRace", Data.data["CharRace"]);
        form.AddField("CharRaceAbility", Data.data["CharRaceAbility"]);
        form.AddField("CharName", Data.data["CharName"]);
        form.AddField("CharWeight", Data.data["CharWeight"]);
        form.AddField("CharHeight", Data.data["CharHeight"]);
        form.AddField("CharAge", Data.data["CharAge"]);
        form.AddField("CharHairColor", Data.data["CharHairColor"]);
        form.AddField("CharSkinColor", Data.data["CharSkinColor"]);
        form.AddField("CharGender", Data.data["CharGender"]);
        form.AddField("CharLanguage", Data.data["CharLanguage"]);
        form.AddField("CharReligion", Data.data["CharReligion"]);
        form.AddField("CharDestiny", Data.data["CharDestiny"]);
        form.AddField("CharDestinyLevel", Data.data["CharDestinyLevel"]);
        form.AddField("CharAmbition", Data.data["CharAmbition"]);
        form.AddField("ModiAmount", Data.data["ModiAmount"]);
        form.AddField("AbilityAmount", Data.data["AbilityAmount"]);
        form.AddField("ItemAmount", Data.data["ItemAmount"]);
        UnityWebRequest request = UnityWebRequest.Post(UrlStrings.SAVE_SHEET, form);
        yield return request.Send();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError("Networkerror");
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            request.Dispose();
        }
    }

    public IEnumerator SafeGW()
    {
        WWWForm form = new WWWForm();
        form.AddField("UserID", Data.data["UserID"]);
        form.AddField("CharSheetNr", Data.data["CharSheetNr"]);

        form.AddField("AG   	  ", Data.data["AG   	      "]);
        form.AddField("AGplus    ", Data.data["AGplus        "]);
        form.AddField("AGminus   ", Data.data["AGminus       "]);
        form.AddField("KR   	   ", Data.data["KR   	       "]);
        form.AddField("KRplus    ", Data.data["KRplus        "]);
        form.AddField("KRminus   ", Data.data["KRminus       "]);
        form.AddField("AU   	   ", Data.data["AU   	       "]);
        form.AddField("AUplus    ", Data.data["AUplus        "]);
        form.AddField("AUminus   ", Data.data["AUminus       "]);
        form.AddField("RE   	   ", Data.data["RE   	       "]);
        form.AddField("REplus    ", Data.data["REplus        "]);
        form.AddField("REminus   ", Data.data["REminus       "]);
        form.AddField("GE   	   ", Data.data["GE   	       "]);
        form.AddField("GEplus    ", Data.data["GEplus        "]);
        form.AddField("GEminus   ", Data.data["GEminusl     "]);
        form.AddField("VE   	   ", Data.data["VE   	       "]);
        form.AddField("VEplus   ", Data.data["VEplus       "]);
        form.AddField("VEminus   ", Data.data["VEminus       "]);

        UnityWebRequest request = UnityWebRequest.Post(UrlStrings.SAVE_GW, form);
        yield return 0;

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError("Networkerror");
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            request.Dispose();
        }
    }
}

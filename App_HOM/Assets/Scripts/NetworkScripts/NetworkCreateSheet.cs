using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class NetworkCreateSheet : MonoBehaviour
{
    //hier werden alle Daten gespeichert und wiedergegeben
    [SerializeField]
    private PlayerData Data;

    GameObject manager;

    //wird ausgeführt, wenn ein neuer Charakterbogen gespeichert wurde
    public void SafeSheet()
    {
        // außerdem fehlt hier noch eine Fehleranalyse
        StartCoroutine(SafeCharacterSheet(UrlStrings.SAVE_SHEET));
        StartCoroutine(SaveInfos(UrlStrings.UPDATE_USERINFO, 0));
    }

    //wenn sich ein neuer Nutzer registriert benötigt er neue UserInfos
    public void RegisterUserInfos(string url)
    {
        StartCoroutine(SaveInfos(url, 1));
    }

    //lädt die Daten aus der Datenbank auf die PlayerData
    public void LoadSheet()
    {
        // außerdem fehlt hier noch eine Fehleranalyse
        StartCoroutine(LoadCharacterSheet());
    }

    public void SafeGW()
    {
        StartCoroutine(SafeAllGW(UrlStrings.SAVE_GW, 1));
    }

    public void UpdateCharSheet()
    {
        StartCoroutine(SafeCharacterSheet(UrlStrings.UPDATE_PERSON));
        StartCoroutine(SafeAllGW(UrlStrings.UPDATE_BASEVALUES, 0));
    }

    //in Arbeit
    public IEnumerator LoadCharacterSheet()
    {
        WWWForm form = new WWWForm();
        form.AddField("UserID", Data.data["UserID"]);
        form.AddField("SheetNr", Data.data["SheetNr"]);
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

    //erhält zwei URL (Save und Update UserInfo) um auch das zu machen
    public IEnumerator SaveInfos(string Url, int type)
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
            Debug.Log("Ergebnis: "+request.downloadHandler.text);
            if(type == 1)
            {
                manager = GameObject.FindGameObjectWithTag("Manager");
                manager.GetComponent<LoginManager>().OpenP("Erfolgreich registriert, bitte weiter.");
            }
            
            request.Dispose();
        }
    }

    //TODO:
    //Noch wurden diese nicht ausgewertet, sondern nur all Namen gespeichert um diese dann auch wieder im Bogen anzuzeigen
    //Im Bogen werden diese Namen dann ausgewertet

    public IEnumerator SafeCharacterSheet(string url)
    {

        //sendet die Daten des Bogens an die Datenbank


        //old Code
        //foreach (var key in Data.data.Keys)
        //{
        //    string value = "";
        //    Data.data.TryGetValue(key, out value);
        //
        //    form.AddField(key, value);
        //}
        WWWForm form = new WWWForm();
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
        UnityWebRequest request = UnityWebRequest.Post(url, form);
        yield return request.Send();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError("Networkerror");
        }
        else
        {
            Debug.Log("Ergebnis: " + request.downloadHandler.text);
            request.Dispose();
        }
    }

    //In Arbeit
    public IEnumerator SafeAllGW(string url, int style)
    {
        //soll die GW der Charakterbögen speichern.
        //wird ähnlich funktionieren wie SafeCharacterSheet und ist nur da um die Datenbanken kleiner zu halten
        WWWForm form = new WWWForm();
        Debug.Log("Connecting GW");
        form.AddField("UserID", Data.data["UserID"]);
        form.AddField("SheetNr", Data.data["SheetNr"]);
        if (style == 0)
        {
            Debug.Log("0");
            form.AddField("AG", Data.data["AG"]);
            form.AddField("AGplus", Data.data["AGplus"]);
            form.AddField("AGminus", Data.data["AGminus"]);
            form.AddField("KR", Data.data["KR"]);
            form.AddField("KRplus", Data.data["KRplus"]);
            form.AddField("KRminus", Data.data["KRminus"]);
            form.AddField("AU", Data.data["AU"]);
            form.AddField("AUplus", Data.data["AUplus"]);
            form.AddField("AUminus", Data.data["AUminus"]);
            form.AddField("RE", Data.data["RE"]);
            form.AddField("REplus", Data.data["REplus"]);
            form.AddField("REminus", Data.data["REminus"]);
            form.AddField("GE", Data.data["GE"]);
            form.AddField("GEplus", Data.data["GEplus"]);
            form.AddField("GEminus", Data.data["GEminus"]);
            form.AddField("VE", Data.data["VE"]);
            form.AddField("VEplus", Data.data["VEplus"]);
            form.AddField("VEminus", Data.data["VEminus"]);
        }
        else
        {
            Debug.Log("1");
            form.AddField("AG", Data.data["AG"]);
            form.AddField("AGplus", "0");
            form.AddField("AGminus", "0");
            form.AddField("KR", Data.data["KR"]);
            form.AddField("KRplus", "0");
            form.AddField("KRminus", "0");
            form.AddField("AU", Data.data["AU"]);
            form.AddField("AUplus", "0");
            form.AddField("AUminus", "0");
            form.AddField("RE", Data.data["RE"]);
            form.AddField("REplus", "0");
            form.AddField("REminus", "0");
            form.AddField("GE", Data.data["GE"]);
            form.AddField("GEplus", "0");
            form.AddField("GEminus", "0");
            form.AddField("VE", Data.data["VE"]);
            form.AddField("VEplus", "0");
            form.AddField("VEminus", "0");
        }
        UnityWebRequest request = UnityWebRequest.Post(url, form);
        yield return request.Send();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError("Networkerror");
        }
        else
        {
            Debug.Log("Grundwerte: " + request.downloadHandler.text);
            request.Dispose();
        }
    }


}

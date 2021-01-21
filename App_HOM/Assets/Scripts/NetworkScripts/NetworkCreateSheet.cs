using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class NetworkCreateSheet : MonoBehaviour
{
    [SerializeField]
    private PlayerData Data;


    [SerializeField]
    private TMP_Text Info;

    [SerializeField]
    private string urlCreate;

    // soll die ID vom einloggen erhhlten
    [SerializeField]
    private int UserID = 111;

    [SerializeField]
    public TMP_Text[] Chars;

    //Momentane Lösung gefällt mir null muss noch geändert werden
    private int CharCivAbility;
    public void ChangeAbility(int Abi)
    {
        CharCivAbility = Abi;
    }

    public void SafeSheet(int page)
    {
        // außerdem fehlt hier noch eine Fehleranalyse
        StartCoroutine(SafeCharactersheet(page));
    }



    //ToDo
    //soll später mit einer Datei gespeichert werden.
    //jetzt erstmal für den first case

    public IEnumerator SafeCharactersheet(int page)
    {

        //sendet die Daten des Bogens an die Datenbank
        //Noch wurden diese nicht ausgewertet, sondern nur all Namen gespeichert um diese dann auch wieder im Bogen anzuzeigen
        //Im Bogen werden diese Namen dann ausgewertet
        WWWForm form = new WWWForm();
        //Person____________________________________
                
        foreach(var key in Data.data.Keys)
        {
            string value = "";
            Data.data.TryGetValue(key, out value);

            form.AddField(key, value);
        }

            //form.AddField("userid", UserID);
            //form.AddField("charciv", Chars[0].text + " " + CharCivAbility);
            //form.AddField("charname", Chars[1].text);
            //form.AddField("charweight", Chars[2].text);
            //form.AddField("charheight", Chars[3].text);
            //form.AddField("charage", Chars[4].text);
            //form.AddField("charcolor", Chars[5].text);
            //form.AddField("charlanguage", Chars[6].text);
            // form.AddField("charreligion", Chars[7].text);
        
            ////Past____________________________________
            // form.AddField("chartraining", Chars[8].text);
            // form.AddField("charfeature",    Chars[9].text);
            // form.AddField("chareducation",  Chars[10].text + " " + CharCivAbility);
            // form.AddField("charenvironment", Chars[11].text + " " + CharCivAbility);

        UnityWebRequest request = UnityWebRequest.Post(urlCreate, form);
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
}

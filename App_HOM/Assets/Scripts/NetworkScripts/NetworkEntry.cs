using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkEntry : MonoBehaviour
{
    public PlayerData Data;

    public LoginManager manager;

    //188.34.197.30/php/Register.php

    public void TestCoroutine(string url)
    {
        StartCoroutine(ConnectDatabase(url));
        Debug.Log(Data.data["UserName"]);
    }

    public IEnumerator ConnectDatabase(string url)
    {
        Debug.Log("Connecting");
        WWWForm form = new WWWForm();
        form.AddField("username", Data.data["UserName"]);
        form.AddField("passport", Data.data["UserPassport"]);
        UnityWebRequest request = UnityWebRequest.Post(url, form);
        yield return request.Send();
    
        if (request.isNetworkError || request.isHttpError)
        {
            //Warning.text = "Networkerror";
            Debug.LogError("Networkerror");
        }
        else if (request.downloadHandler.text == "RegisterWrong")
        {
            Debug.Log("Benutzername vergeben.");
            request.Dispose();
        }
        else if (request.downloadHandler.text == "WrongUser")
        {
            Debug.Log( "Benutzername falsch.");
            request.Dispose();
        }
        else if (request.downloadHandler.text == "WrongPass")
        {
            Debug.Log("Passwort falsch.");
            request.Dispose();
        }
        else if (request.downloadHandler.text == "Succces")
        {
            manager.OpenP("Erfolgreich Registriert, sie sind nun eingeloggt.");
            Debug.Log("Registriert.");
            request.Dispose();
        }
        else
        {
            manager.OpenP("Erfolgreich eingeloggt, bitte weiter.");
            Debug.Log(request.downloadHandler.text + " erfolgreich eingeloggt");
            //Test soll die ID von PHP bekommen
            // wird noch getestet und wo es hingehört
            Data.SaveDataString("UserID", request.downloadHandler.text);
            request.Dispose();
            
        }
    }
}

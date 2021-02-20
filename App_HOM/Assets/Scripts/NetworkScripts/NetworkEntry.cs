using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkEntry : MonoBehaviour
{
    //hier werden alle Daten gespeichert und wiedergegeben
    public PlayerData Data;

    //gibt mithilfe eine PopUps Feedback
    public LoginManager manager;

    //startet den Netzwerkaufbau
    public void TestCoroutine(string url)
    {
        StartCoroutine(ConnectDatabase(url));
        Debug.Log(Data.data["UserName"]);
    }

    //erhält eine URl zum verbinden entweder Login oder Register
    public IEnumerator ConnectDatabase(string url)
    {
        //hier werden die Daten aus Data eingegeben um sie an den Server zu senden
        Debug.Log("Connecting");
        WWWForm form = new WWWForm();
        form.AddField("username", Data.data["UserName"]);
        form.AddField("passport", Data.data["UserPassport"]);
        UnityWebRequest request = UnityWebRequest.Post(url, form);
        yield return request.Send();
    
        //Antwort je nach den Daten, welche gesendet wurden
        if (request.isNetworkError || request.isHttpError)
        {
            //Warning.text = "Networkerror";
            Debug.LogError("Networkerror");
            manager.ShowFail("Netzwerkfehler");
        }
        else if (request.downloadHandler.text == "RegisterWrong")
        {
            Debug.Log("Benutzername vergeben.");
            manager.ShowFail("Benutzername vergeben.");
            request.Dispose();
        }
        else if (request.downloadHandler.text == "WrongUser")
        {
            Debug.Log( "Benutzername falsch.");
            manager.ShowFail("Benutzername falsch.");
            request.Dispose();
        }
        else if (request.downloadHandler.text == "WrongPass")
        {
            Debug.Log("Passwort falsch.");
            manager.ShowFail("Passwort falsch.");
            request.Dispose();
        }
        else if (request.downloadHandler.text == "Succces")
        {
            Debug.Log("Registriert.");
            manager.SwitchToMenu();
            request.Dispose();
        }
        else
        {
            Debug.Log(request.downloadHandler.text + " erfolgreich eingeloggt");
            //speichert die ID des Nutzers, nach dem einloggen. Mit dieser ID kann auf alles zugegriffen werden
            Data.SaveDataString("UserID", request.downloadHandler.text);
            manager.SwitchToMenu();
            request.Dispose();
            
        }
    }
}

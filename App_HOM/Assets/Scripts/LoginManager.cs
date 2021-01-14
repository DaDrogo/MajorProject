using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public PlayerData ID;

    public GameObject PopUp;


    //public TMP_Text Username;
    //public TMP_Text Passport;
    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(side == 0)
            {
                Application.Quit();
            }
            else
            {
                SiwtchSites(0);
            }
        }
    }
    public TMP_InputField[] Inputs;

    public void Login()
    {
        ID.SaveData(Inputs[0]);
        ID.SaveData(Inputs[1]);
        OpenP();
    }

    public void ToMenu()
    {
        CloseP();
        SceneManager.LoadScene(1);
    }
    //127.0.0.1/php/Login.php
    //127.0.0.1/php/Register.php

    // zum einfachen erstellen von Tabs
    //benötigt Buttons, denen diese funktion gegeben wird mit dem int, der dem Tab zugeordent ist auf dem Script in dem Array

    public GameObject Active;
    public GameObject[] Sites;
    int side;

    public void SiwtchSites(int Site)
    {
        side = Site;
        Active.gameObject.SetActive(false);
        Active = Sites[side];
        Active.gameObject.SetActive(true);
    }

    public void OpenP()
    {
        PopUp.SetActive(true);
    }

    public void CloseP()
    {
        PopUp.SetActive(false);
    }



    //public void PressButton(string url)
    //{
    //    //sende Strings zum einloggen an die Datenbank
    //    //erhalte ein Signal ob korrekt oder fehlerhaft
    //    //bei erfolg wechsel des Fensters mit den daten der bank bei misserfolg Nachricht durch Text
    //
    //    int userLE = Username.text.Length;
    //    int passLE = Passport.text.Length;
    //
    //    if (Username.text.ToString() == "123test")
    //    {
    //        ToMenu();
    //    }
    //
    //    if (userLE >=2 && passLE>=2  )
    //    {
    //        
    //        Debug.Log(Username.text);
    //        Debug.Log(Passport.text);
    //        Warning.text = "Danke";
    //        StartCoroutine(ConnectDatabase(url));
    //        //GameObject.FindGameObjectWithTag("ID").GetComponent<PlayerID>().ID = 1;
    //        //ToMenu();
    //    }
    //    else if(userLE <= 1)
    //    {
    //        Warning.text = "Bitte Benutzernamen eingeben.";
    //    }
    //    else if (passLE <= 1)
    //    {
    //        Warning.text = "Bitte Passwort eingeben.";
    //    }
    //    else
    //    {
    //        Warning.text = "Bitte etwas eingeben";
    //    }
    //}

    //public void LogOut()
    //{
    //
    //}
    //
    //public IEnumerator ConnectDatabase(string url)
    //{
    //    WWWForm form = new WWWForm();
    //    form.AddField("username", Username.text.ToString());
    //    form.AddField("passport", Passport.text.ToString());
    //    UnityWebRequest request = UnityWebRequest.Post(url, form);
    //    yield return request.Send();
    //
    //    if (request.isNetworkError || request.isHttpError)
    //    {
    //        Warning.text = "Networkerror";
    //        Debug.LogError("Networkerror");
    //    }
    //    else if(request.downloadHandler.text == "RegisterWrong")
    //    {
    //        Warning.text = "Benutzername ist vergeben.";
    //        request.Dispose();
    //    }
    //    else if(request.downloadHandler.text == "WrongUser")
    //    {
    //        Warning.text = "Benutzername falsch.";
    //        request.Dispose();
    //    }
    //    else if (request.downloadHandler.text == "WrongPass")
    //    {
    //        Warning.text = "Benutzername falsch.";
    //        request.Dispose();
    //    }
    //    else if (request.downloadHandler.text == "Succes")
    //    {
    //        Warning.text = "Account Registriert.";
    //        request.Dispose();
    //    }
    //    else
    //    {
    //        Debug.Log(request.downloadHandler.text);
    //        //Test soll die ID von PHP bekommen
    //        // wird noch getestet und wo es hingehört
    //        GameObject.FindGameObjectWithTag("ID").GetComponent<PlayerID>().ID = int.Parse(request.downloadHandler.text);
    //        request.Dispose();
    //        ToMenu();
    //    }
    //}


}

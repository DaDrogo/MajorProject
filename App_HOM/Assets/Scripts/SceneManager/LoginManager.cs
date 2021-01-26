using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public PlayerData ID;
    public NetworkEntry Entry;

    public GameObject PopUp;

    string register = "188.34.197.30/Register.php";
    string login = "188.34.197.30/Login.php";

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
        ID.SaveDataInput(Inputs[0]);
        ID.SaveDataInput(Inputs[1]);
        Entry.TestCoroutine(login); 
    }

    public void Register()
    {
        ID.SaveDataInput(Inputs[2]);
        ID.SaveDataInput(Inputs[3]);
        Entry.TestCoroutine(register);       
    }

    public void ToMenu()
    {
        CloseP();
        SceneManager.LoadScene(1);
    }
    //127.0.0.1/php/Login.php
    //188.34.197.30/php/Register.php

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

    public void OpenP(string PopUpText)
    {
        PopUp.GetComponentInChildren<TMP_Text>().text = PopUpText;
        PopUp.SetActive(true);
    }

    public void CloseP()
    {
        PopUp.SetActive(false);
    }
}

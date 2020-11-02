using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SheetManager : MonoBehaviour
{
    //network Script
    public NetworkCreateSheet net;

    //PopUp
    [SerializeField]
    GameObject PopUp;
    [SerializeField]
    TMP_Text Info;
    private bool Acceptens;
    private int Popups;

    //Pages
    [SerializeField]
    private GameObject[] Pages;
    private int From;

    //Legt Scene am anfang fest
    private void Awake()
    {
        Acceptens = false;
        //from ist bei Entry also 0
        From = 0;
        Pages[0].SetActive(true);
        PopUp.SetActive(false);
        Popups = 0;

    }

    private void Start()
    {

    }

    public void Update()
    {
        //Soll zwischen den Seiten des Fragebogens wechseln oder die Scene ändern
        //Save ist hier nicht inbegriffen
        if (Acceptens&&Popups==1)
        {
            Popups = 0;
            PopUp.SetActive(false);
            switch (From)
                {
                case -1:
                    //Zurück Button bei Entry
                    ChangeScene(1);
                    break;
                case 2:
                    //weiter button bei entry
                    Debug.Log(From);
                    SwitchPage(Pages[0], Pages[1]);
                    break;
                case 1:
                    //Zurück button bei Person
                    Debug.Log(From);
                    SwitchPage(Pages[1], Pages[0]);
                    From--;
                    break;
                case 4:
                    //weiter button bei Person
                    Debug.Log(From);
                    SwitchPage(Pages[1], Pages[2]);
                    break;
                case 3:
                    //Zurück button bei Past
                    Debug.Log(From);
                    SwitchPage(Pages[2], Pages[1]);
                    From--;
                    break;
                case 6:
                    Debug.Log(From);
                    //weiter Button bei Past
                    ChangeScene(3);
                    break;
            }
        }
        else if (Acceptens && Popups == 2)
        {
            Popups = 0;
            PopUp.SetActive(false);
            Acceptens = false;
            net.SafeSheet(9);
        }
    }

    //Checkt ob das Array voll ist

    public void CheckArray()
    {
        
        TMP_Text[] Array = net.Chars;
        for (int i = 0; i < Array.Length; i++)
        {
            Debug.Log(Array[i].text);
            if (Array[i].text.Length < 2)
            {
                CreateSafeup("Es sind nicht alle Felder augefüllt.");
                break;
            }
            else if(Array.Length == i)
            {
                CreateSafeup("Möchtest du wirklich speichern?");
            }
        }

        Debug.Log(Array.Length);
    }

    //Methode für Update
    void SwitchPage(GameObject FromPage, GameObject ToPage)
    {
        FromPage.SetActive(false);
        ToPage.SetActive(true);
        Acceptens = false;
    }

    //Methode für Update
    void ChangeScene(int scene)
    {
        Acceptens = false;
        SceneManager.LoadSceneAsync(scene);
    }

    // wird den Buttons in der Ecke der UI zugeordnet
    public void CreatePopup(int fr)
    {
        Popups = 1;
        From = From + fr;
        if (fr == 2)
            Info.text = "Möchtest du weiter?";
        else
            Info.text = "Möchtest du zurück?";

        PopUp.SetActive(true);
    }

    void CreateSafeup(string text)
    {
        Popups = 2;
        Info.text = text;
        PopUp.SetActive(true);
    }

    // Wird den Buttons auf dem Popup zugeordnet
    public void ChangeBool(bool change)
    {
        if (change)
            Acceptens = change;
        else
            PopUp.SetActive(false);
    }

}

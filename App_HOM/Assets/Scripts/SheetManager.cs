using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Script für die Fragebogen Scene
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
    void ChangeScene(int scene)
    {
        Acceptens = false;
        SceneManager.LoadSceneAsync(scene);
    }

    void CreateSafeup(string text)
    {
        Popups = 2;
        Info.text = text;
        PopUp.SetActive(true);
    }

    // zum einfachen erstellen von Tabs
    //benötigt Buttons, denen diese funktion gegeben wird mit dem int, der dem Tab zugeordent ist auf dem Script in dem Array

    public GameObject Active;
    public GameObject[] Sites;

    public void SiwtchSites(int Site)
    {
        Active.gameObject.SetActive(false);
        Active = Sites[Site];
        Active.SetActive(true);
    }


}

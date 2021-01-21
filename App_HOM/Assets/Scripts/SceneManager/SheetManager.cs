using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

// Script für die Fragebogen Scene
public class SheetManager : MonoBehaviour
{
    //network Script
    public NetworkCreateSheet net;
    public DropdownManager DM;

    //PopUp
    [SerializeField]
    GameObject PopUp;
    [SerializeField]
    TMP_Text Info;
    private bool Acceptens;
    private int Popups;

    //sollen aufgerufen werden um Text zu laden und ausgewählt zu sein
    public TMP_Dropdown[] Invoker;

    //muss noch gemacht werden mit dem Servers
    public void SaveSheet()
    {
        SwitchScene(1);
    }

    private void Start()
    {
        foreach(TMP_Dropdown b in Invoker)
        {
            InvokeDropdown(b);
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

    void SwitchScene(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    //drückt den Button automatisch
    public void InvokeDropdown(TMP_Dropdown toInvoke)
    {
        toInvoke.onValueChanged.Invoke(0);
    }


}
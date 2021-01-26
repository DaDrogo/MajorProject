using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

// Script für die Fragebogen Scene
public class SheetManager : MonoBehaviour
{
    public NetworkCreateSheet SaveData;
    public PlayerData Data;

    //PopUp
    [SerializeField]
    GameObject PopUp;
    [SerializeField]
    TMP_Text Info;
    private bool Acceptens;
    private int Popups;

    public TMP_Text[] Values;
    public TMP_InputField[] ValuesInput;

    //sollen aufgerufen werden um Text zu laden und ausgewählt zu sein
    public TMP_Dropdown[] Invoker;

    //muss noch gemacht werden mit dem Servers
    public void CancelSheet()
    {
        SwitchScene(1);
    }

    //Hier muss noch was hin um das POP up zu ändern
    //jetzt wird automatisch gespeichert
    public void SaveSheet()
    {
        //PopUp.GetComponent<TMP_Text>().text = "Möchtest du speichern?";
        DetermineValues();
        SaveData.SafeSheet();
        //SaveData.SafeGW();
        PopUp.SetActive(true);
    }

    void DetermineValues()
    {
        foreach (TMP_Text val in Values)
        {
            Data.SaveDataText(val);
        }
        foreach (TMP_InputField inp in ValuesInput)
        {
            Data.SaveDataInput(inp);
        }
        int SheetNr = int.Parse(Data.data[DatabaseData.DataId.UserCharSheets.ToString()]) + 1;
        Debug.Log("SheetNr: " + SheetNr);
        Data.SaveDataString("SheetNr",SheetNr.ToString());
        Data.SaveDataString("ModiAmount", "0");
        Data.SaveDataString("AbilityAmount", "0");
        Data.SaveDataString("ItemAmount", "0");
        Data.SaveDataString("CharDestinyLevel", "1");

    }

    void MakeGW()
    {
        //Erstelle die GW
    }

    
    private void Start()
    {
        int SheetNr = int.Parse(Data.data[DatabaseData.DataId.UserCharSheets.ToString()])+1;
        Debug.Log("SheetNr: "+SheetNr);
        Debug.Log("UserID" + Data.data[DatabaseData.DataId.UserID.ToString()]);
        Debug.Log("UserID" + Data.data[DatabaseData.DataId.CharRace.ToString()]);
        foreach (TMP_Dropdown b in Invoker)
        {
            InvokeDropdown(b);
        }
    }

    //Checkt ob das Array voll ist um abzuspeichern

   // public void CheckArray()
   // {
   //     
   //     TMP_Text[] Array = net.Chars;
   //     for (int i = 0; i < Array.Length; i++)
   //     {
   //         Debug.Log(Array[i].text);
   //         if (Array[i].text.Length < 2)
   //         {
   //             CreateSafeup("Es sind nicht alle Felder augefüllt.");
   //             break;
   //         }
   //         else if(Array.Length == i)
   //         {
   //             CreateSafeup("Möchtest du wirklich speichern?");
   //         }
   //     }
   //
   //     Debug.Log(Array.Length);
   // }

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
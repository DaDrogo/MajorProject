using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

// Script für die Fragebogen Scene

public class CreateSheetManager : MonoBehaviour
{
    public NetworkCreateSheet SaveData;
    public PlayerData Data;

    //PopUp
    public GameObject PopUp;
    public GameObject SaveUp;
    private bool Acceptens;

    public TMP_Text[] Values;
    public TMP_InputField[] ValuesInput;

    public TMP_Dropdown[] Dropdowns;

    //sollen aufgerufen werden um Text zu laden und ausgewählt zu sein
    public TMP_Dropdown[] Invoker;

    public int[] baseValues;

    //muss noch gemacht werden mit dem Servers

    JsonManager json;
    public TextAsset[] baseBaluesTexts;

    private void Start()
    {
        //Test
        

        json = new JsonManager();

        baseValues = new int[6];
        ClearArray();

        int SheetNr = int.Parse(Data.data[DatabaseData.DataId.UserCharSheets.ToString()]) + 1;
        Debug.Log("SheetNr: " + SheetNr);
        Debug.Log("UserID" + Data.data[DatabaseData.DataId.UserID.ToString()]);
        Debug.Log("UserID" + Data.data[DatabaseData.DataId.CharRace.ToString()]);
        foreach (TMP_Dropdown b in Invoker)
        {
            InvokeDropdown(b);
        }
    }
    
    public void CancelSheet()
    {
        SwitchScene(1);
    }

    //Hier muss noch was hin um das POP up zu ändern
    //jetzt wird automatisch gespeichert
    public void SaveSheet()
    {

        //Speichert die Daten zwischen
        DetermineValues();
        //Speichert die Daten auf dem Server
        SaveData.SafeSheet();
        SaveData.SafeGW();
        SwitchScene(1);
    }
    //_____________________________________________________________________CHANGE POPUP____________________________________________________________________________
     int suceder;

    void AreYouReady()
    {
        SaveUp.SetActive(true);
        SaveUp.GetComponentInChildren<TMP_Text>().text = "Hast du alles ausgefüllt?";
        //test
    }

    void WantToSave()
    {
        SaveUp.GetComponentInChildren<TMP_Text>().text = "Möchtest du deinen Charakterbogen speichern?";
    }
    public void Succes()
    {
        suceder++;
        if (suceder == 1)
        {
            AreYouReady();
        }
        else if(suceder == 2)
        {
            WantToSave();
        }
        else if(suceder== 3)
        {
            SaveSheet();
        }
    }

    public void Fail()
    {
        suceder = 0;
        //Info.text = text;
        SaveUp.SetActive(false);
    }

    //_____________________________________________________________________SAFEVALUES____________________________________________________________________________

    void DetermineValues()
    {
        MakeAmounts();
        GetBaseValues();
        MakeBaseValues();

    }

    void MakeAmounts()
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
        Data.SaveDataString("SheetNr", SheetNr.ToString());
        Data.SaveDataString("ModiAmount", "0");
        Data.SaveDataString("AbilityAmount", "0");
        Data.SaveDataString("ItemAmount", "0");
        Data.SaveDataString("CharDestinyLevel", "1");
    }

    void MakeBaseValues()
    {

        //Erstelle die GW
        Data.SaveDataString("AG", baseValues[0].ToString());
        Data.SaveDataString("KR", baseValues[1].ToString());
        Data.SaveDataString("AU", baseValues[2].ToString());
        Data.SaveDataString("RE", baseValues[3].ToString());
        Data.SaveDataString("GE", baseValues[4].ToString());
        Data.SaveDataString("VE", baseValues[5].ToString());
    }

    //_____________________________________________________________________GRUNDWERTE____________________________________________________________________________

    //gw ist gleich welche der GW erhöt werden soll und die value i
    int AddBaseValues(int gw)
    {
        //weiß ich  noch nicht hier muss rein, wofür sich entschieden wurde
        int weißnet = 0;

        // nimmt einmal die json Datei zum auslesen
        // dann wird diese richtig eingetragen
        // dann noch das passende Dropdwon ausgesucht
        // das ganze führt dann zum gw der Json Datei
        // diese wird dann mit weiß net zusammen gerechnet

        //rasse wurde schon im Menu hinzugefügt

        for(int i = 0; i < 5; i++)
        {
            weißnet = weißnet + json.ReadJsonBaseValues(baseBaluesTexts[i], i, Dropdowns[i].value, gw);
        }
        //2.Umgebung
        //3.Merkmal
        //4.Erziehung
        //5.Ausbildung
        //6.Bestimmung
        return baseValues[gw] = baseValues[gw] + weißnet;
    }

    void ClearArray()
    {
        foreach(int i in baseValues)
        {
            baseValues[i] = i;
        }
    }

    void GetBaseValues()
    {
        //Test
   //    foreach (int i in baseValues)
   //    {
   //        baseValues[i] = AddBaseValues(i);
   //        Debug.Log("base value: "+i+" "+baseValues[i]);
   //    }

        for (int i = 0; i < 6; i++)
        {
            baseValues[i] = AddBaseValues(i);
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

    //_____________________________________________________________________UTILITY____________________________________________________________________________



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
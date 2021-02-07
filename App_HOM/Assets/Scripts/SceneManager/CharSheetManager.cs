using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharSheetManager : MonoBehaviour
{
    //Plan:
    //
    //
    //
    //
    //
    //
    //
    //
    //
    //
    //_____________________________________________________________________VARIABLES____________________________________________________________________________

        //Network
    public PlayerData player;
    public NetworkUseSheet usedSheet;
    public NetworkCreateSheet createdSheet;

        //Objects from scene fängt mit dem ersten Object aus dem Inspector an
    public TMP_InputField[] PersonInputs;
    public TMP_InputField[] BaseValuesInputs;
    public TMP_Text[] DestinyTetxs;
    public TMP_Text[] ActionTexts;


    public string[] PersonStrings;
    public int[] baseValuesInt;
    public int[] proofsInt;
    public string[] abilitysString;
    public string[] itemsStrings;
    public int[] actionsInt;

    public int[] amountsInt;






    //public void CreateItem(int arrayNr)
    //{
    //    
    //    GameObject Temp = Instantiate(Items[arrayNr], Spawns[arrayNr].transform);
    //    Temp.GetComponentInChildren<TMP_Text>().text = ItemAmount.ToString();
    //    Temp.transform.position = new Vector3(Spawns[arrayNr].transform.position.x, Spawns[arrayNr].transform.position.y - 50 * ItemAmount, 0);
    //    ItemAmount++;
    //}
    //
    //void ResetItemAmount()
    //{
    //    ItemAmount = 0;
    //}

    //_____________________________________________________________________UTILITY____________________________________________________________________________

    //Wenn gestartet wird, wird erstmal PlayerData gefüllt mit allen Daten
    //Die festen Daten werden in den Charakterbogen eingetragen
    //Danach werden die Modifikationen/Items/Fertigkeiten/Ambitionen geladen
    private void Start()
    {
        baseValuesInt = new int[18];
        TestChar();
        Debug.Log("UserID" + player.data[DatabaseData.DataId.UserID.ToString()]);
        Debug.Log("SheetNr" + player.data[DatabaseData.DataId.SheetNr.ToString()]);

        StartCharSheet();
    }

    void TestChar()
    {

        player.SaveDataString("UserID", "33");
        player.SaveDataString("SheetNr", "1");
        Debug.Log("Created Test"+" + "+ player.data["UserID"]+" + "+player.data["SheetNr"]);
        
    }

    void StartCharSheet()
    {
        MakeTexts();
        LoadMultipleObjects();
    }

    //_____________________________________________________________________TEXTS____________________________________________________________________________

    //bekommt die Dtaen aus der Bank und setzt sie in eine Liste ein
    //kommt noch
    void MakeTexts()
    {
        GetTxtValues();
        
    }


    //startet die Couroutinen um die Daten zu erhalten
    void GetTxtValues()
    {

        //Persönliches
        //usedSheet.GetMultipleObjectsData("person");
        //BaseValues
        usedSheet.GetMultipleObjectsData("baseValue");
        //Amounts
        //usedSheet.GetMultipleObjectsData("amounts");
    }

    //Bekommt Daten und füllt diese in eine Liste aus Text Objekten ein
    void SetTxtValues()
    {
        ShowValues();
        //Persönliches
        //Volk
        //Bestimmung
        //Ambition
        //BaseValues
        //Belastung
        
    }

    //Speichert die Daten von den Objekten aus der Liste auf der Datenbank
    //wenn der Nutzer die App verlässt oder speichern drückt
    void UpdateTxtValues()
    {

    }

    //_____________________________________________________________________Items/Modis/Ambitions/Abilitys____________________________________________________________________________

    void LoadMultipleObjects()
    {

    }

    //_____________________________________________________________________Bestimmungen____________________________________________________________________________

    void MakeDestiny()
    {

    }

    //_____________________________________________________________________Grundwerte____________________________________________________________________________

    public string[] valuesForBase;

    public void MakebaseValues()
    {
        Debug.Log("____________");
        for(int i = 0; i < baseValuesInt.Length; i++)
        {
            Debug.Log(i);
            Debug.Log(baseValuesInt[i]);
            BaseValuesInputs[i].text = baseValuesInt[i].ToString();
        }
        ShowValues();
    }


    //_____________________________________________________________________Aktionen____________________________________________________________________________

    //BaseValues ArrayNR:
    //AG:0/3/6/9/12/15
    //Aktionen ArrayNR:
    //Angriff(Waffe+GE)/Verkleiden(Kleidung+VE)/Unterhalten(RE+VE)/Bewegung(AG+GE)/Steuern(RE+VE)/Wuchten(KR+GE)/Analysieren(AU+VE)/Interagieren(AG+VE)/Kanalisieren(Leitwert+VE)
    //Reaktionen ArrayNR:
    //Argumentieren(RE+VE)/Absorbieren(AU+VE)/Beten(AU+VE)/Verteidigen(Rüstung+GE)/Lügen(RE+VE)/Ausweichen(AG+GE)

    //Initiative
    //[Ag + Re + 1w6]
    //Maximales Tragegewicht
    //AU + KR + Körpergewicht in kg
    void ShowValues()
    {
        Debug.Log("HUH");
        int AG=int.Parse(BaseValuesInputs[0].text) / 10;
        Debug.Log("HUH");
        int KR=int.Parse(BaseValuesInputs[3].text) / 10;
        int AU=int.Parse(BaseValuesInputs[6].text) / 10;
        int RE=int.Parse(BaseValuesInputs[9].text) / 10;
        int GE=int.Parse(BaseValuesInputs[12].text) /10;
        int VE=int.Parse(BaseValuesInputs[15].text) /10;
        int Weapon =0;
        int Cloth = 0;
        int Armor = 0;
        int MainValue = 0;
        ActionTexts[0].text = (Weapon + GE).ToString();
        ActionTexts[1].text = (Cloth + VE).ToString();
        ActionTexts[2].text = (RE + VE).ToString();
        ActionTexts[3].text = (AG + GE).ToString();
        ActionTexts[4].text = (RE + VE).ToString();
        ActionTexts[5].text = (KR + GE).ToString();
        ActionTexts[6].text = (AU + VE).ToString();
        ActionTexts[7].text = (AG + VE).ToString();
        ActionTexts[8].text = (MainValue + VE).ToString();
        ActionTexts[9].text = (RE + VE).ToString();
        ActionTexts[10].text = (AU + VE).ToString();
        ActionTexts[11].text = (AU + VE).ToString();
        ActionTexts[12].text = (Armor + GE).ToString();
        ActionTexts[13].text = (RE + VE).ToString();
        ActionTexts[14].text = (AG + GE).ToString();
        Debug.Log("HAH");
    }

    void ShowDices()
    {

    }

    void RollDices()
    {

    }

    void ShowResult()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class ItemInfos
{
    public string Nr;
    public string Name;
    public string Type;
    public string Weight;
    public string Description;
}

[System.Serializable]
public class ModiInfos
{
    public string Nr;
    public string Name;
    public string Potenzial;
    public string Rank;
}

[System.Serializable]
public class AbilitysInfos
{
    public string Nr;
    public string Name;
    public string Type;
    public string School;
    public string Range;
    public string Length;
    public string Costs;
    public string Effect;

}


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

    public bool test = false;

    //Network
    public PlayerData player;
    public NetworkUseSheet usedSheet;
    public NetworkCreateSheet createdSheet;

        //Objects from scene fängt mit dem ersten Object aus dem Inspector an
    public TMP_InputField[] PersonInputs;
    public TMP_InputField[] BaseValuesInputs;
    public TMP_Text[] ActionTexts;


    public string[] PersonStrings;
    public string[] DestinyStrings;
    public int[] baseValuesInt;
    public int[] proofsInt;
    public int[] actionsInt;

    //0.modi, 1.abil, 2.item
    public int[] amountsInt;
    public TMP_Dropdown[] List;

    //Modifikationen
    public ModiInfos[] modis;
    public TMP_InputField[] modiInputs;
    public TMP_InputField[] modiShow;

    //Fähigkeiten
    public AbilitysInfos[] abilitys;
    public TMP_InputField[] abiInputs;
    public TMP_InputField[] abiShow;
    public TMP_Text abiDropdown;

    //Items:
    public ItemInfos[] items;
    public TMP_InputField[] itemInputs;
    public TMP_InputField[] itemShow;

    //PopUp:




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
        if (test)
        {
            TestChar();
        }
        baseValuesInt = new int[18];
        PersonStrings = new string[13];
        amountsInt = new int[3];
        Debug.Log("UserID" + player.data[DatabaseData.DataId.UserID.ToString()]);
        Debug.Log("SheetNr" + player.data[DatabaseData.DataId.SheetNr.ToString()]);
        StartCharSheet();
    }

    void TestChar()
    {   
        player.SaveDataString("UserID", "42");
        player.SaveDataString("SheetNr", "1");
        Debug.Log("Created Test"+" + "+ player.data["UserID"]+" + "+player.data["SheetNr"]);        
    }

    void StartCharSheet()
    {
        MakeTexts();
    }

    int suceder;
    public GameObject SaveUp;

    void AreYouReady()
    {
        SaveUp.SetActive(true);
        SaveUp.GetComponentInChildren<TMP_Text>().text = "Bist du fertig mit deinem Charakterbogen?";
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
        else if (suceder == 2)
        {
            WantToSave();
        }
        else if (suceder == 3)
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

    void SaveSheet()
    {

        //Speichert die Daten zwischen
        DetermineValues();
        //Speichert die Daten auf dem Server
        createdSheet.UpdateCharSheet();
        SceneManager.LoadScene(1);
    }
    //speichert die Daten zwischen

    void DetermineValues()
    {
        foreach (TMP_InputField inp in BaseValuesInputs)
        {
            Debug.Log("1");
            player.SaveDataInput(inp);
        }
        foreach (TMP_InputField inp in PersonInputs)
        {
            Debug.Log("2");
            player.SaveDataInput(inp);
        }
    player.SaveDataString("ModiAmount", amountsInt[0].ToString());
    player.SaveDataString("AbilityAmount", amountsInt[1].ToString());
    player.SaveDataString("ItemAmount", amountsInt[2].ToString());
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
        usedSheet.GetMultipleObjectsData("person");
        //BaseValues
        usedSheet.GetMultipleObjectsData("baseValue");
        //Amounts
        usedSheet.GetMultipleObjectsData("amounts");
        StartAfterNetwork();
    }

    //Bekommt Daten und füllt diese in eine Liste aus Text Objekten ein
    void SetTxtValues()
    {
        
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
    //0.modi, 1.abil, 2.item
    public void StartAfterNetwork()
    {
        CreateOptions();
    }

    //------Input------
    public void SafeObyektz(int type)
    {
        usedSheet.SafeObyekts(type);
        usedSheet.SaveMultipleObjectsData(3);
    }

    //------fülle Array-------

    //zählt von 0 bis 2 durch um zu erfahren, was vorhanden ist
    //wenn was vorhanden, werden die Objekte geladen


    void CreateOptions()
    {
        for (int i = 0; i <amountsInt.Length; i++)
        {
            if (amountsInt[i] > 0)
            {
                GiveOptionsAmount(i);
            }
            else
            {
                GiveNothing(i);
            }
        }
    }

    public int optionNr = 1;

    //wenn das aufgerufen wird, wissen wir items benötigen optionen
    //obyekt = items
    //nun müssen wir wissen wie viel
    //über amountsInt[obyekt]
    //nun die optionNr durchlazufen lassen, bis optionen done sind.
    public void GiveOptionsAmount(int obyekt)
    {
        usedSheet.GetObyekts(obyekt);
    }
    //-----------Dropdowns-------
    //Dead End

    public List<string> DropOptionsModi = new List<string> { };
    public List<string> DropOptionsAbil = new List<string> { };
    public List<string> DropOptionsItem = new List<string> { };
    List<string> DropOptions = new List<string> { };

    void GiveNothing(int drop)
    {
        List[drop].ClearOptions();
        DropOptions.Add("Leer");
        List[drop].AddOptions(DropOptions);
        DropOptions.Clear();
    }
    //hier 1 und 2
    public void GiveDropdownsOptions(int nummerofdropdown)
    {
        List[nummerofdropdown].ClearOptions();
        if (nummerofdropdown == 0)
        {
            for (int i = 0; i < amountsInt[nummerofdropdown]; i++)
            {
                DropOptions.Add(modis[i].Name);
            }
        }
        else if (nummerofdropdown == 1)
        {
            for (int i = 0; i < amountsInt[nummerofdropdown]; i++)
            {
                DropOptions.Add(abilitys[i].Name);
            }
        }
        else if (nummerofdropdown == 2)
        {
            for (int i = 0; i < amountsInt[nummerofdropdown]; i++)
            {
                DropOptions.Add(items[i].Name);
            }
        }

        List[nummerofdropdown].AddOptions(DropOptions);
        DropOptions.Clear();
        List[nummerofdropdown].value = 1;
        List[nummerofdropdown].value = 0;
    }

    public void DropdownÀctivationModi(int tear)
    {
        if (amountsInt[0] > 0)
        {
            modiShow[0].text = modis[tear].Nr;
            modiShow[1].text = modis[tear].Name;
            modiShow[2].text = modis[tear].Potenzial;
            modiShow[3].text = modis[tear].Rank;
        }
        else
        {
            modiShow[0].text = "";
            modiShow[1].text = "";
            modiShow[2].text = "";
            modiShow[3].text = "";
        }

    }
    public void DropdownÀctivationAbil(int tear)
    {
        if (amountsInt[1] > 0)
        {
            abiShow[0].text = abilitys[tear].Name;
            abiShow[1].text = abilitys[tear].Type;
            abiShow[2].text = abilitys[tear].School;
            abiShow[3].text = abilitys[tear].Range;
            abiShow[4].text = abilitys[tear].Length;
            abiShow[5].text = abilitys[tear].Costs;
            abiShow[6].text = abilitys[tear].Effect;
        }
        else
        {
            abiShow[0].text = "";
            abiShow[1].text = "";
            abiShow[2].text = "";
            abiShow[3].text = "";
            abiShow[4].text = "";
            abiShow[5].text = "";
            abiShow[6].text = "";
        }


    }
    public void DropdownÀctivationItem(int tear)
    {
        if (amountsInt[2] > 0)
        {
            itemShow[0].text = items[tear].Name;
            itemShow[1].text = items[tear].Type;
            itemShow[2].text = items[tear].Weight;
            itemShow[3].text = items[tear].Description;
        }
        else
        {
            itemShow[0].text = "";
            itemShow[1].text = "";
            itemShow[2].text = "";
            itemShow[3].text = "";
        }

    }

    //nimmt die momenaten nr des dropdowns und updatet sie
    public void UpdateObyektz(int kinda)
    {
        Debug.Log(List[kinda].value);
        usedSheet.UpdateObyekts(kinda);
        OpenUpDePopUp("Erflogreich geupdatet");
    }

    //nimmt die momenaten nr des dropdowns und löscht sie gleichzeitig wird der amount runtergesetzt, danach wird das Dropdown refresht. vorher wird natürlich noch ein PopUp gemacht ob der nutzer sicher ist
    public void DeleteObyektz(int kinda)
    {

        if (amountsInt[kinda] > 0)
        {
            usedSheet.DeleteObyekts(kinda);
            OpenUpDePopUp("Erflogreich gelöscht");
        }
        else
        {
            OpenUpDePopUp("Kein Objekt zum Löschen");
        }
    }
    //lädt das Dropdown neu nach einer Veränderung aka. neues Obyektz oder eines weniger
    public void RefreshDropdown(int dropi)
    {
        GiveOptionsAmount(dropi);
    }
    public TMP_Text UpDeText;
    public GameObject UpDePop;
    void OpenUpDePopUp(string value)
    {
        UpDePop.SetActive(true);
        UpDeText.text = value;
    }

    public void CloseUpDePopUp()
    {
        UpDePop.SetActive(false);
    }

    //_____________________________________________________________________Bestimmungen____________________________________________________________________________

    public void MakeDestiny()
    {
        for (int i = 0; i < PersonStrings.Length; i++)
        {
            PersonInputs[i].text = PersonStrings[i];
        }
    }

    //_____________________________________________________________________Grundwerte____________________________________________________________________________

    public string[] valuesForBase;

    public void MakebaseValues()
    {
        for(int i = 0; i < baseValuesInt.Length; i++)
        {
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


    public void ShowValues()
    {
        int AG=(int.Parse(BaseValuesInputs[0].text)+int.Parse(BaseValuesInputs[1].text)-int.Parse(BaseValuesInputs[2].text) )/ 10;
        int KR=(int.Parse(BaseValuesInputs[3].text)+int.Parse(BaseValuesInputs[4].text)-int.Parse(BaseValuesInputs[5].text) )/ 10;
        int AU=(int.Parse(BaseValuesInputs[6].text)+int.Parse(BaseValuesInputs[7].text)-int.Parse(BaseValuesInputs[8].text) )/ 10;
        int RE=(int.Parse(BaseValuesInputs[9].text)+int.Parse(BaseValuesInputs[10].text)-int.Parse(BaseValuesInputs[11].text) )/ 10;
        int GE=(int.Parse(BaseValuesInputs[12].text)+int.Parse(BaseValuesInputs[13].text)-int.Parse(BaseValuesInputs[14].text) )/ 10;
        int VE= (int.Parse(BaseValuesInputs[15].text) + int.Parse(BaseValuesInputs[16].text) - int.Parse(BaseValuesInputs[17].text)) / 10;
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
    }
}

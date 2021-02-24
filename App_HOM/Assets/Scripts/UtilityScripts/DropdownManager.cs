using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// wird noch bearbeitet am besten wenn mal zeit dafür vorhanden ist

[System.Serializable]
public class DropdownInfos
{
    public TMP_Dropdown Dropdowns;
    public int OptionsNr;
    public TextAsset OptionsText;
    public TextAsset DescriptionFile;
    public TMP_Text DescriptionObject;

}

public class DropdownManager : MonoBehaviour
{

    //was muss vom Button ausgewählt werden?
    //OnValueChange
    //SetDropdown(nummer im array)

    List<string> DropOptions = new List<string> { };

    public DropdownInfos[] Dropis;


    //Hardcoded Images
    [SerializeField]
    private Image DescriptionImage;
    public Sprite[] images;

    int x;

    

    private void Start()
    {
        CreateDropdown();
    }

    public void CreateSingleDropdown(int i)
    {
        Dropis[i].Dropdowns.ClearOptions();
        CreateOptions(Dropis[i].OptionsText, Dropis[i].Dropdowns, Dropis[i].OptionsNr);
    }
 
    //erstelle die Dropdowns
    //funktioniert
    void CreateDropdown()
    {
        foreach (DropdownInfos i in Dropis)
        {
            i.Dropdowns.ClearOptions();
            CreateOptions(i.OptionsText, i.Dropdowns, i.OptionsNr);
        }
    }
    void CreateOptions(TextAsset File,TMP_Dropdown Down, int Options)
    {
         for (int i = 0; i < Options; i++)
            {
            DropOptions.Add(ParseFile(File, i));
            }
        Down.AddOptions(DropOptions);

        DropOptions.Clear();
    }

    //____________________________________________________________________________-

    //gibt den Optionen oder dem Text eine Schrift
    private string ParseFile(TextAsset File, int Nr)
    {
        //TXT Dateien aus dem Server holen
        string[] Text = File.text.Split("\n"[0]);
        return (Text[Nr]);
    }

    //Change Info Text nach dem button drücken

    int getX()
    {
        return x;
    }

    void setX(int newX)
    {
        if (newX < 0)
            x = 0;
        else
            x = newX;
    }
    //-----------------Funktionen für die buttons


    //stellt die nummer des gewählten Objekts fest
    public void OnValueChange(int Drop)
    {
        setX(Drop);       
    }
    //ändert den Text der beschreibung
    public void SetDropdown(int what)
    {
        Dropis[what].DescriptionObject.text = ParseFile(Dropis[what].DescriptionFile, getX());
    }

    GameObject civ;

    public void SetCivDropdown(int what)
    {
        civ = GameObject.FindGameObjectWithTag("Civ");
        civ.GetComponent<CivilScript>().OnChange(what);
    }

    // public void OnValueChangeString(TextAsset File)
    // {
    //     
    //     DescriptionText.text = ParseFile(File, getX());
    // }

    public void OnValueChangeImage(int Drop)
    {
        ParseImage(Drop);
    }

    void ParseImage(int Drop)
    {
        DescriptionImage.sprite = images[Drop];
    }

}

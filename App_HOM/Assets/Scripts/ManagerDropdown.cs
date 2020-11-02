﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// wird noch bearbeitet am besten wenn mal zeit dafür vorhanden ist

[System.Serializable]
public class DropdownInfos
{
    public TMP_Dropdown Dropdowns;
    public int OptionsNr;
    public string FileTxt;
}

public class DropdownManager : MonoBehaviour
{

    List<string> DropOptions = new List<string> { };

    public DropdownInfos[] Dropis;

    [SerializeField]
    private TMP_Text DescriptionText;

    int x;

    

    private void Start()
    {
        CreateDropdown();
    }


 
    //erstelle die Dropdowns
    //funktioniert
    public void CreateDropdown()
    {
        foreach (DropdownInfos i in Dropis)
        {
            i.Dropdowns.ClearOptions();
            CreateOptions(i.FileTxt, i.Dropdowns, i.OptionsNr);
        }
    }
    //Tmp reference oder value
    //_____________________________________Problem_______________________________________-
    public void CreateOptions(string File,TMP_Dropdown Down, int Options)
    {
         for (int i = 0; i < Options; i++)
            {
            DropOptions.Add(ParseFile("DropBeschr/"+File, i));
            }
        Down.AddOptions(DropOptions);

        DropOptions.Clear();
    }

    //____________________________________________________________________________-

    private string ParseFile(string File, int Nr)
    {
        //muss noch überarbeitet werden suche des Speicherorts
        //TXT Dateien aus dem Server holen
        string[] Text = System.IO.File.ReadAllLines(Application.dataPath+ "/DescriptionTexts/" + File + ".txt");
        return (Text[Nr]);


    }

    //Change Info Text nach dem button drücken

    public int getX()
    {
        return x;
    }

    public void setX(int newX)
    {
        if (newX < 0)
            x = 0;
        else
            x = newX;
    }

    public void OnValueChange(int Drop)
    {
        setX(Drop);
    }

    public void OnValueChangeString(string File)
    {
        DescriptionText.text = ParseFile(File, getX());
    }

}

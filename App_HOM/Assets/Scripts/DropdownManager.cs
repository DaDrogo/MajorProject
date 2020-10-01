using System.Collections;
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

    private void Start()
    {
        CreateDropdown();
    }

    public void CreateDropdown()
    {
        for (int i = 0; i < Dropis.Length; i++)
        {
            Dropis[i].Dropdowns.ClearOptions();
            CreateOptions(Dropis[i].FileTxt, Dropis[i].Dropdowns, Dropis[i].OptionsNr);
        }
    }

    public void OnValueChange(int Drop)
    {
        setX(Drop);
        Debug.Log(x);
    }

    public void OnValueChangeString(string File)
    {
        Debug.Log(x);
        DescriptionText.text = ParseFile(File, getX());
    }

    public void CreateOptions(string File,TMP_Dropdown Down, int Options)
    {
         for (int i = 0; i < Options; i++)
            {
            DropOptions.Add(ParseFile(File, i));
            }
        Down.AddOptions(DropOptions);
    }

    private string ParseFile(string File, int Nr)
    {
        //muss noch überarbeitet werden suche des Speicherorts
        //TXT Dateien aus dem Server holen
        string[] Text = System.IO.File.ReadAllLines("D:\\Programme\\GitHub\\MajorProject\\App_HOM\\Assets\\DescriptionTexts\\" + File + ".txt");
        return (Text[Nr]);


    }
}

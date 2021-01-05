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
    public TextAsset FileTxt;
}

public class DropdownManager : MonoBehaviour
{

    List<string> DropOptions = new List<string> { };

    public DropdownInfos[] Dropis;

    [SerializeField]
    public TMP_Text DescriptionText;


    //Hardcoded Images
    [SerializeField]
    private Image DescriptionImage;
    public Sprite[] images;

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
    public void CreateOptions(TextAsset File,TMP_Dropdown Down, int Options)
    {
         for (int i = 0; i < Options; i++)
            {
            DropOptions.Add(ParseFile(File, i));
            }
        Down.AddOptions(DropOptions);

        DropOptions.Clear();
    }

    //____________________________________________________________________________-

    private string ParseFile(TextAsset File, int Nr)
    {
        //muss noch überarbeitet werden suche des Speicherorts
        //TXT Dateien aus dem Server holen
        string[] Text = File.text.Split("\n"[0]);
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

    public void OnValueChangeString(TextAsset File)
    {
        DescriptionText.text = ParseFile(File, getX());
    }

    public void OnValueChangeImage(int Drop)
    {
        ParseImage(Drop);
    }

    void ParseImage(int Drop)
    {
        DescriptionImage.sprite = images[Drop];
    }

}

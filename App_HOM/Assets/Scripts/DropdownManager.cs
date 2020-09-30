using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// wird noch bearbeitet am besten wenn mal zeit dafür vorhanden ist

public class DropdownManager : MonoBehaviour
{

    [SerializeField]
    private TMP_Text DescriptionText;

    public GameObject[] Dropdowns;
    public int OpionsNr;
    private string NameTxt;
    TMP_Dropdown.OptionData

   // public void CreateDropdown()
   // {
   //     foreach (GameObject D in Dropdowns){
   //         ;
   //     }
   // }

    public void OnValueChange(int Drop)
    {
        DescriptionText.text = ParseFile("Person\\Sprache", Drop);
    }

    private string ParseFile(string File, int Nr)
    {
        //muss noch überarbeitet werden suche des Speicherorts
        //TXT Dateien aus dem Server holen
        string[] Text = System.IO.File.ReadAllLines("D:\\Programme\\GitHub\\MajorProject\\App_HOM\\Assets\\DescriptionTexts\\" + File + ".txt");
        return (Text[Nr]);


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreationScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text DescriptionText;

 

    public void DescribeDropdown(int Drop)
    {

            DescriptionText.text = ParseFile("Völker", Drop);

    }

    //liest eine Linie einer TXT Datei und gibt diese wieder
    string ParseFile(string File, int Nr)
    {
        //muss noch überarbeitet werden suche des Speicherorts
        //TXT Dateien aus dem Server holen
        string[] Text = System.IO.File.ReadAllLines("D:\\Programme\\GitHub\\MajorProject\\App_HOM\\Assets\\DescriptionTexts\\" + File+ ".txt");
        return (Text[Nr]);
    }
}

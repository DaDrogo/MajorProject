using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersonCreationScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text DescriptionText;

    private TMP_Text Button1Text;
    private TMP_Text Button2Text;
    private TMP_Text Button3Text;

    [SerializeField]
    private GameObject Person;

   private void Start()
   {
      // CivDropdown(0);
      // LanguageDropdown(0);
      // ReligionDropdown(0);
      // DescriptionText.text= ("Bitte Fülle alles aus.");
   }

    //_____________________________________Person_____________________________________________________--

    public void CivDropdown(int Drop)
    {
        DescriptionText.text = ParseFile("Person\\Völker", Drop);
        //ChangeButtonText(Drop, "Person\\Fertigkeit", new string[] { "Civ1", "Civ2", "Civ3"});
        Debug.Log(Drop);
        // Namen der Buttons ändern
    }

    public void LanguageDropdown(int Drop)
    {
        DescriptionText.text = ParseFile("Person\\Sprache", Drop);
    }

    public void ReligionDropdown(int Drop)
    {
        DescriptionText.text = ParseFile("Person\\Religion", Drop);
    }

    //_____________________________________Past_____________________________________________________--

    public void AusbildungDropdown(int Drop)
    {
        DescriptionText.text = ParseFile("Past\\Ausbildung", Drop);
    }

     public void MerkmalDropdown(int Drop)
     {
         DescriptionText.text = ParseFile("Past\\Zeichen", Drop);
         //ChangeButtonText(Drop, "Past\\Merkmal", new string[] { "Civ1", "Civ2", "Civ3" });
     }

    public void ErziehungDropdown(int Drop)
    {
        DescriptionText.text = ParseFile("Past\\Erziehung", Drop);
    }

    public void UmgebungDropdown(int Drop)
    {
        DescriptionText.text = ParseFile("Past\\Umgebung", Drop);
    }

    //_____________________________________Utility_____________________________________________________--

     public void ChangeButtonText(int Drop, string File, string[] Buttons)
     {
         // auch noch überarbeitungswürdig
         //sucht die Buttons nach dem Namen des Text Gameonjects und ändert danach die Namen
         //könnte als schleife eingearbeitet werden mit nur einem Gameobject
         //kann aber auch später noch gemacht werden
         Button1Text = GameObject.Find(Buttons[0]).GetComponent<TMP_Text>();
         Button2Text = GameObject.Find(Buttons[1]).GetComponent<TMP_Text>();
         Button3Text = GameObject.Find(Buttons[2]).GetComponent<TMP_Text>();
         int Line = Drop * 3;
         Button1Text.text = ParseFile(File, Line);
         Button2Text.text = ParseFile(File, Line + 1);
         Button3Text.text = ParseFile(File, Line + 2);
      }

    //liest eine Linie einer TXT Datei und gibt diese wieder
    string ParseFile(string File, int Nr)
    {
        //muss noch überarbeitet werden suche des Speicherorts
        //TXT Dateien aus dem Server holen
        string[] Text = System.IO.File.ReadAllLines(Application.dataPath + "/DescriptionTexts" + File+ ".txt");
        return (Text[Nr]);

       
    }
}

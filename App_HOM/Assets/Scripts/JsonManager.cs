using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class JsonManager : MonoBehaviour
{
    // neue Scene für diese beiden
    // also werden die Daten vorher gespeichert
    // Erziehung und Umgebung sollen einzelnd sein
    // Dort soll die Erklärung des ausgewählten sein und Buttons mit Text gespawnt werden
    // man kann immer noch hin und zurück gehen
    // -----------------------------------------------------------------------
    // bei eingabe soll durch den Namen des Buttons die folgenden seiten bestimmt werden
    // daraufhin soll die json gesucht werden
    // von dieser soll geschaut werden wie viele Optionen es gibt
    // und die Buttons für die nächste Seite gemacht werden
    // also 4 Seiten für die Scene
    // jeweils button zum aussuchen der Überpunkte und dann jeweils unterpunkte mit aussage wie viele gewählt werden sollen
    // dies wird nur soft zwischengespeichert und beim neustarten der Seite rückgangig gemacht
    // wenn am ende gespeichert´werden soll, wird vorher nochmal gefragt. da man ja nur weiter kommt wenn man alles ausgewählt hat.
    //--------------------------------------------------------------------------
    //benötigt wird Prefab für Buttons
    //Prefab für Überschrift
    //Warning Text
    //Json Datei:bennant nach den Überpunkten / beinhalten: Anzahl der Buttons + Überschriften/ Texte der Buttons
    // name:"" / Überschriften:[1/1/1] / Buttons:[2,4,4] / Texte:["","","","","","","","","",""]
    public GameObject spawnpoint;

    public GameObject buttonPrefab;
    int ButtonHeight = 50;
    int ButtonAmount;
    string ButtonText;

    public GameObject headerPrefab;

    //============================JSON====================

    [SerializeField]
    string First;
    string Second;
    string Third;
    string Fourth;

    public TextAsset jsonFile1;
    public Teaching hallo;




    private void Start()
    {
        CreateButton("hallo", 0);
        ReadJson(jsonFile1, 0,"name");
    }

    void LoadJson()
    {
        //erhalte die Information, dass Button gedrückt wurde und den Wert
        // geht zu nächsten Seite über
    }

    [System.Serializable]
    public class Teachings
    {
        public Teaching[] teachings;
    }

    [System.Serializable]
    public class Teaching
    {
        public string name;
        public int[] HeadersNr;
        public int[] Buttons;
        public string[] Texts;
    }

    //Zugriff auf eine Zeile und das Objekt in diesem 
    private void ReadJson(TextAsset jsonFile,int line,string type, int arrayNr = default)
    {

        //string json = File.ReadAllText(Application.dataPath + "/JsonTexts/" + "Erziehung" + ".json");
        Debug.Log(arrayNr);
        Teachings teachInJson = JsonUtility.FromJson<Teachings>(jsonFile.text);

        Debug.Log(teachInJson.teachings.Length);
        if (type == First)
            Debug.Log(teachInJson.teachings[line].HeadersNr[arrayNr]);
        else if (type == Second)
            Debug.Log(teachInJson.teachings[line].HeadersNr[arrayNr]);
        else if (type == Third)
            Debug.Log(teachInJson.teachings[line].HeadersNr[arrayNr]);
        else if (type == Fourth)
            Debug.Log(teachInJson.teachings[line].HeadersNr[arrayNr]);
        else
            Debug.Log("Fuck off");

    }

    void Create()
    {
        for(int i = 0;i<=ButtonAmount;i++)
        {
            
        }
    }

    void CreateHeader(int Nr, Vector2 Position)
    {
        // Gib Header einen Text

        //Erstelle Header an Position
    }

    void CreateButton(string Text, int y)
    {

        // Gib Button Werte
        buttonPrefab.GetComponentInChildren<TMP_Text>().text = Text;
        // Erstelle Button an Ort
        //spawnpoint.transform.position = new Vector3(0, y, 0);
        Instantiate(buttonPrefab, spawnpoint.transform);
    }

    void SwitchPage(int page)
    {

    }
}

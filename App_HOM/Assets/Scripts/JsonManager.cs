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
    //============================JSON====================
    string First = "name";
    string Second = "HeadersNr";
    string Third = "Buttons";
    string Fourth ="Texts";


    //==================================JSON Files=========================================

    [System.Serializable]
    public class Teachings
    {
        public Teaching[] teachings;
    }

    [System.Serializable]
    public class Teaching
    {
        public string name;
        public string[] HeadersNr;
        public string[] Buttons;
        public string[] Texts;
    }



    //Zugriff auf eine Zeile und das Objekt in diesem 

    //Line = welcher Array aus dem Json soll gelesen werden
    //type = der bestimmte array wird ausgesucht darin mit den Werten
    //arrayNr = falls die Werte in einem Array gespeichert sind wird hier die Nummer von wo der Wert genommen werden soll eingefügt
    public string ReadJsonText(int line,string type, int arrayNr )
    {
        string json = File.ReadAllText(Application.dataPath + "/JsonTexts/" + "Erziehung" + ".json");
        Debug.Log(line+","+type+","+arrayNr);
        Teachings teachInJson = JsonUtility.FromJson<Teachings>(json);
        Debug.Log(teachInJson.teachings.Length);
        if (type == First)
            return (teachInJson.teachings[line].name);
        else if (type == Second)
            return (teachInJson.teachings[line].HeadersNr[arrayNr]);
        else if (type == Third)
            return (teachInJson.teachings[line].Buttons[arrayNr]);
        else if (type == Fourth)
            return (teachInJson.teachings[line].Texts[arrayNr]);
        else
            return ("Fuck off");

        

    }

    public int ReadJsonLength(int line, string type)
    {
        string json = File.ReadAllText(Application.dataPath + "/JsonTexts/" + "Erziehung" + ".json");
        Teachings teachInJson = JsonUtility.FromJson<Teachings>(json);
        if (type == First)
            return (teachInJson.teachings[line].name.Length);
        else if (type == Second)
            return(teachInJson.teachings[line].HeadersNr.Length);
        else if (type == Third)
            return (teachInJson.teachings[line].Buttons.Length);
        else if (type == Fourth)
            return (teachInJson.teachings[line].Texts.Length);
        else
            return (1);
    }

    //==============================================

    
}

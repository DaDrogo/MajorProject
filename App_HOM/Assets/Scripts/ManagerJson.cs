﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerJson : MonoBehaviour
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

    public GameObject ButtonPrefab;
    public GameObject HeaderPrefab;

    void LoadJson()
    {
        //erhalte die Information, dass Button gedrückt wurde und den Wert
        // geht zu nächsten Seite über
    }

    private void ReadJson(string Object)
    {
        //Suche im Jsonfile nach dem Object

        //erstelle Header und Buttons mit den Werten und an unterschiedlichen Positionen
    }

    void CreateHeader(int Nr, Vector2 Position)
    {
        // Gib Header einen Text

        //Erstelle Header an Position
    }

    void CreateButton(string Text, Vector2 Position)
    {
        // Gib Button Werte
        ButtonPrefab.GetComponent<TMP_Text>().text = Text;
        // Erstelle Button an Ort
    }

    void SwitchPage(int page)
    {

    }
}

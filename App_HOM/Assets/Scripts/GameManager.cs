using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //_______________________________Variablen
    [SerializeField]
    TMP_Text[] CharNames;

    [SerializeField]
    TMP_Text[] CharValues;

    [SerializeField]
    string file;

    string[] names;
    int[] values;

    //______________________________Charakterbogen ausfüllen

    //nimmt namen und erhält daraus werte
    void InsertValues()
    {

    }

    //nimmt namen und gibt diesen in den Charakterbogen ein
    void InsertNames()
    {

    }


    //______________________________Datenbank

    //erhält Values von der Datenbank und gibt diese ein
    void GetValues()
    {
        
    }

    //setzt die Werte in die Datenbank ein
    void SetValues()
    {


    }

    //___________________________________Spielinteraktion

    //erhalte den Würfel mit dem du würfeln sollst
    void GetDice()
    {

    }

    //erhalte einen random wert von einem Würfel
    int RolledDice(int dice)
    {
        return Random.Range(0, dice);
    }
}

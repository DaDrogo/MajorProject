using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionScript : MonoBehaviour
{
    GameObject Master;

    // Start is called before the first frame update

    //wenn Button gedrückt wurde, soll in Text die zu würfelnden würfel angezeigt werden
    //als bekommt Zahl als Input und gibt string als Output zum Text


    public void GetValue()
    {
        Master = GameObject.FindGameObjectWithTag("Master");
        TMP_Text[] text = gameObject.GetComponentsInChildren<TMP_Text>();
        int value = int.Parse(text[1].text);
        Master.GetComponent<DiceScript>().ShowDice(value);
    }
}

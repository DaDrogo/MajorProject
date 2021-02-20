using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharButtonScript : MonoBehaviour
{
    GameObject MMM;
    public PlayerData Data;
    public TMP_Text[] Inputs;

    void Start()
    {
        MMM = GameObject.FindGameObjectWithTag("Manager");
    }

    public void Activate()
    {
        //MMM.GetComponent<MainMenuManager>().MakeButtonActive();
        GiveData();
    }

    void GiveData()
    {
        Data.SaveDataText(Inputs[0]);
        Data.SaveDataText(Inputs[1]);
        Data.SaveDataText(Inputs[2]);
        Debug.Log(Data.data[DatabaseData.DataId.CharRace.ToString()]);
    }
}

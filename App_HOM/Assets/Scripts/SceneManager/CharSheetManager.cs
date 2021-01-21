using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharSheetManager : MonoBehaviour
{
    //old maybe useful for other things
    //int ItemAmount;
    //public GameObject[] Spawns;
    //public GameObject[] Items;
    //
    //public void CreateItem(int arrayNr)
    //{
    //    
    //    GameObject Temp = Instantiate(Items[arrayNr], Spawns[arrayNr].transform);
    //    Temp.GetComponentInChildren<TMP_Text>().text = ItemAmount.ToString();
    //    Temp.transform.position = new Vector3(Spawns[arrayNr].transform.position.x, Spawns[arrayNr].transform.position.y - 50 * ItemAmount, 0);
    //    ItemAmount++;
    //}
    //
    //void ResetItemAmount()
    //{
    //    ItemAmount = 0;
    //}

    //______________Txt Lists


    private void Start()
    {
        SetTxtValues();
    }

    //bekommt die Dtaen aus der Bank und setzt sie in eine Liste ein
    //kommt noch
    void GetTxtValues()
    {

    }

    //Bekommt Daten und füllt diese in eine Liste aus Text Objekten ein
    void SetTxtValues()
    {

    }

    //Speichert die Daten von den Objekten aus der Liste auf der Datenbank
    //kommt noch
    void SafeTxtValues()
    {

    }
}

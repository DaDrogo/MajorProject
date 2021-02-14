using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpScript : MonoBehaviour
{
    int suceder;
    public GameObject SaveUp;
    GameObject manager;

    void AreYouReady()
    {
        SaveUp.SetActive(true);
        SaveUp.GetComponentInChildren<TMP_Text>().text = "Hast du alles ausgefüllt?";
        //test
    }

    void WantToSave()
    {
        SaveUp.GetComponentInChildren<TMP_Text>().text = "Möchtest du deinen Charakterbogen speichern?";
    }
    public void Succes()
    {
        suceder++;
        if (suceder == 1)
        {
            AreYouReady();
        }
        else if (suceder == 2)
        {
            WantToSave();
        }
        else if (suceder == 3)
        {
            //SaveSheet();
        }
    }

    public void Fail()
    {
        suceder = 0;
        //Info.text = text;
        SaveUp.SetActive(false);
    }
}

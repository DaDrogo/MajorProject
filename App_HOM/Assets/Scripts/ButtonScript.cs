using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private GameObject UserTxt;
    [SerializeField]
    private GameObject PassTxt;

    [SerializeField]
    private GameObject WarningTxt;

    int correct;

    private void Start()
    {
        UserTxt.GetComponent<Text>();
        PassTxt.GetComponent<Text>();
        correct = 0;
    }


    public void LogIn()
    {
        //sende Strings zum einloggen an die Datenbank
        //erhalte ein Signal ob korrekt oder fehlerhaft
        //bei erfolg wechsel des Fensters mit den daten der bank bei misserfolg Nachricht durch Text
        if (correct == 0)
        {

        }
        else
        {

        }
    }

    public void SingUp()
    {
        //sende Strings zum speichern an die Datenbank
        //erhalte ein Signal ob vorhanden oder frei
        //bei erfolg wechsel des Fensters und speicherung der daten bei misserfolg Nachricht durch Text

        if (correct == 0)
        {

        }
        else
        {

        }
    }

    public void LogOut()
    {

    }
}

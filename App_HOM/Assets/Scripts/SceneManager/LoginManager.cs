using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{

    //Daten des Nutzers
    public PlayerData ID;

    //Objekte zum speichern und laden der Datenbank
    public NetworkEntry Entry;
    public NetworkCreateSheet infos;

    //das PopUp um Feedback an den Nutzer zu senden
    public GameObject PopUp;

    public TMP_Text FailText;

    int buttonType;

    //mit dem Zurückbutten die App bedienen
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FailText.enabled = false;
            if (side == 0)
            {
                Application.Quit();
            }
            else
            {
                SiwtchSites(0);
            }
        }
    }
    //Textfelder der Scene um die Daten der Nutzer zu erhalten
    public TMP_InputField[] Inputs;

    //Wird aufgerufen vom Nutzer um sich einzuloggen
    public void Login()
    {
        buttonType = 1;
        ID.SaveDataInput(Inputs[0]);
        ID.SaveDataInput(Inputs[1]);
        Entry.TestCoroutine(UrlStrings.LOGIN);
        
    }

    //Wird aufgerufen vom Nutzer um sich zu registrieren
    public void Register()
    {
        buttonType = 2;
        ID.SaveDataInput(Inputs[2]);
        ID.SaveDataInput(Inputs[3]);
        ID.SaveDataString("SheetNr", "0");
        Entry.TestCoroutine(UrlStrings.REGISTER);
    }

    public void SwitchToMenu()
    {
        if(buttonType == 1)
        {
            OpenP("Erfolgreich eingeloggt, bitte weiter.");
        }
        else if(buttonType == 2)
        {
            infos.RegisterUserInfos(UrlStrings.SAVE_USERINFO);
        }
        buttonType = 0;
        
    }

    //falls input schon vorhanden, wird abgebrochen und fehler zurück gegeben
    public void ShowFail(string fail)
    {
        FailText.enabled = true;
        FailText.text = fail;
        StartCoroutine(FinishFirst());
    }

    IEnumerator FinishFirst()
    {
        yield return new WaitForSeconds(2);
        FailText.enabled = false;
    }

    //Springt zum Hauptmenü
    public void ToMenu()
    {
        CloseP();
        SceneManager.LoadScene(1);
    }

    // zum einfachen erstellen von Seiten
    // benötigt Buttons, denen diese funktion gegeben wird mit dem int, der dem Tab zugeordent ist auf dem Script in dem Array
    
    //die erste Seite, welche angezeigt wird
    public GameObject Active;
    //alle Seiten der Scene
    public GameObject[] Sites;
    //Temp
    int side;

    public void SiwtchSites(int Site)
    {
        side = Site;
        Active.gameObject.SetActive(false);
        Active = Sites[side];
        Active.gameObject.SetActive(true);
    }

    //die nächsten zwei sind offensichtlich, jedoch sie öffnen(mit Text) und shcließen das PopUp
    public void OpenP(string PopUpText)
    {
        PopUp.GetComponentInChildren<TMP_Text>().text = PopUpText;
        PopUp.SetActive(true);
    }

    public void CloseP()
    {
        PopUp.SetActive(false);
    }
}

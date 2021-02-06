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

    //mit dem Zurückbutten die App bedienen
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(side == 0)
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
        ID.SaveDataInput(Inputs[0]);
        ID.SaveDataInput(Inputs[1]);
        Entry.TestCoroutine(UrlStrings.LOGIN);
        OpenP("Erfolgreich eingeloggt, bitte weiter.");
    }

    //Wird aufgerufen vom Nutzer um sich zu registrieren
    public void Register()
    {
        ID.SaveDataInput(Inputs[2]);
        ID.SaveDataInput(Inputs[3]);
        Entry.TestCoroutine(UrlStrings.REGISTER);
        ID.SaveDataString("SheetNr", "0");
        StartCoroutine(FinishFirst(1));
        
    }

    //eine kleine ladezeit um die UserID zu erhalten
    IEnumerator FinishFirst(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        infos.RegisterUserInfos(UrlStrings.SAVE_USERINFO);
        OpenP("Erfolgreich eingeloggt, bitte weiter.");
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

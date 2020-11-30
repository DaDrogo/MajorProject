using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    //was will ich haben?
    //1. abfrage nach id ob es schon Bögen gibt, anzahl an bögen wird in array gespeichert und buttons mit deren name erstellt. also 2 arrays
    //Außerdem wird ein Button für zurück benötigt
    //Main Menu beinhaltet ersmal nur buttons. Diese führen zu
    //1. login zurück
    //2. Erstellen von Fragebogen
    //3. Auswahl der erstellten Fragebögen
    //ez Arbeit kommt bei den Fragebögen

    int scene;
    public GameObject Button;
    public GameObject PopUp;

    private void Start()
    {
        ChangeButton("");
    }

    public void SwitchScene()
    {
        if(scene!=0)
            SceneManager.LoadScene(scene);
        else
        {
            PopUp.SetActive(true);
            PopUp.GetComponentInChildren<TMP_Text>().text = "Bitte Wähle etwas aus.";
            DeactivatePopUp();
        }
    }

    public void DeactivatePopUp()
    {
        PopUp.SetActive(false);
    }

    // zum einfachen erstellen von Tabs
    //benötigt Buttons, denen diese funktion gegeben wird mit dem int, der dem Tab zugeordent ist auf dem Script in dem Array

    public GameObject Active;
    public GameObject[] Sites;

    public void SiwtchSites(int Site)
    {
        Active.gameObject.SetActive(false);
        Active = Sites[Site];
        Active.SetActive(true);
    }

    //gib dem Button zum Wechseln der Seite einen Text und aktiviee ihn um auf die nächste Scene zugreifen zu können.

    public void ChangeButton(string text)
    {
        if (text != "")
        {
            Button.GetComponent<Button>().interactable = true;
            Button.GetComponentInChildren<TMP_Text>().text = text;
        }
        else
        {
            Button.GetComponentInChildren<TMP_Text>().text = "";
            Button.GetComponent<Button>().interactable = false;
        }
    }

    //bekomme eine Zahl, auf welche Seite du zugreifen möchtest außerdem werden Werte gespeichert um auf der nächsten Seite weiter zu geben


    void GetText()
    {

    }

    //_____________________________________________________________________CHARAKTERBÖGEN____________________________________________________________________________

    // hier sollen Gameobjecte gesammelt werden in einer Liste, und auch wieder gelöcht werden jeweils in unterschiedlichen Funktionen
    // wenn der Button gedrückt wird, soll der Spawner eine Zahl bekommen. So oft soll er dann die Liste füllen mit Zahl, Namen und Rasse

    public GameObject CharButton;
    public GameObject SpawnPosition;
    int classAmount;
    GameObject[] Buttons;

    public class CharValues
    {
        int[] nr;
        string[] names;
        string[] races;
    }

    //Hier ist die Funktion des Buttons, wenn dieser gedrückt wird.
    public void PressCharaktersheet()
    {
        GetClassAmount();
        FillList();
        CreateCharacterSheets();
    }

    //Hier wird herausgefunden, wie groß [classAmount] ist durch die ID des Benutzers außerdem wird dann [classAmount]diese Zahl gegeben
    void GetClassAmount()
    {

    }

    //Nun wird mir der ClassAmount die Liste aus der Datenbank befüllt. Dazu wird auf die Datenbank zugegriffen und mithilfde der ID und der Anzahl der Klassen diese runtergeladen

    void FillList()
    {

    }

    //Hier werden die Werte aus der Liste besorgt , wlche vorher durch die Datenbank befüllt wurde
    int GetClassNr(int ID)
    {
        return ID;
    }
    string GetClassName(int ID)
    {
        return ID.ToString();
    }
    string GetClassRace(int ID)
    {
        return ID.ToString();
    }

    //nun werden die Buttons mit den Werten der Liste gefüllt
    void CreateCharacterSheets()
    {
        for(int i = 0; i <= 5; i++)
        {
            GameObject Temp = Instantiate(CharButton, SpawnPosition.transform);
            // Gib Button Werte
            Temp.GetComponentInChildren<TMP_Text>().text = GetClassNr(i).ToString();
            TMP_Text [] ButtonsText =  Temp.GetComponentsInChildren<TMP_Text>(); 
            ButtonsText[0].text = GetClassNr(i).ToString();
            ButtonsText[1].text = GetClassName(i);
            ButtonsText[2].text = GetClassRace(i);
            // Weise dem Button einen Ort zu
            //Temp.transform.position = new Vector3(0, SpawnPosition.transform.position.y - 200 * classAmount, 0);
        }
    }

    //___________________________________ALLROUND_____________________________
    public void DeleteClasses()
    {
        foreach(Transform child in SpawnPosition.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    //___________________________________CHARAKTERERSTELLUNG_____________________________

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;


//Speicher die Daten für die Texte in den Buttons der Charakterbögen
[System.Serializable]
public class CharValues
{
    public int nrs;
    public string names ;
    public string races;

    //Konstruktor nur zum erinnern ;)
   //public CharValues()
   //{
   //    nrs = 0;
   //    names = "0";
   //    races = "0";
   //}
}

public class MainMenuManager : MonoBehaviour
{
    //___________________________________Beschreibung_____________________________
    //was will ich haben?
    //1. abfrage nach id ob es schon Bögen gibt, anzahl an bögen wird in array gespeichert und buttons mit deren name erstellt. also 2 arrays
    //Außerdem wird ein Button für zurück benötigt
    //Main Menu beinhaltet ersmal nur buttons. Diese führen zu
    //1. login zurück
    //2. Erstellen von Fragebogen
    //3. Auswahl der erstellten Fragebögen

    //___________________________________Variablen_____________________________
    
    //speichert die nächste Scene
    int scene;

    //Button der die Scene wechselt
    public GameObject ChangeSceneButton;

    public GameObject PopUp;

    //Der Button welcher automatisch geklickt werden soll, wenn die App geöffnet wird
    public Button StartButton;

    //Zum erstellen der Charakterbögen
    public GameObject CharButton;
    public GameObject SpawnPosition;
    int classAmount;
    //Speichert die Daten der Charakterbögen
    private CharValues[] charis;

    //erhält Daten zum speichern
    public TMP_Text[] Inputs;

    //Speichert und Lädt die Daten des Nutzers
    public PlayerData ID;

    //Networkseiten
    public GetUserInfos userInfos;
    public NetworkCreateSheet Sheet;





    //___________________________________ALLROUND_____________________________

    private void Start()
    {

        userInfos.GetTheInfos(UrlStrings.GET_USERINFO);
        ChangeButton("");
        StartButton.onClick.Invoke();

    }

    public void DeactivatePopUp()
    {
        PopUp.SetActive(false);
    }

    // zum einfachen erstellen von Tabs
    //benötigt Buttons, denen diese funktion gegeben wird mit dem int, der dem Tab zugeordent ist auf dem Script in dem Array

    public GameObject Active;
    public GameObject[] Sites;

    public void SwitchSites(int Site)
    {
        scene = Site;
    }

    //gib dem Button zum Wechseln der Seite einen Text und aktiviee ihn um auf die nächste Scene zugreifen zu können.

    public void ChangeButton(string text)
    {
        if (text != "")
        {

            ChangeSceneButton.GetComponentInChildren<TMP_Text>().text = text;
        }
        else
        {
            ChangeSceneButton.GetComponentInChildren<TMP_Text>().text = "";
            
        }
        ChangeSceneButton.GetComponent<Button>().interactable = false;
    }

    public void MakeButtonActive()
    {
        ChangeSceneButton.GetComponent<Button>().interactable = true;
    }

    //_____________________________________________________________________CHARAKTERBÖGENBUTTON____________________________________________________________________________

    // hier sollen Gameobjecte gesammelt werden in einer Liste, und auch wieder gelöcht werden jeweils in unterschiedlichen Funktionen
    // wenn der Button gedrückt wird, soll der Spawner eine Zahl bekommen. So oft soll er dann die Liste füllen mit Zahl, Namen und Rasse

    //Hier ist die Funktion des Buttons, wenn dieser gedrückt wird.
    public void PressCharaktersheet()
    {
       //string SheetNr = (int.Parse(DatabaseData.DataId.UserCharSheets.ToString()) + 1).ToString();
       //Debug.Log(SheetNr);
        DeleteClasses();
        GetClassAmount();
        FillList();
        StartCoroutine(FinishFirst(1));

    }

    //Hier wird herausgefunden, wie groß [classAmount] ist durch die ID des Benutzers außerdem wird dann [classAmount]diese Zahl gegeben
    void GetClassAmount()
    {
        classAmount = int.Parse(ID.data[DatabaseData.DataId.UserCharSheets.ToString()]);       
        Debug.Log("Klasenanzahl: "+classAmount);
    }

    //Nun wird mir der ClassAmount die Liste aus der Datenbank befüllt. Dazu wird auf die Datenbank zugegriffen und mithilfde der ID und der Anzahl der Klassen diese runtergeladen

    void FillList()
    {
        charis = new CharValues[classAmount];
        
        for (int u = 0; u < classAmount; u++)
        {
            charis[u] = new CharValues();
            charis[u].nrs = u + 1;
            StartCoroutine(GetButtonSheetInfos(u + 1));
        }

    }

    //nun werden die Buttons mit den Werten der Liste gefüllt
    void CreateCharacterSheetsTheSecon()
    {
        foreach (CharValues i in charis)
        {
            GameObject Temp = Instantiate(CharButton, SpawnPosition.transform);
            // Gib Button Werte
            Temp.GetComponentInChildren<TMP_Text>().text = i.nrs.ToString(); ;
            TMP_Text[] ButtonsText = Temp.GetComponentsInChildren<TMP_Text>();
            ButtonsText[0].text = i.nrs.ToString();
            ButtonsText[1].text = i.names;
            ButtonsText[2].text = i.races;
            // Weise dem Button einen Ort zu
            //int zum casten
            Temp.transform.position = new Vector3(SpawnPosition.transform.position.x, SpawnPosition.transform.position.y - 200 * (i.nrs-1), 0);
        }
    }

    //zerstöre die Klassem erschaffen, vom Klassenersteller
    public void DeleteClasses()
    {
        foreach (Transform child in SpawnPosition.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

   

    //___________________________________DataManagment_____________________________


    //Wird beim drücken des Weiterbuttons aktiviert, speichert alle Daten und wechselt die Scene
    public void ChangeScene()
    {
        //speichert die Daten für die Charaktererstellung
        if (scene == 2)
        {
            ID.SaveDataText(Inputs[0]);
            ID.SaveDataText(Inputs[1]);
        }
        //lädt die Daten des Charakterbogens, welcher angeklickt wurde
        else if (scene == 3)
        {
            Sheet.LoadSheet();
        }
        SceneManager.LoadScene(scene);
    }

    //___________________________________Coroutine_____________________________

    IEnumerator FinishFirst(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        CreateCharacterSheetsTheSecon();
    }

    //eine kleine Network Courotine, weil schneller und einfacher
    public IEnumerator GetButtonSheetInfos(int SheetNr)
    {
        Debug.Log("Connecting");
        WWWForm form = new WWWForm();
        form.AddField("UserID", ID.data["UserID"]);
        form.AddField("SheetNr", SheetNr.ToString());
        UnityWebRequest request = UnityWebRequest.Post(UrlStrings.GET_SHEETINFOS, form);
        yield return request.Send();
        if (request.isNetworkError || request.isHttpError)
        {
            //Warning.text = "Networkerror";
            Debug.LogError("Networkerror");
        }
        else if (request.downloadHandler.text == "lol")
        {
            Debug.Log("HAH");
        }
        else
        {
            //Speichert die Daten in dem Array vom MainMenuManager
            string Texti = request.downloadHandler.text;
            string[] textArray = Texti.Split(" "[0]);
            Debug.Log(textArray[0]);
            Debug.Log(textArray[1]);
            charis[SheetNr - 1].names = textArray[0];
            charis[SheetNr - 1].races = textArray[1];
            request.Dispose();
        }
    }
}

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

    public bool test =false;

    //zeigt die zukünftige Scene an
    private int scene;
    //Button der die Scene wechselt
    public GameObject ChangeSceneButton;

    public GameObject PopUp;

    //Der Button welcher automatisch geklickt werden soll, wenn die App geöffnet wird
    public Button StartButton;

    //Zum erstellen der Charakterbögen
    public GameObject CharButton;
    int classAmount;

    //Speichert die Daten der Charakterbögen
    public CharValues[] charis;

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
        if (test)
        {
            TestChar();
        }
        userInfos.GetTheInfos(UrlStrings.GET_USERINFO);
        StartButton.onClick.Invoke();


    }

    void TestChar()
    {
        ID.SaveDataString("UserID", "41");
    }

    public void DeactivatePopUp()
    {
        PopUp.SetActive(false);
    }
    //gib dem Button zum Wechseln der Seite einen Text und aktiviee ihn um auf die nächste Scene zugreifen zu können.

    public void ChangeButton(int future)
    {
        scene = future; 
        if (future == 2)
        {
            PersonalText();
        }
        else
        {
            ChangeSceneButton.GetComponentInChildren<TMP_Text>().text = "Charakter bearbeiten";
            //ChangeSceneButton.GetComponentInChildren<TMP_Text>().text = classShow[1].text + "\n" + " bearbeiten";
        }
    }

    public void PersonalText()
    {
        ChangeSceneButton.GetComponentInChildren<TMP_Text>().text = Inputs[0].text + "\n" + " erstellen";
    }

    //_____________________________________________________________________CHARAKTERBÖGENBUTTON____________________________________________________________________________

    // hier sollen Gameobjecte gesammelt werden in einer Liste, und auch wieder gelöcht werden jeweils in unterschiedlichen Funktionen
    // wenn der Button gedrückt wird, soll der Spawner eine Zahl bekommen. So oft soll er dann die Liste füllen mit Zahl, Namen und Rasse

    //Hier ist die Funktion des Buttons, wenn dieser gedrückt wird.
   public void PressCharaktersheet()
   {
      //string SheetNr = (int.Parse(DatabaseData.DataId.UserCharSheets.ToString()) + 1).ToString();
      //Debug.Log(SheetNr);
       
       GetClassAmount();
       FillList();
   
   }

    //Hier wird herausgefunden, wie groß [classAmount] ist durch die ID des Benutzers außerdem wird dann [classAmount]diese Zahl gegeben
    void GetClassAmount()
    {
        classAmount = int.Parse(ID.data["UserCharSheets"]);       
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
    //___________________________________DropdownLösung_____________________________

    List<string> DropOptions = new List<string> { };
    public TMP_Dropdown CharClasses;

    void GiveDropdownsOptions()
    {
        CharClasses.ClearOptions();    
        for (int i = 0; i < classAmount; i++)
        {
            DropOptions.Add(charis[i].names);
            Debug.Log(charis[i].names);
        }
        CharClasses.AddOptions(DropOptions);
        DropOptions.Clear();
    }

    //zeigt die Werte der Klasse, wenn sie im Dropdown ausgewählt wurde
    //also am Dropdown befestigt und die Value des DD = tear
    public TMP_InputField[] classShow;
    public void DropdownÀctivationClasses(int tear)
    {
        if (charis.Length == 0)
        {
            CharClasses.ClearOptions();
            DropOptions.Add("leer");
            CharClasses.AddOptions(DropOptions);
            DropOptions.Clear();

            classShow[0].text = "leer";
            classShow[1].text = "leer";
            classShow[2].text = "leer";
        }
        else
        {
            classShow[0].text = charis[tear].nrs.ToString();
            classShow[1].text = charis[tear].names;
            classShow[2].text = charis[tear].races;
            ID.SaveDataInput(classShow[0]);
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
            SaveBaseValues();
        }
        //lädt die Daten des Charakterbogens, welcher angeklickt wurde
        else if (scene == 3)
        {
            Sheet.LoadSheet();
        }
        SceneManager.LoadScene(scene);
    }

    int[] basevalues;
    JsonManager json;
    public TextAsset jsonText;
    void SaveBaseValues()
    {    
        ID.SaveDataString("AG", basevalues[0].ToString());
        ID.SaveDataString("KR", basevalues[1].ToString());
        ID.SaveDataString("AU", basevalues[2].ToString());
        ID.SaveDataString("RE", basevalues[3].ToString());
        ID.SaveDataString("GE", basevalues[4].ToString());
        ID.SaveDataString("VE", basevalues[5].ToString());
    }
    
    public TMP_InputField[] civValues;
    public void ShowValues(int value)
    {
        basevalues = new int[6];
        json = new JsonManager();
        for (int i = 0; i < 6; i++)
        {
            basevalues[i] = json.ReadJsonCivValues(jsonText, value, i);
            civValues[i].text = basevalues[i].ToString();
        }
    }

    //___________________________________Coroutine_____________________________

    int gotEverythin = 0;
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
            gotEverythin++;
            //Speichert die Daten in dem Array vom MainMenuManager
            string Texti = request.downloadHandler.text;
            string[] textArray = Texti.Split("|"[0]);
            charis[SheetNr - 1].names = textArray[0];
            charis[SheetNr - 1].races = textArray[1];
            Debug.Log("Name "+charis[SheetNr - 1].names);
            if (gotEverythin == classAmount)
            {
                GiveDropdownsOptions();
                gotEverythin = 0;
            }
            request.Dispose();
        }
    }
}

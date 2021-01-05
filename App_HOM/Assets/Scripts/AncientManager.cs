using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class AncientManager : MonoBehaviour
{
    //dort wird das erste Objekt gespawnt
    public Transform SpawnPosition;

    // Objekte zum spawnen
    public GameObject buttonPrefab;
    public GameObject headerPrefab;

    public int ObjectHeight = 100;
    int ButtonAmount;
    int HeaderAmount;
    int FieldPosition;
    int ButtonTexts;
    string ButtonText;




    string First = "name";
    string Second = "HeadersNr";
    string Third = "Buttons";
    string Fourth = "Texts";


    JsonManager jManager;
    public TextAsset TeachFile;

    private void Start()
    {
        jManager = new JsonManager();
        CreateHeader("ja", 0);
        CreateButton("Nein", 1);
    }

    //Wird von dem Dropdown aufgerufen und erhält einen int Wert welcher der Buttons gedrückt wurde. Der Int wert wird im Json benötigt um die richtigen Werte zu erhalten

    public void TechingDrop(int Drop)
    {
        Create(Drop);
    }

    //Was wird benötigt?
    //eine Funktion die die alten Objekte löscht. Also am besten alle Childs von dem Spawnergameobject X
    //1. eine Schleife um die Objekte zu erstellen
    //2. die Anzahl der zu erstellenden Objekte
    //3.Schleife beinhaltet zuerst wird geschaut ob Header Null ist falls nicht beginnt die schleife
        //a.Header mit Wert erstellen
        //b.Button parsen und soviele erstellen mit den Texten
        //c.dabei wird der Buttoncount immer höher gezählt
    //4.

    void Create(int Drop)
    {
        foreach(Transform child in SpawnPosition)
        {
            Destroy(child.gameObject);
        }
        FieldPosition = 0;
        ButtonTexts = 0;
        bool rdy = false;
        while (rdy == false)
        {
            HeaderAmount = jManager.ReadJsonLength(Drop, Second,TeachFile);
            Debug.Log(HeaderAmount);
            for (int i = 0; i < HeaderAmount; i++)
            {
                CreateHeader(jManager.ReadJsonText(Drop, "HeadersNr",i, TeachFile), FieldPosition);
                
                ButtonAmount = int.Parse(jManager.ReadJsonText(Drop, "Buttons", i, TeachFile));
                Debug.Log(ButtonAmount);
                for (int j = 0; j < ButtonAmount; j++)
                {
                    CreateButton(jManager.ReadJsonText(Drop, "Texts", ButtonTexts, TeachFile), FieldPosition);
                }
            }
            CreateChoice();
            rdy = true;
        }
    }

    void CreateChoice()
    {

    }

    void CreateHeader(string NrText, int HeaderNr)
    {

        GameObject Temp = Instantiate(headerPrefab, SpawnPosition);
        // Gib Header einen Text
        Temp.GetComponent<TMP_Text>().text = "Wähle bitte " + NrText + " aus.";
        //Erstelle Header an Position
        Temp.transform.position = new Vector3(SpawnPosition.transform.position.x, SpawnPosition.transform.position.y - ObjectHeight/10 * HeaderNr, 0);
        FieldPosition++;

    }



    void CreateButton(string Text, int ButtonNr)
    {
        //Erstelle Button als Child von Objekt
        GameObject Temp = Instantiate(buttonPrefab,SpawnPosition);
        // Gib Button Werte
        Temp.GetComponentInChildren<TMP_Text>().text = Text;
        // Weise dem Button einen Ort zu
        Temp.transform.position = new Vector3(SpawnPosition.transform.position.x, SpawnPosition.transform.position.y - ObjectHeight/10 * ButtonNr, 0);
        FieldPosition++;
        ButtonTexts++;
    }

    void SwitchPage(int page)
    {

    }
}

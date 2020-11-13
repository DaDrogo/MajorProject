using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class AncientManager : MonoBehaviour
{
    public GameObject ButtonSpawnpoint;
    public GameObject HeaderSpawnpoint;

    public GameObject buttonPrefab;
    int ObjectHeight = 50;
    int ButtonAmount;
    int HeaderAmount;
    string ButtonText;

    public GameObject headerPrefab;


    string First = "name";
    string Second = "HeadersNr";
    string Third = "Buttons";
    string Fourth = "Texts";


    JsonManager jManager;
    public TextAsset TeachFile;

    private void Start()
    {
        jManager = new JsonManager();
        CreateHeader("Test", 0);
        CreateButton("Test", 1);
        CreateButton("Test", 3);
        Create(1);
    }

    public void TechingDrop(int Drop)
    {
        LoadJson(Drop,TeachFile);
    }

    void LoadJson(int Drop, TextAsset File)
    {
        //erhalte die Information, dass Button gedrückt wurde und den Wert
        // geht zu nächsten Seite über
        Create(Drop);
        CreateHeader("Test", 0);
    }

    void Create(int Drop)
    {
        CreateButton("Test2", 2);
        int amount = 0;
        bool rdy = false;
        while (rdy == false)
        {
            HeaderAmount = jManager.ReadJsonLength(Drop, Second);
            Debug.Log(HeaderAmount);
            for (int i = 0; i <= HeaderAmount; i++)
            {

                amount++;
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
        // Gib Header einen Text
        headerPrefab.GetComponent<TMP_Text>().text = "Wähle bitte " + NrText + " aus.";
        //Erstelle Header an Position
        HeaderSpawnpoint.transform.position = new Vector3(HeaderSpawnpoint.transform.position.x, HeaderSpawnpoint.transform.position.y - 50 * HeaderNr, 0);
        Instantiate(headerPrefab, HeaderSpawnpoint.transform);
    }

    public Transform SpawnPosition;

    void CreateButton(string Text, int ButtonNr)
    {
        //Test 1

        // GameObject Temp = buttonPrefab;
        // // Gib Button Werte
        // Temp.GetComponentInChildren<TMP_Text>().text = Text;
        // // Erstelle Button an Ort
        // Debug.Log(Temp.transform.position);
        // SpawnPosition.position = new Vector3(Temp.transform.position.x, Temp.transform.position.y - 50 * ButtonNr, 0);
        // Debug.Log(Temp.transform.position);
        // Instantiate(Temp,SpawnPosition);


        //Test 2
        Instantiate(buttonPrefab, SpawnPosition);
    }

    //Idee aufbauen einer List von Headern und Buttons und diese dann abarbeiten erst Objekte erschaffen und diese dann befüllen

    void SwitchPage(int page)
    {

    }
}

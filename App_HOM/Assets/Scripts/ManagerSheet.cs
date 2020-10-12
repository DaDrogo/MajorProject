using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class ManagerSheet : MonoBehaviour
{
    //Needs Work




    //PopUp
    [SerializeField]
    GameObject PopUp;
    [SerializeField]
    TMP_Text Info;
    private bool Acceptens;

    //Pages
    [SerializeField]
    private GameObject[] Pages;
    private int From;

    //Legt Scene am anfang fest
    private void Awake()
    {
        Acceptens = false;
        //from ist bei Entry also 0
        From = 0;
        Pages[0].SetActive(true);
        PopUp.SetActive(false);
        
    }

    public void Update()
    {
        //Soll zwischen den Seiten des Fragebogens wechseln oder die Scene ändern
        //Save ist hier nicht inbegriffen
        if (Acceptens)
        {
            PopUp.SetActive(false);
            switch (From)
            {
                case -1:
                    //Zurück Button bei Entry
                    ChangeScene(1);
                    break;
                case 2:
                    //weiter button bei entry
                    Debug.Log(From);
                    SwitchPage(Pages[0], Pages[1]);
                    break;
                case 1:
                    //Zurück button bei Person
                    Debug.Log(From);
                    SwitchPage(Pages[1], Pages[0]);
                    From--;
                    break;
                case 4:
                    //weiter button bei Person
                    Debug.Log(From);
                    SwitchPage(Pages[1], Pages[2]);
                    break;
                case 3:
                    //Zurück button bei Past
                    Debug.Log(From);
                    SwitchPage(Pages[2], Pages[1]);
                    From--;
                    break;
                case 6:
                    Debug.Log(From);
                    //weiter Button bei Past
                    ChangeScene(3);
                    break;
            }
        }
    }

    //Methode für Update
    void SwitchPage(GameObject FromPage, GameObject ToPage)
    {
        FromPage.SetActive(false);
        ToPage.SetActive(true);
        Acceptens = false;
    }

    //Methode für Update
    void ChangeScene(int scene)
    {
        Acceptens = false;
        SceneManager.LoadSceneAsync(scene);
    }

    // wird den Buttons in der Ecke der UI zugeordnet
    public void CreatePopup(int fr)
    {
        From = From+fr;
        if (fr == 2)
            Info.text = "Möchtest du weiter?";
        else
            Info.text = "Möchtest du zurück?";

        PopUp.SetActive(true);
    }

    // Wird den Buttons auf dem Popup zugeordnet
    public void ChangeBool(bool change)
    {
        if (change)
            Acceptens = change;
        else
            PopUp.SetActive(false);
    }

}

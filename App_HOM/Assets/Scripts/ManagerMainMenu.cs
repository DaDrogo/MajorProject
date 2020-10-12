using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerMainMenu : MonoBehaviour
{

    //was will ich haben?
    //1. abfrage nach id ob es schon Bögen gibt, anzahl an bögen wird in array gespeichert und buttons mit deren name erstellt. also 2 arrays
    //Außerdem wird ein Button für zurück benötigt
    //Main Menu beinhaltet ersmal nur buttons. Diese führen zu
    //1. login zurück
    //2. Erstellen von Fragebogen
    //3. Auswahl der erstellten Fragebögen
    //ez Arbeit kommt bei den Fragebögen

    public void SwitchScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}

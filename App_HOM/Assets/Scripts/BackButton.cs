using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    //PopUp falls es benötigt wird
    public GameObject PopUp;
    //gibt es PopUp oder nicht 0=kein PopUp  1=PopUp
    public int Type = 0;

    private void Start()
    {
        if(PopUp!= null)
            ClosePopUp();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoBack();
        }
    }

    void GoBack()
    {
        if (Type == 0)
            QuitApplication();

        else if (Type == 1)
            OpenPopUp();
    }

    void OpenPopUp()
    {
        PopUp.SetActive(true);
    }

    public void ClosePopUp()
    {
        PopUp.SetActive(false);
    }

    public void SwitchScene(int scene)
    {
        ClosePopUp();
        SceneManager.LoadScene(scene);
    }

    void QuitApplication()
    {
        Application.Quit();
    }
}

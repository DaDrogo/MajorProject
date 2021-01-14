using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharButtonScript : MonoBehaviour
{
    GameObject MMM;

    void Start()
    {
        MMM = GameObject.FindGameObjectWithTag("Manager");
    }

    public void Activate()
    {
        MMM.GetComponent<MainMenuManager>().MakeButtonActive();
    }
}

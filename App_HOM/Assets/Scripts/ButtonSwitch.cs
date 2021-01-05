using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : MonoBehaviour
{
    // zum einfachen erstellen von Tabs
    //benötigt Buttons, denen diese funktion gegeben wird mit dem int, der dem Tab zugeordent ist auf dem Script in dem Array

    GameObject Active;
    public GameObject[] Sites;

    private void Start()
    {
        Active = Sites[0];
        Active.gameObject.SetActive(true);
    }

    public void SiwtchSites(int Site)
    {
        Active.gameObject.SetActive(false);
        Active = Sites[Site];
        Active.SetActive(true);
    }
}

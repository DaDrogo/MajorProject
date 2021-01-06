using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitch : MonoBehaviour
{
    // zum einfachen erstellen von Tabs
    //benötigt Buttons, denen diese funktion gegeben wird mit dem int, der dem Tab zugeordent ist auf dem Script in dem Array

    GameObject Active;
    public GameObject[] Sites;
    public GameObject[] Buttons;

    private void Start()
    {
        Active = Sites[0];
        Active.gameObject.SetActive(true);
    }

    public void SiwtchSites(int Site)
    {
        ReturnColor();
        Active.gameObject.SetActive(false);
        Active = Sites[Site];
        Active.SetActive(true);
        NormalColor(Site);
    }

    public void NormalColor(int but)
    {
        var color = Buttons[but].GetComponent<Button>().colors;
        color.normalColor = color.selectedColor;
        Buttons[but].GetComponent<Button>().colors = color;
    }

    public void ReturnColor()
    {
        foreach(GameObject but in Buttons)
        {
            var color = but.GetComponent<Button>().colors;
            color.normalColor = color.highlightedColor;
            but.GetComponent<Button>().colors = color;
        }
    }
}

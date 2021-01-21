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
    public GameObject[] Arrows;
    int side;
    public int max;

    private void Start()
    {
        Active = Sites[0];
        Active.gameObject.SetActive(true);
    }

    public void SiwtchSites(int Site)
    {
        side = Site;
        ChangeSite();
    }

    public void SwitchSitesArrows(int Site)
    {
        side = Site;
        CheckArrows();
        ChangeSite();
    }

    public void GetSite(int multi)
    {
        side = side+multi;
        CheckArrows();
        ChangeSite();
    }

    void ChangeSite()
    {

        ReturnColor();
        Active.gameObject.SetActive(false);
        Active = Sites[side];
        Active.SetActive(true);
        NormalColor(side);
    }

    void CheckArrows()
    {
        if (side <= 0)
        {
            Arrows[1].SetActive(true);
            Arrows[0].SetActive(false);
        }
        else if (side >= max)
        {
            Arrows[0].SetActive(true);
            Arrows[1].SetActive(false);
        }
        else
        {
            Arrows[0].SetActive(true);
            Arrows[1].SetActive(true);
        }
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

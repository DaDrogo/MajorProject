using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeIt : MonoBehaviour
{
    public TMP_Dropdown Drop;
    public TMP_InputField Text;
    public TMP_Text Effect;

    public TextAsset EffectText;
    public TextAsset DropText;

    public Sprite[] images;
    public Image picture;

    //wechsel den String der momentanen Ambition
    public void ChooseIt()
    {
        Text.text = Drop.options[Drop.value].text;
    }

    //wechsel den Effekt wenn der String geändert wurde

    public void ShowIt(string change)
    {
        string[] drop = DropText.text.Split("\n"[0]);

        for(int i = 0; i < drop.Length; i++)
        {
            if (change.Equals(drop[i]))
            {
                Effect.text = ParseFile(i);
            }
        }
    }

    public void ShowPic(string change)
    {
        string[] drop = DropText.text.Split("\n"[0]);
        for (int i = 0; i < drop.Length; i++)
        {
            if (change.Equals(drop[i]))
            {
                picture.sprite = images[i];
            }
        }
    }

    private string ParseFile(int Nr)
    {
        //muss noch überarbeitet werden suche des Speicherorts
        //TXT Dateien aus dem Server holen
        string[] Text = EffectText.text.Split("\n"[0]);
        return (Text[Nr]);
    }
}

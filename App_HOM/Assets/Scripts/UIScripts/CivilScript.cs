using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CivilScript : MonoBehaviour
{
    public TMP_Text AbilityHeader;
    public TMP_Text AbilityEffect;

    public TextAsset Header;
    public TextAsset Effect;

    public void OnChange(int civ)
    {
        ChangeAbiliy(civ);
    }

    void ChangeAbiliy(int civ)
    {
        AbilityHeader.text = ParseFile(Header,civ);
        AbilityEffect.text = ParseFile(Effect, civ);
    }

    private string ParseFile(TextAsset File, int Nr)
    {
        //muss noch überarbeitet werden suche des Speicherorts
        //TXT Dateien aus dem Server holen
        string[] Text = File.text.Split("\n"[0]);
        return (Text[Nr]);
    }
}

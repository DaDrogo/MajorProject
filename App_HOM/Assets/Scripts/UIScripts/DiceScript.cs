using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DiceScript : MonoBehaviour
{
    public TMP_Text Dice;
    public TMP_Text Result;

    string dices;
    //hier wird das Ergebniss an den Text gesendet
    int value;
    bool activ =false;

    public void ShowDice(int diceText)
    {
        activ = true;
        Debug.Log(Randomizer( 5));
        value = diceText;
        Dice.text = getDice(diceText);
    }

    public void RollTheDices()
    {
        if (activ == true)
        {
            getDice(value);
            Result.text = dices;
        }
    }

    string getDice(int value)
    {
        string dice = "";
        if (value <= 4)
        {
            dices = Randomizer(5) + " ";
            dice = "1: W4";
        }
        else if (value <= 7 && value > 4)
        {
            dices = Randomizer(7) + " + einen Modi.";
            dice = "1: W6 + 1: Modi.";
        }
        else if (value <= 13 && value > 7)
        {
            dices = Randomizer(5) + Randomizer(5) + " + einen Modi.";
            dice = "2: W4 + 1: Modi.";
        }
        else if (value <= 17 && value > 13)
        {
            dices = Randomizer(7) + Randomizer(7) + " + zwei Modi.";
            dice = "2: W6 + 2: Modi.";
        }
        else if (value <= 20 && value > 17)
        {
            dices = Randomizer(7) + Randomizer(7) + Randomizer(7) + " + zwei Modi.";
            dice = "3: W6 + 2: Modi.";
        }
        else
        {
             dices = Randomizer(9) + Randomizer(9) + Randomizer(9) + " + drei Modi.";
            dice = "4: W8 + 3: Modi.";
        }
        return dice;
    }

    int Randomizer(int max)
    {
        return Random.Range(0, max);
    }
}

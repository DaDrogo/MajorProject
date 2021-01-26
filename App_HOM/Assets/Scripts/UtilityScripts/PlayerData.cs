using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "HOM/Player Data", order = 0)]
public class PlayerData : ScriptableObject
{
    public Dictionary<string, string> data = new Dictionary<string, string>();


    public void SaveDataInput(TMP_InputField input)
    {
        string key = input.gameObject.GetComponent<DatabaseData>().id.ToString();
        string value = input.text;

        SaveDataString(key, value);
    }
    public void SaveDataText(TMP_Text input)
    {
        string key = input.gameObject.GetComponent<DatabaseData>().id.ToString();
        string value = input.text;

        SaveDataString(key, value);
    }


    public void SaveDataString(string key, string value)
    {
        if (data.ContainsKey(key))
        {
            data[key] = value;
        }
        else
        {
            data.Add(key, value);
        }
        Debug.Log(data[key]);
    }
}



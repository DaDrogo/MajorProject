using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "HOM/Player Data", order = 0)]
public class PlayerData : ScriptableObject
{
    public int ID;
    public Dictionary<string, string> data;

    private void Awake()
    {
        data = new Dictionary<string, string>();
    }

    public void SaveData(TMP_InputField input)
    {
        string key = input.gameObject.GetComponent<DatabaseData>().id.ToString();
        string value = input.text;

        if (data.ContainsKey(key))
        {
            data[key] = value;
        }
        else
        {
            data.Add(key, value);
        }
    }
}

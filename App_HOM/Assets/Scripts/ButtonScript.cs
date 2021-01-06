using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    TMP_Text header;
    public TMP_Text View;

    void Start()
    {
        header = GetComponentInChildren<TMP_Text>();
    }

    public void OnSelect()
    {
        View.text = header.text;
    }

    public void OnDeselect()
    {
        View.text = "";
    }

}

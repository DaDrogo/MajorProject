using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseValues : MonoBehaviour
{
    public CharSheetManager manager;
    public void OnDeselect()
    {
        manager.ShowValues();
    }
}

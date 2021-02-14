using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilityScript : MonoBehaviour
{
    public PlayerData data;
    public DropdownManager dropiManage;

    public void ChangeType(int i)
    {
        if(i == 0)
        {
            data.SaveDataString("AbiType","Physisch");
            
        }
        else if(i == 1)
        {
            data.SaveDataString("AbiType", "Magni Synti");
        }
        else
        {
            data.SaveDataString("AbiType", "Voodoo");
        }
        dropiManage.CreateSingleDropdown(i);
    }
}

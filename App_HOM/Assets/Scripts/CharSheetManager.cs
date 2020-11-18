using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharSheetManager : MonoBehaviour
{
    int ItemAmount;
    public GameObject[] Spawns;
    public GameObject[] Items;

    public void CreateItem(int arrayNr)
    {
        
        GameObject Temp = Instantiate(Items[arrayNr], Spawns[arrayNr].transform);
        Temp.GetComponentInChildren<TMP_Text>().text = ItemAmount.ToString();
        Temp.transform.position = new Vector3(Spawns[arrayNr].transform.position.x, Spawns[arrayNr].transform.position.y - 50 * ItemAmount, 0);
        ItemAmount++;
    }

    void ResetItemAmount()
    {
        ItemAmount = 0;
    }
}

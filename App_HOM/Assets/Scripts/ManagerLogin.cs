using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLogin : MonoBehaviour
{
    public GameObject ID;

    private void Awake()
    {
        GameObject[] ToDestroy = GameObject.FindGameObjectsWithTag("ID");
        foreach(GameObject Gonk in ToDestroy)
            Object.Destroy(Gonk);

        Instantiate(ID);
    }

}

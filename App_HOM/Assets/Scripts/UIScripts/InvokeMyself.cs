using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvokeMyself : MonoBehaviour
{
    TMP_Dropdown me;
    private void Start()
    {
        me = this.GetComponent<TMP_Dropdown>();
        StartInvoke();

    }

    void StartInvoke()
    {
        me.value = 1;
        me.value = 0;
    }
}

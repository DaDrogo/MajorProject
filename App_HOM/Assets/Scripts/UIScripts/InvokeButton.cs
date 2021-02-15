using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvokeButton : MonoBehaviour
{
    Button me;
    private void Start()
    {
        me = this.GetComponent<Button>();
        StartInvoke();

    }

    void StartInvoke()
    {
        me.onClick.Invoke();
        
    }
}

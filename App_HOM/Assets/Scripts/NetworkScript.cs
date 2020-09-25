using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkScript : MonoBehaviour
{
    [SerializeField]
    private string urlRegister;

    [SerializeField]
    private string name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(RegisterUser());
        }
    }

    public IEnumerator RegisterUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", name);
        form.AddField("passport", "12345");
        UnityWebRequest request = UnityWebRequest.Post(urlRegister, form);
        yield return request.Send();

        if(request.isNetworkError||request.isHttpError)
        {
            Debug.LogError("Networkerror");
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            request.Dispose();
        }
    }
}

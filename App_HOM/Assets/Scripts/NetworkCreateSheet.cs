using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class NetworkCreateSheet : MonoBehaviour
{

    [SerializeField]
    private string urlCreate;

    [SerializeField]
    private int UserID = 1;

    [SerializeField]
    private TMP_Text CharCiv;
    [SerializeField]
    private TMP_Text CharName;
    [SerializeField]
    private TMP_Text CharWeight;
    [SerializeField]
    private TMP_Text CharHeight;
    [SerializeField]
    private TMP_Text CharAge;
    [SerializeField]
    private TMP_Text CharColor;
    [SerializeField]
    private TMP_Text CharLanguage;
    [SerializeField]
    private TMP_Text CharReligion;

    public void SafeSheet()
    {
        StartCoroutine(SafeCharactersheet());
    }


    public IEnumerator SafeCharactersheet()
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", UserID);
        form.AddField("charciv", CharCiv.text);
        form.AddField("charname", CharName.text);
        form.AddField("charweight", CharWeight.text);
        form.AddField("charheight", CharHeight.text);
        form.AddField("charage", CharAge.text);
        form.AddField("charcolor", CharColor.text);
        form.AddField("charlanguage", CharLanguage.text);
        form.AddField("charreligion", CharReligion.text);
        UnityWebRequest request = UnityWebRequest.Post(urlCreate, form);
        yield return request.Send();

        if (request.isNetworkError || request.isHttpError)
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

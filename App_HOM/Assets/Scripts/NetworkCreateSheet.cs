using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class NetworkCreateSheet : MonoBehaviour
{

    [SerializeField]
    private string urlCreate;

    // soll die ID vom einloggen erhhlten
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

    //Momentane Lösung gefällt mir null muss noch geändert werden
    private int CharCivAbility;
    public void ChangeAbility(int Abi)
    {
        CharCivAbility = Abi;
    }

    public void SafeSheet()
    {
        // außerdem fehlt hier noch eine Fehleranalyse
        StartCoroutine(SafeCharactersheet());
    }


    public IEnumerator SafeCharactersheet()
    {
        //sendet die Daten des Bogens an die Datenbank
        //Noch wurden diese nicht ausgewertet, sondern nur all Namen gespeichert um diese dann auch wieder im Bogen anzuzeigen
        //Im Bogen werden diese Namen dann ausgewertet
        WWWForm form = new WWWForm();
        //Person____________________________________
        form.AddField("userid", UserID);
        form.AddField("charciv", CharCiv.text + " " + CharCivAbility);
        form.AddField("charname", CharName.text);
        form.AddField("charweight", CharWeight.text);
        form.AddField("charheight", CharHeight.text);
        form.AddField("charage", CharAge.text);
        form.AddField("charcolor", CharColor.text);
        form.AddField("charlanguage", CharLanguage.text);
        form.AddField("charreligion", CharReligion.text);
        //Past____________________________________
      // form.AddField("charstudy", CharAge.text);
      // form.AddField("char", CharColor.text);
      // form.AddField("charlanguage", CharLanguage.text);
      // form.AddField("charreligion", CharReligion.text);
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

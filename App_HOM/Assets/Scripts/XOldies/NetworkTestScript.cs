using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkTestScript : MonoBehaviour
{

    //hier wurde nur getestet, deswegen ist es im oldie Ordner
    public PlayerData Data;
    void Start()
    {
        Data.SaveDataString("CharRace", "Human");
        Data.SaveDataString("CharRaceAbility", "Dumb");
        StartCoroutine(TestNetwork());
    }

    IEnumerator TestNetwork()
    {
        Debug.Log("Connecting");
        WWWForm form = new WWWForm();
        form.AddField("CharRace", Data.data["CharRace"]);
        form.AddField("CharRaceAbility", Data.data["CharRaceAbility"]);
        UnityWebRequest request = UnityWebRequest.Post("188.34.197.30/CreateSheet.php", form);
        yield return request.Send();
    }
}

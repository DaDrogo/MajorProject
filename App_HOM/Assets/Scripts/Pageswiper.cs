using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pageswiper : MonoBehaviour, IDragHandler, IEndDragHandler
{

    //Locations benötigt für consistincy
    Vector3 StartLocation;
    Vector3 EndLocation;
    Vector3 MomentaryLocation;

    //Anzahl der Seiten +1
    public int pages;
    //desto höher die Zahl umso langsamer wird geswiped
    public float sleep =1;
    //wohin sich der Cursor vom ausgangsort bewgt hat
    float difference;
    //auf welche Seite sich der Cursor bewegt hat
    float side;

    //feste Locations werden festgelegt
    void Start()
    {
        StartLocation = transform.position;
        EndLocation = new Vector3(-Screen.width*pages,transform.position.y,0);
        SetLocation(StartLocation);
    }

    // hier wird die xAchse des Panels bewegt

    public void OnDrag(PointerEventData data)
    {
        difference = data.pressPosition.x - data.position.x;
        transform.position = MomentaryLocation - new Vector3(difference, 0, 0);
    }

    // nach dem Loslassen soll ermittelt werden auf welche Seite gesprungen wird

    public void OnEndDrag(PointerEventData data)
    {
        side = (data.pressPosition.x - data.position.x)/Screen.width;
        //zurückspringen auf die erste seite
        if(transform.position.x >= 0)
        {
            SetLocation(StartLocation);
        }
        //letzte Seite
        else if (transform.position.x <= -Screen.width * pages)
        {
            SetLocation(EndLocation);
        }
        else
        {
            //nach rechts
            if (side > 0)
            {
                SetLocation(MomentaryLocation += new Vector3(-Screen.width, 0, 0));
            }
            // nach links
            else if (side < 0)
            {
                SetLocation(MomentaryLocation += new Vector3(Screen.width, 0, 0));
            }
        }
    }
    //hier wird die neue Location fürs Transform festgelegt
    void SetLocation(Vector3 Location)
    {
        StartCoroutine(Move(transform.position,Location));
        MomentaryLocation = Location;
    }

    //für einen Smoothen Übergang zwischen den Seiten
    IEnumerator Move(Vector3 starting, Vector3 ending)
    {
        float t = 0;
        while (t <= 1.0){
            t += Time.deltaTime / sleep;
            transform.position = Vector3.Lerp(starting, ending, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }

}
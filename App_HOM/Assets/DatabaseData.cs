using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseData : MonoBehaviour
{
    public enum DataId
    {
        UserID, CharCiv, CharName, CharWeight, CharHeight, CharAge, CharColor, CharLanguage, CharReligion, CharTraining, CharFeature, CharEducation, CharEnvironment
    }

    public DataId id;
}


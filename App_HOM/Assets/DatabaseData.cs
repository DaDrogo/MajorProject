using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseData : MonoBehaviour
{
    public enum DataId
    {
        UserName, UserPassport, UserID, UserCharSheets,
        CharRace, CharRaceAbility, CharName, CharWeight, CharHeight, CharAge, CharHairColor,CharSkinColor, CharGender, CharLanguage, CharReligion, CharFeature, CharEducation, CharEnvironment, CharTraining, CharDestiny, CharAmbition,

    }

    public DataId id;
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseData : MonoBehaviour
{
    public enum DataId
    {
        //NutzerDaten
        UserName, UserPassport, UserID,

        //Anzahl der Bögen
        UserCharSheets, SheetNr,

        //Speicherung der festen String Werte eines Charakters
        CharRace, CharRaceAbility, CharName, CharWeight, CharHeight, CharAge, CharHairColor,CharSkinColor, CharGender,
        CharLanguage, CharReligion, CharDestiny, CharDestinyLevel, CharAmbition, ModiAmount, AbilityAmount, ItemAmount,
        
        //wird für die GW AUswertung benötigt
        CharFeature, CharEducation, CharEnvironment, CharTraining,

        //Daten eine Modifikation
        ModiNr, ModiName, ModiPotenz, ModiLvl,

        //Daten eines Items
        ItemName, ItemType, ItemWeight, ItemDescription,

        //Daten einer Fertigkeit
        AbiName, AbiType, AbiSchool, AbiRange, AbiCost, AbiLength, AbiEffect,

        //Grundwert Daten
        AG, AGplus, AGminus, KR, KRplus, KRminus, AU, AUplus, AUminus, RE, REplus, REminus, GE, GEplus, GEminus, VE, VEplus, VEminus


    }

    public DataId id;
}


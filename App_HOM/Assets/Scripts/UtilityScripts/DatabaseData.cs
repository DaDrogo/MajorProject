using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseData : MonoBehaviour
{
    public enum DataId
    {
        UserName, UserPassport, UserID,
        UserCharSheets, SheetNr, 
        CharRace, CharRaceAbility, CharName, CharWeight, CharHeight, CharAge, CharHairColor,CharSkinColor, CharGender, CharLanguage, CharReligion, CharDestiny, CharDestinyLevel, CharAmbition, ModiAmount, AbilityAmount, ItemAmount,
        CharFeature, CharEducation, CharEnvironment, CharTraining,    
        ModiNr, ModiName, ModiPotenz, ModiLvl,
        ItemName, ItemType, ItemWeight, ItemDescription,
        AbiName, AbiType, AbiExhaust, AbiEffect,
        AG, AGplus, AGminus, KR, KRplus, KRminus, AU, AUplus, AUminus, RE, REplus, REminus, GE, GEplus, GEminus, VE, VEplus, VEminus,
        ProfDeath, ProfDeathII, ProfLife, ProfLifeII, ProfFriend, ProfFriendII, ProfLonely, ProfLonelyII, ProfMind, ProfMindII, ProdDestiny, ProfDestinyII, ProfGreed, ProfGreedII, ProfZero, ProfZeroII

    }

    public DataId id;
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Datas : IComparable<Datas>
{
    public string Key;
    public string Name;
    public int ID;

    public Datas(string newKey, string newName)
    {
        Key = newKey;
        Name = newName;
    }

    public int CompareTo(Datas other)
    {
        if (other == null)
        {
            return 1;
        }

        //Return the difference in power.
        return ID - other.ID;
    }
}

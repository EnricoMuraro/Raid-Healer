using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StringSelection : PropertyAttribute
{
    public string stringsList;

    public StringSelection(string list)
    {
        stringsList = list;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Modifier
{
    public Type type;
    public Source source;
    public float value;


    public enum Type
    {
        Percentage,
        Flat,
    }

    public enum Source
    {
        Talent,
        Aura,
    }

    public override bool Equals(object obj)
    {
        Modifier modObj = obj as Modifier;
        if (modObj == null)
            return false;
        else
            return (modObj.type == type && modObj.value == value && modObj.source == source);
    }
    public override int GetHashCode()
    {
        return type.GetHashCode() ^ source.GetHashCode() ^ value.GetHashCode();
    }
}


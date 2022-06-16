using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat 
{
    [SerializeField]
    private float baseValue;
    [SerializeField]
    private List<Modifier> modifiers = new ();
    private bool changed = true;
    private float modifiedValue;
    
    public Stat(Stat stat)
    {
        baseValue = stat.baseValue;
        modifiers = new List<Modifier>(stat.modifiers);
        changed = true;
        modifiedValue = stat.modifiedValue;
    }

    public float Value 
    { 
        get
        {
            //if (changed)
            modifiedValue = CalculateModifiedValue();
            
            return modifiedValue;
        }
    }

    public float BaseValue { get => baseValue; set { baseValue = value; changed = true; } }

    public float CalculateModifiedValue()
    {
        float initialValue = BaseValue;
        float flatValuesSum = 0;
        float percentaceValuesSum = 1;

        foreach (var modifier in modifiers)
            switch (modifier.type)
            {
                case Modifier.Type.Flat:
                    flatValuesSum += modifier.value; break;
                case Modifier.Type.Percentage:
                    percentaceValuesSum *= 1 + (modifier.value / 100); break;
            }

        initialValue += flatValuesSum;
        initialValue *= percentaceValuesSum;
        return initialValue;
    }

    public void AddModifier(Modifier mod)
    {
        changed = true;
        modifiers.Add(mod);
    }

    public void RemoveModifier(Modifier mod)
    {
        changed = true;
        modifiers.Remove(mod);
    }

    public void RemoveModifiersFromSource(Modifier.Source source)
    {
        changed = true;
        modifiers.RemoveAll(mod => mod.source == source);
    }

}

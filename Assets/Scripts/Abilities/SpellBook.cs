using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpellBook : ScriptableObject
{
    public Ability[] AllAbilities;
    public Ability[] SelectedAbilities;

    public Ability GetAbilityByID(int ID)
    {
        foreach (Ability a in AllAbilities)
            if (a.ID == ID)
                return a;

        return null;
    }

    public void SetSelectedAbilities(int[] selectedAbilitiesIDs)
    {
        SelectedAbilities = new Ability[selectedAbilitiesIDs.Length];
        for (int i = 0; i < selectedAbilitiesIDs.Length; i++)
            SelectedAbilities[i] = GetAbilityByID(selectedAbilitiesIDs[i]);
    }

}

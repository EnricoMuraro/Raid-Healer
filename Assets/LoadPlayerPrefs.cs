using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerPrefs : MonoBehaviour
{
    public TalentTree talentTree;
    public SpellBook spellBook;

    private void Awake()
    {
        talentTree.SetActiveTalents(Persistance.LoadTalents().IDs);
        spellBook.SetSelectedAbilities(Persistance.LoadSelectedAbilities().IDs);

    }

    private void OnEnable()
    {
        //Load active ability talents into the spellbook
        List<Ability> talentAbilities = new();
        foreach (var talent in talentTree.GetActiveAbilityTalents())
            talentAbilities.Add(talent.ability);
        spellBook.TalentAbilities = talentAbilities;

        //Remove any selected ability that is no longer in the spellbook 
        for(int i = 0; i < spellBook.SelectedAbilities.Length; i++)
            if (!spellBook.AllAbilities.Contains(spellBook.SelectedAbilities[i]))
                spellBook.SelectedAbilities[i] = null;

    }

    private void OnDisable()
    {
        talentTree.DeactivatePassiveTalents();
    }
}

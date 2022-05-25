using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerPrefs : MonoBehaviour
{
    public TalentTree talentTree;
    public SpellBook spellBook;
    public BossFightProgress bossFightProgress;

    private void Awake()
    {
        talentTree.SetActiveTalents(Persistance.LoadTalents());
        spellBook.SetSelectedAbilities(Persistance.LoadSelectedAbilities());

    }

    private void OnEnable()
    {
        //Load active ability talents into the spellbook
        List<Ability> talentAbilities = new();
        foreach (var talent in talentTree.GetActiveAbilityTalents())
            talentAbilities.Add(talent.ability);
        spellBook.TalentAbilities = talentAbilities;

        //Reset modifiers
        talentTree.DeactivateAllPassiveTalents();

        //Activate passive talents
        talentTree.ActivatePassiveTalents();

        //Remove any selected ability that is no longer in the spellbook 
        for (int i = 0; i < spellBook.SelectedAbilities.Length; i++)
            if (!spellBook.AllAbilities.Contains(spellBook.SelectedAbilities[i]))
                spellBook.SelectedAbilities[i] = null;

        //Load boss fights progress
        bossFightProgress.SetProgress(Persistance.LoadBossProgress());
    }
}

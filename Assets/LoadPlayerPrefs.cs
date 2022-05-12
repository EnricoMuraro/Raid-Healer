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

}

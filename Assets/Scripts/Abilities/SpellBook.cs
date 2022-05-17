using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class SpellBook : ScriptableObject
{
    [SerializeField]
    private List<Ability> defaultAbilities;
    private List<Ability> talentAbilities;
    [SerializeField]
    private Ability[] selectedAbilities;

    public UnityEvent onSelectedChange = new();

    public Ability[] SelectedAbilities 
    { 
        get => selectedAbilities;
        set
        {
            selectedAbilities = value;
            onSelectedChange.Invoke();
        }
    }

    public List<Ability> TalentAbilities { get => talentAbilities; set => talentAbilities = value; }

    public List<Ability> AllAbilities 
    {
        get
        {
            List<Ability> allAbilities = new ();
            allAbilities.AddRange(defaultAbilities);
            allAbilities.AddRange(talentAbilities);
            return allAbilities;
        }
    }

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


    public int[] GetSelectedAbilitiesIDs()
    {
        int[] abilitiesIDs = new int[SelectedAbilities.Length];
        for (int i = 0; i < SelectedAbilities.Length; i++)
            if (SelectedAbilities[i] != null)
                abilitiesIDs[i] = SelectedAbilities[i].ID;
        return abilitiesIDs;
    }


}

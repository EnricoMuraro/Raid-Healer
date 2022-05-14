using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AbilitySelection : MonoBehaviour
{
    public Transform Content;
    public Transform ActionBar;
    public Sprite DefaultActionBarIcon;

    public SpellBook spellBook;

    
    private AbilityView AbilityViewPrefab;
    private Ability[] SelectedAbilities;
    private int SelectedAbilitySlot = 0;

    private void Awake()
    {
    }

    private void Start()
    {
        AbilityViewPrefab = Resources.Load<AbilityView>("AbilityView");

        foreach (Ability ability in spellBook.AllAbilities)
        {
            AbilityView abilityView = Instantiate(AbilityViewPrefab, Content);
            abilityView.ShowAbility(ability);
            abilityView.GetComponent<Button>().onClick.AddListener(() => SetAbilitySlot(ability));
        }
    }

    private void OnEnable()
    {
        LoadSelection();
    }

    private void LoadSelection()
    {
        SelectedAbilities = spellBook.SelectedAbilities;
        if(SelectedAbilities.Length < 5)
        {
            Ability[] tmp = new Ability[5];
            for(int i = 0; i < SelectedAbilities.Length; i++)
            {
                tmp[i] = SelectedAbilities[i];
            }
            SelectedAbilities = tmp;
        }    
    }

    private void OnDisable()
    {
        SaveSelection();
    }

    private void SaveSelection()
    {
        spellBook.SelectedAbilities = SelectedAbilities;
        Persistance.SaveSelectedAbilities(new IDStorage(spellBook.GetSelectedAbilitiesIDs()));
    }

    private void SetAbilitySlot(Ability ability)
    {
        // remove the ability if it is duplicated in another part of the array
        for (int i = 0; i < SelectedAbilities.Length; i++)
            if (SelectedAbilities[i] != null && SelectedAbilities[i].ID == ability.ID)
                SelectedAbilities[i] = null;

        SelectedAbilities[SelectedAbilitySlot] = ability;
        spellBook.SelectedAbilities = SelectedAbilities;
    }    

    public void SetSelectedAbilitySlot(int n)
    {
        SelectedAbilitySlot = n;
    }

}

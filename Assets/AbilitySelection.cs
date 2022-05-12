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
    [SerializeField]
    private Image[] SelectedAbilitiesIcons;
    private int SelectedAbilitySlot = 0;

    private void Awake()
    {
        SelectedAbilitiesIcons = ActionBar.GetComponentsInChildren<Image>();
    }

    private void Start()
    {
        AbilityViewPrefab = Resources.Load<AbilityView>("AbilityView");
        SelectedAbilities = new Ability[5];

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
        Debug.Log("Load");
        SelectedAbilities = spellBook.SelectedAbilities;
        DisplaySelectedAbilities();
    }

    private void OnDisable()
    {
        SaveSelection();
    }

    private void SaveSelection()
    {
        int[] abilitiesIDs = new int[5];
        for (int i = 0; i < abilitiesIDs.Length; i++)
            if (SelectedAbilities[i] != null)
                abilitiesIDs[i] = SelectedAbilities[i].ID;

        spellBook.SetSelectedAbilities(abilitiesIDs);
        Persistance.SaveSelectedAbilities(new IDStorage(abilitiesIDs));
    }

    private void SetAbilitySlot(Ability ability)
    {
        for (int i = 0; i < SelectedAbilities.Length; i++)
            if (SelectedAbilities[i] != null && SelectedAbilities[i].ID == ability.ID)
                SelectedAbilities[i] = null;

        SelectedAbilities[SelectedAbilitySlot] = ability;
        DisplaySelectedAbilities();
    }    

    public void SetSelectedAbilitySlot(int n)
    {
        SelectedAbilitySlot = n;
    }

    public void DisplaySelectedAbilities()
    {
        for(int i = 0; i<SelectedAbilities.Length; i++)
        {
            if (SelectedAbilities[i] != null)
                SelectedAbilitiesIcons[i].sprite = SelectedAbilities[i].icon;
            else
                SelectedAbilitiesIcons[i].sprite = DefaultActionBarIcon;
        }
    }
}

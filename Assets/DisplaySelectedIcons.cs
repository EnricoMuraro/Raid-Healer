using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySelectedIcons : MonoBehaviour
{
    public Sprite DefaultActionBarIcon;
    public SpellBook spellBook;

    [SerializeField]
    private Image[] SelectedAbilitiesIcons;

    // Start is called before the first frame update
    void Start()
    {

        SelectedAbilitiesIcons = GetComponentsInChildren<Image>();
        spellBook.onSelectedChange.AddListener(DisplaySelectedAbilities);
        DisplaySelectedAbilities();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplaySelectedAbilities()
    {
        for (int i = 0; i < spellBook.SelectedAbilities.Length; i++)
        {
            if (spellBook.SelectedAbilities[i] != null)
                SelectedAbilitiesIcons[i].sprite = spellBook.SelectedAbilities[i].icon;
            else
                SelectedAbilitiesIcons[i].sprite = DefaultActionBarIcon;
        }
    }
}

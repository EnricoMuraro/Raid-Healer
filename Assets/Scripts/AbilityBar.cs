using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBar : MonoBehaviour
{
    public SpellBook spellBook;
    private AbilitySlot[] abilitySlots;

    private void Awake()
    {
        //TODO SEEK GOD
        abilitySlots = GetComponentsInChildren<AbilitySlot>();
        if (spellBook != null)
            for (int i = 0; i < abilitySlots.Length && i < spellBook.SelectedAbilities.Length; i++)
            {
                abilitySlots[i].ability = spellBook.SelectedAbilities[i];
            }
    }

    private void Start()
    {

    }

    public string Activate(int slotIndex, GameUnit caster, int targetIndex, Raid raid)
    {
        if (slotIndex < abilitySlots.Length)
        {
            foreach (AbilitySlot slot in abilitySlots)
            {
                if (slot.IsCasting())
                    return "";
            }

            return abilitySlots[slotIndex].Activate(caster, targetIndex, raid);
        }
        return "";
    }

    public int AbilitySlotsLength()
    {
        return abilitySlots.Length;
    }

    //public AbilitySlot[] GetAbilitySlots()
    //{
    //    return abilitySlots;
    //}
}

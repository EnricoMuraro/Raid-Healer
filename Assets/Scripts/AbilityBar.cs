using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBar : MonoBehaviour
{
    public SpellBook spellBook;
    private AbilitySlot[] abilitySlots;
    private GameUnit caster;
    private Raid raid;
    private void Awake()
    {

        caster = GetComponentInParent<GameUnit>();
        raid = FindObjectOfType<Raid>();
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

    private void Update()
    {
        foreach (AbilitySlot abilitySlot in abilitySlots)
            if (abilitySlot.ability is PassiveAbility passiveAbility)
                passiveAbility.Activate(caster, 0, raid);
    }

    public string Activate(int slotIndex, GameUnit caster, int targetIndex, Raid raid)
    {
        if (slotIndex < abilitySlots.Length)
        {
            foreach (AbilitySlot slot in abilitySlots)
            {
                if (slot.IsCastingOrChanneling())
                    return "Already casting or channeling";
            }

            return abilitySlots[slotIndex].Activate(caster, targetIndex, raid);
        }
        return "Ability slot index " + slotIndex + " is out of range";
    }

    public void InterruptCast()
    {
        foreach(AbilitySlot abilitySlot in abilitySlots)
            abilitySlot.InterruptCast();
    }

    public int AbilitySlotsLength()
    {
        return abilitySlots.Length;
    }

    public bool isActiveAbility(int slotIndex)
    {
        return abilitySlots[slotIndex].ability is ActiveAbility;
    }

    public bool isOnCooldown(int slotIndex)
    {
        return abilitySlots[slotIndex].CurrentCooldown > 0;
    }

    //public AbilitySlot[] GetAbilitySlots()
    //{
    //    return abilitySlots;
    //}
}

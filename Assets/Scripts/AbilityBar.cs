using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBar : MonoBehaviour
{

    private AbilitySlot[] abilitySlots;

    private void Awake()
    {
        abilitySlots = GetComponentsInChildren<AbilitySlot>();
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

    public AbilitySlot[] GetAbilitySlots()
    {
        return abilitySlots;
    }
}

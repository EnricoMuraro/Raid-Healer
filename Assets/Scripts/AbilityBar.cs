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

    public void Activate(int slotIndex, GameUnit caster, int targetIndex, Raid raid)
    {
        foreach(AbilitySlot slot in abilitySlots)
        {
            if (slot.IsCasting())
                return;
        }

        abilitySlots[slotIndex].Activate(caster, targetIndex, raid);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
